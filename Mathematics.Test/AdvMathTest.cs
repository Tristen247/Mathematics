using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mathematics.Test
{
    public class AdvMathTest
    {
        [Fact]
        public void TestCalculateArea()
        {
            double height = 4;
            double width = 5;
            double expectedArea = 20;

            double result = AdvMath.CalculateArea(height, width);

            Assert.True(result == expectedArea);
        }

        [Fact]
        public void TestCalculateAverage()
        {
            var numbers = new List<double> { 10, 20, 30, 40 };
            double expectedAverage = 25;

            double result = AdvMath.CalculateAverage(numbers);

            Assert.True(result == expectedAverage);
        }

        [Fact]
        public void TestCalculateValueSquared()
        {
            double value = 6;
            double expectedSquare = 36;

            double result = AdvMath.SquareValue(value);

            Assert.True(result == expectedSquare);
        }

        [Fact]
        public void TestCalculatePythagorean()
        {
            double a = 3;
            double b = 4;
            double expectedHypotenuse = 5; 

            double result = AdvMath.CalculatePythagorean(a, b);

            Assert.True(result == expectedHypotenuse);
        }
    }
}
