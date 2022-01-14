using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FrontToBack.Models
{
    public class CATEGORY1
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name{ get; set; }

        public string Description { get; set; }

        public string DataId{ get; set; }

        public ICollection<PRODUCTS1> pRODUCTS1s { get; set; }
    }
}
