﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace FilterByDigit
{
    /// <summary>
    /// Class that contains filter operations of arrays.
    /// </summary>
    public static partial class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that satisfy some predicate.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>New array of elements that satisfy some predicate.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static int[] FilterByPredicate(this int[] source)
        {
            int predicate = Digit;
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source == Array.Empty<int>())
            {
                throw new ArgumentException("Array can not be empty.");
            }



            List<int> match = new List<int>();
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i].ToString(CultureInfo.InvariantCulture).Contains(Digit.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCultureIgnoreCase))
                {
                    match.Add(source[i]);
                }
            }

            return match.ToArray();
        }

        /// <summary>
        /// Forms a collection of integers that match some predicate.
        /// </summary>
        /// <remarks>The predicate logic is implemented in another part of the partial class.</remarks>
        /// <param name="collection">A collection that is formed based on a predicate match.</param>
        /// <param name="item">An element that, if it contains the digit, is added to the collection.</param>
        static partial void AddAccordingToPredicate(ICollection<int> collection, int item);
    }
}
