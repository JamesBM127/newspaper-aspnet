using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public ICollection<News> News { get; set; }

        public Category()
        {
        }

        public Category(string name)
        {
            Name = name;
        }
    }
}
