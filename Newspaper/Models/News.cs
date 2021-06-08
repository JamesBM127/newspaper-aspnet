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
        [StringLength(100, MinimumLength = 1, ErrorMessage = "{0} deve ser maior que {2} e menor que {1}")]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }
        public string ImagePath { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }

        [Required]
        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public News()
        {
        }

        public News(string title, string body, string imagePath, DateTime date, Author author, Category category)
        {
            Title = title;
            Body = body;
            ImagePath = imagePath;
            Date = date;
            Author = author;
            Category = category;
        }
    }
}
