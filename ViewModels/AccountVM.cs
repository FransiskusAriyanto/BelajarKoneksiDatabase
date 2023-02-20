using System.ComponentModel.DataAnnotations;

namespace BelajarKoneksiDatabase.ViewModels
{
    public class AccountVM
    {
        public string EmployeeNIK { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
