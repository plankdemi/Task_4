

using GameCore;

public class Program
{
    static void Main(string[] args)
    {
        
        ClassicMorty morty = new ClassicMorty();
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
            Console.WriteLine("Morty: Let's, uh, generate another value now, I mean, to select a box to keep in the game.");
            morty.GenerateValues(boxCount, 1);
            GameLoop.HmacNumber(morty.hmacs[1], 2);
            rickInput = GameLoop.RickInputForFairValue(boxCount - 1);
            rick.rickValues.Add(rickInput);
            morty.fairValues.Add((morty.mortyValues[1] + rickInput) % (boxCount - 1));
            int boxToKeep = GameLoop.boxToKeep(morty.fairValues[0], rickGuess, morty.fairValues[1], boxCount);
            Console.WriteLine($"Morty: I'm keeping the box you chose, I mean {rickGuess}, and the box {boxToKeep}.");
            Console.WriteLine($"Morty: You can switch your box (enter {boxToKeep}), or, you know, stick with it (enter {rickGuess}). ");
            int newRickGuess = GameLoop.RickInputForGun(boxCount);
            GameLoop.RandomSecretFairNumbers("1st", morty.mortyValues[0], BoxSelector.SecretKeyToString(morty.secretKeys[0]), rick.rickValues[0], boxCount, morty.fairValues[0]);
            GameLoop.RandomSecretFairNumbers("2nd", morty.mortyValues[1], BoxSelector.SecretKeyToString(morty.secretKeys[1]), rick.rickValues[1], boxCount - 1, morty.fairValues[1]);
            Console.WriteLine($"Morty: You portal gun is in the box {morty.fairValues[0]}.");
            GameLoop.GameResult(rickGuess, newRickGuess, morty.fairValues[0], rick);
            isGameActive = GameLoop.PlayAnotherRound();

        }
        Console.WriteLine("Morty: Okay… uh, bye!");
        Statistics.GameStatistics(rick);

    }
}