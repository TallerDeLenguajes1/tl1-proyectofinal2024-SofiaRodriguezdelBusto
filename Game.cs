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
                    FuncionesDelJuego FuncionesDelJuego = new FuncionesDelJuego();
                    List<Personaje> ListadoDePersonajes = FuncionesDelJuego.ObtenerListadoDePersonajes();
                    InterfazGrafica.MostrarPersonajes(ListadoDePersonajes, "Los personajes que se enfretarán en esta edición de los Juegos del Hambre son: ");
                    var tiempoApi = Api.CrearCondicionesClimaticasConApi(); 
                    InterfazGrafica.DescripcionArena(tiempoApi);
                    Personaje ganador = FuncionesDelJuego.DesarrolloDeLasBatallas(ListadoDePersonajes);
                    FuncionesDelJuego.AgregarGanadorAlHistorialDeGanadores(ganador);
                    InterfazGrafica.AnuncioGanador(ganador);
                    EjecutarJuego();
                    break;
                case 1:
                    Console.Clear();
                    string nombreArchivoHistorial = "HistorialDeGanadores.json";
                    HistorialJson archivoGanadores = new HistorialJson();
                    if(archivoGanadores.Existe(nombreArchivoHistorial))
                    {
                        InterfazGrafica.MostrarGanadores(archivoGanadores.LeerGanadores(nombreArchivoHistorial));
                    }else
                    {
                        InterfazGrafica.CentrarTexto("No se han encontrado ganadores históricos del juego");
                        Thread.Sleep(2000);
                    }
                    EjecutarJuego();
                    break;
                case 2:
                    Console.Clear();
                    Animacion.EscribirTextoAnimado("¡Los esperamos pronto en el universo de Panem!", true);
                    Thread.Sleep(2000);
                    Console.Clear(); 
                    break;
            }


        }
    }
    
}