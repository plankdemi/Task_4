
using GameCore;
public class Program
{
    //TODO FIX FOR LAZY MORTY
    static void Main(string[] args)
    {
        LazyMorty morty = new LazyMorty();
        Rick rick = new Rick();
        int boxCount = int.Parse(args[0]);
        bool isGameActive = true;
        while (isGameActive)
        {
            morty.GenerateValues(boxCount, 0);
            Console.WriteLine($"Morty: Oh geez, Rick, I'm gonna hide your portal gun in one of the {boxCount} boxes, okay? ");
            GameLoop.HmacNumber(morty.hmacs[0], 1);
            int rickInput = GameLoop.RickInputForFairValue(boxCount);
            rick.rickValues.Add(rickInput);
            morty.fairValues.Add((morty.mortyValues[0] + rickInput) % boxCount);
            Console.WriteLine($"Morty: Okay, okay, I hid the gun. What's your guess [0,{boxCount})?");
            int rickGuess = GameLoop.RickInputForGun(boxCount);
            int boxToKeep = GameLoop.boxToKeep(morty.fairValues[0], rickGuess, boxCount);
            Console.WriteLine($"Morty: I'm keeping the box you chose, I mean {rickGuess}, and the box {boxToKeep}.");
            Console.WriteLine($"Morty: You can switch your box (enter {boxToKeep}), or, you know, stick with it (enter {rickGuess}). ");
            int newRickGuess = GameLoop.RickInputForGun(boxCount);
            GameLoop.RandomSecretFairNumbers("1st", morty.mortyValues[0], BoxSelector.SecretKeyToString(morty.secretKeys[0]), rick.rickValues[0], boxCount, morty.fairValues[0]);
            Console.WriteLine($"Morty: You portal gun is in the box {morty.fairValues[0]}.");
            GameLoop.GameResult(rickGuess, newRickGuess, morty.fairValues[0], rick);
            isGameActive = GameLoop.PlayAnotherRound();

        }
        Console.WriteLine("Morty: Okay… uh, bye!");
        Statistics.GameStatistics(rick);







    }
}