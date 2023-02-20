using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelajarKoneksiDatabase.Models
{
    [Table("tb_m_roles")]
    public class Role
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("name")]
        public string Name { get; set; }

        public ICollection<AccountRole> AccountRoles { get; set; }
    }
}
