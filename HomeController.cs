using Microsoft.AspNetCore.Mvc;
using webtintuc.Models;
using System.Linq;

public class HomeController : Controller
{
    private readonly DB _context;

    public HomeController(DB context)
    {
        _context = context;
    }

    public IActionResult Index(string category)
    {
        // Lấy tất cả bài viết nếu không có category, hoặc lọc theo category
        var articles = string.IsNullOrEmpty(category)
            ? _context.Articles.ToList()
            : _context.Articles.Where(a => a.Category == category).ToList();

        return View(articles);
    }

    public IActionResult Details(int id)
    {
        var article = _context.Articles.FirstOrDefault(a => a.Id == id);
        if (article == null)
        {
            return NotFound();
        }

        var allArticles = _context.Articles.Where(a => a.Id != id).ToList();
        ViewBag.AllArticles = allArticles;

        return View(article);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}