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
        public string JobDescription { get; set; }

        [MaxLength(1024)]
        public string JobAddress { get; set; }

        public int? JobCategoryId { get; set; }

        [ForeignKey("JobCategoryId")]
        public JobCategory JobCategory { get; set; }

        public string JobTitle { get; set; }
        
        public bool IsInativo { get; set; }
        
        public List<UserFavoriteJob> UsersWhoFavorited { get; set; }
    }
}