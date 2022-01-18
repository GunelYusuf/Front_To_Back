using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FrontToBack.Models
{
    public class PRODUCTS1
    {
        public int Id{ get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public int CATEGORY1Id { get; set; }

        public virtual CATEGORY1 CATEGORY1 { get; set; }

        [NotMapped]
        [Required]

        public IFormFile ImageProduct { get; set; }

    }
}
