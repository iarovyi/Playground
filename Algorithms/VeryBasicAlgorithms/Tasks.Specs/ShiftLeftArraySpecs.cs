using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tasks.Specs
{
    using FluentAssertions;

    [TestClass]
    public class ShiftLeftArraySpecs
    {
        [TestMethod]
        public void Can_rotate()
        {
            int d = 4;
            var input = new[] {1, 2, 3, 4, 5};
            var expected = new[] {5, 1, 2, 3, 4};
            var result = ShiftLeftArray.RotateLeft(input, d);

            result.Should().BeEquivalentTo(expected, x => x.WithStrictOrdering());
        }
    }
}
