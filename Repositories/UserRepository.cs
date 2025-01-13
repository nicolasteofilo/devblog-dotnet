using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;

using dev_blog_dotnet.Models;

namespace dev_blog_dotnet.Repositories;

public class UserRepository(SqlConnection connection) : IGenericRepository<User>
{
    private readonly SqlConnection _connection = connection;

    public bool Add(User entity)
    {
        var rows = _connection.Insert<User>(entity);
        return rows >  0;
    }

    public bool Delete(int id)
    {
        var user = _connection.Get<User>(id);
        var rows = _connection.Insert<User>(user);
        return rows >  0;
    }
    
    public bool Delete(User entity)
    {
        var status = _connection.Delete<User>(entity);
        return status;
    }

    public IEnumerable<User> GetAll() => _connection.GetAll<User>();

    public User GetById(int id)
    {
        return _connection.Get<User>(id);
    }

    public bool Update(User entity)
    {
        var status = _connection.Update<User>(entity);
        return status;
    }
}