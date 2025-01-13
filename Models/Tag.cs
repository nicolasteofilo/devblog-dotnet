using Dapper.Contrib.Extensions;

namespace dev_blog_dotnet.Models;

[Table("[Tag]")]
public class Tag
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Slug { get; set; }
}