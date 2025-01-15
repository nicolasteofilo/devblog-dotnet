using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace dev_blog_dotnet.Repositories;

public class Repository<TModel>(SqlConnection connection) : IGenericRepository<TModel> where TModel : class
{
    private readonly SqlConnection _connection = connection;
    
    public IEnumerable<TModel> GetAll() => _connection.GetAll<TModel>();
    
    public TModel? GetById(int id) => _connection.Get<TModel>(id);
    
    public bool Add(TModel entity) => _connection.Insert(entity) > 0;

    public bool Update(TModel entity) => _connection.Update<TModel>(entity);

    public bool Delete(int id) => _connection.Delete(_connection.Get<TModel>(id));

    public bool Delete(TModel entity) => _connection.Delete(entity);
}