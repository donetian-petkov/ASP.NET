using System.ComponentModel.DataAnnotations;
using ForumDemo.Constants;
using ForumDemo.Data;
using ForumDemo.Data.Models;
using ForumDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

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
    public  IActionResult Add()
    {
        var model = new PostViewModel();

        ViewData["Title"] = "Add New Post";
        
        return View("Edit", model);
    }

    [HttpPost]
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
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        return View();
    }
    
   
}