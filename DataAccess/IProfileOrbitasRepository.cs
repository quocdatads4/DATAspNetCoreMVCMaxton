using DATAspNetCoreMVCMaxton.Models;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.DataAccess
{
    public interface IProfileOrbitasRepository
    {
    }
    public class ProfileOrbitasRepository : IProfileOrbitasRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfileOrbitasRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProfileOrbitaDTO>> GetProfileGroupsAsync()
        {
            return await _context.AspNetProfileOrbita.ToListAsync();
        }
    }
}
