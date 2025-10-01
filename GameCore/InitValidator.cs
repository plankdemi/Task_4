


using System.Globalization;

public static class InitValidator
{


    public static bool Validate(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine($"Wrong number of params - {args.Length}, must be 2");
            return false;
        }
        if (BoxesValidation(args[0]) && MortyValidation(args[1])) return true;
        return false;

    }
    private static bool BoxesValidation(string boxCountString)
    {
        if (int.TryParse(boxCountString, NumberStyles.None, CultureInfo.InvariantCulture, out int boxCountInt))
        {

            if (boxCountInt > 2) return true;
            else
            {
                Console.WriteLine($"Too little boxes - {boxCountInt}, must be 2 or more");
                return false;
            }

        }
        Console.WriteLine("Box count must be a positive number");
        return false;

    }
    private static bool MortyValidation(string mortyType)
    {
        if (MortyRunner.mortyTypes.Contains(mortyType.ToLower())) return true;
        else
        {
            Console.WriteLine($"Wrong Morty type - {mortyType}, Morty type has to be {string.Join(",", MortyRunner.mortyTypes)} ");
            return false;
        }

    }


}