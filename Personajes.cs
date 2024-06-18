
namespace Juego
{
    public class Personaje
    {
        string nombre;

        int distrito;
        TipoPersonaje tipo;

        int puntuacionPrevia;
        int velocidad;
        int armadura;
        int destreza;
        int fuerza;
        int salud;
        public string Nombre{ get => nombre; set => nombre = value; }

        public int Distrito{ get => distrito; set => distrito = value; }
        public TipoPersonaje Tipo{ get => tipo; set => tipo = value; }
        

        public int PuntuacionPrevia{ get => puntuacionPrevia; set => puntuacionPrevia = value; }

        public int Velocidad{ get => velocidad; set => velocidad = value; }

        public int Armadura{ get => armadura; set => armadura = value; }

        public int Destreza{ get => destreza; set => destreza = value; }
        public int Fuerza{ get => fuerza; set => fuerza = value; }

        public int Salud{ get => salud; set => salud = value; }
        


    }

}

