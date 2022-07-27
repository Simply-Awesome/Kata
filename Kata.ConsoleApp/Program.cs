using Kata.Core;

if (!args.Any())
{
    ShowInfoMessageIfNoArgumentIsProvided();

    return;
}

EnsureValidArgumentIsProvided(args);

new KataConsole(new DiamondFormProvider()).Write(args[0][0]);


#region Helpers

const string instructionsAndHelp = "For instructions and help, see https://github.com/Simply-Awesome/Kata/blob/main/README.md";

static void ShowInfoMessageIfNoArgumentIsProvided()
{
    Console.WriteLine($"Kata console app.{Environment.NewLine}{instructionsAndHelp}");
}

static void EnsureValidArgumentIsProvided(string[] args)
{
    if (args is not { Length: 1 } || 
        string.IsNullOrWhiteSpace(args[0]) || 
        args[0].Length != 1)
    {
        throw new ArgumentException($"Valid {nameof(args)} is required. {instructionsAndHelp}");
    }
}

#endregion