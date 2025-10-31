using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("\n---Nested Try-Catch Example---\n");

        // Array of strings to be accessed and potentially parsed
        string[] samples = { "123", "four", "null", "456" };

        // Prompt user for input
        Console.WriteLine("Enter index to read from samples array (0-3):");
        string input = Console.ReadLine();

        // Outer try block: Handles exceptions related to parsing the user's input index.
        try
        {
            // Attempt to parse the user's string input into an integer index.
            // May throw FormatException (if input is not a number) or OverflowException.
            int x = int.Parse(input);

            // Middle try block: Handles exceptions related to array access.
            try
            {
                // Attempt to access the array element at the parsed index 'x'.
                // May throw IndexOutOfRangeException if 'x' is outside [0, samples.Length - 1].
                string value = samples[x]; 
                Console.WriteLine($"Raw value at index {x}: {value}");

                // Innermost try block: Handles exceptions related to parsing the retrieved string value.
                try
                {
                    // Attempt to parse the retrieved string to an integer.
                    // May throw FormatException (if 'value' is not a number, e.g., "four").
                    // May throw ArgumentNullException (if 'value' is null).
                    int parsedValue = int.Parse(value);
                    Console.WriteLine($"Parsed integer value: {parsedValue}");
                }
                catch (ArgumentNullException ne) // Catch for when 'value' is null
                {
                    Console.WriteLine($"Innermost parse failed: The value at index {x} is null. Error: {ne.Message}");
                }
                catch (FormatException fe) // Catch for when 'value' is a string that can't be parsed (e.g., "four")
                {
                    Console.WriteLine($"Innermost parse failed for '{value}': The value is not a valid integer format. Error: {fe.Message}");
                }
                
            }
            // Middle catch block: Catches exceptions from array access.
            // FIX: Changed 'idx' to the correct variable 'x'.
            catch (IndexOutOfRangeException ie)
            {
                Console.WriteLine($"Index {x} is out of range (0..{samples.Length - 1}). Error: {ie.Message}");
            }
        }
        // Outer catch block: Catches exceptions from parsing the user's input.
        catch (FormatException ex)
        {
            Console.WriteLine("Outer parse failed: Provided index was not a valid integer format.");
        }
        catch (OverflowException oe)
        {
            Console.WriteLine($"Outer parse failed: Provided index was too large or too small for an integer. Error: {oe.Message}");
        }
        // The finally block executes after all try and catch blocks, regardless of whether an exception occurred.
        finally
        {
            Console.WriteLine("\nNestedTryCatch: done.");
        }
    }
}