using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class JobCategory
    {
        public string CategoryName { get; set; }
        [Key]
        public int CategoryId { get; set; }
    }
}