using System;
using System.Collections.Concurrent;
using System.Drawing;
namespace Task13_StructsEnums
{
    class Prgoram
    {
        static void Main()
        {

            Console.WriteLine("\nPoint Struct Example:");
            Point point = new Point(10, 20);
            point.Display();

            Console.WriteLine("\nEmployee Struct Example:");
            Employee e1 = new Employee(1, "Shivam");
            e1.Display();

            Console.WriteLine("\nRectangle Struct Example:");
            Rectangle r1 = new Rectangle(5, 10);
            Rectangle r2 = new Rectangle(11, 12);
            r1.Display();
            r2.Display();

            Console.WriteLine("\nOrderStatus enum & Order Struct Example:");
            Order order1 = new Order(101, OrderStatus.Pending);
            order1.Display();

            Console.WriteLine("\nGenre enum & Book Struct Example:");
            Book b1 = new Book("The Alchemist", "Paulo Coelho", Genre.Fiction);
            Book b2 = new Book("A Brief History of Time", "Stephen Hawking", Genre.NonFiction);
            Book b3 = new Book("Pride and Prejudice", "Jane Austen", Genre.Romance);
            b1.Display();
            b2.Display();
            b3.Display();

        }
    }
}