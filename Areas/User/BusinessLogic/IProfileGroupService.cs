using DATAspNetCoreMVCMaxton.Areas.User.Data;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic
{

    public interface IProfileGroupService
    {
        Task<_UserMainDTO> GetProfileGroupListAsync();
        Task<_UserMainDTO> GetProfileGroupForEditAsync(int id);
        Task<IEnumerable<ProfileGroupDTO>> GetProfileGroupsAsync();
        Task<List<SelectListItem>> CreateProfileGroupSelectListAsync();
        Task AddProfileGroupAsync(ProfileGroupDTO profileGroup);
        Task<bool> DeleteProfileGroupAsync(int id);
        Task<bool> EditProfileGroupAsync(_UserMainDTO model);
    }

    public class ProfileGroupService : IProfileGroupService
    {
        private readonly IProfileGroupRepository _profileGroupRepository;

        public ProfileGroupService(IProfileGroupRepository profileGroupRepository)
        {
            _profileGroupRepository = profileGroupRepository;
        }

        public async Task<IEnumerable<ProfileGroupDTO>> GetProfileGroupsAsync()
        {
            return await _profileGroupRepository.GetProfileGroupsAsync();
        }
        public async Task<_UserMainDTO> GetProfileGroupListAsync()
        {
            var profileGroups = await _profileGroupRepository.GetProfileGroupsAsync();
            var mainVM = new _UserMainDTO
            {
                ProfileGroupList = profileGroups
            };

            return mainVM;
        }
        public async Task<bool> DeleteProfileGroupAsync(int id)
        {
            var profileGroup = await _profileGroupRepository.GetProfileGroupByIdAsync(id);
            if (profileGroup != null)
            {
                await _profileGroupRepository.DeleteProfileGroupAsync(profileGroup);
                return true;
            }
            return false;
        }
        public async Task AddProfileGroupAsync(ProfileGroupDTO profileGroup)
        {
            profileGroup.CreatedDate = DateTime.UtcNow;
            await _profileGroupRepository.AddProfileGroupAsync(profileGroup);
        }

        public async Task<_UserMainDTO> GetProfileGroupForEditAsync(int id)
        {
            var profileGroup = await _profileGroupRepository.GetProfileGroupByIdAsync(id);
            if (profileGroup == null) return null;

            var mainVM = new _UserMainDTO { ProfileGroup = profileGroup };
            return mainVM;
        }

        public async Task<bool> EditProfileGroupAsync(_UserMainDTO model)
        {
            var profileGroupInDb = await _profileGroupRepository.GetProfileGroupByIdAsync(model.ProfileGroup.Id);
            if (profileGroupInDb == null) return false;

            profileGroupInDb.Name = model.ProfileGroup.Name;
            profileGroupInDb.TotalProfile = model.ProfileGroup.TotalProfile;
            profileGroupInDb.CreatedDate = DateTime.UtcNow;

            await _profileGroupRepository.UpdateProfileGroupAsync(profileGroupInDb);
            return true;
        }
        public async Task<List<SelectListItem>> CreateProfileGroupSelectListAsync()
        {
            var profileGroups = await _profileGroupRepository.GetAllProfileGroupsAsync();
            return profileGroups.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Name
            }).ToList();
        }
    }
}
