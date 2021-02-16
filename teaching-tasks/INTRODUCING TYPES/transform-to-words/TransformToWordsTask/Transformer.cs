using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TransformToWordsTask
{
    /// <summary>
    /// Provides transformer methods.
    /// </summary>
    public class Transformer
    {
        private const string Minus = "Minus ";
        private const string Point = "point ";
        private const string Plus = "plus ";
        private const string E = "E ";
        private const string NaN = "NaN";
        private const string NegInfinity = "Negative Infinity";
        private const string PosInfinity = "Positive Infinity";
        private const string MinusZero = "Minus zero";
        private const string Zero = "Zero";
        private const string Eps = "Double Epsilon";
        
        private readonly string[] digitLowCase = new string[] { "zero ", "one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nine " };
        private readonly string[] digitUpCase = new string[] { "Zero ", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };

        /// <summary>
        /// Converts number's digital representation into words.
        /// </summary>
        /// <param name="number">Number to convert.</param>
        /// <returns>Words representation.</returns>
        public string TransformToWords(double number)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string numString = number.ToString(CultureInfo.InvariantCulture);

            if (number == 0)
            {
                if (BitConverter.ToString(BitConverter.GetBytes(number)) == BitConverter.ToString(BitConverter.GetBytes(-0.0d)))
                {
                    return MinusZero;
                }

                return Zero;
            }

            if (double.IsNaN(number))
            {
                return NaN;
            }

            if (number == double.NegativeInfinity)
            {
                return NegInfinity;
            }            
            
            if (number == double.PositiveInfinity)
            {
                return PosInfinity;
            }

            if (number == double.Epsilon)
            {
                return Eps;
            }

            if (number < 0)
            {
                stringBuilder.Append(Minus);
            }
            else
            {
                stringBuilder.Append(this.digitUpCase[int.Parse(numString[0].ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture)]);
            }

            for (int i = 1; i < numString.Length; i++)
            {
                if (char.IsDigit(numString[i]))
                {
                    stringBuilder.Append(this.digitLowCase[int.Parse(numString[i].ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture)]);
                }
                else
                {
                    switch (numString[i])
                    {
                        case '+':
                            stringBuilder.Append(Plus);
                            break;
                        case 'E':
                            stringBuilder.Append(E);
                            break;  
                        case '.':
                            stringBuilder.Append(Point);
                            break;
                    }
                }
            }

            return stringBuilder.ToString(0, stringBuilder.Length - 1);
        }
    }
}
