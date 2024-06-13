namespace Personajes
{
    public class FabricaDePersonajes
    {
        Dictionary<string, Personaje.Datos> datosPersonaje = new Dictionary<string, Personaje.Datos>(){
            {"Gloss", new Personaje.Datos(1, TipoPersonaje.Agresivo,10,"Velvereen")},
            {"Enobaria",  new Personaje.Datos(2, TipoPersonaje.Agresivo,12,"Wovey")},
            {"Wiress",  new Personaje.Datos(3, TipoPersonaje.Intelectual,7,"Maysilee")},
            {"Beetee",  new Personaje.Datos(3, TipoPersonaje.Intelectual,9,"Maysilee")},
            {"Finnick",  new Personaje.Datos(4, TipoPersonaje.Habil,12,"Augustus")},
            {"Johanna",  new Personaje.Datos(7, TipoPersonaje.Habil,10,"Glimmer")},
            {"Katniss",  new Personaje.Datos(12, TipoPersonaje.Habil,12,"Haymitch")},
            {"Peeta", new Personaje.Datos(12, TipoPersonaje.Fuerte,12,"Haymitch")}
        };
                
    }
}