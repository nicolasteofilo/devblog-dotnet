using dev_blog_dotnet.Utils;

namespace dev_blog_dotnet.Screens.CategoryScreen;

public static class MenuCategoryScreen
{
    public static void Display()
    {
        Console.WriteLine(ConsoleUtils.BoldText("Categories: "));
        Console.WriteLine(" 1. List categories");
        Console.WriteLine(" 2. New category");
        Console.WriteLine(" 3. Update category");
        Console.WriteLine(" 4. Remove category");
        
        Console.Write("Your choice: ");
        var operation = float.Parse(Console.ReadLine() ?? string.Empty);
        
        switch (operation)
        {
            case 1:
                ConsoleUtils.ClearConsole();
                ListCategoriesScreen.Display();
                break;
            case 2:
                CreateCategoryScreen.Display();
                break;
            case 3:
                UpdateCategoryScreen.Display();
                break;
            case 4:
                DeleteCategoryScreen.Display();
                break;
        }
    }
}