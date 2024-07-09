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
    }
    
}