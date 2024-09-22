using DATAspNetCoreMVCMaxton.Areas.User.Data;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic
{

    public interface IProfileOrbitasBLL
    {
        Task<List<ProfileOrbitaDTO>> GetAll_ProfileOrbita_List();
        Task<IEnumerable<ProfileOrbitaDTO>> Get_ProfileOrbitas_Enumerable();
        Task<ProfileOrbitaDTO> GetProfileOrbitaByIdAsync(int id);
        Task AddProfileOrbitaAsync(ProfileOrbitaDTO profileOrbita);
        Task<bool> EditProfileOrbitaAsync(_UserMainDTO model);
        Task<bool> EditProfileOrbitaAsyncTable(_UserMainDTO model);
        Task<_UserMainDTO> GetProfileOrbitaForEditAsync(int id);
        Task<bool> DeleteProfileOrbitaAsync(int id);

        // Thêm phương thức mới để lấy ProfileOrbita theo nhóm
        Task<IEnumerable<ProfileOrbitaDTO>> GetProfileOrbitasByGroupAsync(int profileGroupId);
    }
    public class ProfileOrbitaService : IProfileOrbitasBLL
    {
        private readonly IProfileOrbitasRepository _profileOrbitaRepository;

        public ProfileOrbitaService(IProfileOrbitasRepository profileOrbitaRepository)
        {
            _profileOrbitaRepository = profileOrbitaRepository;
        }

        // Thêm phương thức mới để lấy ProfileOrbita theo nhóm
        public async Task<IEnumerable<ProfileOrbitaDTO>> GetProfileOrbitasByGroupAsync(int profileGroupId)
        {
            return await _profileOrbitaRepository.GetProfileOrbitasByGroupAsync(profileGroupId);
        }
        public async Task<IEnumerable<ProfileOrbitaDTO>> Get_ProfileOrbitas_Enumerable()
        {
            return await _profileOrbitaRepository.GetAllProfileOrbitaAsync();
        }

        public async Task<List<ProfileOrbitaDTO>> GetAll_ProfileOrbita_List()
        {
            return await _profileOrbitaRepository.GetAllProfileOrbitaAsync();
        }

        public async Task<ProfileOrbitaDTO> GetProfileOrbitaByIdAsync(int id)
        {
            return await _profileOrbitaRepository.GetProfileOrbitaByIdAsync(id);
        }

        public async Task AddProfileOrbitaAsync(ProfileOrbitaDTO profileOrbita)
        {
            await _profileOrbitaRepository.AddProfileOrbitaAsync(profileOrbita);
        }
        public async Task<_UserMainDTO> GetProfileOrbitaForEditAsync(int id)
        {
            var profileOrbitaInDb = await _profileOrbitaRepository.GetProfileOrbitaByIdAsync(id);
            if (profileOrbitaInDb == null) return null;

            var mainVM = new _UserMainDTO { ProfileOrbitas = profileOrbitaInDb };
            return mainVM;
        }
  
        public async Task<bool> EditProfileOrbitaAsync(_UserMainDTO model)
        {
            var profileOrbitaInDb = await _profileOrbitaRepository.GetProfileOrbitaByIdAsync(model.ProfileOrbitas.Id);
            if (profileOrbitaInDb == null) return false;

            profileOrbitaInDb.ProfileName = model.ProfileOrbitas.ProfileName;


            await _profileOrbitaRepository.UpdateProfileOrbitaAsync(profileOrbitaInDb);
            return true;
        }
        public async Task<bool> EditProfileOrbitaAsyncTable(_UserMainDTO model)
        {
            var profileOrbitaInDb = await _profileOrbitaRepository.GetProfileOrbitaByIdAsync(model.Id);
            if (profileOrbitaInDb == null) return false;

            profileOrbitaInDb.ProfileGroupID = model.ProfileGroupID;


            await _profileOrbitaRepository.UpdateProfileOrbitaAsync(profileOrbitaInDb);
            return true;
        }

        public async Task<bool> DeleteProfileOrbitaAsync(int id)
        {
            var profileOrbita = await _profileOrbitaRepository.GetProfileOrbitaByIdAsync(id);
            if (profileOrbita != null)
            {
                await _profileOrbitaRepository.DeleteProfileOrbitaAsync(id);
                return true;
            }
            return false;
        }
    }




}
