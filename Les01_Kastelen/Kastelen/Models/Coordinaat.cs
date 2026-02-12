public class Coordinaat
{
    /// <summary>
    /// Een eigenschap met 'init' wil zeggen dat we enkel deze eigenschap zijn waarde kunnen zetten bij het aanmaken van het object (in de constructor dus)
    /// </summary>
    public int X { get; init; }

    public int Y { get; init; }

    public Coordinaat(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool LigtBinnenRaster(int rasterBreedte, int rasterHoogte)
    {
        // Als x negatief is, of groter of gelijk aan de breedte van het raster, dan ligt het coordinaat niet binnen het raster
        if ( X < 0 || rasterBreedte <= X)
            return false;

        // Als y negatief is, of groter of gelijk aan de hoogte van het raster, dan ligt het coordinaat niet binnen het raster
        if (Y < 0 || rasterHoogte <= Y)
            return false;

        return true;
    }
}

