using System;
using System.IO;

namespace Sensors
{
    public static class Logger        // <-- YES, this is a class
    {
        private static readonly string LogDirectory = "logs";
        private static readonly string LogFilePath = Path.Combine(LogDirectory, "sensor.log");

        static Logger()
        {
            // Ensure log directory exists
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }

        // Assignment-required method
        public static void LogData(Reading reading, bool isValid)
        {
            string status = isValid ? "VALID" : "INVALID";

            string logEntry =
                $"{reading.DateTime:yyyy-MM-dd HH:mm:ss} | {reading.SensorName} | {reading.Value}°C | {status}";

            File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);

            // Optional: confirmation message
            Console.WriteLine($"Logged: {logEntry}");
        }
    }
}
