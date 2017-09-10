namespace ReplaceMethod
{
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            MethodHelper.Replace<string>((a)=> OriginalInstanceMethod(a), (a)=> NewInstanceMethod(a));
            MethodHelper.Replace<int>((a) => OriginalStaticMethod(a), (a) => NewStaticMethod(a));

            OriginalStaticMethod(777);
            OriginalInstanceMethod("");

            ReadKey();
        }

        private static void OriginalStaticMethod(int someInt) =>
            WriteLine("if you see this line then replacer does NOT WORK for static methods");

        private static void NewStaticMethod(int someInt) =>
            WriteLine("If you see this line then replacer WORK for static methods");

        private static void OriginalInstanceMethod(string someArg) =>
            WriteLine("If you see this line then replacer does NOT WORK for instance methods");

        private static void NewInstanceMethod(string someArg) =>
            WriteLine("If you see this line then replacer WORK for instance methods");
    }
}
