using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class UserLoginInfo
    {
        [Key]
        public int UserInfoId { get; set; }

        [Required(ErrorMessage = "The 'Username/Email' field is required.")]
        [MaxLength(50, ErrorMessage = "The 'Username' field must have a maximum of 50 characters.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "It must be an email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The 'Password' field is required.")]
        [MaxLength(255, ErrorMessage = "The 'Password' field must have a maximum of 255 characters.")]
        public string Password { get; set; }
    }
}