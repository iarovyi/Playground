namespace IB.Tasks
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;
    using Xunit.Abstractions;

    public class HanoiTower
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public HanoiTower(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test()
        {
            var fromCord = new Stack<int>();
            var auxCord = new Stack<int>();
            var toCord = new Stack<int>();
            fromCord.Push(3);
            fromCord.Push(2);
            fromCord.Push(1);
            MoveDisks(3, fromCord, auxCord, toCord);

            fromCord.Should().BeEmpty();
            auxCord.Should().BeEmpty();
            toCord.Should().BeEquivalentTo(new Stack(new List<int>(){ 3, 2, 1 }));
        }

        /*
         *  A -> C
            A -> B
            C -> B

            A -> C
            B -> A
            B -> C
         */
        public void MoveDisks(int disks, Stack<int> fromCord, Stack<int> auxCord, Stack<int> toCord)
        {
            if (/*fromCord.Count == 1*/disks == 1)
            {
                Move(fromCord, toCord);
                return;
            }

            MoveDisks(disks - 1, fromCord, toCord, auxCord);

            Move(fromCord, toCord);

            MoveDisks(disks - 1, auxCord, fromCord, toCord);


            //Move(fromCord, toCord);
            //Move(fromCord, auxCord);
            //Move(toCord, auxCord);

            //Move(fromCord, toCord);
            //Move(auxCord, fromCord);
            //Move(auxCord, toCord);

            //Move(fromCord, toCord);
        }

        private void Move(Stack<int> form, Stack<int> to)
        {
            to.Push(form.Pop());
        }
    }
}
