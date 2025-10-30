namespace Task12_Interfaces
{
    class Rectangle : IShape
    {
        public double length { get; set; }
        public double breadth { get; set; }
        public Rectangle(double l, double b)
        {
            length = l;
            breadth = b;
        }
        public double GetArea() => length * breadth;
        public double GetPerimeter() => 2 * (length + breadth);
    }
}