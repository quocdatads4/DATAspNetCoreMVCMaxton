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
        private readonly IProfileOrbitasBLL _profileOrbitaService;
        private readonly IProfileGroupBLL _profileGroupService; // Assuming you have a service for handling profile groups
        public ProfileOrbitaController(IProfileOrbitasBLL profileOrbitaService, IProfileGroupBLL profileGroupService)
        {
            _profileOrbitaService = profileOrbitaService;
            _profileGroupService = profileGroupService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var profileOrbitaList = await _profileOrbitaService.GetAll_ProfileOrbita_List();
            return View(profileOrbitaList);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var profileOrbita = await _profileOrbitaService.GetProfileOrbitaByIdAsync(id);
            if (profileOrbita == null) return NotFound();

            return View(profileOrbita);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var profileGroups = await _profileGroupService.GetProfileGroupsAsync();
            var model = new _UserMainDTO
            {
                ProfileGroupSelectList = profileGroups.Select(pg => new SelectListItem
                {
                    Value = pg.Id.ToString(),
                    Text = pg.Name
                }).ToList(),
            };

            return View(model);
        }
		public async Task<IActionResult> GetProfilesByGroup(int profileGroupId)
		{
			var profileOrbitas = await _profileOrbitaService.GetProfileOrbitasByGroupAsync(profileGroupId);
			return Json(profileOrbitas);
		}
		[HttpPost]
        public async Task<IActionResult> Create(ProfileOrbitaDTO profileOrbita)
        {
            if (ModelState.IsValid)
            {
                await _profileOrbitaService.AddProfileOrbitaAsync(profileOrbita);
                return RedirectToAction(nameof(Index));
            }
            return View(profileOrbita);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var profileOrbita = await _profileOrbitaService.GetProfileOrbitaByIdAsync(id);
            if (profileOrbita == null) return NotFound();

            return View(profileOrbita);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProfileOrbitaDTO profileOrbita)
        {
            if (ModelState.IsValid)
            {
                await _profileOrbitaService.UpdateProfileOrbitaAsync(profileOrbita);
                return RedirectToAction(nameof(Index));
            }
            return View(profileOrbita);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var profileOrbita = await _profileOrbitaService.GetProfileOrbitaByIdAsync(id);
            if (profileOrbita == null) return NotFound();

            return View(profileOrbita);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _profileOrbitaService.DeleteProfileOrbitaAsync(id);
            if (!success) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
