using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _72HourProject.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        public virtual List<Post> Posts { get; set; }
        public Guid AuthorId { get; set; }
    }
}