using Dapper;
using dev_blog_dotnet.Models;
using Microsoft.Data.SqlClient;

namespace dev_blog_dotnet.Repositories;

public class PostRepository(SqlConnection connection) : Repository<Post>(connection)
{
    private readonly SqlConnection _connection = connection;

    public IList<Post> GetAllByCategoryId(int categoryId)
    {
        const string query = @"SELECT [Post].*
                    FROM
                        [Post]
                        WHERE [Post].[CategoryId] = @CategoryId
    ";
        
        var posts = _connection.Query<Post>(query, new { CategoryId = categoryId }).ToList();

        return posts;
    }
}