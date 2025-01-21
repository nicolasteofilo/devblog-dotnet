using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;
using Microsoft.IdentityModel.Tokens;

namespace dev_blog_dotnet.Screens.PostScreen;

public class ListPostsScreen
{
    public static void Display()
    {
        ConsoleUtils.InfoMessage("Filters (Leave blank and press ENTER if you do not want to filter)");
        var categoryId = ConsoleUtils.Input("Category ID (Optional, to filter by category)");
        
        if(!categoryId.IsNullOrEmpty())
        {
            List(int.Parse(categoryId!));
        }
        else
        {
            List();
        };
    }

    private static void List()
    {
        var postsRepository = new PostRepository(Database.Connection!);
        
        var posts = postsRepository.GetAll().ToList();
        foreach (var post in posts)
        {
            Console.WriteLine($"Id: {post.Id}, Title: {post.Title}, Created At: {post.CreateDate}");
        }
        
        if (posts.Count < 1)
        {
            Console.WriteLine("No posts found.");
        }

        ConsoleUtils.BackToMenuQuestion();
    }

    private static void List(int categoryId)
    {
        var postsRepository = new PostRepository(Database.Connection!);
        
        var posts = postsRepository.GetAllByCategoryId(categoryId).ToList();
        foreach (var post in posts)
        {
            Console.WriteLine($"Id: {post.Id}, Title: {post.Title}, Created At: {post.CreateDate}");
        }
        
        if (posts.Count < 1)
        {
            Console.WriteLine("No posts found.");
        }

        ConsoleUtils.BackToMenuQuestion();
    }
}