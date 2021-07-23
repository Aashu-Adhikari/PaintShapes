using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaintShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShapes.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void IsShapeEquals_Circle_ReturnTrue()
        {
            var defFactoryShapes = new DefFactoryShapes();
            bool result = defFactoryShapes.isCircle("circle");

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void ToCheckWeatherTheTypeIS_Shape_ReturnTrue()
        {
            var defFactProd = new DefFactProd();
            bool result = defFactProd.isShape("shape");

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void IsShapeEquals_Rectangle_ReturnTrue()
        {
            var defFactoryShapes = new DefFactoryShapes();
            bool result = defFactoryShapes.isRectangle("rectangle");

            Assert.AreEqual(true, result);
        }
    }
}