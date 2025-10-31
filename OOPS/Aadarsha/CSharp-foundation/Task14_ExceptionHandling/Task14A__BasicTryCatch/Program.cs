using System;

class Program
{   
    static void Main()
    {
        Console.WriteLine("\n---Basic Try-Catch Example---\n");

        Console.Write("Enter dividend(integer):");
        string value1 = Console.ReadLine();
        Console.Write("Enter divisor(integer):");
        string value2 = Console.ReadLine();

        try
        {
            // Parse method is used to convert string to integer
            // int.Parse throws FormatException if the input is not a valid integer
            int num1 = int.Parse(value1);
            int num2 = int.Parse(value2);

            // dividing by zero throws DivideByZeroException for integer division
            int result = num1 / num2;

            Console.WriteLine($"Result: {num1} / {num2} = {result}");
        }
        catch (FormatException fex) // FormatException is caught when input is not a valid integer
        {
            Console.WriteLine("Input was not a valid integer. Please enter valid integers only."); ;
            Console.WriteLine($"Error Details: {fex.Message}");
        }
        catch (DivideByZeroException dzex) // DivideByZeroException is caught when divisor is zero
        {
            Console.WriteLine("Cannot divide by zero. Please enter a non-zero integer divisor.");
            Console.WriteLine($"Error Details: {dzex.Message}");
        }
        catch (Exception ex) // General exception catch block to handle any other unexpected exceptions
        {
            Console.WriteLine("An unexpected error occurred.");
            Console.WriteLine($"Error Details: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Execution of the try-catch block is complete.(finally block executed)");
        }
    }
}

