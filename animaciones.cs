namespace Juego
{
    class Animacion
    {
        public static void EfectoTemblorTitulo(string[] title)
        {
            var semilla = Environment.TickCount;
            Random random = new Random(semilla);

            Console.CursorVisible = false;
            
            do
            {
                Console.Clear();
                int offsetX = random.Next(-2, 3); // Genera un valor entre -2 y 2
                Console.SetCursorPosition((Console.BufferWidth-title[0].Length)/2 + offsetX, 2);
                foreach (var line in title)
                {
                    interfazGrafica.CentrarTexto(line);
                }
                interfazGrafica.CentrarTexto("Presione enter para iniciar");
                Thread.Sleep(500); // Controla la velocidad del temblor
                
            }while(!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Enter);
        }
        public static void EscribirTextoAnimado(string texto, bool centrado)
        {
            if (centrado)
            {
                Console.SetCursorPosition((Console.BufferWidth - texto.Length) / 2, Console.BufferHeight / 4);
            }
            foreach (char c in texto)
            {
                if(c == ':') Thread.Sleep(200);
                Console.Write(c);
                Thread.Sleep(50);
                
            }
        }
        
    }
}