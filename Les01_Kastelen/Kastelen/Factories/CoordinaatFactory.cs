public class CoordinaatFactory
{
    public static FactoryResult<Coordinaat> Create(int x, int y)
    {
        string errorMessage = "";
        if (x < 0)
            errorMessage=  "X moet groter dan 0";

        if (y < 0)
            errorMessage = errorMessage + "Y moet groter dan 0";
        
        var items = new List<string>();
        
        if ( errorMessage.Length > 0 )
            return new FactoryResult<Coordinaat>(errorMessage);
        else
            return new FactoryResult<Coordinaat>(new Coordinaat(x,y));
    }
}

