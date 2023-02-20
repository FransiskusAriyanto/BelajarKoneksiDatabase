using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelajarKoneksiDatabase.Models
{
    [Table("tb_m_educations")]
    public class Education
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("major"), MaxLength(100)]
        public string Major { get; set; }

        [Required, Column("degree"), MaxLength(2)]
        public string Degree { get; set; }

        [Required, Column("gpa")]
        public float GPA { get; set; }

        [Required, Column("unversity_id")]
        public int UniversityId { get; set; }

        public ICollection<Profiling>? Profilings { get; set; }
        public University? University { get; set; }
    }
}
