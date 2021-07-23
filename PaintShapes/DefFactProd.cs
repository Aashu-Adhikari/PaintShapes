using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShapes
{
    public class DefFactProd
    {
        //bool method to check whether the type is shape
        /// <summary>
        /// This method is a bool method to check weather the type is shape or not
        /// </summary>
        /// <param name="type">takes string type as parameter</param>
        /// <returns>if the type is equals to shape then returns true else returns false</returns>
        public bool isShape(string type)
        {
            if (type == "shape")
            {
                return true;
            }
            return false;
        }
    }
}
