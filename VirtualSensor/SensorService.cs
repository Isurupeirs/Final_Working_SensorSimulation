using System;
using System.Collections.Generic;
using System.Linq;

namespace Sensors
{
    public class SensorService
    {
        private readonly Sensor _sensor;
        private readonly Random _random = new();
        private readonly List<Reading> _history = new();

        public SensorService(Sensor sensor)
        {
            _sensor = sensor;
        }

        // Simulate a reading with small noise
        public double SimulateData()
        {
            double value = _random.NextDouble() * (_sensor.MaxValue - _sensor.MinValue) + _sensor.MinValue;
            value += (_random.NextDouble() * 0.6) - 0.3;
            return Math.Round(value, 2);
        }

        public Reading GenerateReading()
        {
            return new Reading
            {
                SensorName = _sensor.Name,
                DateTime = DateTime.Now,
                Value = SimulateData()
            };
        }

        public bool ValidateData(Reading reading)
        {
            return reading.Value >= _sensor.MinValue && reading.Value <= _sensor.MaxValue;
        }

        public void StoreData(Reading reading)
        {
            _history.Add(reading);
            if (_history.Count > 100)
                _history.RemoveAt(0);
        }

        public List<Reading> GetHistory() => _history;

        // Moving average smoothing
        public double SmoothData(int windowSize = 5)
        {
            if (_history.Count == 0)
                return 0;

            int count = Math.Min(windowSize, _history.Count);
            double avg = _history
                .Skip(_history.Count - count)
                .Take(count)
                .Average(r => r.Value);

            return Math.Round(avg, 2);
        }

        // Assignment-correct anomaly detection
        public bool DetectAnomaly(Reading reading, double threshold = 3.0)
        {
            if (_history.Count < 3)
                return false;

            double avg = SmoothData();
            double difference = Math.Abs(reading.Value - avg);

            return difference >= threshold;
        }

        public void ShutdownSensor()
        {
            _history.Clear();
            Console.WriteLine("Sensor has been shut down. History cleared.");
        }
    }
}
