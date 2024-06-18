namespace Juego
{
    public class Partida
    {
        Personaje ganador;
        Personaje perdedor;
        int cantidadDeDisputas;

        public Personaje Ganador { get => ganador; set => ganador = value; }
        public Personaje Perdedor { get => perdedor; set => perdedor = value; }
        public int CantidadDeDisputas { get => cantidadDeDisputas; set => cantidadDeDisputas = value; }
        
    }
    
}