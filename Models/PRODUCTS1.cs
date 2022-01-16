using System;
namespace FrontToBack.Models
{
    public class PRODUCTS1
    {
        public int Id{ get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public virtual CATEGORY1 CATEGORY1 { get; set; }

      
    }
}
