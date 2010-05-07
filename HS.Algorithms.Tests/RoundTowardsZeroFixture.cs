using NUnit.Framework;

namespace HS.Algorithms.Tests
{
    [TestFixture]
    public class RoundTowardsZeroFixture
    {
        [Test]
        public void Rounding1_124ToTwoPlacesGives1_12()
        {
            Assert.AreEqual(1.12m, 1.124m.RoundTowardsZero(2));
        }

        [Test]
        public void Rounding1_1251ToTwoPlacesGives1_13()
        {
            Assert.AreEqual(1.13m, 1.1251m.RoundTowardsZero(2));
        }

        [Test]
        public void Rounding1_125ToTwoPlacesGives1_12()
        {
            Assert.AreEqual(1.12m, 1.125m.RoundTowardsZero(2));
        }

        [Test]
        public void RoundingMinus1_124ToTwoPlacesGivesMinus1_12()
        {
            Assert.AreEqual(-1.12m, -1.124m.RoundTowardsZero(2));
        }

        [Test]
        public void RoundingMinus1_1251ToTwoPlacesGivesMinus1_13()
        {
            Assert.AreEqual(-1.13m, -1.1251m.RoundTowardsZero(2));
        }

        [Test]
        public void RoundingMinus1_125ToTwoPlacesGivesMinus1_12()
        {
            Assert.AreEqual(-1.12m, -1.125m.RoundTowardsZero(2));
        }

        [Test]
        public void RoundingMinusOneToZeroPlacesGivesMinusOne()
        {
            Assert.AreEqual(-1m, -1m.RoundTowardsZero(2));
        }

        [Test]
        public void RoundingMinusPointFiveOneToOnePlaceGivesMinuPointFive()
        {
            Assert.AreEqual(-0.5m, -0.51m.RoundTowardsZero(1));
        }

        [Test]
        public void RoundingMinusPointFiveOneToZeroPlacesGivesMinusOne()
        {
            Assert.AreEqual(-1m, -0.51m.RoundTowardsZero(0));
        }

        [Test]
        public void RoundingMinusPointFiveToOnePlaceGivesMinusPointFive()
        {
            Assert.AreEqual(-0.5m, -0.5m.RoundTowardsZero(1));
        }

        [Test]
        public void RoundingMinusPointFiveToZeroPlacesGivesZero()
        {
            Assert.AreEqual(0m, -0.5m.RoundTowardsZero(0));
        }

        [Test]
        public void RoundingMinusPointFourToOnePlaceGivesMinusPointFour()
        {
            Assert.AreEqual(-0.4m, -0.4m.RoundTowardsZero(1));
        }

        [Test]
        public void RoundingMinusPointFourToZeroPlacesGivesZero()
        {
            Assert.AreEqual(0m, -0.4m.RoundTowardsZero(0));
        }

        [Test]
        public void RoundingOneToZeroPlacesGivesOne()
        {
            Assert.AreEqual(1m, 1m.RoundTowardsZero(2));
        }

        [Test]
        public void RoundingPointFiveOneToOnePlaceGivesPointFive()
        {
            Assert.AreEqual(0.5m, 0.51m.RoundTowardsZero(1));
        }

        [Test]
        public void RoundingPointFiveOneToZeroPlacesGivesOne()
        {
            Assert.AreEqual(1m, 0.51m.RoundTowardsZero(0));
        }

        [Test]
        public void RoundingPointFiveToOnePlaceGivesPointFive()
        {
            Assert.AreEqual(0.5m, 0.5m.RoundTowardsZero(1));
        }

        [Test]
        public void RoundingPointFiveToZeroPlacesGivesZero()
        {
            Assert.AreEqual(0m, 0.5m.RoundTowardsZero(0));
        }

        [Test]
        public void RoundingPointFourToOnePlaceGivesPointFour()
        {
            Assert.AreEqual(0.4m, 0.4m.RoundTowardsZero(1));
        }

        [Test]
        public void RoundingPointFourToZeroPlacesGivesZero()
        {
            Assert.AreEqual(0m, 0.4m.RoundTowardsZero(0));
        }

        [Test]
        public void RoundingZeroToManyPlacesGivesZero()
        {
            Assert.AreEqual(0m, 0m.RoundTowardsZero(2));
        }

        [Test]
        public void RoundingZeroToOnePlaceGivesZero()
        {
            Assert.AreEqual(0m, 0m.RoundTowardsZero(1));
        }

        [Test]
        public void RoundingZeroToZeroPlacesGivesZero()
        {
            Assert.AreEqual(0m, 0m.RoundTowardsZero(0));
        }
    }
}