using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.Data
{
    public interface IFacebookAccountRepository
    {
        Task<List<FacebookAccountDTO>> GetAllFacebookAccountAsync();
        Task<FacebookAccountDTO> GetFacebookAccountByIdAsync(int id);
        Task AddFacebookAccountAsync(FacebookAccountDTO FacebookAccount);
        Task UpdateFacebookAccountAsync(FacebookAccountDTO FacebookAccount);
        Task DeleteFacebookAccountAsync(int id);
        Task<IEnumerable<FacebookAccountDTO>> GetFacebookAccountByGroupAsync(int profileGroupId);
    }

    public class FacebookAccountRepository : IFacebookAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public FacebookAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // Thêm phương thức mới để lấy FacebookAccount theo nhóm
        public async Task<IEnumerable<FacebookAccountDTO>> GetFacebookAccountByGroupAsync(int profileGroupId)
        {
            return await _context.AspNetFacebookAccount
                                 .Where(p => p.Id == profileGroupId)
                                 .ToListAsync();
        }
        public async Task<List<FacebookAccountDTO>> GetAllFacebookAccountAsync()
        {
            return await _context.AspNetFacebookAccount.ToListAsync();
        }

        public async Task<FacebookAccountDTO> GetFacebookAccountByIdAsync(int id)
        {
            return await _context.AspNetFacebookAccount.FindAsync(id);
        }

        public async Task AddFacebookAccountAsync(FacebookAccountDTO FacebookAccount)
        {
            await _context.AspNetFacebookAccount.AddAsync(FacebookAccount);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFacebookAccountAsync(FacebookAccountDTO FacebookAccount)
        {
            _context.AspNetFacebookAccount.Update(FacebookAccount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFacebookAccountAsync(int id)
        {
            var FacebookAccount = await _context.AspNetFacebookAccount.FindAsync(id);
            if (FacebookAccount != null)
            {
                _context.AspNetFacebookAccount.Remove(FacebookAccount);
                await _context.SaveChangesAsync();
            }
        }
    }
}
