using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class JobInfo
    {
        [Key]
        public int JobID { get; set; }

        public DateTime JobCreationDate { get; set; }

        public string JobTitle { get; set; }

        [MaxLength(1024)]
        public string JobDescription { get; set; }

        [MaxLength(1024)]
        public string JobAddress { get; set; }
        [ForeignKey("JobCategory")]
        public int JobCategoryID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual UserInfo User { get; set; }

        public bool IsInativo { get; set; }
    }
}