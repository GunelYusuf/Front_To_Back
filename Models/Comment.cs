using System;
using FrontToBack.Models;

namespace FronToBack.Models
{
    public class Comment
    {
        public int Id{ get; set; }

        public string Comments { get; set; }

        public AppUser User { get; set; }

        public int PRODUCTS1Id { get; set; }

        public PRODUCTS1 PRODUCTS1 { get; set; }
    }
}
