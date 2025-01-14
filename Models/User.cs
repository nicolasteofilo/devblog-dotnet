using Dapper.Contrib.Extensions;

namespace dev_blog_dotnet.Models;

[Table("[User]")]
public class User()
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string Bio { get; set; }
    public required string Image { get; set; }
    public required string Slug { get; set; }
    
    [Write(false)]
    public IList<Role> Roles { get; set; } = new List<Role>();
}