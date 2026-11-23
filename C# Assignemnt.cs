using System;

namespace GeometryCalculator
{
    public static class Calculator
    {
        // 1. Areas

        public static double CircleArea(double radius)
        {
            if (radius < 0) throw new ArgumentException("Radius cannot be negative.");
            return Math.PI * radius * radius;
        }

        public static double TriangleArea(double baseLength, double height)
        {
            if (baseLength < 0 || height < 0) throw new ArgumentException("Base and height cannot be negative.");
            return 0.5 * baseLength * height;
        }

        public static double SquareArea(double side)
        {
            if (side < 0) throw new ArgumentException("Side cannot be negative.");
            return side * side;
        }

        public static double RectangleArea(double length, double width)
        {
            if (length < 0 || width < 0) throw new ArgumentException("Length and width cannot be negative.");
            return length * width;
        }

        // 2. Quadratic formula (Almighty formula): ax^2 + bx + c = 0
        public static string QuadraticFormula(double a, double b, double c)
        {
            if (a == 0)
                return "Not a quadratic equation (a cannot be 0).";

            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return $"Two real roots: x1 = {root1:F4}, x2 = {root2:F4}";
            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);
                return $"One repeated real root: x = {root:F4}";
            }
            else
            {
                double real = -b / (2 * a);
                double imaginary = Math.Sqrt(-discriminant) / (2 * a);
                return $"Two complex roots: x1 = {real:F4} + {Math.Abs(imaginary):F4}i, x2 = {real:F4} - {Math.Abs(imaginary):F4}i";
            }
        }
    }

    class Program
    {
        static double ReadNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                Console.WriteLine("Invalid number, try again.");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== Geometry & Quadratic Calculator ===");
                Console.WriteLine("1. Area of Circle");
                Console.WriteLine("2. Area of Triangle");
                Console.WriteLine("3. Area of Square");
                Console.WriteLine("4. Area of Rectangle");
                Console.WriteLine("5. Quadratic Formula (Almighty Formula)");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            double r = ReadNumber("Radius: ");
                            Console.WriteLine($"Area = {Calculator.CircleArea(r):F2}");
                            break;
                        case "2":
                            double b = ReadNumber("Base: ");
                            double h = ReadNumber("Height: ");
                            Console.WriteLine($"Area = {Calculator.TriangleArea(b, h):F2}");
                            break;
                        case "3":
                            double s = ReadNumber("Side: ");
                            Console.WriteLine($"Area = {Calculator.SquareArea(s):F2}");
                            break;
                        case "4":
                            double l = ReadNumber("Length: ");
                            double w = ReadNumber("Width: ");
                            Console.WriteLine($"Area = {Calculator.RectangleArea(l, w):F2}");
                            break;
                        case "5":
                            double a = ReadNumber("a: ");
                            double bb = ReadNumber("b: ");
                            double c = ReadNumber("c: ");
                            Console.WriteLine(Calculator.QuadraticFormula(a, bb, c));
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
