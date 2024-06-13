

namespace Personajes
{
    public class Personaje
    {
        string nombre;

        public string Nombre{ get => nombre; set => nombre = value; }

        public class Datos
        {
            int distrito;
            TipoPersonaje tipo;

            int puntuacionPrevia;
            string mentor;

            public Datos( int distrito, TipoPersonaje tipo, int puntaje, string mentor)
            {
                Distrito = distrito;
                Tipo = tipo;
                PuntuacionPrevia = puntaje;
                Mentor = mentor;
            }

            public int Distrito{ get => distrito; set => distrito = value; }
            public TipoPersonaje Tipo{ get => tipo; set => tipo = value; }
        

            public int PuntuacionPrevia{ get => puntuacionPrevia; set => puntuacionPrevia = value; }

            public string Mentor{ get => mentor; set => mentor = value; }

        }


        public class Caracteristicas
        {
            int velocidad;
            int destreza;
            int fuerza;
            int salud;

            public Caracteristicas(TipoPersonaje tipo)
            {
                switch (tipo)
                {
                    case TipoPersonaje.Intelectual:
                        
                        break;
                }

            }

            public int Velocidad{ get => velocidad; set => velocidad = value; }

             public int Destreza{ get => destreza; set => destreza = value; }
            public int Fuerza{ get => fuerza; set => fuerza = value; }

            public int Salud{ get => salud; set => salud = value; }

            
            

        }


    }
}