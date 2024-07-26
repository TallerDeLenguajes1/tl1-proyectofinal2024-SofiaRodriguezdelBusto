namespace Juego
{
    public class Game
    {
        public static void EjecutarJuego()
        {
            string TextoMenuPrincipal = "Elija la acción que desea ejecutar:"; 
            string[] opcionesMenuPrincipal = ["Iniciar Juego", "Ver Historial de Ganadores", "Finalizar"];
            Menu menuPrincipal = new Menu(TextoMenuPrincipal, opcionesMenuPrincipal);
            int seleccion = menuPrincipal.MenuDisplay();
            switch (seleccion)
            {
                case 0:
                    Console.Clear();
                    DesarrolloJuego desarrolloJuego = new DesarrolloJuego();
                    List<Personaje> ListadoDePersonajes = desarrolloJuego.ObtenerPersonajes();
                    interfazGrafica.MostrarPersonajes(ListadoDePersonajes, "Los personajes que se enfretarán en esta edición de los Juegos del Hambre son: ");
                    var tiempoApi = Api.CrearCondicionesClimaticasConApi(); 
                    interfazGrafica.DescripcionArena(tiempoApi);
                    Personaje ganador = desarrolloJuego.DesarrolloDeLasBatallas(ListadoDePersonajes);
                    desarrolloJuego.AgregarGanadorAlHistorialDeGanadores(ganador);
                    interfazGrafica.AnuncioGanador(ganador);
                    EjecutarJuego();
                    break;
                case 1:
                    Console.Clear();
                    string nombreArchivo2 = "HistorialDeGanadores.json";
                    HistorialJson archivoGanadores = new HistorialJson();
                    if(archivoGanadores.Existe(nombreArchivo2))
                    {
                        interfazGrafica.mostrarGanadores(archivoGanadores.LeerGanadores(nombreArchivo2));
                    }else
                    {
                        Console.WriteLine("No se han encontrado ganadores históricos del juego");
                    }
                    EjecutarJuego();
                    break;
                case 2:
                    Console.Clear();
                    Animacion.EscribirTextoAnimado("Los esperamos pronto en el universo de Panem!", true);
                    Thread.Sleep(2000);
                    Console.Clear(); 
                    break;
            }


        }
    }
    
}