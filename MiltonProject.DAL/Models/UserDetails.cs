using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiltonProject.DAL.Models
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        [DisplayName("Keresztnév")]
        [Required(ErrorMessage = "Keresztnév megadása kötelező")]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [DisplayName("Vezetéknév")]
        [Required(ErrorMessage = "Vezetéknév megadása kötelező")]
        public string LastName { get; set; }
        public int UserId { get; set; }
        public bool IsBilling { get; set; }
        public bool IsActive { get; set; }
    }
}
