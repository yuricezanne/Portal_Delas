using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class LoginResultModel
    {
        public string? LoginType { get; set; }
        public string? Name { get; set; }
        public string? CompanyName { get; set; }
        public int? UserInfoId { get; set; }
    }
}
