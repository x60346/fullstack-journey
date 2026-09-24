List<Article> articles = new List<Article>
{
    new Article(1, "C# Book", "Amy", 10, DateTime.Parse("2026-01-01")),
    new Article(2, "C++ Book", "David", 50, DateTime.Parse("2026-02-02")),
    new Article(3, "Be Good in C#", "Anita", 100, DateTime.Parse("2026-03-03")),
    new Article(4, "Something Good", "Amy", 150, DateTime.Parse("2026-04-04")),
    new Article(5, "Just a Book", "Amy", 200, DateTime.Parse("2026-05-05"))
};

IEnumerable<string> over100 = articles
    .Where(item => item.Views > 100)
    .Select(item => item.Title);
IEnumerable<Article> orderByCreatedAt = articles
    .OrderByDescending(item => item.CreatedAt);
IEnumerable<IGrouping<string, Article>> everyViews = articles.GroupBy(item => item.Author);
bool includeC = articles
    .Any(item => item.Title.Contains("C#"));

Console.WriteLine("5.");
Console.WriteLine($"Views 超過 100 的文章標題： {string.Join("、", over100)}");
Console.WriteLine("依 CreatedAt 由新到舊排序：");
foreach (var item in orderByCreatedAt)
{
    Console.WriteLine($"{item.Title} write by {item.Author}" );
}
Console.WriteLine("某個作者的總瀏覽數：");
foreach(var arthor in everyViews)
{
    Console.Write($"{arthor.Key}：");
    int counts = 0;
    foreach(var views in arthor)
    {
        counts = counts + views.Views;
    }
    Console.WriteLine(counts);
}
Console.WriteLine($"有沒有標題包含「C#」的文章： {includeC}");

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
if(allSum1 == 2)
{
    Console.WriteLine("PASS");
} else
{
    Console.WriteLine("FAIL");
}
if (allSum2 == 0)
{
    Console.WriteLine("PASS");
}
else
{
    Console.WriteLine("FAIL");
}
if (allSum3 == 0)
{
    Console.WriteLine("PASS");
}
else
{
    Console.WriteLine("FAIL");
}


public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Views { get; set; }
    public DateTime CreatedAt { get; set; }

    public Article(int id, string title, string author, int views, DateTime createdAt)
    {
        Id = id;
        Title = title;
        Author = author;
        Views = views;
        CreatedAt = createdAt;
    }
}