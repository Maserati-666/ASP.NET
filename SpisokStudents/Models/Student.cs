using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SpisokStudents.Models
{
    public class Student
    {
        // ID студента
        [Key]
        [Required]
        public virtual int StudentId { get; set; }
        // Имя
        [Required]
        [DisplayName("Имя")]
        public virtual string FirstName { get; set; }
        // Фамилия
        [Required]
        [DisplayName("Фамилия")]
        public virtual string LastName { get; set; }
        // День рождения
        [Required]
        [DisplayName("Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public virtual DateTime Birthday { get; set; }
        // Телефон
        [Required]
        [DisplayName("Телефон")]
        public virtual string Phone { get; set; }
    }
}
