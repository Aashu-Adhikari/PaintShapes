using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintShapes
{
    public partial class Form1 : Form
    {

        
        Boolean drawCircle, drawRectangle, drawPolygon, drawTriangle, fill;
        //string variables to store text command text info
        String app;
        //holds the information of words in arrayS
        String[] words;
        //stores integer variables of x and y cordinates
        int moveX, moveY;
        //stores the thickness of pen in integer
        int thickness;
        //FactoryShapes Declared
        Shapes shape1, shape2, shape3, shape4;
        //list to hold circle, rectangle, variable, triangle and polygon objects
        List<Circle> circleObjects;
        
        List<Rectangle> rectangleObjects;
        
        List<Polygon> polygonObjects;
        
        List<Variables> variableObjects;
        
        List<Triangle> triangleObjects;

        Circle circle;
        Rectangle rectangle;
        Variables variable;
        Polygon polygon;
        //Declared the Color as c
        Color c;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            implementCmd = textBox1.Text.ToLower();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        int counter; // counter to loop the code
        int loopCounter; //loopcounter to hold loop value in loop code

        //stores the implement command form implement text
        string implementCmd;


        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //inbuilt Graphic library in value g to paint
            Graphics g = e.Graphics;
            if (fill == true)//checks if the condition is true then
            {
                if (drawTriangle == true)// paint condition is true then
                {
                    foreach (Triangle traingleObject in triangleObjects)
                    {
                        traingleObject.fill(g, c); //paint the triangle
                    }
                }

                if (drawCircle == true)
                {
                    foreach (Circle circleObject in circleObjects)
                    {
                        circleObject.fill(g, c);
                    }
                }

                if (drawRectangle == true) 
                {
                    foreach (Rectangle rectangleObject in rectangleObjects)
                    {
                        rectangleObject.fill(g, c); 
                    }
                }

                if (drawPolygon == true)
                {
                    foreach (Polygon polygonObject in polygonObjects)
                    {
                        polygonObject.fill(g, c); 
                    }
                }
            }
            if (fill == false)//checks if the condition is false then
            {
                if (drawTriangle == true)// paint condition is true then
                {
                    foreach (Triangle triangleObject in triangleObjects)
                    {
                        triangleObject.paint(g, c, thickness); // paints the triangle
                    }
                }

                if (drawCircle == true)
                {
                    foreach (Circle circleObject in circleObjects)
                    {
                        circleObject.paint(g, c, thickness); 
                    }
                }

                if (drawRectangle == true) 
                {
                    foreach (Rectangle rectangleObject in rectangleObjects)
                    {
                        rectangleObject.paint(g, c, thickness); 
                    }
                }

                if (drawPolygon == true)
                {
                    foreach (Polygon polygonObject in polygonObjects)
                    {
                        polygonObject.paint(g, c, thickness); 
                    }
                }
            }
        }
    }
}
