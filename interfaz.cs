using System.Media;

namespace Juego
{
    class interfazGrafica
    {
        public static void CentrarTexto(string texto)
        {

            int padding = (Console.WindowWidth - texto.Length)/2;
            Console.SetCursorPosition(padding, Console.CursorTop);
            Console.WriteLine(texto);
        }
        

        public static void EscribirTextoAnimado(string texto, bool centrado)
        {
            if (centrado)
            {
                Console.SetCursorPosition((Console.BufferWidth - texto.Length) / 2, Console.BufferHeight / 4);
            }
            foreach (char c in texto)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }

        }
        public static void MostrarInicioDelJuego()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
            | |     ___   ___     (_)  _  _   ___   __ _   ___   ___    __| |  ___  | |   | |_    __ _   _ __   | |__   _ _   ___ 
            | |__  / _ \ (_-<     | | | || | / -_) / _` | / _ \ (_-<   / _` | / -_) | |   | ' \  / _` | | '  \  | '_ \ | '_| / -_)
            |____| \___/ /__/    _/ |  \_,_| \___| \__, | \___/ /__/   \__,_| \___| |_|   |_||_| \__,_| |_|_|_| |_.__/ |_|   \___|
                                |__/               |___/                                                                          
            ");
            Console.WriteLine("\n");
            CentrarTexto("Ingrese una tecla para iniciar");
            Console.ReadKey();
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
            Console.WriteLine("1.Se pedirá que ingrese la cantidad de personas que van a jugar. Luego deberás ingresar sus nombres para crear los personajes.");
            Console.WriteLine("2.Se generaran de manera automática y aleatoria las características de los personajes");
            Console.WriteLine("3.De manera aleatoria los personajes se irán enfrentando en la arena. Cada enfrentamiento tendrá un vencedor mientras que el tributo caído queda fuera de juego.");
            Console.WriteLine("4.El último tributo en sobrevivir será declarado ganador de la 74ma edición de los Juegos del Hambre!");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            CentrarTexto("QUE LA SUERTE ESTE SIEMPRE DE SU LADO");
            Console.ReadKey();
            Console.Clear();
        }

        public static void MostrarPersonajes(List<Personaje> personajes)
        {
            int pos = 0;
            int filas = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Los tributos de las 74ma edición de los Juegos del Hambre son:");
            foreach (var personaje in personajes)
            {
                
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, Console.BufferHeight / 4 - 2 + filas);
                Console.WriteLine($"-----{personaje.Nombre}-----");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, Console.BufferHeight / 4 - 1 + filas);
                Console.WriteLine($"Distrito: {personaje.Distrito}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, Console.BufferHeight / 4 + filas);
                Console.WriteLine($"Tipo de personaje: {personaje.Tipo}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, Console.BufferHeight / 4 + 1 + filas);
                Console.WriteLine($"Puntuación previa: {personaje.PuntuacionPrevia}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, Console.BufferHeight / 4 + 2 + filas);
                Console.WriteLine($"Velocidad: {personaje.Velocidad}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, Console.BufferHeight / 4 + 3 + filas);
                Console.WriteLine($"Destreza: {personaje.Destreza}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, Console.BufferHeight / 4 + 4 + filas);
                Console.WriteLine($"Fuerza: {personaje.Fuerza}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, Console.BufferHeight / 4 + 5 + filas);
                Console.WriteLine($"Armadura: {personaje.Armadura}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, Console.BufferHeight / 4 + 6 + filas);
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
            if (tiempoArena != null && tiempoArena.Datos != null)
            {
                Console.WriteLine("La arena donde se llevará a cabo esta emocionante y despiadada competencia es volátil e impredecible.");
                Console.WriteLine($"En el dia de hoy la arena presenta las siguientes condiciones: se esperan temperaturas entre {tiempoArena.Datos.TemperaturaMin[0]} ºC y {tiempoArena.Datos.TemperaturaMax[0]} ºC. Además, se esperan {tiempoArena.Datos.Lluvia[0]} mm de lluvia y {tiempoArena.Datos.Nieve[0]} cm de nieve. El viento soplará a una velocidad de {tiempoArena.Datos.VientoMax[0]} km/h.\nLa duración de la luz será de {(int)tiempoArena.Datos.DuracionDia[0]/3600} horas. Luego, deberán enfrentarse con los tributos en la más profunda oscuridad");
            }
            Console.ReadKey();
            Console.Clear();
        }
        public static void MostrarTributoCaido(Personaje tributoCaido)
        {
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
                                                               ██████████████████████                           
                                                                    ████████████                             
               

            ");
        }

        public static void mostrarGanadores(List<HistorialDeGanadores> ganadores)
        {
           Console.WriteLine("\n");
           int contador = 0;
           int pos = 0;
           int filas = 0;
           foreach (var ganador in ganadores)
           {
                contador++;
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, Console.BufferHeight / 4 - 2 + filas);
                Console.WriteLine($"Vencedor {contador}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, Console.BufferHeight / 4 - 1 + filas);
                Console.WriteLine($"Nombre: {ganador.NombreGanador}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, Console.BufferHeight / 4 + filas);
                Console.WriteLine($"Cantidad de enfretamientos ganados: {ganador.CantidadDeBatallasGanadas}");
                Console.SetCursorPosition(pos * Console.BufferWidth / 3 + 1, Console.BufferHeight / 4 + 1 + filas);
                Console.WriteLine($"Mejor ataque: {ganador.MejorAtaque}");
                
                pos++;
                if (pos == 3)
                {
                    filas += 9;
                    pos = 0;
                }
           }
        }
        public static void AnuncioGanador(Personaje ganador)
        {
            EscribirTextoAnimado($"El ganador de la 74ma Edición de los Juegos del Hambre es {ganador.Nombre}", true);
            Thread.Sleep(2000);
        }

    }

    
}