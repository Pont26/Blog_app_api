using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Blog_api.Data;
using Blog_api.Models;


namespace Blog_api.Controller;

public class BlogsController : ODataController
{
  private readonly DataContext _db;
  private readonly ILogger<BlogsController> _logger;

  public BlogsController(DataContext dbContext, ILogger<BlogsController> logger)
  {
    _db = dbContext;
    _logger = logger;
  }

  [EnableQuery(PageSize = 15)]
  public IQueryable<Blog> Get()
  {
    return _db.Blogs;
  }

  [EnableQuery]
  public SingleResult<Blog> Get([FromODataUri] Guid key)
  {
    var result = _db.Blogs.Where(e => e.Id == key);
    return SingleResult.Create(result);
  }

  [EnableQuery]
  public async Task<IActionResult> Post([FromBody] Blog Blog)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    Blog.CreatedAt = DateTime.UtcNow; 
    Blog.UpdatedAt = DateTime.UtcNow; 
    _db.Blogs.Add(Blog);
    await _db.SaveChangesAsync();
    return Created(Blog);
  }

  [EnableQuery]
  public async Task<IActionResult> Patch([FromODataUri] Guid key, Delta<Blog> Blog)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    var exisitngBlog = await _db.Blogs.FindAsync(key);
    if (exisitngBlog == null)
    {
      return NotFound();
    }
    Blog.Patch(exisitngBlog);
    try
    {
      await _db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!BlogExist(key))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }
    return Updated(exisitngBlog);
  }

  [EnableQuery]
public async Task<IActionResult> Delete([FromODataUri] Guid key)
{
    var existingBlog = await _db.Blogs.FindAsync(key);
    if (existingBlog == null)
    {
        return NotFound();
    }

    existingBlog.DeletedAt = DateTime.UtcNow; 
    _db.Blogs.Update(existingBlog);
    await _db.SaveChangesAsync();

    return StatusCode(StatusCodes.Status204NoContent);
}


  private bool BlogExist(Guid key)
  {

    return _db.Blogs.Any(p => p.Id == key);

  }
}