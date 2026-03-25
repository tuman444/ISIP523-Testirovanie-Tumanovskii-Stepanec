using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PR4_Stepanec_Tumanovskii.Logic;
using System.ComponentModel;

namespace UnitTestProject1
{
    [TestClass]
    public class OneCaseTests
    {
        [TestMethod]
        public void TryParseVales_ValidNumbers_ReturnsTrue()
        {
            bool result = OneCaseCalculator.TryParseValues("2", "1", "3", out double x, out double y, out double z);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TryParseVales_EmptyString_ReturnsFalse()
        {
            bool result = OneCaseCalculator.TryParseValues("", "1", "3", out _, out _, out _);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TryParseVales_Symbols_ReturnsFalse()
        {
            bool result = OneCaseCalculator.TryParseValues("!@#@", "1", "3", out _, out _, out _);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TryParseVales_Letters_ReturnsFalse()
        {
            bool result = OneCaseCalculator.TryParseValues("aaabbbcccc", "1", "3", out _, out _, out _);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Calculate_NormalValues_ReturnCorrectResult()
        {
            double x = 2;
            double y = 1;
            double z = 3;
            double result = OneCaseCalculator.Calculate(x, y, z);
            double expected = 5 * Math.Atan(x) - (1.0 / 4.0) * Math.Atan(x) * ((x + 3 * Math.Abs(x - y) + Math.Pow(x, 2)) / (Math.Abs(x - y) * z + Math.Pow(x, 2)));
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Calculate_NegativeValues_ReturnCorrectResult()
        {
            double x = -2;
            double y = -1;
            double z = 4;
            double result = OneCaseCalculator.Calculate(x, y, z);
            Assert.IsTrue(!double.IsNaN(result));
        }
        [TestMethod]
        public void Calculate_ZeroValues_ReturnCorrectResult()
        {
            double x = 0;
            double y = 1;
            double z = 1;
            double result = OneCaseCalculator.Calculate(x, y, z);
            Assert.IsTrue(!double.IsNaN(result));
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Calculate_DividedByZero_ThrowException()
        {
            double x = 0;
            double y = 0;
            double z = 0;
            double result = OneCaseCalculator.Calculate(x, y, z);
        }
        [TestMethod]
        public void Calculate_LargeNumbers_WorksCorrectly()
        {
            double x = 30000;
            double y = 1000;
            double z = 200;
            double result = OneCaseCalculator.Calculate(x, y, z);
            Assert.IsTrue(!double.IsInfinity(result));
        }
    }

    [TestClass]
    public class TwoCaseTests
    {
        [TestMethod]    
        public void TryParseValues_ValidValues_ReturnsTrue()
        {
            bool result = TwoCaseCalculator.TryParseValues("2", "3", out double x, out double b);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TryParseVales_EmptyString_ReturnFalse()
        {
            bool result = TwoCaseCalculator.TryParseValues("", "2", out _, out _);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TryParseVales_Letters_ReturnFalse()
        {
            bool result = TwoCaseCalculator.TryParseValues("asd", "3", out _, out _);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TryParseVales_Symbols_ReturnFalse()
        {
            bool result = TwoCaseCalculator.TryParseValues("!@#", "4", out _, out _);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CalculareFx_Sinh_ReturnsCorrectValue()
        {
            double result = TwoCaseCalculator.CalculateFx(1, FxType.Sinh);
            Assert.AreEqual(Math.Sinh(1), result, 0.0001);
        }
        [TestMethod]
        public void CalculareFx_Squere_ReturnsCorrectValue()
        {
            double result = TwoCaseCalculator.CalculateFx(3, FxType.Square);
            Assert.AreEqual(9, result);
        }
        [TestMethod]
        public void CalculareFx_Exp_ReturnsCorrectValue()
        {
            double result = TwoCaseCalculator.CalculateFx(2, FxType.Exp);
            Assert.AreEqual(Math.Exp(2), result, 0.0001);
        }
        [TestMethod]
        public void Calculate_Range1_ReturnsExp()
        {
            double x = 2;
            double b = 2;

            double result = TwoCaseCalculator.Calculate(x, b, FxType.Square);
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void Calculate_Range2_ReturnsSqrt()
        {
            double x = 5;
            double b = 3;

            double result = TwoCaseCalculator.Calculate(x, b, FxType.Sinh);
            Assert.IsTrue(result >= 0);
        }
        [TestMethod]
        public void Calculate_DeafaultBranch_ReturnsCorrect()
        {
            double x = 0.5;
            double b = 1;

            double result = TwoCaseCalculator.Calculate(x, b, FxType.Exp);
            Assert.IsTrue(result >= 0);
        }
    }

    [TestClass]
    public class ThreeCaseTests
    {
        [TestMethod]
        public void TryParseValue_ValidNumber_ReturnsTrue()
        {
            bool result = ThreeCaseCalculator.TryParseValue("3.0", out double x);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TryParseValue_EmptyString_ReturnsFalse()
        {
            bool result = ThreeCaseCalculator.TryParseValue("", out _);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryParseValue_Letters_ReturnsFalse()
        {
            bool result = ThreeCaseCalculator.TryParseValue("abc", out _);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsInRange_ValidValue_ReturnsTrue()
        {
            bool result = ThreeCaseCalculator.IsInRange(3.0);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsInRange_LessThanMinimum_ReturnsFalse()
        {
            bool result = ThreeCaseCalculator.IsInRange(2.0);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsInRange_GreaterThanMaximum_ReturnsFalse()
        {
            bool result = ThreeCaseCalculator.IsInRange(5.0);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Calculate_ValidValue_ReturnsCorrectResult()
        {
            double x = 3;

            double result = ThreeCaseCalculator.Calculate(x);

            double expected =
                9 * (x + 15 * Math.Sqrt(Math.Pow(x, 3) + Math.Pow(2.3, 3)));

            Assert.AreEqual(expected, result, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Calculate_OutOfRange_ThrowsException()
        {
            ThreeCaseCalculator.Calculate(1);
        }
    }
}
