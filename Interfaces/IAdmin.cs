using RCWLogisticsBackend.DTOs.Admin;
using RSWLogistics.ResponseVM;

namespace RCWLogisticsBackend.Interfaces
{
    public interface IAdmin
    {
        Task<ResponseVm> CreateAdmin(CreateAdminVm admin);
        Task<ResponseVm> LoginAdmin(LoginAdmin admin);
        Task<ResponseVm> GetAllDrivers();
    }
}
