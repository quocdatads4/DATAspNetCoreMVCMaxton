using DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using DATAspNetCoreMVCMaxton.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DATAspNetCoreMVCMaxton.Areas.User.Controllers
{
    [Area("User")]
    public class ProfileOrbitaController : Controller
    {
        private readonly IProfileOrbitasService _profileOrbitaService;
        private readonly IProfileGroupService _profileGroupService;
        public ProfileOrbitaController(IProfileOrbitasService profileOrbitaService, IProfileGroupService profileGroupService)
        {
            _profileOrbitaService = profileOrbitaService;
            _profileGroupService = profileGroupService;

        }
        // Action để lấy danh sách ProfileOrbita theo ProfileGroupId
        [HttpGet]
        public async Task<IActionResult> GetProfileOrbitasByGroup(int profileGroupId)
        {
            if (profileGroupId == 0) // Kiểm tra nếu ID nhóm không hợp lệ
            {
                return Json(new List<ProfileOrbitaDTO>()); // Trả về danh sách trống
            }

            // Gọi hàm từ BLL để lấy danh sách ProfileOrbita theo nhóm
            var profileOrbitas = await _profileOrbitaService.GetProfileOrbitasByGroupAsync(profileGroupId);
            return Json(profileOrbitas); // Trả về dữ liệu dưới dạng JSON
        }
        [HttpPost]
        public async Task<IActionResult> EditProfileGroupOrbitaTable([FromBody] _UserMainDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _profileOrbitaService.EditProfileOrbitaAsyncTable(model);
                if (result)
                    return Ok(true); // Trả về HTTP 200 cùng với dữ liệu thành công
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        public async Task<IActionResult> EditProfileOrbita(int id)
        {
            // Get the ProfileOrbita data for editing
            var profileOrbita = await _profileOrbitaService.GetProfileOrbitaForEditAsync(id);
            if (profileOrbita == null)
            {
                // If no ProfileOrbita found with the given id, return NotFound (HTTP 404)
                return NotFound();
            }

            // Prepare the model for the View
            var model = new _UserMainDTO
            {
                ProfileGroupSelectList = await _profileGroupService.CreateProfileGroupSelectListAsync(),
                ProfileOrbita = profileOrbita.ProfileOrbita
            };

            // Return the View with the model
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfileOrbita(_UserMainDTO model)
        {
            if (ModelState.IsValid)
            {
                await _profileOrbitaService.EditProfileOrbitaAsync(model);
                return RedirectToAction(nameof(Index), "Home", new { area = "User" });
            }
            return View("ProfileOrbita", new _UserMainDTO { ProfileGroup = model.ProfileGroup });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProfileOrbita(int id)
        {
            var result = await _profileOrbitaService.DeleteProfileOrbitaAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Hồ sơ đã được xóa thành công.";
            }
            else
            {
                TempData["ErrorMessage"] = "Không tìm thấy hồ sơ hoặc không thể xóa hồ sơ.";
            }

            return RedirectToAction(nameof(Index), "Home", new { area = "User" });
        }

    }
}
