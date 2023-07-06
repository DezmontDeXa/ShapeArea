using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeArea.Shapes;

namespace ShapeArea.Tests
{
    [TestClass()]
    public class ShapeAreaCalculatorTests
    {
        [TestMethod()]
        public void CalculateTriangle254()
        {
            ShapeAreaCalculator calculator = new ShapeAreaCalculator();
            Assert.AreEqual(3.799671038392666, calculator.Calculate(Triangle.CreateBySides(2, 5, 4)));
        }

        [TestMethod()]
        public void CalculateCircle5()
        {
            ShapeAreaCalculator calculator = new ShapeAreaCalculator();
            Assert.AreEqual(25*Math.PI, calculator.Calculate(Circle.Create(5)));
        }
    }
}