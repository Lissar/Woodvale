using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLab2.Models
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
    }
}
