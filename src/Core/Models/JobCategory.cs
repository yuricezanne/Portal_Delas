using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class JobCategory
    {
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }

        public List<JobInfo> Jobs { get; set; }
    }
}