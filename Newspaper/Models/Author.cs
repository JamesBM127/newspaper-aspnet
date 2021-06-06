using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newspaper.Services;

namespace Newspaper.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        public ICollection<News> News { get; set; }

        public Author()
        {
        }

        public Author(string name)
        {
            Name = name;
        }

        public string FindAuthorName(int id)
        {
            return new AuthorService().FindAuthorNameByIdService(id);
        }
    }
}
