using System.Linq;
using HS.Algorithms.EnumerableExtensions;
using NUnit.Framework;

namespace HS.Algorithms.Tests.EnumerableExtensions
{
    [TestFixture]
    public class FancyWhereFixture
    {
        [Test]
        public void WhereWithSurroundingYieldsNothingWithNoInput()
        {
            Assert.IsFalse(new int[] { }.Where(-1, (previous, current, next) => false).Any());
        }

        [Test]
        public void WhereWithSurroundingYieldsNothingWithAllNegativeSelectionAndOneItem()
        {
            Assert.IsFalse(new [] { 1 }.Where(-1, (previous, current, next) => false).Any());
        }

        [Test]
        public void WhereWithSurroundingYieldsNothingWithAllNegativeSelectionAndTwoItems()
        {
            Assert.IsFalse(new [] { 1, 2 }.Where(-1, (previous, current, next) => false).Any());
        }

        [Test]
        public void WhereWithSurroundingYieldsNothingWithAllNegativeSelectionAndThreeItems()
        {
            Assert.IsFalse(new [] { 1, 2, 3 }.Where(-1, (previous, current, next) => false).Any());
        }

        [Test]
        public void WhereWithSurroundingYieldsNothingWithAllNegativeSelectionAndFourItems()
        {
            Assert.IsFalse(new [] { 1, 2, 3, 4 }.Where(-1, (previous, current, next) => false).Any());
        }

        [Test]
        public void WhereWithSurroundingYieldsNothingWithAllPositiveSelectionAndOneItem()
        {
            Assert.IsFalse(new [] { 1 }.Where(-1, (previous, current, next) => false).Any());
        }

        [Test]
        public void WhereWithSurroundingYieldsNothingWithAllPositiveSelectionAndTwoItems()
        {
            Assert.IsFalse(new [] { 1, 2 }.Where(-1, (previous, current, next) => false).Any());
        }

        [Test]
        public void WhereWithSurroundingYieldsNothingWithAllPositiveSelectionAndThreeItems()
        {
            Assert.IsFalse(new [] { 1, 2, 3 }.Where(-1, (previous, current, next) => false).Any());
        }

        [Test]
        public void WhereWithSurroundingYieldsNothingWithAllPositiveSelectionAndFourItems()
        {
            Assert.IsFalse(new [] { 1, 2, 3, 4 }.Where(-1, (previous, current, next) => false).Any());
        }

        [Test]
        public void WhereWithSurroundingYieldsOnlySelectedWithOneItem()
        {
            Assert.AreEqual
                (
                new [] { 1 },
                new [] { 1 }.Where(-1, (previous, current, next) => (previous == -1 && next == -1) && current == 1).ToArray())
                ;
        }

        [Test]
        public void WhereWithSurroundingYieldsOnlySelectedWithTwoItems()
        {
            Assert.AreEqual
                (
                new [] { 1 },
                new [] { 1, 2 }.Where(-1, (previous, current, next) => next == current + 1).ToArray())
                ;
        }

        [Test]
        public void WhereWithSurroundingYieldsOnlySelectedWithThreeItems()
        {
            Assert.AreEqual
                (
                new [] { 1, 2 },
                new [] { 1, 2, 3 }.Where(-1, (previous, current, next) => next == current + 1).ToArray())
                ;
        }

        [Test]
        public void WhereWithSurroundingYieldsOnlySelectedWithFourItems()
        {
            Assert.AreEqual
                (
                new [] { 1, 3 },
                new [] { 1, 2, 3, 4 }.Where(-1, (previous, current, next) => (next % 2 == 0)).ToArray())
                ;
        }

        [Test]
        public void SelectAllItemsWorksWithLargeInput()
        {
            Assert.AreEqual
                (
                new [] { 1, 2, 3, 4, 5, 6, 7, 8 },
                new [] { 1, 2, 3, 4, 5, 6, 7, 8 }.Where(-1, (previous, current, next) => true).ToArray())
                ;
        }
    }
}