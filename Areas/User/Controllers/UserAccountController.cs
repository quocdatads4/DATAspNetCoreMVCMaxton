using DATAspNetCoreMVCMaxton.Areas.User.Models;
using DATAspNetCoreMVCMaxton.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.Controllers
{
    [Area("User")]
    public class UserAccountController : Controller
    {

        private readonly ApplicationDbContext _context;
        public List<UserAccountDTO> UserAccount { get; set; }
        public UserAccountController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: UserAccount/Edit/1
        [HttpGet]
        public async Task<IActionResult> BasicUserAccount()
        {

            var userAccount = await GetUserAccountAsync(1);  // Lấy thông tin tài khoản người dùng với Id = 1

            var viewMainVM = new _UserMainDTO
            {
                UserAccount = userAccount,
            };

            return View(viewMainVM);
        }
        // Phương thức này lấy thông tin tài khoản người dùng với Id
        private async Task<UserAccountDTO> GetUserAccountAsync(int id)
        {
            return await _context.AspNetUserAccounts.FirstOrDefaultAsync(u => u.Id == id);
        }
        // Phương thức này tạo DashboardModel từ các tham số đầu vào

        public IActionResult SecurityUserAccount() { return View(); }

    }
}
