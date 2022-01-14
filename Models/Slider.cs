using System.ComponentModel.DataAnnotations;

namespace FrontToBack.Models
{
    public class Slider
    {
        public int Id{ get; set; }
        [Required,StringLength(260),MinLength(5)]
        public string ImageUrl { get; set; }

        
    }
}
