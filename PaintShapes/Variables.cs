using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShapes
{
    public class Variables
    {
        /// <summary>
        /// string variable get and set
        /// </summary>
        public string variable { get; set; }
        /// <summary>
        /// string value get and set
        /// </summary>
        public float value { get; set; }
        /// <summary>
        /// declared set method of variables which takes varibales as parameter
        /// </summary>
        /// <param name="variable">takes string variables as parameter</param>
        public void setVariable(string variable)
        {
            this.variable = variable;
        }
        /// <summary>
        /// declared get method of Variables
        /// </summary>
        /// <returns>returns the variable</returns>
        public string getVariable()
        {
            return this.variable;
        }
        /// <summary>
        /// declared set method of value which takes value as parameter
        /// </summary>
        /// <param name="value">takes string value as parameter</param>
        public void setValue(float value)
        {
            this.value = value;
        }
        /// <summary>
        /// declared get mthod of value
        /// </summary>
        /// <returns>returns value</returns>
        public float getValue()
        {
            return this.value;
        }
    }
}
