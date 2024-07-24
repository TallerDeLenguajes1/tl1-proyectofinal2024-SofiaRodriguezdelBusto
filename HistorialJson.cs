using System.Text.Json;

namespace Juego
{
    public class HistorialJson
    {
        public bool Existe(string nombreArchivo)
        {
            string ruta = "Data/"+nombreArchivo;
            if(File.Exists(ruta))
            {
                return true;
            }else
            {
                return false;
            }

        }
        public void GuardarGanador(Personaje ganador, string nombreArchivo)
        {
            string ruta = "Data/"+nombreArchivo;
            HistorialDeGanadores informacionGanador = new HistorialDeGanadores(ganador);
            List<HistorialDeGanadores> historialGanadores = new List<HistorialDeGanadores>();
            if(Existe(nombreArchivo))
            {
                historialGanadores = LeerGanadores(nombreArchivo);
            }
            historialGanadores.Add(informacionGanador);
            string historial = JsonSerializer.Serialize(historialGanadores);
            using(var archivo = new FileStream(ruta, FileMode.OpenOrCreate))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine("{0}", historial);
                    strWriter.Close();
                }
            }

        }
        public List<HistorialDeGanadores> LeerGanadores(string nombreArchivo)
        {
            string ruta = "Data/"+nombreArchivo;
            string cadenaGanadores;
            List<HistorialDeGanadores> historialGanadores;
            using (var archivoOpen = new FileStream(ruta, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    cadenaGanadores =strReader.ReadToEnd();
                    archivoOpen.Close();
                }
            }
                
            historialGanadores = JsonSerializer.Deserialize<List<HistorialDeGanadores>>(cadenaGanadores);

            return historialGanadores;

        }
    
    }
}