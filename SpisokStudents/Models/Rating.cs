using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpisokStudents.Models
{
    public class Rating
    {
        // ID оценок
        public virtual int RatingId { get; set; }
        // Ссылка ID студента
        [DisplayName("ID номер студента")]
        public virtual int StudentId { get; set; }

        [ValidateNever]
        public Student Student { get; set; }

        [DisplayName("Предмет")]
        [ForeignKey("Course")]
        public virtual string CourseName { get; set; }

        [ValidateNever]
        public Course Course { get; set; }

        [Required]
        [DisplayName("Баллы")]
        [Range(0, 100)]
        // Оценка за предмет
        public virtual int RatingStudent { get; set; }
    }
}
