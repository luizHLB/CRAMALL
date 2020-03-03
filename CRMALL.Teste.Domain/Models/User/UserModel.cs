using CRMALL.Teste.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMALL.Teste.Domain.Models.User
{
    public class UserModel : BaseEntity
    {
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Login { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Password { get; set; }
    }
}
