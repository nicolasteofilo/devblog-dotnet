using Dapper.Contrib.Extensions;

namespace dev_blog_dotnet.Models;

[Table("[Post]")]
public class Post
{
    public int Id { get; set; }
    public required int CategoryId { get; set; }
    public required int AuthorId { get; set; }
    public required string Title { get; set; }
    public required string Summary { get; set; }
    public required string Body { get; set; }
    public required string Slug { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
}