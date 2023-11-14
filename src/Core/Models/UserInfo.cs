using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class UserInfo
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserType { get; set; }

        public string? CompanyName { get; set; }

        [StringLength(22)]
        public string UserPhone { get; set; }
        public int UserInfoId { get; set; }
    }
}