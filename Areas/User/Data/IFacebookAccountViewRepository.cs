using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.Data
{
    public interface IFacebookAccountViewRepository
    {
        Task<FacebookAccountViewDTO> GetFacebookAccountByIdView(int id);
    }
    public class FacebookAccountViewRepository : IFacebookAccountViewRepository
    {
        private readonly ApplicationDbContext _context;

        public FacebookAccountViewRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // Thêm phương thức mới để lấy FacebookAccount theo nhóm
        public async Task<FacebookAccountViewDTO> GetFacebookAccountByIdView(int id)
        {
            return await _context.AspNetFacebookAccountView.FirstOrDefaultAsync(u => u.Id == id);
        }

    }

}
