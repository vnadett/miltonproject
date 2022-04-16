namespace miltonProject.Client.Models
{
    public class BillingRequest
    {
        public int Id { get; set; }
        public int UploaderId { get; set; }
        public int BillingUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
