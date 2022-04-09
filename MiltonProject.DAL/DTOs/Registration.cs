using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiltonProject.DAL.DTOs
{
    public class Registration
    {
        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Az email cím nem megfelelő!")]
        [DisplayName("Email cím")]
        public string Email { get; set; }
        [Required]
        [MaxLength(200)]
        [DisplayName("Felhasználónév")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        [DisplayName("Jelszó")]
        public string Password { get; set; }

        [NotMapped]
        [DisplayName("Jelszó megerősítése")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string? Error { get; set; }
        public bool Success { get; set; }
        public int Role { get; set; }
    }
}
