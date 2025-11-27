namespace Sensors
{
    public class Reading
    {
        public int ReadingId { get; set; }
        public string SensorName { get; set; } = string.Empty;
        public double Value { get; set; }
        public DateTime DateTime { get; set; }
    }
}