using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiltonProject.DAL.DTOs
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public int UploaderId { get; set; }
        public int BillingUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime DeadLine { get; set; }
        public string? FileName { get; set; }
        public bool IsAccepted { get; set; }

    }
}
