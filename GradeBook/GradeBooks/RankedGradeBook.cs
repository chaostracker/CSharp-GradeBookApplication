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
        public RankedGradeBook(string name, bool weighted) : base(name, weighted)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) {
            var numberOfStudents = this.Students.Count;
            if (numberOfStudents < 5) throw new InvalidOperationException("You must have at least 5 students to do ranked grading.");
            var numberOfStudentsInGradeGroup = numberOfStudents * 0.2;
            var averageGradeOrderedStudentList = this.Students.OrderByDescending(s => s.AverageGrade).ToList();
            if (averageGrade >= averageGradeOrderedStudentList[Convert.ToInt32(numberOfStudentsInGradeGroup)-1].AverageGrade)
                return 'A';
            else if (averageGrade >= averageGradeOrderedStudentList[Convert.ToInt32(numberOfStudentsInGradeGroup*2)-1].AverageGrade)
                return 'B';
            else if (averageGrade >= averageGradeOrderedStudentList[Convert.ToInt32(numberOfStudentsInGradeGroup*3)-1].AverageGrade)
                return 'C';
            else if (averageGrade >= averageGradeOrderedStudentList[Convert.ToInt32(numberOfStudentsInGradeGroup*4)-1].AverageGrade)
                return 'D';
            else
                return 'F';
        }
        public override void CalculateStatistics() {
            if (this.Students.Count < 5) {
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
             if (this.Students.Count < 5) {
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }

}