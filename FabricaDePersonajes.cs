namespace Juego
{

    public class FabricaDePersonajes
    {
        public List<Personaje> GeneradorDePersonajes(List<string> Nombres)
        {
            List<Personaje> ListaDePersonajes = new List<Personaje>();
            var semilla = Environment.TickCount;
            var random = new Random(semilla); 
            foreach (var nombre in Nombres)
            {
                Personaje personaje = new Personaje();
                personaje.Nombre = nombre;
                personaje.Distrito = random.Next(1,12);
                personaje.Tipo = (TipoPersonaje)random.Next(1,4);
                personaje.PuntuacionPrevia = random.Next(1,12);
                switch (personaje.Tipo)
                {
                        case TipoPersonaje.Intelectual:
                            personaje.Velocidad = random.Next(1,6);
                            personaje.Armadura = random.Next(6,10);
                            personaje.Destreza = random.Next(1,5);
                            personaje.Fuerza = random.Next(1,5);
                            break;
                        case TipoPersonaje.Agresivo:
                            personaje.Velocidad = random.Next(4,8);
                            personaje.Armadura = random.Next(7,10);
                            personaje.Destreza = random.Next(1,5);
                            personaje.Fuerza = random.Next(5,10);
                            break;
                        case TipoPersonaje.Habil:
                            personaje.Velocidad = random.Next(5,10);
                            personaje.Armadura = random.Next(1,10);
                            personaje.Destreza = random.Next(3,5);
                            personaje.Fuerza = random.Next(5,10);
                            break;
                        case TipoPersonaje.Fuerte:
                            personaje.Velocidad = random.Next(1,10);
                            personaje.Armadura = random.Next(5,10);
                            personaje.Destreza = random.Next(1,5);
                            personaje.Fuerza = random.Next(8,10);
                            break;

                }
                ListaDePersonajes.Add(personaje);
                
            }
            return ListaDePersonajes;

        }
                    


    }
}