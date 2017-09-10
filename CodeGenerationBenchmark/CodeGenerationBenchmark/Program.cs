namespace CodeGenerationBenchmark
{
    using System;
    using System.IO;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.CompilerServices;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Reports;
    using BenchmarkDotNet.Running;

    public sealed class Program
    {
        static void Main(string[] args)
        {
            Summary summary = BenchmarkRunner.Run<MyBenchmark>();
            Console.WriteLine(summary);
            Console.ReadKey();
        }

        internal sealed class MyBenchmark
        {
            private readonly Func<int, int, int> _methodBuildWithIlUsingDynamicMethod = BuildWithIlUsingDynamicMethod();
            private readonly Func<int, int, int> _methodBuildWithIlUsingDynamicAssembly = BuildWithIlUsingDynamicAssembly();
            private readonly Func<int, int, int> _methodBuildWithExpressions = BuildWithExpression();

            private static Func<int, int, int> BuildWithIlUsingDynamicMethod()
            {
                DynamicMethod method = new DynamicMethod("Sum", typeof(int), new[] { typeof(int), typeof(int) },
                    typeof(Program), true);
                ILGenerator ilGen = method.GetILGenerator();
                BuildMethodWithIl(ilGen);
                return (Func<int, int, int>)method.CreateDelegate(typeof(Func<int, int, int>));
            }

            private static Func<int, int, int> BuildWithIlUsingDynamicAssembly()
            {
                string methodName = "Sum";
                string directory = Directory.GetCurrentDirectory();
                AppDomain domain = AppDomain.CurrentDomain;
                AssemblyName aname = new AssemblyName(Guid.NewGuid().ToString());
                AssemblyBuilder assemBuilder = domain.DefineDynamicAssembly(aname, AssemblyBuilderAccess.RunAndSave, directory);
                string moduleFileName = $"{assemBuilder.GetName().Name}.mod";
                ModuleBuilder modBuilder = assemBuilder.DefineDynamicModule(assemBuilder.GetName().Name, moduleFileName);
                TypeBuilder tb = modBuilder.DefineType("Foo", TypeAttributes.Public | TypeAttributes.Class);

                MethodBuilder mb = tb.DefineMethod(methodName,
                    MethodAttributes.Static | MethodAttributes.Public,
                    CallingConventions.Standard,
                    typeof(int),
                    new[] { typeof(int), typeof(int) });

                ILGenerator ilGen = mb.GetILGenerator();
                BuildMethodWithIl(ilGen);

                Type realType = tb.CreateType();
                var meth = realType.GetMethod(methodName);

                return (Func<int, int, int>)Delegate.CreateDelegate(typeof(Func<int, int, int>), meth);
            }

            private static void BuildMethodWithIl(ILGenerator ilGen)
            {
                ilGen.Emit(OpCodes.Ldarg_0);
                ilGen.Emit(OpCodes.Ldarg_1);
                ilGen.Emit(OpCodes.Add);
                ilGen.Emit(OpCodes.Ret);
            }

            private static Func<int, int, int> BuildWithExpression()
            {
                var oneParam = Expression.Parameter(typeof(int), "one");
                var twoParam = Expression.Parameter(typeof(int), "two");

                return Expression
                    .Lambda<Func<int, int, int>>(Expression.Add(oneParam, twoParam), oneParam, twoParam)
                    .Compile();
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            private static int RealSum(int one, int two) => one + two;

            [Benchmark, MethodImpl(MethodImplOptions.NoInlining)]
            public int TestRealMethod() => RealSum(1, 2);
            [Benchmark, MethodImpl(MethodImplOptions.NoInlining)]
            public int TestMethodCreatedByExpressionTrees() => _methodBuildWithExpressions(1, 2);
            [Benchmark, MethodImpl(MethodImplOptions.NoInlining)]
            public int TestMethodCreatedByIlEmitUsingDynamicMethod() => _methodBuildWithIlUsingDynamicMethod(1, 2);
            [Benchmark, MethodImpl(MethodImplOptions.NoInlining)]
            public int TestMethodCreatedByIlEmitUsingDynamicAssembly() => _methodBuildWithIlUsingDynamicAssembly(1, 2);
        }
    }
}
