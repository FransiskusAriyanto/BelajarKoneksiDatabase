using System.ComponentModel.DataAnnotations;

namespace BelajarKoneksiDatabase.ViewModels
{
    public class UniversityVM
    {
        public int Id { get; set; }

        [Display(Name = "University Name")]
        public string Name { get; set; }
    }
}
