using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DATAspNetCoreMVCMaxton.Areas.User.Models
{
    [Area("User")]
    public class _UserMainDTO
    {
        public IEnumerable<SelectListItem>? ProfileGroupSelectList { get; set; }
        public IEnumerable<SelectListItem>? ProfileGroupSelectbyID { get; set; }
        public ProfileGroupDTO? ProfileGroup { get; set; }
        public List<ProfileGroupDTO>? ProfileGroupList { get; set; }

        public List<ProfileOrbitaDTO>? ProfileOrbitasList { get; set; }
        public ProfileOrbitaDTO? ProfileOrbita { get; set; }


        public UserAccountDTO? UserAccount { get; set; }
        public List<UserAccountDTO>? UserAccountList { get; set; }
        public AppUserDTO? AppUser { get; set; }
        public List<FacebookAccountDTO>? FacebookAccountList { get; set; }
        public List<GoogleAccountDTO>? GoogleAccountList { get; set; }
        public List<HotmailOutlookDTO>? HotmailOutlookList { get; set; }

        public int IdProfileOrbitaTable { get; set; }
        public int ProfileGroupIDTable { get; set; }

    }
}
