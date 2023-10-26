using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SpisokStudents.Models
{
    public class  Bigtable
    {
        [DisplayName("Студент")]
        public string NameStudent { get; set; }

        [DisplayName("Предмет")]
        public string NameCourse { get; set; }

        [DisplayName("Баллы")]
        public int RatingStud { get; set; }
    }
}
