
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
        public int CantidadDeEnfrentamientosGanados { get => cantidadDeEnfrentamientosGanados; set => cantidadDeEnfrentamientosGanados = value; }
        public int MejorAtaque { get => mejorAtaque; set => mejorAtaque = value; }

        public void MejorarSalud()
        {
            Salud += 10;
        }

        public int Ataque(Personaje defensor)
        {
            const int ajuste = 400;
            var semilla = Environment.TickCount;
            var random = new Random(semilla); 
            int efectividad = random.Next(1,101);
            int ataque =  Destreza*Fuerza*PuntuacionPrevia;
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
        public string ElegirJugadaDeAtaque(int danio)
        {
            string[] AtaquesFuertes = {
                "Dispara su flecha y acierta en el pecho de su oponente generando un grave sangrado.",
                "Dispara su flecha y ésta se clava directamente en el rostro del otro tributo.",
                "Aprovecha la distracción de su oponente y logra clavar su cuchillo en el abdomen del mismo.",
                "Toma su lanza y la arroja con gran fuerza y velocidad hacia su oponente. Logra acertarle a su cuerpo.",
                "Se encuentra con un fuego encendido, calienta su arma y la arroja generando grandes quemaduras y heridas.",
                "Aprovecha la oscuridad y embosca a su oponente, asestándole un golpe en la cabeza con una roca.",
                "Se lanza desde un árbol y entierra su cuchillo en la espalda de su oponente.",
                "Carga contra su oponente con una lanza, atravesando su torso en un movimiento rápido"
            };

            string[] AtaquesMedios = {
                "Dispara su flecha y ésta golpea la pierna del oponente dificultando su movimiento.",
                "Agarra un mazo y golpea a su oponente por la espalda causándole una grave caida.",
                "Toma las piedras que se encuentran a su alrededor y logra disminuir a su oponente.",
                "Lanza su cuerpo hacia su oponente y logra golpearlo directamente con sus puños.",
                "Logra levantar a su oponente y lo arroja directamente contra un árbol.",
                "Se esconde en los arbustos y lanza una piedra grande, golpeando a su oponente en la cabeza y dejándolo aturdido.",
                "Golpea a su oponente con el extremo de su arco, dejándolo con un dolor fuerte en las costillas.",
                "Se lanza hacia su oponente y lo golpea con una rama gruesa, dejándolo desorientado."
            };

            string[] AtaquesDebiles = {
                "Logra alcanzar unas piedras pequeñas y las apunta contra su oponente provocandole poco daño y distrayendolo.",
                "Ataque directamente a su oponente pero solo alcanza a darle una patada y cae contra el suelo.",
                "Logra inmovilizar una de las extremidades del oponente con una cuerda.",
                "Con palo logra golpear y alejar a su oponente unos metros.",
                "Lanza su flecha contra el oponente pero solo logra rozar uno de sus brazos.",
                "Usa una honda para lanzar una piedra pequeña, golpeando a su oponente en el brazo y causando una pequeña distracción.",
                "Encuentra una rama delgada y la usa para azotar a su oponente, causándole solo un rasguño.",
                "Lanza una bolsa de arena a su oponente, haciéndolo tropezar pero sin causar mucho daño."
            };
            var semilla = Environment.TickCount;
            var random = new Random(semilla); 
            if(danio > 40)
            {
                return AtaquesFuertes[random.Next(0,8)];
            }else if (danio > 15)
            {
                return AtaquesMedios[random.Next(0,8)];
            }else
            {
                return AtaquesDebiles[random.Next(0,8)];
            }
        }

    }


}

