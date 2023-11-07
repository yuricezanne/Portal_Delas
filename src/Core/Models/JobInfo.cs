using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class JobInfo
    {
        [Key]
        public int JobID { get; set; }

        public DateTime JobCreationDate { get; set; }

        public DateTime JobDate { get; set; }

        [MaxLength(1024)]
        public string JobDescription { get; set; }

        [MaxLength(1024)]
        public string JobAddress { get; set; }

        public string JobCategory { get; set; }
    }
}