
using System.Drawing;

int rasterHoogte = 3;
int rasterBreedte = 3;

var positie = CoordinaatFactory.Create(2, 1);
if ( ! positie.IsSuccess)
{
    var kasteel = new Kasteel(positie.Result, 3, Color.Red);
    if ( kasteel.LigtBinnenRaster(rasterBreedte, rasterHoogte) )
    {
        Console.WriteLine("Het kasteel ligt binnen het raster");
    }
}
else
{
    Console.WriteLine("Er is een fout opgetreden bij het aanmaken van het coordinaat");
    Console.WriteLine($"Foutmelding: {positie.ErrorMessage}");
}

