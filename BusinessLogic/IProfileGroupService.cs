using DATAspNetCoreMVCMaxton.DataAccess;
using DATAspNetCoreMVCMaxton.Models;
using DATAspNetCoreMVCMaxton.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DATAspNetCoreMVCMaxton.BusinessLogic
{
    public interface IProfileGroupService
    {
        Task<MainVM> GetProfileGroupListAsync();
        Task<bool> DeleteProfileGroupAsync(int id);
        Task AddProfileGroupAsync(ProfileGroupDTO profileGroup);
        Task<MainVM> GetProfileGroupForEditAsync(int id);
        Task<bool> EditProfileGroupAsync(MainVM model);
        Task<List<SelectListItem>> CreateProfileGroupSelectListAsync();

    }

    public class ProfileGroupService : IProfileGroupService
    {
        private readonly IProfileGroupRepository _profileGroupRepository;

        public ProfileGroupService(IProfileGroupRepository profileGroupRepository)
        {
            _profileGroupRepository = profileGroupRepository;
        }

        public async Task<MainVM> GetProfileGroupListAsync()
        {
            var profileGroups = await _profileGroupRepository.GetProfileGroupsAsync();
            var mainVM = new MainVM
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

        public async Task<MainVM> GetProfileGroupForEditAsync(int id)
        {
            var profileGroup = await _profileGroupRepository.GetProfileGroupByIdAsync(id);
            if (profileGroup == null) return null;

            var mainVM = new MainVM { ProfileGroup = profileGroup };
            return mainVM;
        }

        public async Task<bool> EditProfileGroupAsync(MainVM model)
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
