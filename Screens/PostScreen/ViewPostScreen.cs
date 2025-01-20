using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;

namespace dev_blog_dotnet.Screens.PostScreen;

public class ViewPostScreen
{
    public static void Display()
    {
        ConsoleUtils.ClearConsole();
        var id = ConsoleUtils.Input("ID");

        IList<string> errors = new List<string>();
        
        var postsRepository = new Repository<Post>(Database.Connection!);

        var postExist = postsRepository.GetById(int.Parse(id!));
        
        if (postExist is null) errors.Add("Post does not exist");
        
        if (errors.Any())
        {
            ConsoleUtils.ClearConsole();
            Console.WriteLine(ConsoleUtils.BoldText("Errors: "));
            foreach (var err in errors)
            {
                ConsoleUtils.ErrorMessage(err);    
            }
            
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
        }
        else
        {
            ViewPost(int.Parse(id!));
        }
    }

    private static void ViewPost(int postId)
    {
        var postsRepository = new Repository<Post>(Database.Connection!);
        var post = postsRepository.GetById(postId);
        
        Console.WriteLine($"Id: {post!.Id}, Title: {post.Title}");
        Console.WriteLine($"Slug: {post.Slug}");
        Console.WriteLine($"Summary: {post.Summary}");
        Console.WriteLine($"Body: {post.Body}");
        Console.WriteLine($"CreateDate: {post.CreateDate}, LastUpdateDate: {post.LastUpdateDate}");
        ConsoleUtils.BackToMenuQuestion();
    }
}