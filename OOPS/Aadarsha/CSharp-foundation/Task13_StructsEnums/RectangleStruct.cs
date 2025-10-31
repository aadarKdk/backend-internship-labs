using System;
using System.Reflection.Metadata.Ecma335;

namespace Task13_StructsEnums
{
    public struct Rectangle
    {
        public double Length { get; set; }
        public double Breadth { get; set; }
        public Rectangle(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }
        public double GetArea() => Length * Breadth;
        public void Display() => Console.WriteLine($"Rectangle = {Length} x {Breadth}, Area = {GetArea()}");

    }
}