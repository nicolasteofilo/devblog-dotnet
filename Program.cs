using Dapper.Contrib.Extensions;
using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using Microsoft.Data.SqlClient;

namespace dev_blog_dotnet
{
    class Program
    {
        private const string ConnectionString = @"Server=127.0.0.1,1433;Database=dev-blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true";

        public static void Main()
        {
            Welcome();
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            MenuOptions();
            
            var userRepository = new UserRepository(connection);
            var rolesRepository = new Repository<Role>(connection);
            var tagsRepository = new Repository<Tag>(connection);
        
            connection.Close();
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
        }
     }
}
