using System;
using System.IO;

// Logger implements IDisposable, which ensures resources (like the file handle) are properly released
class Logger : IDisposable
{
    // readonly ensures the file path remains constant throughout the object's lifetime.
    private readonly string _filePath;
    private readonly StreamWriter _writer; // StreamWriter to handle file writing
    private bool _disposed = false; // To detect redundant calls to Dispose

    public Logger(string filePath)
    {
        _filePath = filePath;
        
        // Ensure the directory for the log file exists.
        // Path.GetDirectoryName(Path.GetFullPath(filePath)) returns the directory path. 
        // The ?? "." handles the case where the path is just a file name in the current directory.
        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(filePath)) ?? "."); 

        // Initialize StreamWriter: 
        // 1. FileMode.Append: Adds new content to the end of the file.
        // 2. AutoFlush = true: Ensures data is written to the file immediately after each call to WriteLine.
        _writer = new StreamWriter(new FileStream(_filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
        {
            AutoFlush = true
        };
    }

    /// <summary>
    /// Writes a log entry with the current timestamp, level, and message.
    /// </summary>
    /// <param name="level">The log level (e.g., INFO, WARNING).</param>
    /// <param name="message">The content of the log entry.</param>
    public void Log(string level, string message)
    {
        // Formatted log line with timestamp, level, and message 
        string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
        _writer.WriteLine(line);
    }
    
    // --- FIX: Add specific helper methods for convenience ---

    public void Info(string message)
    {
        Log("INFO", message);
    }

    public void Warn(string message)
    {
        Log("WARNING", message);
    }

    public void Error(string message)
    {
        Log("ERROR", message);
    }
    
    // --------------------------------------------------------

    /// <summary>
    /// Disposes the unmanaged resource (StreamWriter) and suppresses finalization.
    /// </summary>
    public void Dispose()
    {
        // Call the private Dispose(bool) method. Passing 'true' indicates that the method 
        // was called from the user code and managed/unmanaged resources should be disposed.
        Dispose(true);
        // Suppress finalization to prevent the garbage collector from calling the finalizer 
        // (which would be redundant since we just cleaned up).
        GC.SuppressFinalize(this);
    }
    
    /// <summary>
    /// The actual resource cleanup logic.
    /// </summary>
    /// <param name="disposing">True if called from user code (Dispose()), false if called from finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Dispose managed state (StreamWriter).
                _writer?.Dispose(); 
            }
            // Note: If there were unmanaged resources, they would be released here.

            _disposed = true; // mark as disposed
        }
    }
}

class Program
{
    static void Main()
    {
        string logFilePath = "logs/app.log";

        // using statement ensures Dispose is called automatically, even if exceptions occur.
        using (var logger = new Logger(logFilePath))
        {
            // FIX: The calls now use the new single-argument helper methods
            logger.Info("Application started.");
            logger.Warn("This is a warning message.");
            logger.Error("An error occurred.");
            logger.Info("Application ended.");
        } // Dispose() is called here automatically by the 'using' statement

        Console.WriteLine($"Logs have been written to {logFilePath}");
        Console.WriteLine("Contents of the log file:");
        
        // Read the file and print contents to the console
        try
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(File.ReadAllText(logFilePath));
            Console.WriteLine("------------------------------------------");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: The log file was not created or found.");
        }
    }
}
