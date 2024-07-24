using System.Text.Json;

namespace Juego
{
    public class PersonajesJson
    {
        public void GuardarPersonajes(List<Personaje> ListadoDePersonajes, string nombreArchivo)
        {
            string ruta = "Data/"+nombreArchivo;
            string personajesJson = JsonSerializer.Serialize(ListadoDePersonajes);
            
            using(var archivo = new FileStream(ruta, FileMode.Create))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine("{0}", personajesJson);
                    strWriter.Close();
                }
            }
        }
        public List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            string ruta = "Data/"+nombreArchivo;
            string cadenaPersonajes;
            using (var archivoOpen = new FileStream(ruta, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    cadenaPersonajes = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
            }
            var listadoPersonajes= JsonSerializer.Deserialize<List<Personaje>>(cadenaPersonajes);
            return listadoPersonajes;
        }
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
        public void EliminarArchivo(string nombreArchivo)
        {
            string ruta = "Data/"+nombreArchivo;
            File.Delete(ruta);
        }

    }
    
}