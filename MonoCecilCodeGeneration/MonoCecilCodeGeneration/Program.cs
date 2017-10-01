namespace MonoCecilCodeGeneration
{
    using System;
    using System.IO;
    using Mono.Cecil;
    using Mono.Cecil.Cil;
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            GenerateExecutable();

            WriteLine($"{Path.Combine(Directory.GetCurrentDirectory(), "HelloWorld.exe")} was generated using Mono.Cecil");
            ReadKey();
        }

        private static void GenerateExecutable()
        {
            var myHelloWorldApp = AssemblyDefinition.CreateAssembly(
                new AssemblyNameDefinition("HelloWorld", new Version(1, 0, 0, 0)), "HelloWorld", ModuleKind.Console);

            var module = myHelloWorldApp.MainModule;

            // create the program type and add it to the module
            var programType = new TypeDefinition("HelloWorld", "Program",
                TypeAttributes.Class | TypeAttributes.Public, module.TypeSystem.Object);

            module.Types.Add(programType);

            // add an empty constructor
            var ctor = new MethodDefinition(".ctor", MethodAttributes.Public | MethodAttributes.HideBySig
                                                     | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName, module.TypeSystem.Void);

            // create the constructor's method body
            var il = ctor.Body.GetILProcessor();

            il.Append(il.Create(OpCodes.Ldarg_0));

            // call the base constructor
            il.Append(il.Create(OpCodes.Call, module.Import(typeof(object).GetConstructor(Type.EmptyTypes))));

            il.Append(il.Create(OpCodes.Nop));
            il.Append(il.Create(OpCodes.Ret));

            programType.Methods.Add(ctor);

            // define the 'Main' method and add it to 'Program'
            var mainMethod = new MethodDefinition("Main",
                MethodAttributes.Public | MethodAttributes.Static, module.TypeSystem.Void);

            programType.Methods.Add(mainMethod);

            // add the 'args' parameter
            var argsParameter = new ParameterDefinition("args",
                ParameterAttributes.None, module.Import(typeof(string[])));

            mainMethod.Parameters.Add(argsParameter);

            // create the method body
            il = mainMethod.Body.GetILProcessor();

            il.Append(il.Create(OpCodes.Nop));
            il.Append(il.Create(OpCodes.Ldstr, "Hello World"));

            var writeLineMethod = il.Create(OpCodes.Call,
                module.Import(typeof(Console).GetMethod("WriteLine", new[] { typeof(string) })));

            // call the method
            il.Append(writeLineMethod);

            il.Append(il.Create(OpCodes.Nop));
            il.Append(il.Create(OpCodes.Ret));

            // set the entry point and save the module
            myHelloWorldApp.EntryPoint = mainMethod;
            myHelloWorldApp.Write("HelloWorld.exe");
        }
    }
}
