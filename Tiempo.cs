
using System.Text.Json.Serialization;

namespace Juego
{
    public class Tiempo
    {
        [JsonPropertyName("daily")]
        public DatosClima Datos{get;set;}
    }
    public class DatosClima
    {
        [JsonPropertyName("temperature_2m_max")]
        public List<double> TemperaturaMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<double> TemperaturaMin { get; set; }

        [JsonPropertyName("daylight_duration")]
        public List<double> DuracionDia { get; set; }

        [JsonPropertyName("rain_sum")]
        public List<double> Lluvia { get; set; }

        [JsonPropertyName("snowfall_sum")]
        public List<double> Nieve { get; set; }

        [JsonPropertyName("wind_speed_10m_max")]
        public List<double> VientoMax { get; set; }
    }
 

}