using System;

namespace Task13_StructsEnums
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }

    public struct Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; } // using the enum to represent order status

        public Order(int id, OrderStatus stat)
        {
            Id = id;
            Status = stat;
        }
        public void Display()
        {
            Console.WriteLine($"Order ID: {Id}, Status: {Status}");
            switch(Status)
            {
                case OrderStatus.Pending:
                    Console.WriteLine("Your order is pending.");
                    break;
                case OrderStatus.Processing:
                    Console.WriteLine("Your order is being processed.");
                    break;
                case OrderStatus.Shipped:
                    Console.WriteLine("Your order has been shipped.");
                    break;
                case OrderStatus.Delivered:
                    Console.WriteLine("Your order has been delivered.");
                    break;
                case OrderStatus.Cancelled:
                    Console.WriteLine("Your order has been cancelled.");
                    break;
                default:
                    Console.WriteLine("Order has been cancelled.");
                    break;
            }
        }
    }
}