using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SpisokStudents.Models
{
    public class Course
    {
        // Название предмета
        [Key]
        [Required]
        [DisplayName("Предмет")]
        public virtual string CourseName { get; set; }
    }
}
