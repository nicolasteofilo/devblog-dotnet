using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;

namespace dev_blog_dotnet.Screens.UserScreen;

public static class DeleteUserScreen
{
    public static void Display()
    {
        ConsoleUtils.ClearConsole();
        var id = ConsoleUtils.Input("User ID");
        
        if (!Int32.TryParse(id, out var userId))
        {
            ConsoleUtils.ClearConsole();
            Console.WriteLine(ConsoleUtils.BoldText("Errors: "));
            ConsoleUtils.ErrorMessage("User ID is required.");
            Console.Write("Try again? (y/n): ");
            var input = Console.ReadLine();
            switch (input?.ToLower())
            {
                case "y":
                    Display();
                    break;
                case "n":
                    Program.Main();
                    break;
            }
        }
        
        Delete(userId);
    }

    private static void Delete(int userId)
    {
        var repository = new UserRepository(Database.Connection!);
        var user = repository.GetById(userId);
        if (user == null)
        {
            ConsoleUtils.ErrorMessage("User not found");
            Console.Write("Try again? (y/n): ");
            var input = Console.ReadLine();
            switch (input?.ToLower())
            {
                case "y":
                    Display();
                    break;
                case "n":
                    Program.Main();
                    break;
            }
        }
        
        repository.Delete(userId);
        ConsoleUtils.SuccessMessage("User deleted!");
        Console.Write("Delete new user? (y/n): ");
        var optionToDeleteNewUser = Console.ReadLine() ?? string.Empty;
        switch (optionToDeleteNewUser)
        {
            case "y":
                ConsoleUtils.ClearConsole();
                Display();
                break;
            case "n":
                Program.Main();
                break;
        }
    }
}