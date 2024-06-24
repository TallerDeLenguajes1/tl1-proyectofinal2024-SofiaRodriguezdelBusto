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

        public void Batalla(Personaje atacante, Personaje defensor)
        {
            const int ajuste = 500;
            var semilla = Environment.TickCount;
            var random = new Random(semilla); 
            int efectividad = random.Next(1,100);
            int danioProvocado = (atacante.Ataque()*efectividad-defensor.Defensa())/ajuste;

            if (danioProvocado>0)
            {
                defensor.Salud -= danioProvocado;
            }
        }   
    }   
}