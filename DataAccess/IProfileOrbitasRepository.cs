using DATAspNetCoreMVCMaxton.Models;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.DataAccess
{
    public interface IProfileOrbitaRepository
    {
        Task<List<ProfileOrbitaDTO>> GetAllProfileOrbitaAsync();
        Task<ProfileOrbitaDTO> GetProfileOrbitaByIdAsync(int id);
        Task AddProfileOrbitaAsync(ProfileOrbitaDTO profileOrbita);
        Task UpdateProfileOrbitaAsync(ProfileOrbitaDTO profileOrbita);
        Task DeleteProfileOrbitaAsync(int id);
    }

    public class ProfileOrbitaRepository : IProfileOrbitaRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfileOrbitaRepository(ApplicationDbContext context)
        {
            _context = context;
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
