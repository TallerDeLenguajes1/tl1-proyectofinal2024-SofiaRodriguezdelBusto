namespace Juego
{
    public class HistorialDeBatallas
    {
        string ganador;
    
        int cantidadDeBatallasGanadas;

        int mejorAtaque;

        public Personaje Ganador { get => ganador; set => ganador = value; }
        public int CantidadDeBatallasGanadas { get => cantidadDeBatallas; set => cantidadDeBatallas = value; }
        public int MejorAtaque { get => mejorAtaque; set => mejorAtaque = value; }
    }   
}

