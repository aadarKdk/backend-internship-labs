using System;

namespace Task12_Interfaces
{
    class Circle : IDrawable, IResizable, IShape
    {
        public double radius { get; set; }
        public Circle(double r)
        {
            radius = r;
        }
        public void Draw() => Console.WriteLine($"Drawing a circle with radius: {radius}");
        public void Resize(double factor) => radius *= factor;
        public double GetArea() => Math.PI * radius * radius;
        public double GetPerimeter() => 2 * Math.PI * radius;
    }

}