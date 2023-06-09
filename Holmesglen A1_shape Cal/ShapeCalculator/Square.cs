using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeCalculator
{
    public class Square : Shape
    {
        // a square is defined by a length value
        public double Length;

        // Constructor v1
        public Square()
        {
            Length = 0; 
        }

        // Constructor V2
        public Square(double length)
        {
            Length = length;
        }

        // Area = length * length
    
        public override double GetArea()
        {
            return Length * Length;
        }

        // Perimeter = 4 * length
        public override double GetPerimeter()
        {
            return 4 * Length;
        }
    }
}

