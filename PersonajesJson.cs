using System.Text.Json;

namespace Personajes
{
    public class PersonajesJson
    {
        public async void GuardarPersonajes(List<Personaje> ListadoDePersonajes, string nombreArchivo)
        {
            if(!Existe(nombreArchivo))
            {
                await using FileStream createStream = File.Create(nombreArchivo);
                await JsonSerializer.SerializeAsync(createStream, ListadoDePersonajes); 
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