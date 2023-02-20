using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelajarKoneksiDatabase.Models
{
    [Table("tb_tr_account_roles")]
    public class AccountRole
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("account_nik"), MaxLength(5)]
        public string AccountNIK { get; set; }

        [Required, Column("role_id")]
        public int RoleId { get; set; }

        public Account? Account { get; set; }
        public Role? Role { get; set; }
    }
}
