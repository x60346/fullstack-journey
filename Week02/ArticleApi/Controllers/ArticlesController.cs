namespace Article.Controllers;

using Article.Models;
using Article.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ArticleController : ControllerBase
{
    private readonly ArticleRepository _Article;
    public ArticleController(ArticleRepository article)
    {
        _Article = article;
    }

    [HttpGet]
    public async Task<ActionResult> GetArticle()
    {
        return Ok(await _Article.GetAllAsync());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult> GetArticle(int Id)
    {
        var article = await _Article.GetByIdAsync(Id);
        if (article is null) return NotFound();
        return Ok(article);
    }
}