using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeCalculator
{
    public class Circle : Shape
    {
        public double Radius;

        // Constructor V1
        public Circle()
        {
            Radius = 0;
        }

        // Constructor V2
        public Circle(double radius)
        {
            Radius = radius;
        }
        // Area = pi * radius * radius;
        public override double GetArea()
        {            
           return Math.PI * Radius * Radius;
        }

        // Perimeter = pi * radius * 2;
        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        


    }





}    
