using System.ComponentModel.DataAnnotations;
using ForumDemo.Data;
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

    public async Task<IActionResult> Edit(int id)
    {
        return View();
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        return View();
    }
    
    public async Task<IActionResult> Add(int id)
    {
        return View();
    }
}