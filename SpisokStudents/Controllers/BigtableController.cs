using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Identity.Client;
using SpisokStudents.Data;
using SpisokStudents.Models;
using System.Linq;
using System.Text;

namespace SpisokStudents.Controllers
{
    public class BigtableController : Controller
    {
        private readonly RatingStudentContext _context;

        public BigtableController(RatingStudentContext context)
        {
            _context = context;
        }

        // Вывод Сводной таблицы
        public ActionResult AllStudent()
        {
            var bT = BigTable();
            return View(bT);
        }

        // Вывод Итоговой таблицы
        public ActionResult ItogStudent()
        {
            var table = ItogTable();
            return View(table);
        }

        // Вывод пяти лучших студентов
        public ActionResult TopStudent()
        {
            var sT = ItogTable();
            sT = sT.OrderByDescending(p => p.SummaRating).ToList();
            sT.Count();
            if (sT.Count() > 5)
            {
                sT = sT.GetRange(0, 5);
            }
            return View(sT);
        }

        // Вывод пяти худших студентов
        public ActionResult WorstStudent()
        {
            var sT = ItogTable();
            sT = sT.OrderBy(p => p.SummaRating).ToList();
            sT.Count();
            if (sT.Count() > 5)
            {
                sT = sT.GetRange(0, 5);
            }
            return View(sT);
        }

        // Вывод Итоговой таблицы в файл
        public IActionResult ExportToCsv()
        {
            var table = ItogTable();
            var builder = new StringBuilder();
            builder.AppendLine("Студент,Сумма баллов");
            foreach (var user in table)
            {
                builder.AppendLine($"{user.NameStudent},{user.SummaRating}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Итоговая таблица.csv");
        }

        // Метод формирующий сводную таблицу без суммы баллов
        public List<Bigtable> BigTable()
        {
            var bT = new List<Bigtable>();
            foreach (var item in _context.Ratings)
            {
                string a = "";
                string b = "";
                foreach (var s in _context.Students)
                {
                    if (item.StudentId == s.StudentId)
                    {
                        a = s.FirstName + " " + s.LastName;
                    }
                }
                foreach (var s in _context.Courses)
                {
                    if (item.CourseName == s.CourseName)
                    {
                        b = s.CourseName;
                    }
                }
                bT.Add(new Bigtable { NameStudent = a, NameCourse = b, RatingStud = item.RatingStudent });
            }
            return bT;
        }


        // Метод формирующий Таблицу с суммой баллов студентов
        public List<Summa> ItogTable()
        {
            int c;
            var sT = new List<Summa>();
            foreach (var item in _context.Students)
            {
                c = 0;
                foreach (var s in _context.Ratings)
                {
                    if (item.StudentId == s.StudentId)
                    {
                        c = c + s.RatingStudent;
                    }
                }
                sT.Add(new Summa { NameStudent = item.FirstName + " " + item.LastName, SummaRating = c });
            }
            return sT;
        }


    }

}
