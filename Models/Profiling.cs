using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelajarKoneksiDatabase.Models
{
    [Table("tb_tr_profilings")]
    public class Profiling
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("employee_nik"), MaxLength(5)]
        public string EmployeeNIK { get; set; }

        [Required, Column("education_id")]
        public int EducationId { get; set; }

        public Employee? Employee { get; set; }
        public Education? Education { get; set; }
    }
}
