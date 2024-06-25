// See https://aka.ms/new-console-template for more information


using Juego;

interfazGrafica interfaz = new interfazGrafica();

interfaz.PresentacionDelJuego();

List<string> nombresPersonajes = new List<string>();
nombresPersonajes = interfaz.IngresoJugadores();

FabricaDePersonajes fabricaPersonajes = new FabricaDePersonajes();
List<Personaje> ListadoDePersonajes = new List<Personaje>();

ListadoDePersonajes = fabricaPersonajes.GeneradorDePersonajes(nombresPersonajes); 

interfaz.MostrarPersonajes(ListadoDePersonajes);

interfaz.MostrarLogoCapitolio();