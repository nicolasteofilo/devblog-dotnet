using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;
using Microsoft.IdentityModel.Tokens;

namespace dev_blog_dotnet.Screens.UserScreen;

public static class CreateUserScreen
{
    public static void Display()
    {
        ConsoleUtils.ClearConsole();
        var name = ConsoleUtils.Input("Full name");
        var email = ConsoleUtils.Input("Email");
        var password = ConsoleUtils.Input("Password");
        var bio = ConsoleUtils.Input("Bio");            
        
        Add(name, email, password, bio);
    }

    private static void Add(string? name, string? email, string? password, string? bio)
    {
        var repository = new UserRepository(Database.Connection!);
        var slug = name?.Replace(" ", "-").Trim().ToLower();

        IList<string> errors = new List<string>();
        
        var emailExists = repository.GetByEmail(email ?? String.Empty)?.Email;
        
        if(name.IsNullOrEmpty())
            errors.Add("Name is required");
        if (email.IsNullOrEmpty())
            errors.Add("Email is required");
        if (password.IsNullOrEmpty())
            errors.Add("Password is required");
        if (bio.IsNullOrEmpty())
            errors.Add("Bio is required");
        
        if (!emailExists.IsNullOrEmpty())
            errors.Add("This email already exists in system. Please try another one.");


        if (errors.Any())
        {
            ConsoleUtils.ClearConsole();
            Console.WriteLine(ConsoleUtils.BoldText("Errors: "));
            foreach (var err in errors)
            {
                ConsoleUtils.ErrorMessage(err);    
            }
            
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
        }
        else
        {
            var user = new User()
            {
                Name = name!,
                Email = email!,
                PasswordHash = password!,
                Bio = bio!,
                Image = "https://image.png",
                Slug = slug!
            };
            
            repository.Add(user);
            ConsoleUtils.SuccessMessage("New user created!");
            ConsoleUtils.HandleQuestion("Add new user?", Display, Program.Main);
        }
    }
}