using Dapper;
using dev_blog_dotnet.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

class Program
{
    private const string CONNECTION_STRING = @"Server=127.0.0.1,1433;Database=dev-blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true";    

    private static void Main()
    {
        var allusers = GetUsers();
        Console.WriteLine($"{allusers.Count} users");

        // var fistUser = GetUserById(1);
        var newUser = new User(){
            Id = 5,
            Name = "John Doe [edited]",
            Email = "johndoe2@dev.com",
            Bio = "Front-end developer",
            Image = "https://image.png",
            PasswordHash = "hashpass",
            Slug = "john-doe-2"
        };

        // CreateUser(newUser);
        // UpdateUser(newUser);
        // DeleteUser(2);
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

    private static void CreateUser(User user) {
        using var connection = new SqlConnection(CONNECTION_STRING);
        connection.Insert<User>(user);
    }

    private static void UpdateUser(User user) {
        var connection = new SqlConnection(CONNECTION_STRING);
        connection.Update<User>(user);
    }

    private static void DeleteUser(int userId) {
        var connection = new SqlConnection(CONNECTION_STRING);
        var userToBeDeleted = connection.Get<User>(userId);
        connection.Delete<User>(userToBeDeleted);
    }
}