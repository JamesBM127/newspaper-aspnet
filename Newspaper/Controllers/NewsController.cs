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
        private readonly CategoryService _categoryService;

        public NewsController(NewsService newsService, AuthorService authorService, CategoryService categoryService)
        {
            _newsService = newsService;
            _authorService = authorService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _newsService.FindAllNewsAsync();
            NewspaperViewModel viewModel = new NewspaperViewModel() { NewsList = news };
            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            List<Author> authors = await _authorService.FindAllAuthorsAsync();
            List<Category> categories = await _categoryService.FindAllCategoriesAsync();
            var viewModel = new NewspaperViewModel() { Authors = authors, Categories = categories };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(News news)
        {
            if (ModelState.IsValid)
            {
                news.Date = DateTime.Now;
                await _newsService.InsertNewsToDbAsync(news);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit()
        {
            List<Author> authors = await _authorService.FindAllAuthorsAsync();
            List<Category> categories = await _categoryService.FindAllCategoriesAsync();
            var viewModel = new NewspaperViewModel() { Authors = authors, Categories = categories };
            return View(viewModel);
        }

        public async Task<IActionResult> ManagerNews()
        {
            var news = await _newsService.FindAllNewsAsync();
            return View(news);
        }
    }
}
