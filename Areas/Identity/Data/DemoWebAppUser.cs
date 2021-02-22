using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DemoWebApp.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the DemoWebAppUser class
    public class DemoWebAppUser : IdentityUser
    {
        [Column(TypeName ="varchar(50)")]
        public string UserType { get; set; }
    }
}
