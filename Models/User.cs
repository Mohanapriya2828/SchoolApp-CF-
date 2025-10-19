using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace SchoolApp.Models
{ 
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DOB { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Department { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


        public void HashPassword()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: this.PasswordHash,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            this.PasswordHash = $"{Convert.ToBase64String(salt)}.{hashed}";
        }
        public bool VerifyPassword(string input)
        {
            var parts = this.PasswordHash.Split('.');
            if (parts.Length != 2) return false;

            var salt = Convert.FromBase64String(parts[0]);
            var hash = parts[1];

            string hashedInput = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: input,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hash == hashedInput;
        }
    }
}
