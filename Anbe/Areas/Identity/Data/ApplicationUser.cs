using Anbe.Areas.AnbeAdmin.Models;
using Anbe.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;


namespace Anbe.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Nazar1988User class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameMaqaze { get; set; }
        public string Address { get; set; }

        public bool ForooshBaste { get; set; }
        public bool Active { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastVisitDateTime { get; set; }

        public string ImagePath { set; get; }

        public int KifePool { set; get; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual List<ApplicationUserRole> Roles { get; set; }
        public virtual List<Wallet> Wallets { get; set; }
        public virtual List<Product> Products { get; set; }


        public virtual List<JadvaleVaset> DastebandiKollis { get; set; }
    }
}
