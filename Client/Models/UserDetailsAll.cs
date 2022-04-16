﻿namespace miltonProject.Client.Models
{
    public class UserDetailsAll
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public bool IsBilling { get; set; }
        public bool IsActive { get; set; }
    }
}
