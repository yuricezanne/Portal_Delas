using System.ComponentModel.DataAnnotations;

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

        public string JobCategory { get; set; }
        public string JobTitle { get;  set; }
        public bool IsInativo { get;  set; }
        public List<UserFavoriteJob> UsersWhoFavorited { get; set; }

    }
}