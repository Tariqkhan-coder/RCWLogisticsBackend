using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RCWLogisticsBackend.Models
{
    public class Admins
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string Username { get; set; } = string.Empty;
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(450)]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
