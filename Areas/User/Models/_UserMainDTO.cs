using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DATAspNetCoreMVCMaxton.Areas.User.Models
{
    [Area("User")]
    public class _UserMainDTO
    {
        public IEnumerable<SelectListItem>? ProfileGroupSelectList { get; set; }
        public ProfileGroupDTO? ProfileGroup { get; set; }
        public List<ProfileGroupDTO>? ProfileGroupList { get; set; }

        public IEnumerable<SelectListItem>? ProfileOrbitasSelectList { get; set; }
        public ProfileOrbitaDTO? ProfileOrbitas { get; set; }
        public List<ProfileOrbitaDTO>? ProfileOrbitasList { get; set; }

        public UserAccountDTO? UserAccount { get; set; }
        public List<UserAccountDTO>? UserAccountList { get; set; }
        public AppUserDTO? AppUser { get; set; }

        public IEnumerable<SelectListItem>? FacebookAccountSelectList { get; set; }
        public FacebookAccountDTO? FacebookAccount { get; set; }
        public List<FacebookAccountDTO>? FacebookAccountList { get; set; }

        public IEnumerable<SelectListItem>? GoogleAccountSelectList { get; set; }
        public GoogleAccountDTO? GoogleAccount { get; set; }
        public List<GoogleAccountDTO>? GoogleAccountList { get; set; }

        public int Id { get; set; }
        public int ProfileGroupID { get; set; }

        public IFormFile? AvatarFile { get; set; }  // Thêm thuộc tính để upload file
    }
}
