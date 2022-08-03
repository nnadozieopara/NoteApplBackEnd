using System.Text.Json.Serialization;

namespace CCSA_Web
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public SharedEnum Shared { get; set; }
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
public enum SharedEnum
{
    Public,
    Private
}