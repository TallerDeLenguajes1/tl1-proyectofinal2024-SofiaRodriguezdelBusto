using System.Text.Json;

namespace Juego
{
    public class PersonajesJson
    {
        public void GuardarPersonajes(List<Personaje> ListadoDePersonajes, string nombreArchivo)
        {
            string personajesJson = JsonSerializer.Serialize(ListadoDePersonajes);
            
            using(var archivo = new FileStream(nombreArchivo, FileMode.Create))
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
            string cadenaPersonajes;
            using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
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
            string ruta = nombreArchivo;
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
            File.Delete(nombreArchivo);
        }

    }
    
}