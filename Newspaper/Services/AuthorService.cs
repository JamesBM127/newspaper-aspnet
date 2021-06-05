using Microsoft.EntityFrameworkCore;
using Newspaper.Data;
using Newspaper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Services
{
    public class AuthorService
    {
        private readonly NewspaperContext _newspaperContext;

        public AuthorService()
        {
        }

        public AuthorService(NewspaperContext newspaperContext)
        {
            _newspaperContext = newspaperContext;
        }

        public async Task<List<Author>> FindAllAuthors()
        {
            return await _newspaperContext.Authors
                .OrderBy(obj => obj.Name)
                .ToListAsync();
        }

        public async Task InsertAuthorToDbAsync(Author author)
        {
            _newspaperContext.Add(author);
            await _newspaperContext.SaveChangesAsync();
        }
    }
}
