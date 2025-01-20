using dev_blog_dotnet.Models;
using dev_blog_dotnet.Repositories;
using dev_blog_dotnet.Utils;

namespace dev_blog_dotnet.Screens.PostScreen;

public static class CreatePostScreen
{
    public static void Display()
    {
        ConsoleUtils.ClearConsole();

        var categoryRepository = new Repository<Category>(Database.Connection!);
        var authorRepository = new Repository<User>(Database.Connection!);
        
        var categoryId = ConsoleUtils.Input("Category ID");
        var authorId = ConsoleUtils.Input("Author ID");
        var title = ConsoleUtils.Input("Title");
        var summary = ConsoleUtils.Input("Summary");
        var body = ConsoleUtils.Input("Body");

        IList<string> errors = new List<string>();
        
        var categoryExists = categoryRepository.GetById(Int32.Parse(categoryId!));  
        var authorExists = authorRepository.GetById(Int32.Parse(authorId!));
        
        if (categoryExists is null) errors.Add("Category does not exist");
        if (authorExists is null) errors.Add("Author does not exist");
        if (title is null) errors.Add("Title is required");
        if (summary is null) errors.Add("Summary is required");
        if (body is null) errors.Add("Body is required");
        
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
            var slug = title!.Replace(" ", "-").Trim().ToLower()!;
            var newPost = new Post()
            {
                Title = title!,
                Summary = summary!,
                Body = body!,
                CategoryId = Int32.Parse(categoryId!),
                AuthorId = int.Parse(authorId!),
                Slug = slug,
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
            };
            
            Create(newPost);
        }
    }

    private static void Create(Post post)
    {
        var postRepository = new Repository<Post>(Database.Connection!);

        try
        {
            postRepository.Add(post);
            ConsoleUtils.SuccessMessage("New post created!");
            ConsoleUtils.HandleQuestion("Add new post?", Display, Program.Main);
        }
        catch (Exception ex)
        {
            ConsoleUtils.ErrorMessage(ex.Message);
            ConsoleUtils.ErrorMessage("Error creating post");
            ConsoleUtils.HandleQuestion("Try again?", Display, Program.Main);
        }
    }
}