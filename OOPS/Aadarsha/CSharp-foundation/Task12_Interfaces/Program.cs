/* 
    Interfaces in C#: Contract and Polymorphism

    Interfaces in C# are contracts that define a set of methods and properties
    that a class must implement. They provide a way to achieve abstraction and polymorphism.

    ## Key Concepts:
    
    1.  Contract Enforcement: 
        An interface defines a mandatory "contract" or blueprint. Any class or struct that implements the interface is **guaranteed** to provide an implementation for *all* members (methods, properties, indexers, and events) declared in the interface.
    
    2.  Abstraction:
        Interfaces hide the implementation details. When you use an interface reference, you only care about the **behavior** (the methods defined in the contract), not *how* that behavior is achieved by the underlying class.

    3.  Multiple Inheritance (of Contracts):
        C# classes can inherit from only one base class, but they can implement **multiple interfaces**. This allows a class to fulfill many different contracts simultaneously, making C# highly flexible.

    4.  Runtime Polymorphism: 
        Interfaces enable **Runtime Polymorphism** because an interface variable can hold a reference to any object whose class implements that interface. The method call (`interfaceVariable.Method()`) is resolved at runtime based on the actual object type, allowing different classes to respond differently to the same method call (e.g., IAnimal can reference a Dog or a Cat, and both respond to the Speak() method differently).

    5.  No Implementation: 
        Traditionally (before C# 8.0), interfaces could not contain any implementation code, fields, or constructors. They were purely declaration. (Note: C# 8.0 introduced *Default Interface Methods*, which allow an interface to provide a default body for a method, but this is an advanced topic.)

    6.  Accessibility:
        Interface members are implicitly **public** and cannot have explicit access modifiers (like `public`, `private`, etc.) because the whole point is to expose a contract for public use.
*/

using System;
using System.Drawing;
namespace Task12_Interfaces
{
    class Program
    {
        static void Main()
        {
            IShape rect = new Rectangle(2, 3);
            Console.WriteLine("Rectangle:");
            Console.WriteLine($"Area: {rect.GetArea()}");
            Console.WriteLine($"Perimeter: {rect.GetPerimeter()}");
            Console.WriteLine();

            Circle circle = new Circle(5);
            Console.WriteLine("Circle:");
            Console.WriteLine($"Area: {circle.GetArea()}");
            circle.Draw();
            circle.Resize(1.5);
            Console.WriteLine("New radius after resizing: " + circle.radius);
            Console.WriteLine($"New Circle Area: {circle.GetArea()}");
            Console.WriteLine($"New Circle Perimeter: {circle.GetPerimeter()}");
        }
    }
}