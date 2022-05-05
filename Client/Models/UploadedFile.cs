namespace miltonProject.Client.Models
{
    public class UploadedFile
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public int BillingId { get; set; }
    }
}
