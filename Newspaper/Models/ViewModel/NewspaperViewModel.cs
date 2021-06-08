using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newspaper.Services;

namespace Newspaper.Models.ViewModel
{
    public class NewspaperViewModel
    { 
        public News News { get; set; }
        public ICollection<News> NewsList { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
