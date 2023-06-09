using System;

namespace ShapeCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape shape = null;
            Console.WriteLine("Select a shape");
            Console.WriteLine("1. Rectangle");
            Console.WriteLine("2. Circle");
            string type = Console.ReadLine();
            switch(type)
            {
                case "1":
                    Console.WriteLine("Set the rectangle length");
                    double l = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Set the rectangle height");
                    double h = Double.Parse(Console.ReadLine());
                    shape = new Rectangle(l,h);
                    break;

                 case "2":
                    Console.WriteLine("Set the radius of the circle");
                    double r = Double.Parse(Console.ReadLine());
                    shape = new Circle(r);
                    break;

                 default:
                    Console.WriteLine("Wrong selection.");
                    return;
            }
            Console.WriteLine("Solve for");
            Console.WriteLine("1. Area");
            Console.WriteLine("2. Perimeter");
            string operation = Console.ReadLine();

            switch(operation)
            {
                case "1":
                    Console.WriteLine("Area is: " + shape.GetArea());
                    break;
                case "2":
                    Console.WriteLine("Perimeter is: " + shape.GetPerimeter());
                    break;
                default :
                    Console.WriteLine("Wrong selection.");
                    return;
            }


            

            /*  // test Rectangle class
            Rectangle r1 = new Rectangle(4, 5);
            Console.WriteLine($"r1 area: {r1.GetArea()}");
            Console.WriteLine($"r1 perimeter: {r1.GetPerimeter()}");

            // test Circle class
            Circle c1 = new Circle(5);
            Console.WriteLine($"c1 area: {c1.GetArea()}");
            Console.WriteLine($"c1 perimeter: {c1.GetPerimeter()}");

            // test Square class
            Square l1 = new Square(5);
            Console.WriteLine($"l1 area: {l1.GetArea()}");
            Console.WriteLine($"l1 perimeter: {l1.GetPerimeter()}");

            // test trapezoid class
            Trapezoid t1 = new Trapezoid(4,12,5,5,3);
            Console.WriteLine($"t1 area: {t1.GetArea()}");
            Console.WriteLine($"t1 perimeter: {t1.GetPerimeter()}"); */

            

        }
    }
}
