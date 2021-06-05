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
    }
}
