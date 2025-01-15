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

    public static void BackToMenuQuestion()
    {
        ConsoleUtils.InfoMessage("Back to menu? (y/n): ");
        var option = Console.ReadLine() ?? string.Empty;
            
        switch (option)
        {
            case "y":
                ConsoleUtils.ClearConsole();
                Program.Main();
                break;
            case "n":
                ConsoleUtils.ClearConsole();
                System.Environment.Exit(0);
                break;
        }
    }

    public static void HandleQuestion(string prompt, Action onConfirm, Action onCancel)
    {
        Console.Write($"{prompt} (y/n): ");
        var option = Console.ReadLine() ?? string.Empty;
        
        switch (option.ToLower())
        {
            case "y":
                ConsoleUtils.ClearConsole();
                onConfirm.Invoke();
                break;
            case "n":
                onCancel.Invoke();
                break;
        }
    }

    public static void PrintErrors(IList<string> errors, Action fnToBack)
    {
        if (errors.Any())
        {
            ConsoleUtils.ClearConsole();
            Console.WriteLine(ConsoleUtils.BoldText("Errors: "));
            foreach (var err in errors)
            {
                ConsoleUtils.ErrorMessage(err);
            }

            Console.Write("Try again? (y/n): ");
            var input = Console.ReadLine();
            switch (input?.ToLower())
            {
                case "y":
                    fnToBack?.Invoke();
                    break;
                case "n":
                    Program.Main();
                    break;
            }
        }
    }
}