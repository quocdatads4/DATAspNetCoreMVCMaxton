using DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATAspNetCoreMVCMaxton.Areas.User.Controllers
{
    [Area("User")]
    public class ProfileGroupController : Controller
    {
        private readonly IProfileGroupService _profileGroupService;

        public ProfileGroupController(IProfileGroupService profileGroupService)
        {
            _profileGroupService = profileGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> ProfileGroupList()
        {
            var mainVM = await _profileGroupService.GetProfileGroupListAsync();
            return View("ProfileGroupList", mainVM);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProfileGroup(int id)
        {
            var result = await _profileGroupService.DeleteProfileGroupAsync(id);
            if (result)
            {
                // Profile group deleted successfully
            }
            else
            {
                // Profile group not found or could not be deleted
            }

			return RedirectToAction(nameof(ProfileGroupList), "ProfileGroup", new { area = "User" });
		}
        [HttpPost]

		public async Task<IActionResult> AddProfileGroup(ProfileGroupDTO model)
		{
			if (ModelState.IsValid)
			{
				await _profileGroupService.AddProfileGroupAsync(model);
				return RedirectToAction(nameof(ProfileGroupList), "ProfileGroup", new { area = "User" });
			}
			return View("ProfileGroupList", new _UserMainDTO { ProfileGroup = model });
		}

		[HttpGet]
        public async Task<IActionResult> EditProfileGroup(int id)
        {
            var mainVM = await _profileGroupService.GetProfileGroupForEditAsync(id);
            if (mainVM == null) return NotFound();

            return View(mainVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfileGroup(_UserMainDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _profileGroupService.EditProfileGroupAsync(model);
                if (result) return RedirectToAction(nameof(ProfileGroupList), "ProfileGroup", new { area = "User" });
                return NotFound();
            }
            return View(new _UserMainDTO { ProfileGroup = model.ProfileGroup });
        }

        
    }
}
