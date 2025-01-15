namespace dev_blog_dotnet.Utils;

public static class ConsoleUtils
{
    public static void ErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void SuccessMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void InfoMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(message);
        Console.ResetColor();
    }
    
    public static string BoldText(string text) => $"\x1b[1m{text}\x1b[0m";
    
    public static void ClearConsole()
    {
        Console.Clear();
    }

    public static string? Input(string fieldName)
    {
        Console.Write($"{fieldName}: ");
        var data = Console.ReadLine();
        return data;
    }
}