﻿
using System.Text.Json;
using Juego;


interfazGrafica interfaz = new interfazGrafica();


interfaz.MostrarInicioDelJuego();
interfaz.MostrarPresentacionEInstrucciones();

string nombreArchivo = "Personajes.json";
PersonajesJson archivoPersonajes = new PersonajesJson();

List<Personaje> ListadoDePersonajes;

if (!archivoPersonajes.Existe(nombreArchivo))
{
    List<string> nombresPersonajes = interfaz.IngresoJugadores();
    FabricaDePersonajes fabricaPersonajes = new FabricaDePersonajes();
    ListadoDePersonajes = fabricaPersonajes.GeneradorDePersonajes(nombresPersonajes); 
    archivoPersonajes.GuardarPersonajes(ListadoDePersonajes, nombreArchivo);

}else
{
    Console.WriteLine("Los personajes cargados previamente son: ");
    interfaz.MostrarPersonajes(archivoPersonajes.LeerPersonajes(nombreArchivo));
    string textoMenu = "¿Desea repetir los personajes de la partida anterior?";
    string[] opcionesMenu = ["Si", "No"];
    Menu menuSeleccionPersonajes = new Menu(textoMenu, opcionesMenu);
    
    int eleccionMenu = menuSeleccionPersonajes.MenuDisplay();
    if(eleccionMenu == 0)
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
    interfaz.MostrarTributoCaido(tributoCaido);
    
}
string nombreArchivo2 = "HistorialDeGanadores.json";
HistorialJson archivoGanadores = new HistorialJson();
archivoGanadores.GuardarGanador(ListadoDePersonajes[0], nombreArchivo2);

interfaz.AnuncioGanador(ListadoDePersonajes[0]);
if(archivoGanadores.Existe(nombreArchivo2))
{
    Console.WriteLine("El vencedor se une nuestro selecto grupo de vencedores");
    interfaz.mostrarGanadores(archivoGanadores.LeerGanadores(nombreArchivo2));
}



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
