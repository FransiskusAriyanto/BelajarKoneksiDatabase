using System.ComponentModel.DataAnnotations;

namespace BelajarKoneksiDatabase.ViewModels
{
    public class RoleVM
    {
        public int Id { get; set; }

        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}
