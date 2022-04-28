using Anbe.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Anbe.Areas.AnbeAdmin.Controllers
{
    [Area("AnbeAdmin")]
    public class SubscriptionController : Controller
    {
        private readonly UserManager<ApplicationUser> _context;
        public SubscriptionController(UserManager<ApplicationUser> _context)
        {
            this._context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int money)
        {
            int cash ;
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var UserFound = _context.Users.SingleOrDefault(x => x.Id == UserId).Id;
            if (UserFound == null)
            {
                return NotFound();
            }

            switch (money)
            {
                case 1:
                    cash = 30000;
                    break;
                case 2:
                    cash = 50000;
                    break;
                case 3:
                    cash = 150000;
                    break;
                default:
                    return View();
            }

            var payment = new ZarinpalSandbox.Payment(cash);
            string CurrentUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var res = payment.PaymentRequest($"پرداخت فاکتور شماره {1}",
                "https://localhost:44393/Home/OnlinePaymentSharge/" + cash);
            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }
            else
            {
                return BadRequest();
            }

            
        }
        
    }
}
