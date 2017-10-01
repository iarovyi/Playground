namespace DissassembleMethod
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            Expression<Action> someMethod = () => Main(null);
            string ilCode = someMethod.ToIlCode();
            string currentMethodIlCode = MethodBase.GetCurrentMethod().ToIlCode();

            WriteLine(ilCode);
            WriteLine($"Decompiled Il code is {(ilCode == currentMethodIlCode ? "the same": "not the same")} as Il code of current method");
            ReadKey();
        }
    }
}
