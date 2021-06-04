using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newspaper.Models;

namespace Newspaper.Data
{
    public class NewspaperContext : DbContext
    {
        public NewspaperContext(DbContextOptions<NewspaperContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
