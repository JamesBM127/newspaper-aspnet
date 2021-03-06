using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newspaper.Data;
using Newspaper.Models;

namespace Newspaper.Services
{
    public class NewsService
    {
        private readonly NewspaperContext _newspaperContext;

        public NewsService()
        {
        }

        public NewsService(NewspaperContext newspaperContext)
        {
            _newspaperContext = newspaperContext;
        }

        public async Task<News> FindByIdAsync(int id)
        {
            return await _newspaperContext.News.FindAsync(id);
        }

        public async Task<List<News>> FindAllNewsAsync()
        {
            return await _newspaperContext.News
                .OrderByDescending(obj => obj.Date)
                .ToListAsync();
        }

        public async Task InsertNewsToDbAsync(News news)
        {
            _newspaperContext.Add(news);
            await _newspaperContext.SaveChangesAsync();
        }

        public async Task UpdateNewsAsync(News news)
        {
            _newspaperContext.Update(news);
            await _newspaperContext.SaveChangesAsync();
        }

        public async Task<List<News>> FindNewsBySearch(string search)
        {
            return await _newspaperContext.News
                .Where(
                    obj => obj.Title.Contains(search) ||
                    obj.Body.Contains(search) ||
                    obj.Category.Name.Contains(search))
                .OrderByDescending(obj => obj.Date)
                .ToListAsync();
        }
    }
}
