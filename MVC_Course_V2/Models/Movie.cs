using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace MVC_Course_V2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime? DateAdded { get; set; }
        [Required]
        [Display(Name ="Number In Stock")]
        //[Between1And20]
        [Range(1,20)]
        public int NumberInStock { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display(Name ="Genre")]
        public byte GenreId { get; set; }
    }

}