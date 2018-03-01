using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook :BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException();

            List<double> grades = new List<double>();
            Students.ForEach(s => grades.AddRange(s.Grades));

            var rank = ((decimal)grades.Where(g => g < averageGrade).Count() / grades.Count()) * 100;

            if (rank >= 80)
            {
                return 'A';
            }
            else if (rank >= 60)
            {
                return 'B';
            }
            else if (rank >= 40)
            {
                return 'C';
            }
            else if (rank >= 20)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
