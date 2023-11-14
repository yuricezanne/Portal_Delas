using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class JobCategory
    {
        [Key]
        public int JobCategoryID { get; set; }

        public string CategoryName { get; set; }
    }
}