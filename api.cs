using System.Text.Json;

namespace Juego
{
    public class Api
    {
        static async Task<Tiempo> GetWeatherAsync()
        {
            var url = "https://api.open-meteo.com/v1/forecast?latitude=-54&longitude=-70&daily=temperature_2m_max,temperature_2m_min,daylight_duration,rain_sum,snowfall_sum,wind_speed_10m_max&forecast_days=1";
            try
            {
                HttpClient Client = new HttpClient();
                HttpResponseMessage response = await Client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Tiempo tiempoArena = JsonSerializer.Deserialize<Tiempo>(responseBody);
                return tiempoArena;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Problemas con el acceso a la API");
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }

        }

        double[] DatosClimaPredeterminado = [-1.2,6.8,21600, 1.4,0.5,40.2];
        public static async Tiempo CrearCondicionesClimaticasConApi()
        {
        
            var tiempoApi = await GetWeatherAsync();
            Tiempo tiempoArena;
            if(tiempoApi != null)
            {
                tiempoArena = tiempoApi;
            }else
            {
                tiempoArena = new Tiempo(DatosClimaPredeterminado);
            }
            return tiempoArena;
        }

        
    }
    
}