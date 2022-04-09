namespace miltonProject.Client.Models
{
    public class Registration
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
        public int Role { get; set; }
    }
}
