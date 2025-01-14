using Dapper;
using Dapper.Contrib.Extensions;
using dev_blog_dotnet.Models;
using Microsoft.Data.SqlClient;

namespace dev_blog_dotnet.Repositories;

public class UserRepository(SqlConnection connection) : Repository<User>(connection)
{
    private readonly SqlConnection _connection = connection;
    
    public IList<User> GetWithRoles()
    {
        var query = @"SELECT [User].*, [Role].*
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
}