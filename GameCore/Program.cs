

public class Program
{
    static void Main(string[] args)
    {


        if (InitValidator.Validate(args))
        {

            MortyRunner.RunMorty(args[1], args[0]);

        }


    }
}