using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newspaper.Services;
using Newspaper.Models;
using Newspaper.Models.ViewModel;

namespace Newspaper.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsService _newsService;
        private readonly AuthorService _authorService;

        public NewsController(NewsService newsService, AuthorService authorService)
        {
            _newsService = newsService;
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            List<News> news = await _newsService.FindAllNewsAsync();
            return View(news);
        }

        public async Task<IActionResult> Create()
        {
            List<Author> authors = await _authorService.FindAllAuthors();
            //List<Category> categories = 
            var viewModel = new NewspaperViewModel(){ Authors = authors};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(News news)
        {
            if (ModelState.IsValid)
            {
                await _newsService.InsertNewsToDbAsync(news);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
