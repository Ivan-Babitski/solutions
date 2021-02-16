using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace IEEE754FormatTask
{
    public static class DoubleExtension
    {
        /// <summary>
        /// Returns a string representation of a double type number
        /// in the IEEE754 (see https://en.wikipedia.org/wiki/IEEE_754) format.
        /// </summary>
        /// <param name="number">Input number.</param>
        /// <returns>A string representation of a double type number in the IEEE754 format.</returns>
        public static string GetIEEE754Format(this double number)
        {
            BitArray bitArray = new BitArray(BitConverter.GetBytes(number));
            string b = "";
            for (int i = bitArray.Length - 1; i >= 0; i--)
            {
                if (bitArray[i])
                {
                    b += 1;
                    continue;
                }

                b += 0;
            }

            return b;
            //string returnableString = string.Empty;
            //int[] result = new int[64];
            //if (number < 0)
            //{
            //    result[0] = 1;
            //}
            //else
            //{
            //    result[0] = 0;
            //}

            //int[] absolutNumInBitWay = Array.Empty<int>();

            //double exponentialForm = Math.Truncate(Math.Abs(number));
            //Console.WriteLine(exponentialForm);
            //int exp = 0;
            //if (number > 1 || number < -1)
            //{
            //    absolutNumInBitWay = BitHelper(exponentialForm);
            //}

            //int[] forMantissa = MantissaHelper(number);
            //int[] mantissa = new int[absolutNumInBitWay.Length + 52];
            //for (int i = 0; i < absolutNumInBitWay.Length; i++)
            //{
            //    mantissa[i] = absolutNumInBitWay[i];
            //}

            //for (int i = 0, j = absolutNumInBitWay.Length; i < forMantissa.Length; i++, j++)
            //{
            //    mantissa[j] = forMantissa[i];
            //}

            //foreach (var item in forMantissa)
            //{
            //    Console.Write(item);
            //}

            //Console.WriteLine();

            //if (exponentialForm == 0)
            //{
            //    for (int i = 0; i < mantissa.Length; i++)
            //    {
            //        if (mantissa[i] == 0)
            //        {
            //            exp--;
            //        }
            //        else
            //        {
            //            exp--;
            //            break;
            //        }
            //    }
            //}
            //else if (exponentialForm >= 2)
            //{
            //    exp = absolutNumInBitWay.Length - 1;
            //}

            //int[] exponentShift = BitHelper(1023 + exp);
            //for (int i = 1, j = 0; j < exponentShift.Length; i++, j++)
            //{
            //    result[i] = exponentShift[j];
            //}

            //for (int i = 12, j = 1; i < result.Length && j < mantissa.Length; i++, j++)
            //{
            //    result[i] = mantissa[j];
            //}

            //foreach (var item in exponentShift)
            //{
            //    Console.Write(item);
            //}

            //Console.WriteLine();

            //static int[] MantissaHelper(double num)
            //{
            //    int quantityOfDigitAfterDot = 0;
            //    if (num.ToString().Contains('.'))
            //    {
            //        quantityOfDigitAfterDot = num.ToString(CultureInfo.InvariantCulture).Split('.')[1].Length;
            //    }

            //    num = Math.Abs(num);
            //    num -= Math.Truncate(Math.Abs(num));
            //    if (quantityOfDigitAfterDot > 15)
            //    {
            //        num = Math.Round(num, 15);
            //    }
            //    else
            //    {
            //        num = Math.Round(num, quantityOfDigitAfterDot);
            //    }

            //    int[] arrayOfBitsForMantissa = new int[52];
            //    for (int i = 0; i < arrayOfBitsForMantissa.Length; i++)
            //    {
            //        num *= 2;
            //        if (num > 1)
            //        {
            //            arrayOfBitsForMantissa[i] = 1;
            //            num -= 1;
            //        }
            //        else
            //        {
            //            arrayOfBitsForMantissa[i] = 0;
            //        }
            //    }

            //    return arrayOfBitsForMantissa;
            //}

            //static int[] BitHelper(double num)
            //{
            //    long a = (long)num;
            //    List<int> absNumberBit = new List<int>();
            //    while (true)
            //    {
            //        if (absNumberBit.Count > 62)
            //        {
            //            break;
            //        }

            //        if (a == 1)
            //        {
            //            absNumberBit.Add(1);
            //            break;
            //        }

            //        if (a % 2 == 0)
            //        {
            //            absNumberBit.Add(0);
            //            a /= 2;
            //        }
            //        else
            //        {
            //            absNumberBit.Add(1);
            //            a /= 2;
            //        }
            //    }

            //    absNumberBit.Reverse();
            //    return absNumberBit.ToArray();
            //}

            //foreach (int item in result)
            //{
            //    returnableString += item;
            //}

            //return returnableString;
        }
    }
}
