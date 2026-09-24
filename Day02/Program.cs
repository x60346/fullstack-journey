using System.Text.RegularExpressions;

List<Article> Articles = new List<Article>
{
    new Article(1, "C# Book", "Amy", 10, DateTime.Parse("2026-01-01")),
    new Article(2, "C++ Book", "David", 50, DateTime.Parse("2026-02-02")),
    new Article(3, "Be Good in C#", "Anita", 100, DateTime.Parse("2026-03-03")),
    new Article(4, "Something Good", "Amy", 150, DateTime.Parse("2026-04-04")),
    new Article(5, "Just a Book", "Amy", 200, DateTime.Parse("2026-05-05"))
};

IEnumerable<string> over100 = Articles
    .Where(item => item.Views > 100)
    .Select(item => item.Title);
IEnumerable<Article> orderByCreatedAt = Articles
    .OrderByDescending(item => item.CreatedAt);
IEnumerable<(string Author,int Views)> allViews = Articles
    .Select(item => (item.Author, item.Views));
Dictionary<string, int> everyViews = new Dictionary<string, int>();
foreach (var item in allViews)
{
    if (everyViews.TryGetValue(item.Author, out int value))
    {
        everyViews[item.Author] = value + item.Views;
    }
    else
    {
        everyViews[item.Author] = item.Views;
    }
}
IEnumerable<string> includeC = Articles
    .Where (item => item.Title.Contains("C#"))
    .Select(item => item.Title);

Console.WriteLine("5.");
Console.WriteLine($"Views 超過 100 的文章標題： {string.Join("、", over100)}");
Console.WriteLine("依 CreatedAt 由新到舊排序：");
foreach (var item in orderByCreatedAt)
{
    Console.WriteLine($"{item.Title} write by {item.Author}" );
}
Console.WriteLine("某個作者的總瀏覽數：");
foreach(var item in everyViews)
{
    Console.WriteLine($"{item.Key}： {item.Value}");
}
Console.WriteLine($"有沒有標題包含「C#」的文章： {string.Join("、", includeC)}");

Console.WriteLine("\n6.");

List<int> test1 = [1, 2, 3];
List<int> test2 = [1, 1, 1];
List<int> test3 = [0];

int allSum1 = test1
    .Where(item => item % 2 == 0)
    .Sum();
int allSum2 = test2
    .Where(item => item % 2 == 0)
    .Sum();
int allSum3 = test3
    .Where(item => item % 2 == 0)
    .Sum();

Console.WriteLine($"test1： {allSum1}");
Console.WriteLine($"test2： {allSum2}");
Console.WriteLine($"test3： {allSum3}");


public class Article
{
    public int Id = 0;
    public string Title = "";
    public string Author = "";
    public int Views = 0;
    public DateTime CreatedAt;

    public Article()
    {

    }

    public Article(int id, string title, string author, int views, DateTime createdAt)
    {
        Id = id;
        Title = title;
        Author = author;
        Views = views;
        CreatedAt = createdAt;
    }
}