using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "example.txt";

        // Write text to the file
        File.WriteAllText(filePath, "Let's learn C# file handling!");

        // read text from the file
        string content = File.ReadAllText(filePath);
        Console.WriteLine("File Content: " + content);

        // Append text to the file
        if (File.Exists(filePath))
        {
            File.AppendAllText(filePath, "\nAppending some more text at " + DateTime.Now);
            Console.WriteLine("File updated successfully.");
        }
        else
        {
            Console.WriteLine("File not found!.");
        }
        string updated = File.ReadAllText(filePath);
        Console.WriteLine("Updated file content: " + updated);  
    }
}