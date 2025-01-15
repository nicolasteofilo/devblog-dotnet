using Dapper.Contrib.Extensions;

namespace dev_blog_dotnet.Models;

[Table("[Category]")]
public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Slug { get; set; }
    
    [Write(false)]
    public IList<Post> Posts { get; set; } = new List<Post>();
}