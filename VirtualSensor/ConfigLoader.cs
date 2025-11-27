using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Sensors
{
    public static class ConfigLoader
    {
        public static List<Sensor> LoadSensors(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Configuration file not found.");

            string json = File.ReadAllText(filePath);

            // Basic sanitisation
            if (json.Contains("<script>") || json.Contains("DROP TABLE") || json.Contains("<?php"))
                throw new Exception("Unsafe content detected in configuration file.");

            List<Sensor> sensors;

            try
            {
                sensors = JsonSerializer.Deserialize<List<Sensor>>(json)
                          ?? throw new Exception("Invalid JSON (deserialized null).");
            }
            catch
            {
                throw new Exception("Invalid JSON format for sensors file.");
            }

            // Validate each sensor
            foreach (var s in sensors)
            {
                if (string.IsNullOrWhiteSpace(s.Name))
                    throw new Exception("Sensor missing name.");

                if (s.MinValue >= s.MaxValue)
                    throw new Exception($"Invalid range for {s.Name}.");
            }

            return sensors;
        }
    }
}
