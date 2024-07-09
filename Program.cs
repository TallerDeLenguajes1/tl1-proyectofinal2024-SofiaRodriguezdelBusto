
using System.Text.Json;
using Juego;

interfazGrafica interfaz = new interfazGrafica();


interfaz.PresentacionDelJuego();

string nombreArchivo = "Personajes.json";
PersonajesJson archivoPersonajes = new PersonajesJson();

List<Personaje> ListadoDePersonajes;
string control;
int controla;
if (!archivoPersonajes.Existe(nombreArchivo))
{
    List<string> nombresPersonajes = interfaz.IngresoJugadores();
    FabricaDePersonajes fabricaPersonajes = new FabricaDePersonajes();
    ListadoDePersonajes = fabricaPersonajes.GeneradorDePersonajes(nombresPersonajes); 
    archivoPersonajes.GuardarPersonajes(ListadoDePersonajes, nombreArchivo);

}else
{
    do
    {
        Console.WriteLine("¿Desea repetir los personajes de la partida anterior? Ingrese 1 si asi lo desea. Caso contrario, ingrese 0");
        control = Console.ReadLine();
        
    } while ((!int.TryParse(control, out controla) )||( controla != 0 && controla != 1));
    if(controla == 1)
    {
        ListadoDePersonajes = archivoPersonajes.LeerPersonajes(nombreArchivo);
    }else
    {
        archivoPersonajes.EliminarArchivo(nombreArchivo);
        List<string> nombresPersonajes = interfaz.IngresoJugadores();
        FabricaDePersonajes fabricaPersonajes = new FabricaDePersonajes();
        ListadoDePersonajes = fabricaPersonajes.GeneradorDePersonajes(nombresPersonajes);
        archivoPersonajes.GuardarPersonajes(ListadoDePersonajes, nombreArchivo); 
    }
}



interfaz.MostrarPersonajes(ListadoDePersonajes);

var tiempoApi = await GetWeatherAsync();

interfaz.DescripcionArena(tiempoApi);

while (ListadoDePersonajes.Count >1)
{
    var semilla = Environment.TickCount;
    var random = new Random(semilla); 
    int indicePersonaje1 = random.Next(0, ListadoDePersonajes.Count);
    int indicePersonaje2;
    do
    {
        indicePersonaje2 = random.Next(0, ListadoDePersonajes.Count);
    } while (indicePersonaje1 == indicePersonaje2);

    Batalla batalla = new Batalla();
    Personaje tributoCaido = batalla.GeneradorDeBatalla(ListadoDePersonajes[indicePersonaje1],ListadoDePersonajes[indicePersonaje2]);
    ListadoDePersonajes.Remove(tributoCaido);
    
}

interfaz.AnuncioGanador(ListadoDePersonajes[0]);



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