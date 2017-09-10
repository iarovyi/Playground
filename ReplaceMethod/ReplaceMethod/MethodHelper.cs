namespace ReplaceMethod
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Based on:
    /// https://www.codeproject.com/Articles/37549/CLR-Injection-Runtime-Method-Replacer
    /// https://stackoverflow.com/questions/7299097/dynamically-replace-the-contents-of-a-c-sharp-method
    /// </summary>
    public static class MethodHelper
    {
        public static void Replace<T, TResult>(Expression<Func<T, TResult>> methodToReplace, Expression<Func<T, TResult>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T1, T2, TResult>(Expression<Func<T1, T2, TResult>> methodToReplace, Expression<Func<T1, T2, TResult>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T1, T2, T3, TResult>(Expression<Func<T1, T2, T3, TResult>> methodToReplace, Expression<Func<T1, T2, T3, TResult>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T1, T2, T3, T4, TResult>(Expression<Func<T1, T2, T3, T4, TResult>> methodToReplace, Expression<Func<T1, T2, T3, T4, TResult>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T1, T2, T3, T4, T5, TResult>(Expression<Func<T1, T2, T3, T4, T5, TResult>> methodToReplace, Expression<Func<T1, T2, T3, T4, T5, TResult>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T1, T2, T3, T4, T5, T6, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> methodToReplace, Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T1, T2, T3, T4, T5, T6, T7, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> methodToReplace, Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> methodToReplace, Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace(Expression<Action> methodToReplace, Expression<Action> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T>(Expression<Action<T>> methodToReplace, Expression<Action<T>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T1, T2>(Expression<Action<T1, T2>> methodToReplace, Expression<Action<T1, T2>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T1, T2, T3>(Expression<Action<T1, T2, T3>> methodToReplace, Expression<Action<T1, T2>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T1, T2, T3, T4>(Expression<Action<T1, T2, T3, T4>> methodToReplace, Expression<Action<T1, T2>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T1, T2, T3, T4, T5>(Expression<Action<T1, T2, T3, T4, T5>> methodToReplace, Expression<Action<T1, T2>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T1, T2, T3, T4, T5, T6>(Expression<Action<T1, T2, T3, T4, T5, T6>> methodToReplace, Expression<Action<T1, T2>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T1, T2, T3, T4, T5, T6, T7>(Expression<Action<T1, T2, T3, T4, T5, T6, T7>> methodToReplace, Expression<Action<T1, T2>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);

        public static void Replace<T1, T2, T3, T4, T5, T6, T7, T8>(Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8>> methodToReplace, Expression<Action<T1, T2>> methodToInject) =>
            ReplaceImpl(methodToReplace, methodToInject);


        private static void ReplaceImpl(Expression methodToReplace, Expression methodToInject) =>
            Replace(methodToReplace.GetMethodExpression().Method, methodToInject.GetMethodExpression().Method);

        private static void Replace(MethodInfo methodToReplace, MethodInfo methodToInject)
        {
            RuntimeHelpers.PrepareMethod(methodToReplace.MethodHandle);
            RuntimeHelpers.PrepareMethod(methodToInject.MethodHandle);

            unsafe
            {
                bool isX86 = IntPtr.Size == 4;
                if (isX86)
                {
                    int* inj = (int*)methodToInject.MethodHandle.Value.ToPointer() + 2;
                    int* tar = (int*)methodToReplace.MethodHandle.Value.ToPointer() + 2;
#if DEBUG
                    byte* injInst = (byte*)*inj;
                    byte* tarInst = (byte*)*tar;

                    int* injSrc = (int*)(injInst + 1);
                    int* tarSrc = (int*)(tarInst + 1);

                    *tarSrc = (((int)injInst + 5) + *injSrc) - ((int)tarInst + 5);
#else
                    *tar = *inj;
#endif
                }
                else
                {

                    long* inj = (long*)methodToInject.MethodHandle.Value.ToPointer() + 1;
                    long* tar = (long*)methodToReplace.MethodHandle.Value.ToPointer() + 1;
#if DEBUG
                    byte* injInst = (byte*)*inj;
                    byte* tarInst = (byte*)*tar;


                    int* injSrc = (int*)(injInst + 1);
                    int* tarSrc = (int*)(tarInst + 1);

                    *tarSrc = (((int)injInst + 5) + *injSrc) - ((int)tarInst + 5);
#else
                    *tar = *inj;
#endif
                }
            }
        }
    }

    internal static class ExpressionExtensions
    {
        public static MethodCallExpression GetMethodExpression(this Expression memberSelector)
        {
            return GetMethod(memberSelector);
        }

        private static MethodCallExpression GetMethod(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Lambda:
                    return GetMethod(((LambdaExpression)expression).Body);
                case ExpressionType.Call:
                    return (MethodCallExpression)expression;
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    return GetMethod(((UnaryExpression)expression).Operand);
                case ExpressionType.Invoke:
                    return GetMethod(((InvocationExpression)expression).Expression);
                default:
                    throw new Exception("Not a proper method call expression");
            }
        }
    }
}
