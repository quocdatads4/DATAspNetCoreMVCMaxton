using DATAspNetCoreMVCMaxton.BusinessLogic;
using DATAspNetCoreMVCMaxton.DataAccess;
using DATAspNetCoreMVCMaxton.Models;
using DATAspNetCoreMVCMaxton.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DATAspNetCoreMVCMaxton.Controllers
{
    public class ProfileOrbitaController : Controller
    {
        private readonly IProfileOrbitaService _profileOrbitaService;

        public ProfileOrbitaController(IProfileOrbitaService profileOrbitaService)
        {
            _profileOrbitaService = profileOrbitaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var profileOrbitaList = await _profileOrbitaService.GetAllProfileOrbitaAsync();
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
        public IActionResult Create()
        {
            return View();
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
