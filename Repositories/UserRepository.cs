using Dapper;
using Dapper.Contrib.Extensions;
using dev_blog_dotnet.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace dev_blog_dotnet.Repositories;

public class UserRepository(SqlConnection connection) : Repository<User>(connection)
{
    private readonly SqlConnection _connection = connection;
    
    public IList<User> GetWithRoles()
    {
        const string query = @"SELECT [User].*, [Role].*
                    FROM
                        [User]
                        LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                        LEFT JOIN [Role] ON [Role].[Id] = [UserRole].[RoleId]
    ";

        var users = new List<User>();

        var items = _connection.Query<User, Role, User>(query, (user, role) =>
        {
            var usr = users.FirstOrDefault(x => x.Id == user.Id);
            if (usr == null)
            {
                usr = user;
                if (role != null)
                {
                    usr.Roles.Add(role);
                }
                users.Add(usr);
            }
            else
            {
                usr.Roles.Add(role);
            }

            return user;
        }, splitOn: "Id");
        
        return users;
    }

    public User? GetByEmail(string email)
    {
        if (email.IsNullOrEmpty()) return null;
        
        const string query = "SELECT * FROM [User] WHERE [Email] = @email";

        var user = _connection.Query<User>(query,new { email }).FirstOrDefault();
        return user;
    }
    
    public User? GetByIdWithRoles(int id)
    {
        const string query = @"SELECT [User].*, [Role].*
                    FROM
                        [User]
                        LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                        LEFT JOIN [Role] ON [Role].[Id] = [UserRole].[RoleId]
                    WHERE [User].[Id] = @id
    ";

        User? usr = null;
        var user = _connection.Query<User, Role, User>(query, (user, role) =>
        {
            if (usr == null)
            {
                usr = user;
                if (role != null)
                {
                    usr.Roles.Add(role);
                }
            }
            else
            {
                usr.Roles.Add(role);
            }

            return user;
        }, new { id }).FirstOrDefault();
        return user;
    }
}