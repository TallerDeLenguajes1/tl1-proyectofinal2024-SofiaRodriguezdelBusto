using System.Text.Json;

namespace Juego
{
    public class HistorialJson
    {
        public bool Existe(string nombreArchivo)
        {
            string ruta = nombreArchivo;
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
            HistorialDeGanadores informacionGanador = new HistorialDeGanadores(ganador);
            List<HistorialDeGanadores> historialGanadores = new List<HistorialDeGanadores>();
            if(Existe(nombreArchivo))
            {
                historialGanadores = LeerGanadores(nombreArchivo);
            }
            historialGanadores.Add(informacionGanador);
            string historial = JsonSerializer.Serialize(historialGanadores);
            using(var archivo = new FileStream(nombreArchivo, FileMode.OpenOrCreate))
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
            string cadenaGanadores;
            using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    cadenaGanadores = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
            }
            
            var HistorialDeGanadores = JsonSerializer.Deserialize<List<HistorialDeGanadores>>(cadenaGanadores);

            return HistorialDeGanadores;

        }
    
    }
}