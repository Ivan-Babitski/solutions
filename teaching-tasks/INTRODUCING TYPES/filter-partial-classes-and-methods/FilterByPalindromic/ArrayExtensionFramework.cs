using System;
using System.Collections.Generic;

namespace FilterByPalindromic
{
    /// <summary>
    /// ArrayExtension class.
    /// </summary>
    public static partial class ArrayExtension
    {
        /// <summary>
        /// Creates new array of elements that satisfy some predicate.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>New array of elements that satisfy some predicate.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static int[] FilterByPredicate(this int[] source)
        {
            if (source == Array.Empty<int>())
            {
                throw new ArgumentException("Array can not be empty.");
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            List<int> list = new List<int>();

            for (int i = 0; i < source.Length; i++)
            {
                if (IsPalindromicNumber(source[i]))
                {
                    list.Add(source[i]);
                }
            }

            static bool IsPalindromicNumber(int number)
            {
                if (number < 0)
                {
                    return false;
                }

                if (number < 10)
                {
                    return true;
                }

                int degree = 1;
                int degreeUp = 10;
                int degreeDown = 1;
                int countDigit = 1;

                int result = number;

                int tempNum = number;
                int tempUp = number;

                int tempDegree;
                while (number / degreeDown > 10)
                {
                    degreeDown *= 10;
                    countDigit++;
                }

                tempDegree = degreeDown;

                int count;
                if (countDigit % 2 == 0)
                {
                    count = countDigit / 2;
                }
                else
                {
                    count = (countDigit / 2) + 1;
                }

                for (int i = 0; i < count; i++)
                {
                    tempUp /= degreeUp;
                    tempUp *= degreeUp;
                    tempNum = ((tempNum / degree) - (tempUp / degree)) * degreeDown;
                    result -= tempNum;
                    tempNum = number;
                    tempUp = number;
                    degreeDown /= 10;
                    degreeUp *= 10;
                    degree *= 10;
                }

                degreeUp = tempDegree;
                degreeDown = 10;
                degree = 1;
                tempNum = result;

                tempUp /= degreeUp;
                tempNum -= tempUp;
                tempUp = number;
                degree = 10;
                degreeUp /= 10;

                for (int i = 1; i < countDigit / 2; i++)
                {
                    tempUp /= degreeUp;
                    tempUp = (tempUp - (tempUp / degree * degree)) * degreeDown;
                    tempNum = tempNum - tempUp;
                    tempUp = number;
                    degreeUp /= 10;
                    degreeDown *= 10;
                }

                result = tempNum;

                if (result != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return list.ToArray();
        }

        static partial void AddAccordingToPredicate(ICollection<int> collection, int item);
    }
}
