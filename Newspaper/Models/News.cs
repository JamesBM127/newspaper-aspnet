using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newspaper.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }
        public DateTime Date { get; set; }

        public Author Author { get; set; }
        public Category Category { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

        public News()
        {
        }

        public News(string title, string body, DateTime date, Author author, Category category)
        {
            Title = title;
            Body = body;
            Date = date;
            Author = author;
            Category = category;
        }
    }
}
