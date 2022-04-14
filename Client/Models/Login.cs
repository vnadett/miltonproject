namespace miltonProject.Client.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string? Error { get; set; }
        public bool? Success { get; set; }
        public int Role { get; set; }
    }
}
