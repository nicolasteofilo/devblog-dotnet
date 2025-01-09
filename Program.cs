using Dapper;
using dev_blog_dotnet.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

class Program
{
    private const string CONNECTION_STRING = @"Server=127.0.0.1,1433;Database=dev-blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true";    

    private static void Main(string[] args)
    {
        var users = GetUsers();
        var getUse = GetUserById(1);
    }

    private static IList<User> GetUsers()
    {
        using var connection = new SqlConnection(CONNECTION_STRING);
        var users = connection.GetAll<User>();
        return users.ToList();
    }

    private static User GetUserById(int userId) {
        using var connection = new SqlConnection(CONNECTION_STRING);
        var user = connection.Get<User>(userId);
        return user;
    }
}