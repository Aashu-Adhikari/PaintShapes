using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShapes
{
    public abstract class FactoryAbstract
    {
        /// <summary>
        /// Creates a abstract class getShapes and has string shapeType
        /// </summary>
        /// <param name="shapeType">takes string paremeter shapeType</param>
        /// <returns></returns>
        public abstract Shapes getShapes(String shapeType);
    }
}
