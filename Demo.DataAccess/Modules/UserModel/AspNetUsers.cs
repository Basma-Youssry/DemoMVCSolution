using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Modules.IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace Demo.DataAccess.Modules.UserModel
{
    public class AspNetUsers (UserManager<ApplicationUser> _userManager)
    {

        public int Id { get; set; }

        public string FName { get; set; } = null!;

        public string LName { get; set; } = null!;

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
