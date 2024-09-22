using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.Data
{
    public interface IProfileGroupRepository
    {
        Task<List<ProfileGroupDTO>> GetProfileGroupsAsync();
        Task<List<ProfileGroupDTO>> GetAllProfileGroupsAsync();
        Task<ProfileGroupDTO> GetProfileGroupByIdAsync(int id);
        Task DeleteProfileGroupAsync(ProfileGroupDTO profileGroup);
        Task AddProfileGroupAsync(ProfileGroupDTO profileGroup);
        Task UpdateProfileGroupAsync(ProfileGroupDTO profileGroup);
    }

    public class ProfileGroupRepository : IProfileGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfileGroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProfileGroupDTO>> GetProfileGroupsAsync()
        {
            return await _context.AspNetProfileGroup.ToListAsync();
        }
        public async Task<ProfileGroupDTO> GetProfileGroupByIdAsync(int id)
        {
            return await _context.AspNetProfileGroup.FindAsync(id);
        }
        public async Task DeleteProfileGroupAsync(ProfileGroupDTO profileGroup)
        {
            _context.AspNetProfileGroup.Remove(profileGroup);
            await _context.SaveChangesAsync();
        }
        public async Task AddProfileGroupAsync(ProfileGroupDTO profileGroup)
        {
            _context.AspNetProfileGroup.Add(profileGroup);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProfileGroupAsync(ProfileGroupDTO profileGroup)
        {
            _context.AspNetProfileGroup.Update(profileGroup);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ProfileGroupDTO>> GetAllProfileGroupsAsync()
        {
            return await _context.AspNetProfileGroup
                                 .Select(g => new ProfileGroupDTO
                                 {
                                     Id = g.Id,
                                     Name = g.Name
                                 })
                                 .ToListAsync();
        }
    }
}
