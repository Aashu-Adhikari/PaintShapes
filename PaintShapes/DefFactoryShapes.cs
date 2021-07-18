using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShapes
{
    public class DefFactoryShapes
    {
        /// <summary>
        /// method to check if shape is circle
        /// </summary>
        /// <param name="shape">Takes shape as string parameter</param>
        /// <returns>if the contition is true then returns true else returns false</returns>
        public bool isCircle(string shape)
        {
            if (shape == "circle")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// method to check if shape is Rectangle
        /// </summary>
        /// <param name="shape">Takes shape as string parameter</param>
        /// <returns>if the contition is true then returns true else returns false</returns>
        public bool isRectangle(string shape)
        {
            if (shape == "rectangle")
            {
                return true;
            }
            return false;
        }
    }
}
