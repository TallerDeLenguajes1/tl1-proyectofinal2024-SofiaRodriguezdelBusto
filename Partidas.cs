namespace Juego
{
    public class HistorialDeBatallas
    {
        Personaje ganador;
        Personaje perdedor;
        int cantidadDeDisputas;

        public HistorialDeBatallas(Personaje ganador, Personaje perdedor, int cantDisputas)
        {
            Ganador = ganador;
            Perdedor = perdedor;
            CantidadDeDisputas = cantDisputas;
        }

        public Personaje Ganador { get => ganador; set => ganador = value; }
        public Personaje Perdedor { get => perdedor; set => perdedor = value; }
        public int CantidadDeDisputas { get => cantidadDeDisputas; set => cantidadDeDisputas = value; }


    }   
}