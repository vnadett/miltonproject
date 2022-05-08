using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiltonProject.DAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [DisplayName("Email cím")]
        public string Email { get; set; }
        [MaxLength(200)]
        [DisplayName("Felhasználónév")]
        public string UserName { get; set; }
        [MaxLength(200)]
        [DataType(DataType.Password)]
        [DisplayName("Jelszó")]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public int Role { get; set; }
    }
}
