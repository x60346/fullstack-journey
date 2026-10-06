namespace ArticleApi.Repositories;
using ArticleApi.Models;

public class ArticleRepository
{
    List<Article> articles = new List<Article>
    {
        new Article(1, "C# Book", "Amy", 10, DateTime.Parse("2026-01-01")),
        new Article(2, "C++ Book", "David", 50, DateTime.Parse("2026-02-02")),
        new Article(3, "Be Good in C#", "Anita", 100, DateTime.Parse("2026-03-03")),
        new Article(4, "Something Good", "Amy", 150, DateTime.Parse("2026-04-04")),
        new Article(5, "Just a Book", "Amy", 200, DateTime.Parse("2026-05-05"))
    };

    public async Task<List<Article>> GetAllAsync()
    {
        await Task.Delay(300);
        return articles;
    }

    public async Task<Article?> GetByIdAsync(int id)
    {
        await Task.Delay(300);
        return articles.Find(a => a.Id == id);
    }

    public async Task AddAsync(Article article)
    {
        await Task.Delay(300);
        if (articles.Find(a => a.Id == article.Id) != null)
        {
            throw new ArgumentException("Id 不可重複");
        }
        else articles.Add(article);
        // method intentionally returns Task (no value)
    }
}