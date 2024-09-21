using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.Data
{
    public interface IProfileOrbitasDAL
    {
        Task<List<ProfileOrbitaDTO>> GetAllProfileOrbitaAsync();
        Task<ProfileOrbitaDTO> GetProfileOrbitaByIdAsync(int id);
        Task AddProfileOrbitaAsync(ProfileOrbitaDTO profileOrbita);
        Task UpdateProfileOrbitaAsync(ProfileOrbitaDTO profileOrbita);
        Task DeleteProfileOrbitaAsync(int id);
		Task<IEnumerable<ProfileOrbitaDTO>> GetProfileOrbitasByGroupAsync(int profileGroupId);
	}
	
	public class ProfileOrbitaRepository : IProfileOrbitasDAL
    {
        private readonly ApplicationDbContext _context;

        public ProfileOrbitaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // Thêm phương thức mới để lấy ProfileOrbita theo nhóm
        public async Task<IEnumerable<ProfileOrbitaDTO>> GetProfileOrbitasByGroupAsync(int profileGroupId)
        {
            return await _context.AspNetProfileOrbita
                                 .Where(p => p.ProfileGroupID == profileGroupId)
                                 .ToListAsync();
        }
        public async Task<List<ProfileOrbitaDTO>> GetAllProfileOrbitaAsync()
        {
            return await _context.AspNetProfileOrbita.ToListAsync();
        }

        public async Task<ProfileOrbitaDTO> GetProfileOrbitaByIdAsync(int id)
        {
            return await _context.AspNetProfileOrbita.FindAsync(id);
        }

        public async Task AddProfileOrbitaAsync(ProfileOrbitaDTO profileOrbita)
        {
            await _context.AspNetProfileOrbita.AddAsync(profileOrbita);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfileOrbitaAsync(ProfileOrbitaDTO profileOrbita)
        {
            _context.AspNetProfileOrbita.Update(profileOrbita);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfileOrbitaAsync(int id)
        {
            var profileOrbita = await _context.AspNetProfileOrbita.FindAsync(id);
            if (profileOrbita != null)
            {
                _context.AspNetProfileOrbita.Remove(profileOrbita);
                await _context.SaveChangesAsync();
            }
        }
    }

}
