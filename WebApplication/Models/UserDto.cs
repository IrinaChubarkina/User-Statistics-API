using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        
        [Required]
        public DateTime RegistrationDate { get; set; }
        
        [Required]
        public DateTime LastActivityDate { get; set; }
    }
}