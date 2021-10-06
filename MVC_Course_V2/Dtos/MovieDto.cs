using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Course_V2.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime? DateAdded { get; set; }
        [Required]
        
        
        [Range(1, 20)]
        public int NumberInStock { get; set; }
        
        [Required]
        
        public byte GenreId { get; set; }
    }
}