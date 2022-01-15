using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FrontToBack.Models
{
    public class CATEGORY1
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "do not leave empty")]
        public string Name{ get; set; }
        [MaxLength(10,ErrorMessage= "Must be less than 100")]
        public string Description { get; set; }

        public string DataId{ get; set; }

        public ICollection<PRODUCTS1> pRODUCTS1s { get; set; }
    }
}
