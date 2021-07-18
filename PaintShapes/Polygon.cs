using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShapes
{
    /// <summary>
    /// Polygon class which extends the base class Shape class
    /// </summary>
    class Polygon : Shapes
    {
        PointF[] points
            ;
        /// <summary>
        /// createed a default constructor
        /// </summary>
        public Polygon()
        {
        }
        /// <summary>
        /// created a constructor which takes the array of points
        /// </summary>
        /// <param name="points">takes arrays of points as parameter</param>
        public Polygon(PointF[] points)
        {
            this.points = points;
        }
        /// <summary>
        /// this method is the setter method of Points
        /// </summary>
        /// <param name="points">takes array of points as parameter</param>
        public void setPoints(PointF[] points)
        {
            this.points = points;
        }
        /// <summary>
        /// created a arrays get method which returns the array of ponts
        /// </summary>
        /// <returns>returns the array of points</returns>
        public PointF[] getPoint()
        {
            return this.points;
        }
        /// <summary>
        /// Fill method is the inheritance of the shape class which uses Drawing library
        /// </summary>
        /// <param name="g">takes g as Graphic function</param>
        /// <param name="c">takes c as Color function</param>
        public override void fill(Graphics g, Color c)
        {
            SolidBrush fill = new SolidBrush(c);
            g.FillPolygon(fill, points);

        }

        /// <summary>
        /// Paint method is the inheritance of the shape class which uses Drawing library
        /// </summary>
        /// <param name="g">takes g as Graphic function</param>
        /// <param name="c">takes c as Color function</param>
        /// <param name="thickness">takes integer thickness as Pen thickness</param>
        public override void paint(Graphics g, Color c, int thickness)
        {
            Pen p = new Pen(c);
            g.DrawPolygon(p, points);
        }
    }
}
