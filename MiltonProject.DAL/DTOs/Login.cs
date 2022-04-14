using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiltonProject.DAL.DTOs
{
    public class Login
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        [DisplayName("Felhasználónév")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        [DisplayName("Jelszó")]
        public string Password { get; set; }

        public string? Error { get; set; }
        public bool? Success { get; set; }
        public int? Role { get; set; }
    }
}
