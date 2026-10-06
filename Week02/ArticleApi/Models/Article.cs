namespace ArticleApi.Models;

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

