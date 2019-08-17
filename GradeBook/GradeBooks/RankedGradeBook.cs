using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool weighted) : base(name, weighted)
        {
            Type = GradeBookType.Ranked;

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
       

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires 5 or more students.");
            }

            
            var gradeList = new List<double>();
            foreach(var student in Students)
            {
               gradeList.Add(student.AverageGrade);
               
            }

            var gradeCount = gradeList.Count;
            var higher = 0;
            foreach(var grade in gradeList)
            {
                if (grade > averageGrade)
                    higher++;
            }

            if (higher < gradeCount * 0.2)
            {
                return 'A';
            }

            if (higher < gradeCount * 0.4)
            {
                return 'B';
            }

            if (higher < gradeCount * 0.6)
            {
                return 'C';
            }

            if (higher < gradeCount * 0.8)
            {
                return 'D';
            }

            return 'F';

        }
    }
}
