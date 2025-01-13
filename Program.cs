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

        var users = GetUsers(connection);
        var roles = GetRoles(connection);
        
        Console.WriteLine($"There are a total of {users.Count()} user(s) registered in the database.");
        Console.WriteLine($"There are {roles.Count()} role(s) registered in the database."); 

        connection.Close();
    }

    private static IEnumerable<User> GetUsers(SqlConnection connection) => new UserRepository(connection).GetAll();

    private static User GetUserById(SqlConnection connection, int userId) => new UserRepository(connection).GetById(userId);

    private static void CreateUser(SqlConnection connection, User user) => new UserRepository(connection).Add(user);

    private static void UpdateUser(SqlConnection connection, User user) => new UserRepository(connection).Update(user);

    private static void DeleteUser(SqlConnection connection, int userId) => new UserRepository(connection).Delete(userId);
    
    private static void CreateRole(SqlConnection connection, Role role) => new RoleRepository(connection).Add(role);
    
    private static IEnumerable<Role> GetRoles(SqlConnection connection) => new RoleRepository(connection).GetAll();
}