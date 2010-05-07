using System.Linq;
using HS.Algorithms.EnumerableExtensions;
using NUnit.Framework;

namespace HS.Algorithms.Tests.EnumerableExtensions
{
    [TestFixture]
    class UnixStyleUniqFixture
    {
        [Test]
        public void UniqEmptyEnumerableIsEmpty()
        {
            Assert.IsFalse(new int[] {}.Uniq(x => x).Any());
        }

        [Test]
        public void UniqSingleItemEnumerableOnPropertyIsThatItem()
        {
            Assert.AreEqual(new {X = 42}, new[] {new {X = 42}}.Uniq(x => x.X).Single());
        }

        [Test]
        public void UniqDoubleItemEnumerableWithMatchReturnsFirstItem()
        {
            Assert.AreEqual
                (
                new {X = 42, Y = 0},
                new[] {new {X = 42, Y = 0}, new {X = 42, Y = 1}}.Uniq(x => x.X).Single()
                );
        }

        [Test]
        public void UniqDoubleItemEnumerableWithNoMatchReturnsBothItems()
        {
            Assert.AreEqual
                (
                new[] {new {X = 42, Y = 0}, new {X = 43, Y = 0}},
                new[] {new {X = 42, Y = 0}, new {X = 43, Y = 0}}.Uniq(x => x.X).ToArray()
                );
        }

        [Test]
        public void UniqTripleItemEnumerableWithSeparatedDuplicateReturnsAllItems()
        {
            Assert.AreEqual
                (
                new[] {new {X = 42, Y = 0}, new {X = 43, Y = 0}, new {X = 42, Y = 0}},
                new[] {new {X = 42, Y = 0}, new {X = 43, Y = 0}, new {X = 42, Y = 0}}.Uniq(x => x.X).ToArray()
                );
        }
    }
}
