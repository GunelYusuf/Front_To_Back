using System;
using System.ComponentModel.DataAnnotations;

namespace FronToBack.ViewModels
{
    public class LoginVM
    {
        [Required]

        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
