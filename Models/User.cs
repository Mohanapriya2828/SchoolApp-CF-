using System;

namespace SchoolApp.Models
{
    public enum Role
    {
        Student,
        Teacher
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public Role Designation { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Department { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
