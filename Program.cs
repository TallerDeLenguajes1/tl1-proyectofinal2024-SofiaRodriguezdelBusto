// See https://aka.ms/new-console-template for more information


using Juego;

interfazGrafica interfaz = new interfazGrafica();

interfaz.PresentacionDelJuego();

List<string> nombresPersonajes = interfaz.IngresoJugadores();

FabricaDePersonajes fabricaPersonajes = new FabricaDePersonajes();
List<Personaje> ListadoDePersonajes = fabricaPersonajes.GeneradorDePersonajes(nombresPersonajes); 

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
