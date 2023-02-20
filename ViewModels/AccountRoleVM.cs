using System.ComponentModel.DataAnnotations;

namespace BelajarKoneksiDatabase.ViewModels
{
    public class AccountRoleVM
    {
        public int Id { get; set; }
        public string AccountNIK { get; set; }

        [Display(Name = "Role Name")]
        public int RoleId { get; set; }
    }
}
