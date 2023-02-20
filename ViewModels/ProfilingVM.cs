using System.ComponentModel.DataAnnotations;

namespace BelajarKoneksiDatabase.ViewModels
{
    public class ProfilingVM
    {
        public int Id { get; set; }

        /*[Display(Name = "Employee NIK")]*/
        public string EmployeeNIK { get; set; }

        /*[Display(Name = "Education Id")]*/
        public int EducationID { get; set; }

    }
}
