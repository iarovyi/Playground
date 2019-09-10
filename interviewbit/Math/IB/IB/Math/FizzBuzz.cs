namespace IB.Math
{
    using System.Collections.Generic;
    using FluentAssertions;

    internal static class FizzBuzz
    {
        public static void Test()
        {
            var buzzOf5 = GetList(5);
            buzzOf5.Should().BeEquivalentTo(new[] {"1", "2", "Fizz", "4", "Buzz"});
        }

        public static List<string> GetList(int number)
        {
            var list = new List<string>();

            for (int i = 1; i <= number; i++)
            {
                bool divisibleBy3 = i % 3 == 0;
                bool divisibleBy5 = i % 5 == 0;

                list.Add(divisibleBy3 && divisibleBy5 ? "FizzBuzz" :
                         divisibleBy3 ? "Fizz" :
                         divisibleBy5 ? "Buzz" :
                             i.ToString());
            }

            return list;
        }
    }
}
