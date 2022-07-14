using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComarchZadania.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarchZadania.Console.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        [DataRow(4, 2, 2)]
        [DataRow(8, 2, 4)]
        public void DividyShouldReturnExpectedValueForCorrectData(int x, int y, int expected)
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            float actual = calculator.Dividy(x, y);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DividyShouldThrowExceptionForZeroParameter()
        {
            //Arrange
            Calculator calculator = new Calculator();
            int x = 4, y = 0;

            //Act & Assert
            Assert.ThrowsException<DivideByZeroException>(() => calculator.Dividy(x, y));
        }
    }
}