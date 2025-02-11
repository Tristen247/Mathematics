using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics
{
    public class AdvMath
    {
        
        // 1. Calculates Area
        public static double CalculateArea(double height, double width)
        {
            return height * width;
        }

        // 2. Calculate the average of a list of doubles.
        public static double CalculateAverage(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException("The list cannot be null or empty.", nameof(numbers));

            double sum = 0;
            foreach (double num in numbers)
            {
                sum += num;
            }
            return sum / numbers.Count;
        }

        // 3. Calculate Value Squared (Singular value multiplied by itself)
        public static double SquareValue(double value)
        {
            return value * value;
        }


        // 4. Calculate Pythagorean Theorem (a2 + b2 = c2).
        public static double CalculatePythagorean(double a, double b)
        {
            return Math.Sqrt(SquareValue(a) + SquareValue(b));
        }
    }
}
