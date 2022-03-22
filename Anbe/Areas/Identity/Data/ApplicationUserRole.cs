using Microsoft.AspNetCore.Identity;

namespace Anbe.Areas.Identity.Data
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationRole Role { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
