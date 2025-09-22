using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCWLogistics.DTOs.DriverVM
{
    public class EquipmentInformationvm
    {
        public long DriverId { get; set; }
        public string TruckType { get; set; } = "";
        public string AdditionalEquipmentNotes { get; set; } = "";
    }
}
