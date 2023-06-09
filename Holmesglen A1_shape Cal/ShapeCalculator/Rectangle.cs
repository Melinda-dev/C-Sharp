using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ShapeCalculator
{
    // Rectangle class derive from Shape
    public class Rectangle : Shape
    {
        // A rectangle is defined by a lenght and a height value
        public double Length;
        public double Height;
        
        //constructor V1
        public Rectangle()
        {
            Length = 0;
            Height = 0;
        }
        //constructor V2
        public Rectangle(double length, double height)
        {
            Length = length;
            Height = height;
        }

        // Area = length * height
        public override double GetArea()
        {
            return Length * Height;
        }

        // Area = 2 * (length + height)
        public override double GetPerimeter()
        {
            return 2*(Length + Height);
        }
    }
}
