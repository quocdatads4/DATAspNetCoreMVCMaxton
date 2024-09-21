using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DATAspNetCoreMVCMaxton.Areas.User.Models
{
    [Area("User")]
    public class _UserMainDTO
    {
        public IEnumerable<SelectListItem>? ProfileGroupSelectList { get; set; }
        public List<ProfileOrbitaDTO>? ProfileOrbitas { get; set; }

        public UserAccountDTO? UserAccount { get; set; }
        public List<UserAccountDTO>? UserAccountList { get; set; }
        public AppUserDTO? AppUser { get; set; }
        public ProfileGroupDTO? ProfileGroup { get; set; }
        public List<ProfileGroupDTO>? ProfileGroupList { get; set; }
    }
}
