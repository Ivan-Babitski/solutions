using System;
using System.Collections.Generic;
using System.Globalization;

namespace TransformerTask
{
    /// <summary>
    /// Implement transformer class.
    /// </summary>
    public class Transformer
    {
        /// <summary>
        /// Transform each element of source array into its binary representation according to IEEE 754 format.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of IEEE754-binary representation of elements of source array.</returns>
        /// <exception cref="ArgumentNullException">Throw if array is null.</exception>
        /// <exception cref="ArgumentException">Throw if array is empty.</exception>
        public string[] Transform(double[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source == Array.Empty<double>())
            {
                throw new ArgumentException("Array cannot be empty.");
            }

            string[] result = new string[source.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = this.GetIEEE754Format(source[i]);
            }

            return result;
        }

        public string GetIEEE754Format(double number)
        {
            string returnableString = string.Empty;
            int[] result = new int[64];
            if (number < 0)
            {
                result[0] = 1;
            }
            else
            {
                result[0] = 0;
            }

            int[] absolutNumInBitWay = Array.Empty<int>();

            double exponentialForm = Math.Truncate(Math.Abs(number));
            Console.WriteLine(exponentialForm);
            int exp = 0;
            if (number > 1 || number < -1)
            {
                absolutNumInBitWay = BitHelper(exponentialForm);
            }

            int[] forMantissa = MantissaHelper(number);
            int[] mantissa = new int[absolutNumInBitWay.Length + 52];
            for (int i = 0; i < absolutNumInBitWay.Length; i++)
            {
                mantissa[i] = absolutNumInBitWay[i];
            }

            for (int i = 0, j = absolutNumInBitWay.Length; i < forMantissa.Length; i++, j++)
            {
                mantissa[j] = forMantissa[i];
            }

            foreach (var item in forMantissa)
            {
                Console.Write(item);
            }

            Console.WriteLine();

            if (exponentialForm == 0)
            {
                for (int i = 0; i < mantissa.Length; i++)
                {
                    if (mantissa[i] == 0)
                    {
                        exp--;
                    }
                    else
                    {
                        exp--;
                        break;
                    }
                }
            }
            else if (exponentialForm >= 2)
            {
                exp = absolutNumInBitWay.Length - 1;
            }

            int[] exponentShift = BitHelper(1023 + exp);
            for (int i = 1, j = 0; j < exponentShift.Length; i++, j++)
            {
                result[i] = exponentShift[j];
            }

            for (int i = 12, j = 1; i < result.Length && j < mantissa.Length; i++, j++)
            {
                result[i] = mantissa[j];
            }

            foreach (var item in exponentShift)
            {
                Console.Write(item);
            }

            Console.WriteLine();

            static int[] MantissaHelper(double num)
            {
                int quantityOfDigitAfterDot = 0;
                if (num.ToString(CultureInfo.InvariantCulture).Contains('.', StringComparison.InvariantCulture))
                {
                    quantityOfDigitAfterDot = num.ToString(CultureInfo.InvariantCulture).Split('.')[1].Length;
                }

                num = Math.Abs(num);
                num -= Math.Truncate(Math.Abs(num));
                if (quantityOfDigitAfterDot > 15)
                {
                    num = Math.Round(num, 15);
                }
                else
                {
                    num = Math.Round(num, quantityOfDigitAfterDot);
                }

                int[] arrayOfBitsForMantissa = new int[52];
                for (int i = 0; i < arrayOfBitsForMantissa.Length; i++)
                {
                    num *= 2;
                    if (num > 1)
                    {
                        arrayOfBitsForMantissa[i] = 1;
                        num -= 1;
                    }
                    else
                    {
                        arrayOfBitsForMantissa[i] = 0;
                    }
                }

                return arrayOfBitsForMantissa;
            }

            static int[] BitHelper(double num)
            {
                long a = (long)num;
                List<int> absNumberBit = new List<int>();
                while (true)
                {
                    if (absNumberBit.Count > 62)
                    {
                        break;
                    }

                    if (a == 1)
                    {
                        absNumberBit.Add(1);
                        break;
                    }

                    if (a % 2 == 0)
                    {
                        absNumberBit.Add(0);
                        a /= 2;
                    }
                    else
                    {
                        absNumberBit.Add(1);
                        a /= 2;
                    }
                }

                absNumberBit.Reverse();
                return absNumberBit.ToArray();
            }

            foreach (int item in result)
            {
                returnableString += item;
            }

            return returnableString;
        }
    }
}
