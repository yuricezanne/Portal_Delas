using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class JobInfo
    {
        [Key]
        public int JobID { get; set; }

        public DateTime JobCreationDate { get; set; }

        [MaxLength(1024)]
        public string JobTitle { get; set; }

        [MaxLength(1024)]
        public string JobDescription { get; set; }

       
        public string JobCategory { get; set; }
    
        public string JobAddress { get; set; }

        public bool IsInativo { get; set; }

        // Chave estrangeira para o criador do trabalho
        public int CreatedByUserId { get; set; }

        [ForeignKey("CreatedByUserId")]
        public UserInfo CreatedByUser { get; set; }

        public List<UserFavoriteJob> UsersWhoFavorited { get; set; }
    }
}