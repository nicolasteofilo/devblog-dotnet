using Dapper.Contrib.Extensions;
using dev_blog_dotnet.Models;
using Microsoft.Data.SqlClient;

namespace dev_blog_dotnet.Repositories;

public class RoleRepository(SqlConnection connection) : IGenericRepository<Role>
{
    private readonly SqlConnection _connection = connection;
    
    public Role GetById(int id)
    {
        return _connection.Get<Role>(id);
    }

    public IEnumerable<Role> GetAll() => _connection.GetAll<Role>();

    public bool Add(Role entity)
    {
        var rows = _connection.Insert<Role>(entity);
        return rows >  0;
    }

    public bool Update(Role entity)
    {
        var status = _connection.Update<Role>(entity);
        return status;
    }

    public bool Delete(int id)
    {
        var role = _connection.Get<Role>(id);
        var rows = _connection.Insert<Role>(role);
        return rows >  0;
    }

    public bool Delete(Role entity)
    {
        var status = _connection.Delete<Role>(entity);
        return status;
    }
}