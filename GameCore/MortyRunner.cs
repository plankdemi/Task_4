using System.Diagnostics;


public static class MortyRunner
{
    public static readonly string[] mortyTypes = ["classic", "lazy"];
    public static void RunMorty(string morty, string boxCount)
    {
        morty = char.ToUpper(morty[0]) + morty.Substring(1);

        string parentFolder = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName;
        string dllPath = Path.Combine(parentFolder, $"{morty}Morty", "bin", "Debug", "net8.0", $"{morty}Morty.dll");
        Console.WriteLine(dllPath);


        var psi = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = $"\"{dllPath}\" {boxCount}",
            UseShellExecute = false,
            RedirectStandardInput = false,
            RedirectStandardOutput = false,
            RedirectStandardError = false,
            CreateNoWindow = false
        };

        Process.Start(psi)?.WaitForExit();




    }
}

