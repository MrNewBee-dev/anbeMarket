using Anbe.Models;
using Anbe.Models.ViewModels;
using System.Collections.Generic;

namespace Anbe.Areas.Identity.Data.Services
{
    public interface _WalletService
    {
        #region WalletInterFace
        int BalanceUserWallet(string Id);
        List<WalletViewModel> GetWalletUser(string Id);
        int ChargeWallet(string userName, int amount, string description, bool isPay = false, string shomareCheck = "0", int typeId = 1, bool etebar = false);
        int AddWallet(Wallet wallet);
        #endregion

        int GetWalletUserIdBedehi(string userId);
        List<BedehiViewModel> GetWalletUserBedehi();


    }
}
