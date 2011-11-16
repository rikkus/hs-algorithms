using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Safeware.Utils
{
    public static class BaseNCodec
    {
        public static string Encode(BigInteger bigNumber, string alphabet)
        {
            var ret = new StringBuilder();

            if (bigNumber == 0)
                return alphabet[0].ToString();

            BigInteger theBase = alphabet.Length;

            while (bigNumber.CompareTo(0) != 0)
            {
                BigInteger remainder;
                var newBigNumber = BigInteger.DivRem(bigNumber, theBase, out remainder);
                ret.Insert(0, alphabet[(int)remainder]);
                bigNumber = newBigNumber;
            }

            return ret.ToString();
        }

        public static BigInteger Decode(string data, string alphabet)
        {
            var theBase = alphabet.Length;
            var dataLength = data.Length;

            var i = 0;

            return data.Aggregate<char, BigInteger>
                (0,
                 (current, c) =>
                 current + BigInteger.Multiply(alphabet.IndexOf(c), BigInteger.Pow(theBase, dataLength - (i++ + 1)))
                );
        }
    }
}
