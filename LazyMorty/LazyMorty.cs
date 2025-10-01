using GameCore;


public class LazyMorty : IMorty
{

    public List<int> mortyValues { get; set; } = new();
    public List<string> hmacs { get; set; } = new();
    public List<byte[]> secretKeys { get; set; } = new();
    public List<int> fairValues { get; set; } = new();

    public void GenerateValues(int boxCount, int i)
    {
        secretKeys.Add(BoxSelector.GenerateSecretKey());
        mortyValues.Add(BoxSelector.GenerateMortyValue(boxCount));
        hmacs.Add(BoxSelector.GenerateHMAC(secretKeys[i], mortyValues[i]));
    }

}


