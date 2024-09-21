using DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATAspNetCoreMVCMaxton.Areas.User.Controllers
{
    [Area("User")]
    public class ProfileGroupController : Controller
    {
        private readonly IProfileGroupBLL _profileGroupService;

        public ProfileGroupController(IProfileGroupBLL profileGroupService)
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

            return RedirectToAction(nameof(ProfileGroupList));
        }
        [HttpPost]

        public async Task<IActionResult> AddProfileGroup(ProfileGroupDTO model)
        {
            if (ModelState.IsValid)
            {
                await _profileGroupService.AddProfileGroupAsync(model);
                return RedirectToAction(nameof(ProfileGroupList));
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
                if (result) return RedirectToAction(nameof(ProfileGroupList));
                return NotFound();
            }
            return View(new _UserMainDTO { ProfileGroup = model.ProfileGroup });
        }

        //private readonly ApplicationDbContext _context;
        //public ProfileGroupController(ApplicationDbContext context)
        //{
        //	_context = context;
        //}

        //[HttpGet]

        //public async Task<IActionResult> ProfileGroupList()
        //{
        //	var profileGroups = await _context.AspNetProfileGroup.ToListAsync();
        //	var mainVM = new MainVM
        //	{
        //		ProfileGroupList = profileGroups
        //	};

        //	return View("ProfileGroupList", mainVM);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddProfileGroup(ProfileGroupDTO model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.CreatedDate = DateTime.UtcNow;
        //        _context.AspNetProfileGroup.Add(model);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(ProfileGroupList));
        //    }
        //    return View("ProfileGroupList", new MainVM { ProfileGroup = model });
        //}
        //private async Task AddProfileGroupAsync(ProfileGroupDTO profileGroup)
        //{
        //    _context.AspNetProfileGroup.Add(profileGroup);
        //    await _context.SaveChangesAsync();
        //}

        //[HttpPost]
        //public async Task<IActionResult> DeleteProfileGroup(int id)
        //{
        //    var profileGroup = await _context.AspNetProfileGroup.FindAsync(id);
        //    if (profileGroup != null)
        //    {
        //        _context.AspNetProfileGroup.Remove(profileGroup);
        //        await _context.SaveChangesAsync();
        //    }
        //    return RedirectToAction(nameof(ProfileGroupList));
        //}


        //[HttpGet]
        //public async Task<IActionResult> EditProfileGroup(int id)
        //{
        //    var profileGroup = await _context.AspNetProfileGroup.FindAsync(id);
        //    if (profileGroup == null) return NotFound();

        //    var mainVM = new MainVM { ProfileGroup = profileGroup };
        //    return View(mainVM);
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditProfileGroup(MainVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var profileGroupInDb = await _context.AspNetProfileGroup.FindAsync(model.ProfileGroup.Id);
        //        if (profileGroupInDb == null) return NotFound();

        //        profileGroupInDb.Name = model.ProfileGroup.Name;
        //        profileGroupInDb.TotalProfile = model.ProfileGroup.TotalProfile;
        //        profileGroupInDb.CreatedDate = DateTime.UtcNow;

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(ProfileGroupList));
        //    }
        //    return View(new MainVM { ProfileGroup = model.ProfileGroup });
        //}

    }
}
