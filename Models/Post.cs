namespace dev_blog_dotnet.Models;

public class Post
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required int CategoryId { get; set; }
}