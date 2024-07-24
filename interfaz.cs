
using System.Media;


namespace Juego
{
    class interfazGrafica
    {
        public static void CentrarTexto(string texto)
        {
            string[] lineas = texto.Split("\n");
            foreach (var linea in lineas)
            {
                int padding = (Console.BufferWidth - linea.Length)/2;
                Console.SetCursorPosition(padding, Console.CursorTop);
                Console.WriteLine(linea);
            }
        }
        

            public static string [] ObtenerTituloAsciiTxt(string ruta)
            {
                string [] tituloAsciiArt = File.ReadAllLines(ruta);
                return tituloAsciiArt;
            }
    
        public static void MostrarInicioDelJuego()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string[] title = ObtenerTituloAsciiTxt("Data/TituloAscii.txt");
            Animacion.EfectoTemblorTitulo(title);
            Console.Clear();
        }
        

        public static void MostrarPresentacionEInstrucciones()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            CentrarTexto("¡Bienvenidos a la 74ma edición de los Juegos del Hambre!");
            Console.WriteLine("En el corazón de Panem, donde la opulencia del Capitolio contrasta con la lucha diaria de los doce distritos, se celebra cada año un evento que pone a prueba el valor, la astucia y la resistencia de nuestros tributos. Este es un espectáculo sin igual, un recordatorio de la fuerza y el control del Capitolio");
            Console.WriteLine("Esta es tu oportunidad de adentrarte en el mundo de Panem con tus amigos y familiares. Sumerjanse en una competencia virtual en la arena, donde solo uno puede salir victorioso");
            Console.WriteLine("\n");
            Console.WriteLine("Funcionamiento del juego:");
            Console.WriteLine("1.Se pedirá que ingrese la cantidad de personas que van a jugar. Luego deberás ingresar sus nombres para crear los personajes. En caso de existir, se podrán repetir los personajes de la partida anterior.");
            Console.WriteLine("2.Se generaran de manera automática y aleatoria las características de los personajes");
            Console.WriteLine("3.De manera aleatoria los personajes se irán enfrentando en la arena. Cada enfrentamiento tendrá un vencedor mientras que el tributo caído queda fuera de juego.");
            Console.WriteLine("4.El último tributo en sobrevivir será declarado ganador de la 74ma edición de los Juegos del Hambre!");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            CentrarTexto("QUE LA SUERTE ESTE SIEMPRE DE SU LADO");
            Console.ReadKey();
            Console.Clear();
        }

        public static void MostrarPersonajes(List<Personaje> personajes, string mensaje)
        {
            int pos = 0;
            int filas = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(mensaje);
            foreach (var personaje in personajes)
            {
                
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, 2 + filas);
                Console.WriteLine($"-----{personaje.Nombre}-----");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, 3 + filas);
                Console.WriteLine($"Distrito: {personaje.Distrito}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, 4 + filas);
                Console.WriteLine($"Tipo de personaje: {personaje.Tipo}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, 5 + filas);
                Console.WriteLine($"Puntuación previa: {personaje.PuntuacionPrevia}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, 6 + filas);
                Console.WriteLine($"Velocidad: {personaje.Velocidad}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, 7 + filas);
                Console.WriteLine($"Destreza: {personaje.Destreza}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, 8 + filas);
                Console.WriteLine($"Fuerza: {personaje.Fuerza}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, 9 + filas);
                Console.WriteLine($"Armadura: {personaje.Armadura}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, 10 + filas);
                Console.WriteLine($"Salud: {personaje.Salud}");

                
                pos++;
                if (pos == 3)
                {
                    filas += 9;
                    pos = 0;
                }
            }
            Console.ReadKey();
            Console.Clear();
        }  

        public static void DescripcionArena(Tiempo tiempoArena)
        {
            double[] DatosClimaPredeterminado = [-1.2,6.8,21600, 1.4,0.5,40.2];
            if (tiempoArena != null && tiempoArena.Datos != null)
            {
                Console.WriteLine("La arena donde se llevará a cabo esta emocionante y despiadada competencia es volátil e impredecible.");
                Console.WriteLine($"En el dia de hoy la arena presenta las siguientes condiciones: se esperan temperaturas entre {tiempoArena.Datos.TemperaturaMin[0]} ºC y {tiempoArena.Datos.TemperaturaMax[0]} ºC. Además, se esperan {tiempoArena.Datos.Lluvia[0]} mm de lluvia y {tiempoArena.Datos.Nieve[0]} cm de nieve. El viento soplará a una velocidad de {tiempoArena.Datos.VientoMax[0]} km/h.\nLa duración de la luz será de {(int)tiempoArena.Datos.DuracionDia[0]/3600} horas. Luego, deberán enfrentarse con los tributos en la más profunda oscuridad");
            }else
            {
                Console.WriteLine("La arena donde se llevará a cabo esta emocionante y despiadada competencia es volátil e impredecible.");
                Console.WriteLine($"En el dia de hoy la arena presenta las siguientes condiciones: se esperan temperaturas entre {DatosClimaPredeterminado[0]} ºC y {DatosClimaPredeterminado[1]} ºC. Además, se esperan {DatosClimaPredeterminado[3]} mm de lluvia y { DatosClimaPredeterminado[3]} cm de nieve. El viento soplará a una velocidad de { DatosClimaPredeterminado[5]} km/h.\nLa duración de la luz será de {(int)tiempoArena.Datos.DuracionDia[3]/3600} horas. Luego, deberán enfrentarse con los tributos en la más profunda oscuridad");
            }
            Console.ReadKey();
            Console.Clear();
        }
        public static void MostrarTributoCaido(Personaje tributoCaido)
        {
            SoundPlayer sonidoCanion = new SoundPlayer("audio/audioAnuncioCaido.wav");
            sonidoCanion.Play();
            Thread.Sleep(500);
            MostrarLogoCapitolio();
            CentrarTexto($"El capitolio anuncia la caida del tributo {tributoCaido.Nombre}");
            Console.SetCursorPosition(1, 1);
            Console.ReadKey();
            Console.Clear();
        }

        public static void MostrarLogoCapitolio()
        {
            Console.WriteLine(@"
            
                                                               
                                                                        ██      ██                 
                                                                    ██████      ██████                      
                                                                ██████████      ███████████                
                                                              ████████████      ████████████            
                                                            ██████████████      ██████████████       
                                                             █████████████      █████████████         
                                                           ███████████████ ████ ███████████████         
                                                           ███████████████  ███ ███████████████       
                                                           ████████████████████████████████████      
                                                            ██████████████████████████████████       
                                                                        ████  ████                 
                                                                          ██  ██                     
                                                                ████ █    ██████    █ █████        
                                                                   █████████████████████                          
                                                                       ████████████                             
               
 
            ");  
        }

        public static void mostrarGanadores(List<HistorialDeGanadores> ganadores)
        {
           SoundPlayer musicaGanadores = new SoundPlayer("audio/musicaGanadores.wav");
           Console.WriteLine("\n");
           musicaGanadores.PlayLooping();
           Thread.Sleep(1000);
           CentrarTexto("Nuestros queridos tributos campeones de Panem son");
           int contador = 0;
           int pos = 0;
           int filas = 0;
           foreach (var ganador in ganadores)
           {
                contador++;
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1,  4 + filas);
                Console.WriteLine($"Vencedor {contador}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, 5 + filas);
                Console.WriteLine($"Nombre: {ganador.NombreGanador}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, 6 + filas);
                Console.WriteLine($"Cantidad de enfretamientos ganados: {ganador.CantidadDeBatallasGanadas}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, 7 + filas);
                Console.WriteLine($"Mejor ataque: {ganador.MejorAtaque}");
                
                pos++;
                if (pos == 3)
                {
                    filas += 5;
                    pos = 0;
                }
           }
           Console.ReadKey();
           musicaGanadores.Stop();
           Console.Clear();
        }
        public static void AnuncioGanador(Personaje ganador)
        {
            SoundPlayer musicaGanadores = new SoundPlayer("audio/musicaGanadores.wav");
            musicaGanadores.PlayLooping();
            Thread.Sleep(1000);
        
            Animacion.EscribirTextoAnimado($"El ganador de la 74ma Edición de los Juegos del Hambre es: {ganador.Nombre}", true);
            Thread.Sleep(2000);
            musicaGanadores.Stop();
        }
        

    }
    
}