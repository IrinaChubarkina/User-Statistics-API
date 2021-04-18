using System.ComponentModel.DataAnnotations;

namespace Domain.Core.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        
        [Required]
        public string RegistrationDate { get; set; }
        
        [Required]
        public string LastActivityDate { get; set; }
    }
}