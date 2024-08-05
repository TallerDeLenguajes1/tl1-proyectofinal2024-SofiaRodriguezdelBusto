namespace Juego
{
    class Batalla
    {   
        public Personaje GeneradorDeBatalla(Personaje personaje1, Personaje personaje2)
        {
            Batalla batalla = new Batalla();
            InterfazGrafica.CentrarTexto($"Se encuentran {personaje1.Nombre} y {personaje2.Nombre} en la arena\nEs el momento de enfretarse y solo uno de ellos seguirá en competencia");
            Console.ReadKey();
            Console.Clear();
            Personaje aux;
            Personaje atacante = personaje1;
            Personaje defensor = personaje2;
            int contadorDisputas = 0;
            while (personaje1.Salud > 0 && personaje2.Salud>0)
            {
                contadorDisputas++;
                int danio = atacante.Ataque(defensor);
                if(danio > atacante.MejorAtaque)
                {
                    atacante.MejorAtaque = danio;
                }
                string jugadaDeAtaque = atacante.ElegirJugadaDeAtaque(danio);
                InterfazGrafica.MostrarTitulosDeAnunciosDeBatallas();
                InterfazGrafica.TextoCentradoConDecoracion($"Disputa {contadorDisputas}\n{atacante.Nombre} avanza hacia {defensor.Nombre} e intenta dejarlo fuera de competencia\n{jugadaDeAtaque}\nEl daño provocado por el atacante es {danio}\nLa salud de los jugadores luego del ataque:\nSalud {atacante.Nombre}: {atacante.Salud}\nSalud {defensor.Nombre}: {defensor.Salud}", contadorDisputas);
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