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
        Task UpdateProfileOrbitaAsync(ProfileOrbitaDTO profileOrbita);
        Task<bool> DeleteProfileOrbitaAsync(int id);

        // Thêm phương thức mới để lấy ProfileOrbita theo nhóm
        Task<IEnumerable<ProfileOrbitaDTO>> GetProfileOrbitasByGroupAsync(int profileGroupId);
    }
    public class ProfileOrbitaService : IProfileOrbitasBLL
    {
        private readonly IProfileOrbitasDAL _profileOrbitaRepository;

        public ProfileOrbitaService(IProfileOrbitasDAL profileOrbitaRepository)
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

        public async Task UpdateProfileOrbitaAsync(ProfileOrbitaDTO profileOrbita)
        {
            await _profileOrbitaRepository.UpdateProfileOrbitaAsync(profileOrbita);
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
