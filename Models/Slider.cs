using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FrontToBack.Models
{
    public class Slider
    {
        public int Id{ get; set; }
        [StringLength(260),MinLength(5)]

        public string ImageUrl { get; set; }

        [NotMapped]
        [Required]

        public IFormFile Photo { get; set; }
    }
}
