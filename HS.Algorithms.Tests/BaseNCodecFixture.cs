using System;
using System.Globalization;
using System.Numerics;
using NUnit.Framework;

namespace Safeware.Utils.Tests
{
    [TestFixture]
    public class BaseNCodecFifture
    {            
        [Test]
        public void RoundTrips()
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            foreach (var n in new[] { 0, 1, 2, 42, 1024, BigInteger.Parse("4125636888562548868221559797461449"), BigInteger.Parse("47023505233334520000") })
                Assert.AreEqual(n, BaseNCodec.Decode(BaseNCodec.Encode(n, alphabet), alphabet));
        }

        [Test]
        public void RoundTripsPleasantUri()
        {
            const string alphabet = "BCDGHJKLMPQRSTVWXYZbcdghjklmpqrstvwxyz0123456789_-";

            foreach (var n in new[] { 0, 1, 2, 42, 1024, BigInteger.Parse("4125636888562548868221559797461449"), BigInteger.Parse("47023505233334520000") })
                Assert.AreEqual(n, BaseNCodec.Decode(BaseNCodec.Encode(n, alphabet), alphabet));
        }

        [Test]
        public void Prettiness()
        {
            const string alphabet = "BCDGHJKLMPQRSTVWfXZbcdghjklmpqrstvwxyz0123456789";

            for (int i = 0; i < 10000; i++)
            {
                var guid = Guid.NewGuid();

                var n = BigInteger.Parse("0" + guid.ToString("N"), NumberStyles.HexNumber);

                var s = BaseNCodec.Encode(n, alphabet);

                Console.WriteLine("http://libry.net/" + s.PadLeft(23, '_') + ".pdf\t->\t" + "http://libry.net/" + guid.ToString("N") + ".pdf");
            }
        }
    }
}
