using System.Text.Json.Serialization;

namespace Juego
{
    public class HistorialDeGanadores
    {
        string nombreGanador;
    
        int cantidadDeBatallasGanadas;

        int mejorAtaque;

        [JsonConstructor]
        public HistorialDeGanadores(string nombreGanador, int cantidadDeBatallasGanadas, int mejorAtaque)
        {
            NombreGanador = nombreGanador;
            CantidadDeBatallasGanadas = cantidadDeBatallasGanadas;
            MejorAtaque = mejorAtaque;
        }

        public HistorialDeGanadores(Personaje vencedor)
        {
            NombreGanador = vencedor.Nombre;
            CantidadDeBatallasGanadas = vencedor.CantidadDeEnfrentamientosGanados;
            MejorAtaque = vencedor.MejorAtaque;
        }

        public string NombreGanador { get => nombreGanador; set => nombreGanador = value; }
        public int CantidadDeBatallasGanadas { get => cantidadDeBatallasGanadas; set => cantidadDeBatallasGanadas = value; }
        public int MejorAtaque { get => mejorAtaque; set => mejorAtaque = value; }
    }   
}

