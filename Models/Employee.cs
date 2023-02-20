using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelajarKoneksiDatabase.Models
{
    [Table("tb_m_employees")]
    public class Employee
    {
        [Key, Column("nik", TypeName = "nchar(5)")]
        public string NIK { get; set; }

        [Required, Column("first_name"), MaxLength(50)]
        public string FirstName { get; set; }

        [Column("last_name"), MaxLength(50)]
        public string? LastName { get; set; }

        [Required, Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Required, Column("gender")]
        public GenderEnum Gender { get; set; }

        [Required, Column("hire_date")]
        public DateTime HireDate { get; set; }

        [Required, Column("email"), MaxLength(50)]
        public string Email { get; set; }

        [Column("phone_number"), MaxLength(20)]
        public string? PhoneNumber { get; set; }


        public ICollection<Profiling>? Profilings { get; set; }
        public Account? Account { get; set; }
    }

    public enum GenderEnum
    {
        Male,
        Female
    }
}
