using Dapper.Contrib.Extensions;
using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace dev_blog_dotnet
{
    class Program
    {
        private const string ConnectionString = @"Server=127.0.0.1,1433;Database=dev-blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true";
        
        private static readonly SqlConnection Conn = new SqlConnection(ConnectionString);
        private static readonly UserRepository UsersRepository = new UserRepository(Conn);
        private static readonly Repository<Role> RolesRepository = new Repository<Role>(Conn);
        private static readonly Repository<Tag> TagsRepository = new Repository<Tag>(Conn);
        
        public Program()
        {
            Conn.Open();
        }
        
        public static void Main()
        {
            Welcome();
            MenuOptions();

            Conn.Close();
        }

        private static void Welcome()
        {
            Console.WriteLine(@"
 __   ___          __        __   __  
|  \ |__  \  /    |__) |    /  \ / _` 
|__/ |___  \/     |__) |___ \__/ \__> 
            ");
        }

        private static string BoldText(string text) => $"\x1b[1m{text}\x1b[0m";

        private static void MenuOptions()
        {
            Console.WriteLine(BoldText("OPTIONS"));
            Console.WriteLine(" Inserts: ");
            Console.WriteLine("  1. Add new user");
            Console.WriteLine("  2. Add a new profile (role)");
            Console.WriteLine("  3. Add a new tag (for posts)");
            Console.WriteLine("  4. Add a new post");
            
            Console.Write("Your choice: ");
            var operation = float.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine(operation);

            switch (operation)
            {
                case 1:
                    ClearConsole();
                    AddNewUserOption();
                    break;
            }
        }

        private static void ClearConsole()
        {
            Console.Clear();
        }

        private static void ErrorConsoleMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void SuccessConsoleMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        
        private static void AddNewUserOption()
        {
            Console.Write("Full name: ");
            var name = Console.ReadLine();
            
            Console.Write("Email: ");
            var email = Console.ReadLine();
            
            Console.Write("Password: ");
            var password = Console.ReadLine();
            
            Console.Write("Bio: ");
            var bio = Console.ReadLine();

            var slug = name?.Replace(" ", "-").Trim().ToLower();

            var emailExists = UsersRepository.GetByEmail(email ?? String.Empty)?.Email;

            if (!emailExists.IsNullOrEmpty())
            {
                ClearConsole();
                ErrorConsoleMessage("This email already exists in system. Please try another one.");
                Console.Write("Try again? (y/n): ");
                
                var option = (Console.ReadLine() ?? string.Empty);
                switch (option)
                {
                    case "y":
                        ClearConsole();
                        AddNewUserOption();
                        break;
                    case "n":
                        ClearConsole();
                        Welcome();
                        MenuOptions();
                        break;
                }
            }
            
            var newUser = new User()
            {
                Name = name ?? string.Empty,
                Email = email ?? string.Empty,
                Bio = bio ?? string.Empty,
                Slug = slug ?? string.Empty,
                Image = "https://image.png",
                PasswordHash = password ?? string.Empty,
            };
            
            UsersRepository.Add(newUser);
            SuccessConsoleMessage("New user created!");
            
            Console.Write("Add new user? (y/n): ");
            var optionToAddNewUser = (Console.ReadLine() ?? string.Empty);
            switch (optionToAddNewUser)
            {
                case "y":
                    ClearConsole();
                    AddNewUserOption();
                    break;
                case "n":
                    ClearConsole();
                    Welcome();
                    MenuOptions();
                    break;
            }
        }
     }
}
