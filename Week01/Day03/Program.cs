using System.Text.Json;
using Day03.Models;
using Day03.Repositories;

var repo = new ArticleRepository();
var startTime1 = DateTime.Now;
await Task.WhenAll(repo.GetByIdAsync(1), repo.GetByIdAsync(2));
var endTime1 = DateTime.Now;
Console.WriteLine($"並行總耗時：{(endTime1 - startTime1).TotalSeconds}");
var startTime2 = DateTime.Now;
await repo.GetByIdAsync(1);
await repo.GetByIdAsync(2);
var endTime2 = DateTime.Now;
Console.WriteLine($"依序總耗時：{(endTime2 - startTime2).TotalSeconds}");

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
if (test2?.Id == 1) Console.WriteLine("PASS");
else Console.WriteLine("FAIL");

var art = new Article(1, "C# Book", "Amy", 10, DateTime.Parse("2026-01-01"));
try
{
    await repo.AddAsync(art);
    Console.WriteLine("FAIL");
} catch (ArgumentException)
{
    Console.WriteLine("PASS");
}

Console.ReadKey();
