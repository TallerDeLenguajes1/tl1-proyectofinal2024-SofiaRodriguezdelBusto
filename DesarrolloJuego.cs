namespace Juego
{
    public class DesarrolloJuego
    {
        public List<string> IngresoJugadores()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string jugadores;
            int cantidadDeJugadores;
            Console.WriteLine("\nIngrese la cantidad de jugadores: ");
            do
            {
                jugadores = Console.ReadLine();
                if(!int.TryParse(jugadores, out cantidadDeJugadores))
                {
                   Console.WriteLine("\nDebe ingresar un cantidad válida");
                }
            } while (!int.TryParse(jugadores, out cantidadDeJugadores));

            List<string> ListadoDeNombres =  new List<string>();

            for (int i = 0; i < cantidadDeJugadores; i++)
            {
                Console.WriteLine($"\nIngrese el nombre del jugador {i+1}: ");
                string nombre = Console.ReadLine();
                ListadoDeNombres.Add(nombre);
            }
            Console.SetCursorPosition(1, 1);
            Console.ReadKey();
            Console.Clear();
            return ListadoDeNombres;   
        }
        public List<Personaje> CrearPersonajes(string nombreArchivo)
        {
            PersonajesJson archivoPersonajes = new PersonajesJson();
            List<string> nombresPersonajes = IngresoJugadores();
            FabricaDePersonajes fabricaPersonajes = new FabricaDePersonajes();
            List<Personaje> ListadoDePersonajes = fabricaPersonajes.GeneradorDePersonajes(nombresPersonajes); 
            archivoPersonajes.GuardarPersonajes(ListadoDePersonajes, nombreArchivo);
            
            return ListadoDePersonajes;

        }
        public List<Personaje> ObtenerPersonajes()
        {
            string nombreArchivo = "Personajes.json";
            PersonajesJson archivoPersonajes = new PersonajesJson();
            List<Personaje> ListadoDePersonajes;

            if (!archivoPersonajes.Existe(nombreArchivo))
            {
                ListadoDePersonajes = CrearPersonajes(nombreArchivo);

            }else
            {
        
                Console.WriteLine("Los personajes cargados previamente son: ");
                interfazGrafica.MostrarPersonajes(archivoPersonajes.LeerPersonajes(nombreArchivo));
                string textoMenu = "¿Desea repetir los personajes de la partida anterior?";
                string[] opcionesMenu = ["Si", "No"];
                Menu menuSeleccionPersonajes = new Menu(textoMenu, opcionesMenu);
                
                int eleccionMenu = menuSeleccionPersonajes.MenuDisplay();
                if(eleccionMenu == 0)
                {
                    ListadoDePersonajes = archivoPersonajes.LeerPersonajes(nombreArchivo);
                }else
                {
                    ListadoDePersonajes = CrearPersonajes(nombreArchivo);
                }
            }
            return ListadoDePersonajes;
        }
        
        
        public Personaje DesarrolloDeLasBatallas(List<Personaje> ListadoDePersonajes)
        {
            
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
                interfazGrafica.MostrarTributoCaido(tributoCaido);
                
            }
            return ListadoDePersonajes[0];
        }

        public void AgregarGanadorAlHistorialDeGanadores(Personaje ganador)
        {
            string nombreArchivo2 = "HistorialDeGanadores.json";
            HistorialJson archivoGanadores = new HistorialJson();
            archivoGanadores.GuardarGanador(ganador, nombreArchivo2);
        }

    }
    
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
                    Console.WriteLine("Los personajes que se enfretarán en esta edición de los Juegos del Hambre son: ");
                    interfazGrafica.MostrarPersonajes(ListadoDePersonajes);
                    var tiempoApi = Api.CrearCondicionesClimaticasConApi(); 
                    //interfazGrafica.DescripcionArena(tiempoApi);
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
                        interfazGrafica.CentrarTexto("Nuestros queridos tributos campeones de Panem son");
                        interfazGrafica.mostrarGanadores(archivoGanadores.LeerGanadores(nombreArchivo2));
                    }else
                    {
                        Console.WriteLine("No se han encontrado ganadores históricos del juego");
                    }
                    Console.ReadKey();
                    EjecutarJuego();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Los esperamos pronto en el universo de Panem!");
                    Thread.Sleep(2000);
                    Console.Clear(); 
                    break;
            }


        }
    }
    
}