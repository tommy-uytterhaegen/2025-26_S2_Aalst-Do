using System.Drawing;

public class Kasteel
{
    /// <summary>
    /// We kunnen basis typen gebruiken als types voor eigenschappen (int, string, bool, etc.)
    /// </summary>
    public int AantalTorens { get; init; }

    /// <summary>
    /// We kunnen niet-basis typen gebruiken als types voor eigenschappen (DateTime, Color, etc.)
    /// </summary>
    public Color KleurVlagjes { get; init; }

    /// <summary>
    /// We kunnen onze eigen klassen gebruiken als types voor eigenschappen
    /// </summary>
    public Coordinaat Positie { get; init; }

    public Kasteel(Coordinaat positie, int aantalTorens, Color kleurVlagjes)
    {
        Positie = positie;
        AantalTorens = aantalTorens;
        KleurVlagjes = kleurVlagjes;
    }

    /// <summary>
    /// We gaan de methode doorsturen naar de coordinaat klasse. De coordinaat klasse heeft logischerwijs de verantwoordelijkheid om te weten of een coordinaat binnen een bepaald raster ligt of niet. 
    /// Door de methode door te sturen, kunnen we de code van de coordinaat klasse hergebruiken en vermijden we duplicatie van code.
    /// </summary>
    /// <param name="rasterBreedte"></param>
    /// <param name="rasterHoogte"></param>
    /// <returns></returns>
    public bool LigtBinnenRaster(int rasterBreedte, int rasterHoogte)
        => Positie.LigtBinnenRaster(rasterBreedte, rasterHoogte);
}

