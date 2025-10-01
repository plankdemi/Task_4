
using System.Globalization;

namespace GameCore
{
    public static class GameLoop
    {

        public static void HmacNumber(string hmac, int hmacNumber)
        {

            Console.WriteLine($"Morty:\nHMAC{hmacNumber}={hmac}");

        }

        public static void RandomSecretFairNumbers(string itteration, int mortyValue, string mortySecretKey, int rickValue, int boxCount, int mortyFairValue)
        {

            Console.WriteLine($"Morty: Aww man, my {itteration} random value is {mortyValue}.");
            Console.WriteLine($"Morty:\nKEY{itteration[0]}={mortySecretKey}");
            Console.WriteLine($"Morty: So the {itteration} fair number is ({mortyValue} + {rickValue}) % {boxCount} = {mortyFairValue}. ");
        }


        public static void GameResult(int rickGuess, int newRickGuess, int gunBox, Rick rick)
        {
            if (newRickGuess == gunBox)
            {
                Console.WriteLine("Morty: Aww man, you won, Rick. Now we gotta go on one of your adventures!");

                if (rickGuess == newRickGuess)
                {
                    rick.stayedRickWin();
                    rick.stayedRickRound();
                }
                else
                {
                    rick.switchedRickWin();
                    rick.switchedRickRound();
                }



            }
            else
            {
                if (rickGuess == newRickGuess)
                {

                    rick.stayedRickRound();
                }
                else
                {

                    rick.switchedRickRound();
                }
                Console.WriteLine("Morty: Aww man, you lost, Rick. Now we gotta go on one of *my* adventures!");

            }
            rick.RoundsPlayed();



        }

        public static bool PlayAnotherRound()
        {

            while (true)
            {
                Console.WriteLine("Morty: D-do you wanna play another round (y/n)?");
                string? input = Console.ReadLine();
                if (input != null)
                {
                    if (input.ToLower() == "yes" || input.ToLower() == "y") return true;
                    else if (input.ToLower() == "no" || input.ToLower() == "n") return false;
                }

            }


        }

        public static int RickInputForFairValue(int boxCount)
        {
            Console.WriteLine($"Morty: Rick, enter your number [0,{boxCount}) so you don't whine later that I cheated, alright?");
            return RickInput(boxCount);
        }
        public static int RickInputForGun(int boxCount)
        {
            return RickInput(boxCount);
        }
        public static int boxToKeep(int gunBox, int rickGuess, int altGunBox, int boxCount)
        {
            int boxToKeep = gunBox;

            if (rickGuess == boxToKeep)
            {
                boxToKeep = altGunBox;
                if (rickGuess == boxToKeep)
                {
                    if (rickGuess == boxCount)
                    {
                        boxToKeep = rickGuess - 1;
                    }
                    else if (rickGuess == 0)
                    {
                        boxToKeep = boxToKeep + 1;
                    }
                    else
                    {
                        boxToKeep = boxToKeep + 1;
                    }
                }

            }

            return boxToKeep;

        }

        public static int boxToKeep(int gunBox, int rickGuess, int boxCount)
        {
            if (gunBox != rickGuess) return gunBox;
            if (boxCount - 1 == rickGuess) return rickGuess - 1;
            return boxCount - 1;

        }




        private static int RickInput(int maxInput)
        {

            bool isValid = false;
            string? rickInput = "";

            while (!isValid)
            {
                Console.Write("Rick: ");
                rickInput = Console.ReadLine();
                isValid = isRickInputValid(rickInput, maxInput);
            }


            return int.Parse(rickInput!);

        }


        private static bool isRickInputValid(string? rickInput, int maxInput)
        {
            if (int.TryParse(rickInput, NumberStyles.None, CultureInfo.InvariantCulture, out int rickInputInt))
            {
                if (rickInputInt < maxInput)
                {

                    return true;

                }
                else
                {
                    Console.WriteLine($"Number is out of bounds - {rickInputInt}, must be [0,{maxInput})");
                    return false;
                }

            }
            Console.WriteLine("Value must be a number");
            return false;
        }


    }
}
