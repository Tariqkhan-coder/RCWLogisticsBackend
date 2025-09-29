using RCWLogistics.DTOs.DriverVM;
using RSWLogistics.DTOs.DriverVM;
using RSWLogistics.ResponseVM;

namespace RSWLogistics.Interfaces
{
    public interface IDriver
    {
        Task<ResponseVm> CreateDriver(CreateDriver driver);
        Task<ResponseVm> UpdateDriver(UpdateDriverVM driver);
        Task<ResponseVm> DeleteDriver(long driverId);
        Task<ResponseVm> EquipmentsInformation(EquipmentInformationvm eq);
       
        Task<ResponseVm> UploadDriverDocuments(UploadDocuments documents);
        Task<ResponseVm> RequestLoad(RequestLoadVM request);
    }
}
