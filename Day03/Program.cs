using System.Text.Json;
using ArticleModel;

var repo = new ArticleRepository();
var startTime = DateTime.Now;
//Article article1 = await repo.GetByIdAsync(1);
//Article article2 = await repo.GetByIdAsync(2);
await Task.WhenAll(repo.GetByIdAsync(1), repo.GetByIdAsync(2));
var endTime = DateTime.Now;
Console.WriteLine($"總耗時：{(endTime - startTime).TotalSeconds}");

//Console.WriteLine(JsonSerializer.Serialize(article, new JsonSerializerOptions { WriteIndented = true}));

var articles = await repo.GetAllAsync();
var authorViews = articles
    .GroupBy(item => item.Author)
    .Select(items => new { Author = items.Key, Views = items.Sum(v => v.Views) });
foreach(var authorView in authorViews)
{
    Console.WriteLine($"作者：{authorView.Author}，觀看數：{authorView.Views}");
}

var test1 = await repo.GetByIdAsync(10);
if (test1 == null) Console.WriteLine("PASS");
else Console.WriteLine("FAIL");

var test2 = await repo.GetByIdAsync(1);
if (test2.Id == 1) Console.WriteLine("PASS");
else Console.WriteLine("FAIL");

var art = new Article(1, "C# Book", "Amy", 10, DateTime.Parse("2026-01-01"));
try
{
    await repo.AddAsync(art);
    Console.WriteLine("FAIL");
} catch
{
    Console.WriteLine("PASS");
}

Console.ReadKey();
