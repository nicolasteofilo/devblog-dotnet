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
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
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
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
        }
        
        repository.Delete(userId);
        ConsoleUtils.SuccessMessage("User deleted!");
        ConsoleUtils.HandleQuestion("Delete new user?", Display, Program.Main);
    }
}