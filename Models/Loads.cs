using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCWLogistics.Models
{
    public class Loads
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LoadId { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string EmailAddress { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string ContactNumber { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string PickUpLocation { get; set; } = "";

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string DropOffLocation { get; set; } = "";

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string PickUpDate { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string DeliveryDate { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string EquipmentType { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string Weight { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string Dimensions { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string Description { get; set; } = "";
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string Documents { get; set; } = "";

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string TargetRate { get; set; } = "";

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string AdditionalNotes { get; set; } = "";
    }
}
