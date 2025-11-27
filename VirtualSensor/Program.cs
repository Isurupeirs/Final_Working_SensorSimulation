using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Sensors
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            List<Sensor> sensors;

            // Load all sensors from JSON
            try
            {
                sensors = ConfigLoader.LoadSensors("sensorConfig.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load sensor configuration: " + ex.Message);
                return;
            }

            // Create a SensorService for each sensor
            var services = sensors.Select(s => new SensorService(s)).ToList();

            Console.WriteLine("=== Multi-Sensor Simulation Started ===");
            Console.WriteLine($"Loaded {services.Count} sensors.\n");

            // Continuous simulation loop
            while (true)
            {
                foreach (var service in services)
                {
                    Reading reading = service.GenerateReading();
                    bool valid = service.ValidateData(reading);
                    bool anomaly = service.DetectAnomaly(reading);
                    double smoothed = service.SmoothData();

                    // Display results
                    Console.WriteLine(
                        $"{reading.DateTime:HH:mm:ss} | {reading.SensorName} | " +
                        $"{reading.Value}°C | Valid: {valid} | Smooth: {smoothed} | Anomaly: {anomaly}"
                    );

                    // Log
                    Logger.LogData(reading, valid);

                    // Save history
                    service.StoreData(reading);
                }

                Thread.Sleep(1000); // wait 1 second
            }
        }
    }
}
