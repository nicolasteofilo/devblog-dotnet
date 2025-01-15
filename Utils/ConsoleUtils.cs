namespace dev_blog_dotnet.Utils;

public static class ConsoleUtils
{
    public static void ErrorMessage(string message)
    {
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine(message);
        System.Console.ResetColor();
    }

    public static void SuccessMessage(string message)
    {
        System.Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine(message);
        System.Console.ResetColor();
    }
    
    public static string BoldText(string text) => $"\x1b[1m{text}\x1b[0m";
    
    public static void ClearConsole()
    {
        System.Console.Clear();
    }

    public static string? Input(string fieldName)
    {
        Console.Write($"{fieldName}: ");
        var data = Console.ReadLine();
        return data;
    }
}