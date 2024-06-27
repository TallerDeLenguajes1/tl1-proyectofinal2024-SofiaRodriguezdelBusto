
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

List<HistorialDeBatallas> HistorialJuego = new List<HistorialDeBatallas>();
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
    HistorialDeBatallas nuevaBatalla = batalla.GeneradorDeBatalla(ListadoDePersonajes[indicePersonaje1],ListadoDePersonajes[indicePersonaje2]);
    interfaz.MostrarResultadoDeBatalla(nuevaBatalla);
    ListadoDePersonajes.Remove(nuevaBatalla.Perdedor);
    HistorialJuego.Append(nuevaBatalla);
}

interfaz.AnuncioGanador(ListadoDePersonajes[0]);
