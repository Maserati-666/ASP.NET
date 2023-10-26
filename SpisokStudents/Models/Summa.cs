using System.ComponentModel;

namespace SpisokStudents.Models
{
    public class Summa
    {
        [DisplayName("Студент")]
        public string NameStudent { get; set; }

        [DisplayName("Сумма баллов")]
        public int SummaRating { get; set;}
    }
}
