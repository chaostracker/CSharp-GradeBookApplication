using System;
using System.Linq;

using GradeBook.Enums;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) {
            var numberOfStudents = this.Students.Count();
            if (numberOfStudents < 5) throw new InvalidOperationException();
            var numberOfStudentsInGradeGroup = numberOfStudents * 0.2;
            // CalculateStatistics();
            var averageGradeOrderedStudentList = this.Students.OrderByDescending(s => s.AverageGrade).ToList();
            if (averageGrade > averageGradeOrderedStudentList[Convert.ToInt32(numberOfStudentsInGradeGroup)].AverageGrade)
                return 'A';
            else if (averageGrade > averageGradeOrderedStudentList[Convert.ToInt32(numberOfStudentsInGradeGroup*2)].AverageGrade)
                return 'B';
            else if (averageGrade > averageGradeOrderedStudentList[Convert.ToInt32(numberOfStudentsInGradeGroup*3)].AverageGrade)
                return 'C';
            else if (averageGrade > averageGradeOrderedStudentList[Convert.ToInt32(numberOfStudentsInGradeGroup*4)].AverageGrade)
                return 'D';
            else
                return 'F';
        }
    }

}