using DATAspNetCoreMVCMaxton.Models;

namespace DATAspNetCoreMVCMaxton.ViewModel
{
    public class MainVM
    {
        public DashboardModel? Dashboard { get; set; }
        public UserAccountModel? UserAccount { get; set; }
        public ApplicationUserModel? AppUser { get; set; }
        public ProfileGroupModel? ProfileGroup { get; set; }
    }
}
