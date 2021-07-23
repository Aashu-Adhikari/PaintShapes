using PaintShapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintShapes
{
    public partial class Form1 : Form
    {


        Boolean drawCircle, drawRectangle, drawPolygon, drawTriangle, fill;
        //string variable to store text command text info
        String app;
        //holds the information of words in arrayS
        String[] words;
        //stores integer variable of x and y cordinates
        int moveX, moveY;
        //stores the thickness of pen in integer
        int thickness;
        //FactoryShapes Declared
        Shapes shape1, shape2, shape3, shape4;
        //list to hold circle, rectangle, variable, triangle and polygon objects
        List<Circle> circleObjects;

        List<Rectangle> rectangleObjects;

        List<Polygon> polygonObjects;

        List<Variable> variableObjects;

        List<Triangle> triangleObjects;

        Triangle triangle;
        Circle circle;
        Rectangle rectangle;
        Variable variable;
        Polygon polygon;
        //Declared the Color as c
        Color c;

        int counter; // counter to loop the code
        int loopCounter; //loopcounter to hold loop value in loop code

        //stores the implement command form implement text
        string implementCmd;

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            panel2.Invalidate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            circle = new Circle(); //creates new circle
            rectangle = new Rectangle(); //creates new rectangle
            circleObjects = new List<Circle>(); //creates array of new circle objects
            rectangleObjects = new List<Rectangle>(); //creates array of new rectangle objects
            variableObjects = new List<Variable>();//creates array of new variable objects
            polygonObjects = new List<Polygon>();//creates array of new polygon objects
            triangleObjects = new List<Triangle>();//creates array of new trangle objects
            c = Color.White;//sets the color on startUp
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("!!!!MAKE SURE YOU ENTER THE SYNTAX AND PARAMATERS CORRECT!!!!\n" +
                "+++++++++++++++++++++++++++++++\n" +
                "Hint\n" +
                "+++++++++++++++++++++++++++++++\n" +
                "TO paint SHAPES COMMANDS\n" +
                "-------------------------------\n" +
                "draw rectangle 500 100\n" +
                "draw circle 100 100\n" +
                "draw polygon\n" +
                "draw traingle\n" +
                "-------------------------------\n" +
                "To paint Shapes With user defined Paremeter\n" +
                "radius = 100\n" +
                "draw circle radius\n" +
                "width = 100\n" +
                "height = 50\n" +
                "draw width height\n" +
                "--------------------------------\n" +
                "For looping: \n" +
                "--------------------------------\n" +
                "r = 100 \n loop 4 \n r + 100 \n draw circle r \n end loop \n " +
                "--------------------------------\n" +
                "For if statement:\n" +
                "--------------------------------\n" +
                "counter = 5 \n if counter = 5 then \n draw circle 100 \n end if \n" +
                "--------------------------------\n" +
                "TO CHANGE THE CORDINATES OF THE SHAPES COMMANDS\n" +
                "--------------------------------\n" +
                "move 100 100\n" +
                "--------------------------------\n" +
                "TO CHANGE THE COLOR AND SIZE OF THE PEN\n" +
                "--------------------------------\n" +
                "color red 23\n" +
                "---------------------------------\n" +
                "TO ENABLE FILL OPTION ON AND OFF\n" +
                "---------------------------------\n" +
                "fill on\n" +
                "fill off\n" +
                "---------------------------------\n");
        }

        
        public Form1()
        {
            InitializeComponent();
            //Shape creation and initialization
            FactoryAbstract shapeFactory = FactProd.getFactory("Shapes");
            shape1 = shapeFactory.getShapes("circle");
            shape2 = shapeFactory.getShapes("rectangle");
            shape3 = shapeFactory.getShapes("polygon");
            shape4 = shapeFactory.getShapes("triangle");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            implementCmd = textBox1.Text.ToLower();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (implementCmd)
            {
                case "run":
                    //checks if command code is empty when clicked action button
                    if (richTextBox1.Text == "")
                    {
                        MessageBox.Show("No Syntax and Paramater Detected");
                    }
                    try
                    {
                        //Cnversts all the written command to lower case
                        app = richTextBox1.Text.ToLower();
                        //delimeters variable holds the array \r \n
                        char[] delimiters = new char[] { '\r', '\n' };
                        //holds invididuals code line 
                        string[] parts = app.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        //loop through the whole app code line
                        for (int i = 0; i < parts.Length; i++)
                        {
                            //single code line
                            String code_line = parts[i];
                            //splits the code when space 
                            char[] value_code = new char[] { ' ' };
                            //holds invididuals code line
                            words = code_line.Split(value_code, StringSplitOptions.RemoveEmptyEntries);

                            //calculation to add value to variable
                            if (Regex.IsMatch(words[0], @"^[a-zA-Z]+$") && words[1].Equals("+"))
                            {
                                //sets new incremented value to the defined variable and puts it in vaiableObjects class
                                variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))].
                                    setValue(variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))]
                                    .getValue() + Convert.ToInt32(words[2]));
                            }
                            if ((Regex.IsMatch(words[0], @"^[a-zA-Z]+$") && words[1].Equals("=")))
                            {
                                if (variableObjects.Exists(x => x.variable == words[0] && x.value == Convert.ToInt32(words[2])) == true)
                                {
                                    Console.WriteLine("variable exists: ");

                                }
                                //add new variableObjects if variableObject is empty
                                else if (variableObjects == null || variableObjects.Count == 0)
                                {
                                    variable = new Variable();
                                    variable.setVariable(words[0]);
                                    variable.setValue(Convert.ToInt32(words[2]));
                                    variableObjects.Add(variable);
                                }
                                else
                                {
                                    //else checks if variable exists or not
                                    if (!variableObjects.Exists(x => x.variable == words[0]))
                                    {
                                        variable = new Variable();
                                        variable.setVariable(words[0]);
                                        variable.setValue(Convert.ToInt32(words[2]));
                                        variableObjects.Add(variable);
                                    }
                                    //else add new variable value to variableObjects
                                    else
                                    {
                                        variable = new Variable();
                                        variable.setVariable(words[0]);
                                        variable.setValue(Convert.ToInt32(words[2]));
                                        variableObjects[variableObjects.FindIndex(x => x.variable.Contains(words[0]))] = variable;
                                    }
                                }
                            }

                            //checks if words has 'move' command then
                            if (words[0] == "move")
                            {
                                moveX = Convert.ToInt32(words[1]);//sets the location the shape xaxis
                                moveY = Convert.ToInt32(words[2]);//sets the location of the shape yaxis
                            }

                            //checks if word holds the value 'color' then
                            if (words[0] == "color")
                            {
                                thickness = Convert.ToInt32(words[2]);//converting string value to integer value

                                if (words[1] == "red")//if red then color changes to red
                                {
                                    c = Color.Red;
                                }
                                else if (words[1] == "blue")//if blue then color changes to blue
                                {
                                    c = Color.Blue;
                                }
                                else if (words[1] == "yellow")//if yellow then color changes to yellow
                                {
                                    c = Color.Yellow;
                                }
                                else
                                {
                                    c = Color.AliceBlue;//default color
                                }
                            }

                            //checks if the word holds the value 'fill' then
                            if (words[0] == "fill")
                            {
                                if (words[1] == "on")//checks if the word[1] holds value'on'
                                {
                                    fill = true;//sets fill ture
                                }
                                if (words[1] == "off")//checks if the word[1] holds value 'off'
                                {
                                    fill = false;//sets fill false
                                }
                            }

                            //checks if the word holds the value 'draw' then
                            if (words[0].Equals("draw"))
                            {
                                counter += 1;//value to increment draw circle method

                                if (words[1] == "triangle")
                                {
                                    //created triangle instance of triangle class
                                    Triangle triangle = new Triangle();
                                    //Takes the cordination of the trangle
                                    PointF[] points = { new PointF(100, 100), new PointF(200, 100), new PointF(150, 10) };
                                    //puts points value to Trangle setter method
                                    triangle.setPoints(points);
                                    triangleObjects.Add(triangle);
                                    //makes draw triangle true
                                    drawTriangle = true;
                                }
                                //checks for 'circle' word
                                if (words[1] == "circle")
                                {

                                    //checks weather the written code is right or wrong
                                    if (!(words.Length == 3))
                                    {
                                        MessageBox.Show("!!!Wrong Command!!!\neg.draw circle 100");
                                    }
                                    if (variableObjects.Exists(x => x.variable == words[2]) == true)
                                    //assigns variable value to draw code parameter value
                                    {
                                        words[2] = Convert.ToString(variableObjects.ElementAt(variableObjects.
                                            FindIndex(x => x.variable.Contains(words[2]))).getValue()); //variable value to radius parameter
                                    }

                                    if (circleObjects.Exists(x => x.getX() == moveX && x.getY() == moveY
                                && x.getRadius() == Convert.ToInt32(words[2])) == true)
                                    //checks if circle with x,y,radius parameter exists or not
                                    {
                                        Console.WriteLine("circle object exists with given parameters");
                                    }

                                    else
                                    {
                                        Circle circle = new Circle();
                                        circle.setX(moveX);
                                        circle.setY(moveY);
                                        circle.setRadius(Convert.ToInt32(words[2]));
                                        circleObjects.Add(circle);
                                        drawCircle = true;
                                    }
                                }
                                //checks if the word is rectangle or not
                                if (words[1].Equals("rectangle"))
                                {
                                    //checks if the given paramater is wrng then draws message
                                    if (!(words.Length == 4))
                                    {
                                        MessageBox.Show("!!!Wrong Command!!!\neg.draw rectangle 100 100 ");
                                    }

                                    else
                                    {
                                        if (variableObjects.Exists(x => x.variable == words[2] == true))
                                        {
                                            words[2] = Convert.ToString(variableObjects.ElementAt(variableObjects.
                                                FindIndex(x => x.variable.Contains(words[2]))).getValue()); //variable value to height parameter
                                        }
                                        if (variableObjects.Exists(x => x.variable == words[3]) == true)
                                        {
                                            words[3] = Convert.ToString(variableObjects.ElementAt(variableObjects.
                                                FindIndex(x => x.variable.Contains(words[3]))).getValue()); //variable value to width parameter
                                        }

                                        if (rectangleObjects.Exists(x => x.getX() == moveX && x.getY() == moveY
                                        && x.getHeight() == Convert.ToInt32(words[2]) && x.getWidth() ==
                                        Convert.ToInt32(words[3])) == true)//checks if rectangle with x,y,height,width parameter exists or not
                                        {
                                            Console.WriteLine("!!rectangle object exists with given parameters!!");
                                        }
                                        else
                                        {
                                            Rectangle rect = new Rectangle();
                                            rect.setX(moveX);
                                            rect.setY(moveY);
                                            rect.setHeight(Convert.ToInt32(words[2]));
                                            rect.setWidth(Convert.ToInt32(words[3]));
                                            rectangleObjects.Add(rect);
                                            drawRectangle = true;
                                        }
                                    }
                                }
                                if (words[1].Equals("polygon"))
                                {
                                    //created poly instace of Polygon class
                                    Polygon poly = new Polygon();
                                    //stores the points in array PointF
                                    PointF[] points = {
                                        new PointF(50.0F, 50.0F),
                                        new PointF(70.0F, 25.0F),
                                        new PointF(100.0F, 5.0F),
                                        new PointF(150.0F, 30.0F),
                                        new PointF(200.0F, 50.0F),
                                        new PointF(250.0F, 100.0F),
                                        new PointF(150.0F, 150.0F)
                                    };
                                    //adds the value of points in the Polygon setter method
                                    poly.setPoints(points);
                                    polygonObjects.Add(poly);
                                    drawPolygon = true;
                                }
                            }

                            //checks if the word holds the value 'if' then   
                            if (words[0] == "if") //code for if statement
                            {
                                //decleared the variable_nanme as string and stored the value of 'word[1]'
                                string variable_name = words[1];
                                //decleared value as an integer and stored the value of word[3]
                                int value = Convert.ToInt32(words[3]);
                                if (variableObjects.Exists(x => x.variable == words[1]) == true
                                    && variableObjects.Exists(x => x.value == Convert.ToInt32(words[3])) == true)
                                //checks if condition defined in if condition matches with variable objects list
                                {
                                    Console.WriteLine("Entered into if statement");
                                }
                                else
                                {//directed to end if line
                                    i = Array.IndexOf(parts, "end if");
                                }

                            }

                            //checks if the word holds the value 'loop' then
                            if (words[0] == "loop") //code for loop statement
                            {
                                loopCounter = Convert.ToInt32(words[1]); //defines loop counter variable
                            }

                            //checks if the word holds the value 'end loop' then
                            if (parts[i] == "end loop") // code for end loop statement
                            {
                                if (counter < loopCounter) //if counter to draw is not less than loop counter
                                {
                                    i = Array.IndexOf(parts, "loop " + loopCounter);
                                }
                                else // keep drawing
                                {
                                    i = Array.IndexOf(parts, "end loop");
                                }
                            }

                        }
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine("Error" + " " + ex);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Enter the correct parameter" + " " + ex);

                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine("Enter the correct parameter" + " " + ex);
                    }
                    //refresh everytime drawing equals to true
                    panel2.Refresh();
                    break;
                case "clear"://if action command is clear
                    circleObjects.Clear();
                    rectangleObjects.Clear();
                    variableObjects.Clear();
                    fill = false;
                    drawTriangle = false;
                    drawCircle = false;
                    drawRectangle = false;
                    drawPolygon = false;
                    textBox1.Clear();
                    richTextBox1.Clear();
                    panel2.Refresh();
                    break;
                default://if acction text area is empty
                    MessageBox.Show("The action command is empty\n" +
                        "Or\n" +
                        "Must be: 'Run' for Execuit the app\n" +
                        "Must be: 'Clear' for Fresh Start");
                    break;
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //inbuilt Graphic library in value g to paint
            Graphics g = e.Graphics;
            if (fill == true)//checks if the condition is true then
            {
                if (drawTriangle == true)// draw condition is true then
                {
                    foreach (Triangle traingleObject in triangleObjects)
                    {
                        traingleObject.fill(g, c); //draw the triangle
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
                if (drawTriangle == true)// draw condition is true then
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