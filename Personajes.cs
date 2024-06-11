

namespace Personajes
{
    public class Personaje
    {
        string[] nombresPersonajes = {"Gloss","Enobaria","Brutus","Wiress","Beetee", "Mags", "Finnick", "Johanna", "Katniss", "Peeta"};

        string[] mentores = {"Velvereen","Wovey","Wovey","Maysilee","Maysilee", "Augustus", "Augustus", "Glimmer", "Haymitch", "Haymitch"};
        string nombre;
        int edad;

        DateTime fechaNacimiento;
        int distrito;
        TipoPersonaje tipo = TipoPersonaje.Agresivo;

        int velocidad;
        int destreza;
        int fuerza;

        int puntuacionPrevia;
        string mentor;
        int salud;

        public string Nombre{ get => nombre; set => nombre = value; }

        public int Edad{ get => edad; set => edad = value; }
        public DateTime FechaNacimiento{ get => fechaNacimiento; set => fechaNacimiento = value; }

        public int Distrito{ get => distrito; set => distrito = value; }
        public TipoPersonaje Tipo{ get => tipo; set => tipo = value; }
        
        public int Velocidad{ get => velocidad; set => velocidad = value; }

        public int Destreza{ get => destreza; set => destreza = value; }
        public int Fuerza{ get => fuerza; set => fuerza = value; }

        public int PuntuacionPrevia{ get => puntuacionPrevia; set => puntuacionPrevia = value; }

        
        public int Salud{ get => salud; set => salud = value; }

        public string Mentor{ get => mentor; set => mentor = value; }


    }
}