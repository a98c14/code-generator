using System;

namespace KeyGenerator
{
    /// <summary>
    /// Converts given numbers to arbitrary number system
    /// </summary>
    public class BaseConverter
    {
        const int LongBits = 64;
        private readonly string Digits;

        /// <summary>
        /// Creates an instance of the BaseConverter with given digit set
        /// </summary>
        /// <param name="digits">Charset (e.g "0123456789" for decimal)</param>
        public BaseConverter(string digits)
        {
            Digits = digits;
        }

        public long Convert(string number)
        {
            var radix = Digits.Length;

            long value = 0;
            for(int i = 0; i < number.Length; i++)
            {
                var digit = number[i];
                var index = Digits.IndexOf(digit);
                value += index * (long)Math.Pow(radix, number.Length - i - 1);
            }
            return value;
        }

        public string Convert(long number)
        {
            var radix = Digits.Length;

            if (number == 0)
                return Digits[0].ToString();

            var index = LongBits - 1;
            var n = Math.Abs(number);
            var charArray = new char[LongBits];

            while (n != 0)
            {
                var remainder = (int)(n % radix);
                charArray[index--] = Digits[remainder];
                n /= radix;
            }

            var result = new string(charArray, index + 1, LongBits - index - 1);
            if (number < 0)
                result = "-" + result;

            return result;
        }

    }
}
