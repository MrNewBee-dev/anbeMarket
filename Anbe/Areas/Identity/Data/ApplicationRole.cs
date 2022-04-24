using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


        [ForeignKey("role")]
        [Column(TypeName = "nvarchar(450)")]
        public string roleParentID { get; set; }

        public ApplicationRole role { get; set; }
        public List<ApplicationRole> roles { get; set; }

    }
}
