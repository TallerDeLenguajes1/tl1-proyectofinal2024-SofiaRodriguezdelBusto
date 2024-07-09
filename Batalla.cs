namespace Juego
{
    class Batalla
    {   
        public Personaje GeneradorDeBatalla(Personaje personaje1, Personaje personaje2)
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
                int danio = atacante.Ataque(atacante, defensor);
                if(danio > atacante.MejorAtaque)
                {
                    atacante.MejorAtaque = danio;
                }
                Console.WriteLine($"El daño provocado por el atacante es {danio}");
                Console.WriteLine($"La salud de los jugadores luego del ataque: ");
                Console.WriteLine($"Salud {atacante.Nombre}: {atacante.Salud}");
                Console.WriteLine($"Salud {defensor.Nombre}: {defensor.Salud}");
                aux = atacante;
                atacante = defensor;
                defensor = aux;
                Console.ReadKey();
                Console.Clear();
            }
            if (personaje1.Salud <= 0)
            {
                personaje2.MejorarSalud();
                personaje2.CantidadDeEnfrentamientosGanados++;
                return personaje1;
            }else
            {
                personaje1.MejorarSalud();
                personaje1.CantidadDeEnfrentamientosGanados++;
                return personaje2;
            }
        }
        
    }
    
}