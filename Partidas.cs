namespace Juego
{
    public class Batalla
    {
        Personaje ganador;
        Personaje perdedor;
        int cantidadDeDisputas;

        public Personaje Ganador { get => ganador; set => ganador = value; }
        public Personaje Perdedor { get => perdedor; set => perdedor = value; }
        public int CantidadDeDisputas { get => cantidadDeDisputas; set => cantidadDeDisputas = value; }

        public Batalla GeneradorDeBatalla(Personaje personaje1, Personaje personaje2)
        {
            Console.WriteLine($"Se encuentran {personaje1.Nombre} y {personaje2.Nombre} en la arena");
            Console.WriteLine("Es el momento de enfretarse y solo uno de ellos seguirá en competencia");
            Personaje aux;
            Personaje atacante = personaje1;
            Personaje defensor = personaje2;
            int contadorDisputas = 0;
            while (personaje1.Salud > 0 && personaje2.Salud>0)
            {
                contadorDisputas++;
                Console.WriteLine($"Disputa {contadorDisputas}");
                Console.WriteLine($"{atacante.Nombre} avanza hacia {defensor.Nombre} e intenta dejarlo fuera de competencia");
                int danio = atacante.Disputa(atacante, defensor);
                Console.WriteLine($"El daño provocado por el atacante es {danio}");
                Console.WriteLine($"La salud de los jugadores luego del ataque: ");
                Console.WriteLine($"Salud {atacante.Nombre}: {atacante.Salud}");
                Console.WriteLine($"Salud {defensor.Nombre}: {defensor.Salud}");
                aux = atacante;
                atacante = defensor;
                defensor = aux;
            }
            Batalla batalla = new Batalla();
            batalla.CantidadDeDisputas = contadorDisputas;
            if (personaje1.Salud < 0)
            {
                batalla.Ganador = personaje2;
                batalla.Perdedor = personaje1;
            }else
            {
                batalla.Ganador = personaje1;
                batalla.Perdedor = personaje2;
            }
            return batalla;
        }
    }   
}