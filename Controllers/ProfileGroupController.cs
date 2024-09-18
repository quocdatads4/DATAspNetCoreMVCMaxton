using DATAspNetCoreMVCMaxton.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Controllers
{
	public class ProfileGroupController : Controller
	{
		private readonly ApplicationDbContext _context;
		public ProfileGroupController(ApplicationDbContext context)
		{
			_context = context;
		}
		// Hiển thị DropdownList với tất cả tên

        public async Task<IActionResult> ProfileGroupList()
        {
            var profileGroups = await _context.AspNetProfileGroup.ToListAsync();

            return View();
        }
		public IActionResult ProfileGroupAdd()
		{
			return View();
		}
		public IActionResult ProfileGroupUpdate()
		{
			return View();
		}
		public IActionResult ProfileGroupDelete()
		{
			return View();
		}
	}
}
