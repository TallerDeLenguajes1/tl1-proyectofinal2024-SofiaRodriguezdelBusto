// See https://aka.ms/new-console-template for more information


using Personajes;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine(@"
 | |     ___   ___     (_)  _  _   ___   __ _   ___   ___    __| |  ___  | |   | |_    __ _   _ __   | |__   _ _   ___ 
 | |__  / _ \ (_-<     | | | || | / -_) / _` | / _ \ (_-<   / _` | / -_) | |   | ' \  / _` | | '  \  | '_ \ | '_| / -_)
 |____| \___/ /__/    _/ |  \_,_| \___| \__, | \___/ /__/   \__,_| \___| |_|   |_||_| \__,_| |_|_|_| |_.__/ |_|   \___|
                     |__/               |___/                                                                          
");
Console.WriteLine("\n");
Console.SetCursorPosition(Console.BufferWidth/3, Console.BufferHeight/2);
Console.WriteLine("Ingrese una tecla para iniciar");
Console.ReadKey();
Console.Clear();


Console.ForegroundColor = ConsoleColor.White;
Console.SetCursorPosition(Console.BufferWidth/3, 1);
Console.WriteLine("¡Bienvenidos a la 74ma edición de los Juegos del Hambre!");
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
Console.SetCursorPosition(Console.BufferWidth/3, 15);
Console.WriteLine("QUE LA SUERTE ESTE SIEMPRE DE SU LADO");
Console.SetCursorPosition(1, 1);
Console.ReadKey();
Console.Clear();

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

FabricaDePersonajes fabricaPersonajes = new FabricaDePersonajes();
List<Personaje> ListadoDePersonajes = new List<Personaje>();

ListadoDePersonajes = fabricaPersonajes.GeneradorDePersonajes(ListadoDeNombres); 