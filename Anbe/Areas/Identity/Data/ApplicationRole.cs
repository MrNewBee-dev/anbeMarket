using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Anbe.Areas.Identity.Data
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {

        }

        public ApplicationRole(string name) : base(name)
        {

        }



        public virtual List<ApplicationUserRole> Users { get; set; }

    }
}
