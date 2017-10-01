namespace DissassembleMethod
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using Mono.Reflection;

    public static class DissassemblingExtensions
    {
        public static string ToIlCode<TDelegate>(this Expression<TDelegate> @delegate)
        {
            var call = @delegate.Body as MethodCallExpression;
            if (call == null)
            {
                throw new ArgumentException($"{nameof(@delegate)} should be a method call");
            }

            return call.Method.ToIlCode();
        }

        public static string ToIlCode(this MethodBase method) =>
            string.Join(Environment.NewLine, method.GetInstructions());
    }
}
