using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootStrapProjectOne.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BootStrapProjectOne.Context
{
    public class ApplicationDataContext : IdentityDbContext<AppUser>
    {
        public ApplicationDataContext()
            : base("DefaultConnection")
        { }

        public System.Data.Entity.DbSet<AppUser> AppUsers { get; set; }

        public System.Data.Entity.DbSet<BootStrapProjectOne.Models.Student> Students { get; set; }
    }
}