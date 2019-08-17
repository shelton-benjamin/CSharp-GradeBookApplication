using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires 5 or more students.");
            }

            var totalGrade = 0.0;
            foreach (var student in Students)
            {
                totalGrade += student.AverageGrade;
            }
            totalGrade /= Students.Count;

            if (averageGrade >= totalGrade * .8)
            {
                return 'A';
            }

            if (averageGrade >= totalGrade * .6)
            {
                return 'B';
            }

            if (averageGrade >= totalGrade * .4)
            {
                return 'C';
            }

            if (averageGrade >= totalGrade * .2)
            {
                return 'D';
            }

            return 'F';

        }
    }
}
