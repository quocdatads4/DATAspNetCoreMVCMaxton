using DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.Data
{
    public interface IProfileGroupRepository
    {
        Task<List<ProfileGroupDTO>> GetProfileGroupsAsync();
        Task<List<ProfileGroupDTO>> GetAllProfileGroupsAsync();

		Task AddProfileGroupsAsync(ProfileGroupDTO profileGroup);

		//Tìm kiếm xem ID của Profile Group có tồn tại trong database
		Task<ProfileGroupDTO> GetProfileGroupByIdAsync(int id);

        //Xoá Profile Group
		Task DeleteProfileGroupAsync(ProfileGroupDTO profileGroup);

		Task EditProfileGroupAsync(ProfileGroupDTO profileGroup);

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
		public async Task AddProfileGroupsAsync(ProfileGroupDTO profileGroup)
		{
			await _context.AspNetProfileGroup.AddAsync(profileGroup);
			await _context.SaveChangesAsync();
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
		public async Task EditProfileGroupAsync(ProfileGroupDTO profileGroup)
		{
			_context.AspNetProfileGroup.Update(profileGroup);
			await _context.SaveChangesAsync();
		}
	}
}
