
using System.Data;

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

        int cantidadDeEnfrentamientosGanados;
        int mejorAtaque;
        public string Nombre{ get => nombre; set => nombre = value; }

        public int Distrito{ get => distrito; set => distrito = value; }
        public TipoPersonaje Tipo{ get => tipo; set => tipo = value; }
        

        public int PuntuacionPrevia{ get => puntuacionPrevia; set => puntuacionPrevia = value; }

        public int Velocidad{ get => velocidad; set => velocidad = value; }

        public int Armadura{ get => armadura; set => armadura = value; }

        public int Destreza{ get => destreza; set => destreza = value; }
        public int Fuerza{ get => fuerza; set => fuerza = value; }

        public int Salud{ get => salud; set => salud = value; }
        public int CantidadDeEnfrentamientosGanados { get => cantidadDeEnfrentamientos; set => cantidadDeEnfrentamientos = value; }
        public int MejorAtaque { get => mejorAtaque; set => mejorAtaque = value; }

        public void MejorarSalud()
        {
            Salud += 10;
        }

        public int Ataque(Personaje atacante, Personaje defensor)
        {
            const int ajuste = 500;
            var semilla = Environment.TickCount;
            var random = new Random(semilla); 
            int efectividad = random.Next(1,101);
            int ataque =  atacante.Destreza*atacante.Fuerza*atacante.PuntuacionPrevia;
            int defensa = defensor.Armadura*defensor.Velocidad;
            int danioProvocado = (ataque*efectividad-defensa)/ajuste;

            if (danioProvocado>0)
            {
                defensor.Salud -= danioProvocado;
                if(defensor.Salud < 0)
                {
                    defensor.Salud = 0;
                }
            }else
            {
                danioProvocado = 0;
            }

            return danioProvocado;
        }   

    }

}

