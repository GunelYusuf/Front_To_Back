using System;
using System.ComponentModel.DataAnnotations;

namespace FronToBack.Areas.AdminArea.ViewModels
{
    public class CreateUserVM
    {
        [Required, StringLength(40)]

        public string UserName { get; set; }


        [Required, StringLength(40)]

        public string FullName { get; set; }

        [Required, StringLength(50)]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password), Compare(nameof(Password))]

        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
    }
}
