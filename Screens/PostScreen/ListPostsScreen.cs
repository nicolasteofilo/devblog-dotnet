using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;

namespace dev_blog_dotnet.Screens.PostScreen;

public class ListPostsScreen
{
    public static void Display()
    {
        ConsoleUtils.ClearConsole();
        List();
    }

    private static void List()
    {
        var postsRepository = new Repository<Post>(Database.Connection!);
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
}