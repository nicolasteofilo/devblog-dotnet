using Dapper.Contrib.Extensions;

namespace dev_blog_dotnet.Models;

[Table("[Role]")]
public class Role
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Slug { get; set; }
}