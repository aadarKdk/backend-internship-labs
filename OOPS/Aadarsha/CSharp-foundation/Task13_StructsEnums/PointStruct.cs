using System;
namespace Task13_StructsEnums
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Display()
        {
            Console.WriteLine($"Point: ({X}, {Y})");
        }
        
    }
}
   
