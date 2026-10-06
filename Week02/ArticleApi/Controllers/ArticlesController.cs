namespace ArticleApi.Controllers;

using ArticleApi.Models;
using ArticleApi.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ArticlesController : ControllerBase
{
    private readonly ArticleRepository _repository;
    public ArticlesController(ArticleRepository article)
    {
        _repository = article;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Article>>> GetArticle()
    {
        return await _repository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetArticle(int id)
    {
        var article = await _repository.GetByIdAsync(id);
        if (article is null) return NotFound();
        return Ok(article);
    }
}