using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeCalculator
{
    public class Trapezoid : Shape
    {
        // A Trapezoid is defiened by base_top, base_bottom, side_left, side_right, height value
        public double Base_top;
        public double Base_bottom;
        public double Side_left;
        public double Side_right;
        public double Height;

        // Constructor V1
        public Trapezoid()
        {
            Base_top = 0;
            Base_bottom = 0;
            Side_left = 0;
            Side_right = 0;
            Height = 0;
        }
        // Constructor V2
        public Trapezoid(double base_top, double base_bottom, double side_left, double side_right, double height)
        {
            Base_top = base_top;
            Base_bottom = base_bottom;
            Side_left = side_left;
            Side_right = side_right;
            Height = height;

        }

        // Area = ( Base_top + Base_bottom ) * Height /2
        public override double GetArea()
        {
            return (Base_top + Base_bottom) * Height / 2;
        }

        // Perimeter =  Base_top + Base_bottom + Side_left + Height;
        public override double GetPerimeter()
        {
            return Base_top + Base_bottom + Side_left + Height;
        }
    }
}
