using Dapper.Contrib.Extensions;
using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Screens.ManagementScreen;
using dev_blog_dotnet.Screens.UserScreen;
using dev_blog_dotnet.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace dev_blog_dotnet
{
    public class Program
    {
        private const string ConnectionString = @"Server=127.0.0.1,1433;Database=dev-blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true";

        public static void Main()
        {
            Database.Connection = new SqlConnection(ConnectionString);
            Database.Connection.Open();
            ConsoleUtils.ClearConsole();
            Welcome();
            MenuOptions();
            Database.Connection.Close();
        }

        private static void Welcome()
        {
            Console.WriteLine(@"
 __   ___          __        __   __  
|  \ |__  \  /    |__) |    /  \ / _` 
|__/ |___  \/     |__) |___ \__/ \__> 
            ");
        }
        
        private static void MenuOptions()
        {
            MenuManagementScreen.Display();
        }
     }
}
