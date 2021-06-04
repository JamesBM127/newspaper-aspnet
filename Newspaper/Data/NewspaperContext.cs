using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Newspaper.Data
{
    public class NewspaperContext : DbContext
    {
        public NewspaperContext(DbContextOptions<NewspaperContext> options) : base(options)
        {
        }
    }
}
