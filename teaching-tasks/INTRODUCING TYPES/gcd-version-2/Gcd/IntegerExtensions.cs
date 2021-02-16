using System;

namespace Gcd
{
    /// <summary>
    /// Provide methods with integers.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return Math.Max(a, b);
        }
            
        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            a = Math.Abs(a);
            b = Math.Abs(b);
            c = Math.Abs(c);

            static int GetGcd(int a, int b)
            {
                while (a != 0 && b != 0)
                {
                    if (a > b)
                    {
                        a -= b;
                    }
                    else
                    {
                        b -= a;
                    }
                }

                return Math.Max(a, b);
            }

            return GetGcd(GetGcd(a, b), c);
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, params int[] other)
        {
            int[] nums = new int[other.Length + 2];
            nums[0] = a;
            nums[1] = b;
            bool allZero = true;

            for (int i = 2, j = 0; i < nums.Length; i++, j++)
            {
                nums[i] = other[j];
            }

            foreach (var item in nums)
            {
                if (item != 0)
                {
                    allZero = false;
                    break;
                }
            }

            if (allZero)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            foreach (var item in nums)
            {
                if (item == int.MinValue)
                {
                    throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
                }
            }

            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = Math.Abs(nums[i]);
            }

            int temp = nums[0];
            for (int i = 0, j = 1; j < nums.Length; i++, j++)
            {
                if (temp == 0)
                {
                    temp = nums[j];
                }
                else
                {
                    while (nums[j] != 0)
                    {
                        if (nums[i] > nums[j])
                        {
                            nums[i] -= nums[j];
                        }
                        else
                        {
                            nums[j] -= nums[i];
                        }
                    }

                    nums[j] = nums[i];
                    temp = nums[i];
                }
            }

            return temp;
        }

        /// <summary>
        /// Calculates GCD of two integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }
            
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            int k;
            for (k = 0; ((a | b) & 1) == 0; ++k)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    int temp = a;
                    a = b;
                    b = temp;
                }

                b = b - a;
            }
            while (b != 0);

            return a << k;
        }

        /// <summary>
        /// Calculates GCD of three integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            a = Math.Abs(a);
            b = Math.Abs(b);
            c = Math.Abs(c);

            int GcdStain(int a, int b)
            {
                if (a == 0)
                {
                    return b;
                }

                if (b == 0)
                {
                    return a;
                }

                int k;
                for (k = 0; ((a | b) & 1) == 0; ++k)
                {
                    a >>= 1;
                    b >>= 1;
                }

                while ((a & 1) == 0)
                {
                    a >>= 1;
                }

                do
                {
                    while ((b & 1) == 0)
                    {
                        b >>= 1;
                    }

                    if (a > b)
                    {
                        int temp = a;
                        a = b;
                        b = temp;
                    }

                    b = b - a;
                }
                while (b != 0);

                return a << k;
            }

            return GcdStain(GcdStain(a, b), c);
        }

        /// <summary>
        /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, params int[] other)
        {
            int[] nums = new int[other.Length + 2];
            nums[0] = a;
            nums[1] = b;
            bool allZero = true;
            int temp;

            for (int i = 2, j = 0; i < nums.Length; i++, j++)
            {
                nums[i] = other[j];
            }

            foreach (var item in nums)
            {
                if (item != 0)
                {
                    allZero = false;
                    break;
                }
            }

            if (allZero)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            foreach (var item in nums)
            {
                if (item == int.MinValue)
                {
                    throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = Math.Abs(nums[i]);
            }

            temp = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                temp = GcdStain(temp, nums[i]);
            }

            int GcdStain(int a, int b)
            {
                if (a == 0)
                {
                    return b;
                }

                if (b == 0)
                {
                    return a;
                }

                int k;
                for (k = 0; ((a | b) & 1) == 0; ++k)
                {
                    a >>= 1;
                    b >>= 1;
                }

                while ((a & 1) == 0)
                {
                    a >>= 1;
                }

                do
                {
                    while ((b & 1) == 0)
                    {
                        b >>= 1;
                    }

                    if (a > b)
                    {
                        int temp = a;
                        a = b;
                        b = temp;
                    }

                    b = b - a;
                }
                while (b != 0);

                return a << k;
            }

            return temp;
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b)
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static long GetGcdByEuclidean(out long elapsedTicks, int a, int b, int c)
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static long GetGcdByEuclidean(out long elapsedTicks, int a, int b, params int[] other)
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b)
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static long GetGcdByStein(out long elapsedTicks, int a, int b, int c)
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static long GetGcdByStein(out long elapsedTicks, int a, int b, params int[] other)
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }
}
