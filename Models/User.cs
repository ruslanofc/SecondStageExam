using Microsoft.AspNetCore.Identity;
using System;

namespace SecondStageExam.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public int Passnum { get; set; }
        public Guid Card { get; set; }
    }
}
