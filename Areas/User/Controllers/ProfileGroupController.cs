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
		public async Task<IActionResult> TableProfileGroup()
		{
            var model = new _UserMainDTO
            {
                ProfileGroupList = await _profileGroupService.GetAllProfileGroupAsync(),
            };
			return View(model);
		}
		[HttpPost]

		public async Task<IActionResult> AddProfileGroup(ProfileGroupDTO model)
		{
			if (ModelState.IsValid)
			{
				await _profileGroupService.AddProfileGroupAsync(model);
				return RedirectToAction(nameof(TableProfileGroup), "ProfileGroup", new { area = "User" });
			}
			return View("TableProfileGroup", new _UserMainDTO { ProfileGroup = model });
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

			return RedirectToAction(nameof(TableProfileGroup), "ProfileGroup", new { area = "User" });
		}
		[HttpGet]
		public async Task<IActionResult> EditProfileGroup(int id)
		{
			var mainVM = await _profileGroupService.GetProfileGroupForEditAsync(id);
			if (mainVM == null) return NotFound();

			return View(mainVM);
		}

		[HttpPost]
		public async Task<IActionResult> EditProfileGroup(ProfileGroupDTO profileGroup)
		{
			if (ModelState.IsValid)
			{
				await _profileGroupService.EditProfileGroupAsync(profileGroup);
				return RedirectToAction(nameof(TableProfileGroup), "ProfileGroup", new { area = "User" });
			}
			return View("TableProfileGroup", new _UserMainDTO { ProfileGroup = profileGroup });
		}
        // Action để lấy danh sách Facebook Account
        [HttpGet]
        public async Task<IActionResult> GetProfileGroupList()
        {

            // Gọi hàm từ BLL để lấy danh sách Facebook Account
            var profileGroup = await _profileGroupService.GetProfileGroupsAsync();
            return Json(profileGroup); // Trả về dữ liệu dưới dạng JSON
        }
   

    }
}
