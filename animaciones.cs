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
                int offsetX = random.Next(-2, 3); 
                Console.SetCursorPosition((Console.BufferWidth-title[0].Length)/2 + offsetX, 2);
                foreach (var line in title)
                {
                    InterfazGrafica.CentrarTexto(line);
                }
                InterfazGrafica.CentrarTexto("Presione enter para iniciar");
                Thread.Sleep(500);
                
            }while(!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Enter);
        }
        public static void EscribirTextoAnimado(string texto, bool centrado)
        {
            if (centrado)
            {
                Console.SetCursorPosition((Console.BufferWidth - texto.Length) / 2, Console.CursorTop);
            }
            foreach (char c in texto)
            {
                if(c == ':')
                {
                    Console.Write(c);
                    Thread.Sleep(1000);
                }else
                {
                    Console.Write(c);
                    Thread.Sleep(50);
                }    
            }
        }
        
    }
}