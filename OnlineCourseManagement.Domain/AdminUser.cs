using OnlineCourseManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Domain
{
    public class AdminUser : BaseEntity
    {
        
        public string UserName { get; set; } =string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string role { get; set; } = "Admin"; 

    }
}
