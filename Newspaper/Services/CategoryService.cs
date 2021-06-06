using Microsoft.EntityFrameworkCore;
using Newspaper.Data;
using Newspaper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Services
{
    public class CategoryService
    {
        private readonly NewspaperContext _newspaperContext;

        public CategoryService()
        {
        }

        public CategoryService(NewspaperContext newspaperContext)
        {
            _newspaperContext = newspaperContext;
        }

        public async Task<List<Category>> FindAllCategoriesAsync()
        {
            return await _newspaperContext.Categories
                .OrderBy(obj => obj.Name)
                .ToListAsync();
        }

        public async Task InsertCategoryToDbAsync(Category category)
        {
            _newspaperContext.Add(category);
            await _newspaperContext.SaveChangesAsync();
        }
    }
}
