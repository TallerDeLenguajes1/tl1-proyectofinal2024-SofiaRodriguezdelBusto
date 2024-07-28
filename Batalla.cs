namespace Juego
{
    class Batalla
    {   
        public Personaje GeneradorDeBatalla(Personaje personaje1, Personaje personaje2)
        {
            Batalla batalla = new Batalla();
            interfazGrafica.CentrarTexto($"Se encuentran {personaje1.Nombre} y {personaje2.Nombre} en la arena\nEs el momento de enfretarse y solo uno de ellos seguirá en competencia");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n\n");
            Personaje aux;
            Personaje atacante = personaje1;
            Personaje defensor = personaje2;
            int contadorDisputas = 0;
            while (personaje1.Salud > 0 && personaje2.Salud>0)
            {
                contadorDisputas++;
                int danio = atacante.Ataque(atacante, defensor);
                if(danio > atacante.MejorAtaque)
                {
                    atacante.MejorAtaque = danio;
                }
                string jugadaDeAtaque = batalla.ElegirJugadaDeAtaque(danio);
                interfazGrafica.TextoCentradoConDecoracion($"Disputa {contadorDisputas}\n{atacante.Nombre} avanza hacia {defensor.Nombre} e intenta dejarlo fuera de competencia\n{jugadaDeAtaque}\nEl daño provocado por el atacante es {danio}\nLa salud de los jugadores luego del ataque:\nSalud {atacante.Nombre}: {atacante.Salud}\nSalud {defensor.Nombre}: {defensor.Salud}", contadorDisputas);
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


        public string ElegirJugadaDeAtaque(int danio)
        {
            string[] AtaquesFuertes = {
                "Dispara su flecha y acierta en el pecho de su oponente generando un grave sangrado.",
                "Dispara su flecha y ésta se clava directamente en el rostro del otro tributo.",
                "Aprovecha la distracción de su oponente y logra clavar su cuchillo en el abdomen del mismo.",
                "Toma su lanza y la arroja con gran fuerza y velocidad hacia su oponente. Logra acertarle a su cuerpo.",
                "Se encuentra con un fuego encendido, calienta su arma y la arroja generando grandes quemaduras y heridas."
            };

            string[] AtaquesMedios = {
                "Dispara su flecha y ésta golpea la pierna del oponente dificultando su movimiento.",
                "Agarra un mazo y golpea a su oponente por la espalda causándole una grave caida.",
                "Toma las piedras que se encuentran a su alrededor y logra disminuir a su oponente.",
                "Lanza su cuerpo hacia su oponente y logra golpearlo directamente con sus puños.",
                "Logra levantar a su oponente y lo arroja directamente contra un árbol."
            };

            string[] AtaquesDebiles = {
                "Logra alcanzar unas piedras pequeñas y las apunta contra su oponente provocandole poco daño y distrayendolo.",
                "Ataque directamente a su oponente pero solo alcanza a darle una patada y cae contra el suelo.",
                "Logra inmovilizar una de las extremidades del oponente con una cuerda.",
                "Con palo logra golpear y alejar a su oponente unos metros.",
                "Lanza su flecha contra el oponente pero solo logra rozar uno de sus brazos."
            };
            var semilla = Environment.TickCount;
            var random = new Random(semilla); 
            if(danio > 40)
            {
                return AtaquesFuertes[random.Next(0,5)];
            }else if (danio > 15)
            {
                return AtaquesMedios[random.Next(0,5)];
            }else
            {
                return AtaquesDebiles[random.Next(0,5)];
            }
        }
    }
    
}