using System.Text.Json;

namespace Juego
{
    public class PersonajesJson
    {
        public void GuardarPersonajes(List<Personaje> ListadoDePersonajes, string nombreArchivo)
        {
            FileStream MiArchivo;
            if(!Existe(nombreArchivo))
            {
                MiArchivo = new FileStream(@"c:\Users\pc\TLI\tl1-proyectofinal2024-SofiaRodriguezdelBusto\json"+nombreArchivo, FileMode.Create);
            }else
            {
                MiArchivo = new FileStream(@"c:\Users\pc\TLI\tl1-proyectofinal2024-SofiaRodriguezdelBusto\json"+nombreArchivo, FileMode.Open);
            }
            string personajesJson = JsonSerializer.Serialize(ListadoDePersonajes);
            using (StreamWriter StrWriter = new StreamWriter(MiArchivo))
            {
                StrWriter.WriteLine("{0}", personajesJson);
                StrWriter.Close();
            }
        }
        public List<Personaje>? LeerPersonajes(string nombreArchivo)
        {
            if (Existe(nombreArchivo))
            {
                FileStream MiArchivo = new FileStream(@"c:\Users\pc\TLI\tl1-proyectofinal2024-SofiaRodriguezdelBusto\json"+nombreArchivo, FileMode.Open);
                List<Personaje> ListadoDePersonajes = JsonSerializer.Deserialize<List<Personaje>>(MiArchivo);
                return ListadoDePersonajes;
            }else
            {
                return null;
                
            }
        }
        public bool Existe(string nombreArchivo)
        {
            string ruta = "json/"+nombreArchivo;
            if(File.Exists(ruta))
            {
                return true;
            }else
            {
                return false;
            }
        }

    }
    
}