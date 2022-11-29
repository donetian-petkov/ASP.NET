using ForumDemo.Data;
using ForumDemo.Data.Models;
using ForumDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumDemo.Controllers;

public class PostsController : Controller
{

    private readonly ApplicationDbContext context;

    public PostsController(ApplicationDbContext _context)
    {
        context = _context;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var model = await context.Posts
            .Where(p => p.IsDeleted == false)
            .Select(p => new PostViewModel()
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content
            })
            .ToListAsync();

        return View(model);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var model = new AddPostViewModel();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(PostViewModel model)
    {

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        context.Posts.Add(new Post()
        {
            Title = model.Title,
            Content = model.Content
        });

        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));

    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var post = await context.Posts
            .Where(p => p.Id == id)
            .Select(p => new PostViewModel()
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content
            }).FirstOrDefaultAsync();

        if (post != null)
        {

            return View(post);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PostViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        var post = await context.Posts.FindAsync(model.Id);

        if (post != null)
        {
            post.Title = model.Title;
            post.Content = model.Content;
        }
        
        await context.SaveChangesAsync();
    
        return RedirectToAction(nameof(Index));
    }


/*[HttpPost]
public async Task<IActionResult> Edit(PostViewModel model)
{
    ViewData["Title"] = model.Id == 0 ? "Add New Post" : "Edit Post";

    if (!ModelState.IsValid)
    {
        return View(model);
    }

    if (model.Id == 0)
    {
        context.Add(new Post()
        {
            Id = model.Id,
            Title = model.Title,
            Content = model.Content
        });
    }
    else
    {
        var post = await context.Posts.FindAsync(model.Id);

        if (post != null)
        {
            post.Title = model.Title;
            post.Content = model.Content;
        }
    }

    await context.SaveChangesAsync();
    
    return RedirectToAction(nameof(Index));
}*/

    public async Task<IActionResult> Delete(int id)
    {
        
        var post = await context.Posts.FindAsync(id);

        if (post != null)
        {
            post.IsDeleted = true;

            await context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
    
    
   
}