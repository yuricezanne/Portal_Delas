using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Models
{
    public class UserFavoriteJob
    {
        [Key]
        public int UserFavoriteJobID { get; set; }

        public int UserInfoID { get; set; }
        
        [ForeignKey("UserInfoID")]
        public UserInfo UserInfo { get; set; }

        public int JobID { get; set; }
        
        [ForeignKey("JobID")]
        public JobInfo JobInfo { get; set; }
    }
}
