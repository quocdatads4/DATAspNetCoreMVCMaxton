using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.Data
{
    public interface IFacebookAccountRepository
    {
        Task<List<FacebookAccountDTO>> GetAllFacebookAccountAsync();
    }

    public class FacebookAccountRepository : IFacebookAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public FacebookAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // Thêm phương thức mới để lấy FacebookAccount theo nhóm
        public async Task<List<FacebookAccountDTO>> GetAllFacebookAccountAsync()
        {
            return await _context.AspNetFacebookAccount.ToListAsync();
        }
      
    }
}
