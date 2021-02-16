using System;
using System.Collections.Generic;
using System.Globalization;

namespace Numbers
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Obtains formalized information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number. 
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number
        /// or null if the information is not defined.</returns>
        public static ComparisonSigns? GetTypeComparisonSigns(this long number)
        {
            if (number < 10 && number > -10)
            {
                return null;
            }

            List<ComparisonSigns> vs = new List<ComparisonSigns>();

            string temp = number.ToString(CultureInfo.InvariantCulture);
            int[] digits = new int[temp.Length];

            for (int a = 0; a < temp.Length; a++)
            {
                digits[a] = temp[a] - '0';
            }

            if (digits.Length > 0)
            {
                for (int i = 0, j = 1; j < digits.Length; i++, j++)
                {
                    if (digits[i] > digits[j])
                    {
                        vs.Add(ComparisonSigns.MoreThan);
                        break;
                    }
                }

                for (int i = 0, j = 1; j < digits.Length; i++, j++)
                {
                    if (digits[i] < digits[j])
                    {
                        vs.Add(ComparisonSigns.LessThan);
                        break;
                    }
                }

                for (int i = 0, j = 1; j < digits.Length; i++, j++)
                {
                    if (digits[i] == digits[j])
                    {
                        vs.Add(ComparisonSigns.Equals);
                        break;
                    }
                }
            }

            ComparisonSigns comparisonSigns;
            comparisonSigns = vs[0];
            for (int i = 0; i < vs.Count; i++)
            {
                comparisonSigns = comparisonSigns | vs[i];
            }

            return comparisonSigns;
        }

        /// <summary>
        /// Gets information in the form of a string about the type of sequence that the digit of a given number represents.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The information in the form of a string about the type of sequence that the digit of a given number represents.</returns>
        public static string GetTypeOfDigitsSequence(this long number)
        {
            const string StrictlyIncreasing = "Strictly Increasing.";
            const string StrictlyDecreasing = "Strictly Decreasing.";
            const string Unordered = "Unordered.";
            const string Decreasing = "Decreasing.";
            const string Increasing = "Increasing.";
            const string Monotonous = "Monotonous.";
            const string OneDigitNumber = "One digit number.";

            ComparisonSigns? temp = GetTypeComparisonSigns(number);

            switch (temp)
            {
                case ComparisonSigns.Equals:
                    return Monotonous;
                case ComparisonSigns.LessThan:
                    return StrictlyIncreasing;
                case ComparisonSigns.MoreThan:
                    return StrictlyDecreasing;
                case ComparisonSigns.LessThan | ComparisonSigns.Equals:
                    return Increasing;
                case ComparisonSigns.MoreThan | ComparisonSigns.Equals:
                    return Decreasing;
                case ComparisonSigns.MoreThan | ComparisonSigns.LessThan:
                    return Unordered;
                case ComparisonSigns.Equals | ComparisonSigns.LessThan | ComparisonSigns.MoreThan:
                    return Unordered;
            }

            return OneDigitNumber;
        }
    }
}
