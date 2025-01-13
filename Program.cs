using Dapper.Contrib.Extensions;
using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using Microsoft.Data.SqlClient;

class Program
{
    private const string CONNECTION_STRING = @"Server=127.0.0.1,1433;Database=dev-blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true";

    public static void Main()
    {
        var connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();

        var userRepository = new Repository<User>(connection);
        var rolesRepository = new Repository<Role>(connection);
        
        Console.WriteLine($"There are a total of {userRepository.GetAll().Count()} user(s) registered in the database.");
        Console.WriteLine($"There are {rolesRepository.GetAll().Count()} role(s) registered in the database."); 

        connection.Close();
    }
}