using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqJoins
{
    class Program
    {
        private static readonly Student[] students = new[]
        {
            new Student { Id = 1, FirstName = "John", LastName = "Doe" },
            new Student { Id = 2, FirstName = "Jane", LastName = "Roe" },
            new Student { Id = 3, FirstName = "Max", LastName = "Lane" }
        };

        private static readonly Registration[] registrations = new[]
        {
            new Registration { StudentId = 1, CourseId = 101, DateRegistered = new DateTime(2018, 2, 15) },
            new Registration { StudentId = 1, CourseId = 102, DateRegistered = new DateTime(2018, 2, 15) },
            new Registration { StudentId = 2, CourseId = 102, DateRegistered = new DateTime(2018, 2, 17) }
        };

        private static readonly StudentGrade[] grades = new[]
        {
            new StudentGrade { StudentId = 1, CourseId = 102, GradingDate = new DateTime(2018, 6, 10), Grade = 9 },
            new StudentGrade { StudentId = 2, CourseId = 102, GradingDate = new DateTime(2018, 6, 10), Grade = 10 }
        };

        static void Main(string[] args)
        {
            InnerJoinQuerySyntax();
            InnerJoinMethodSyntax();
            MultipleInnerJoinQuerySyntax();
            MultipleInnerJoinMethodSyntax();
            GroupJoinQuerySyntax();
            GroupJoinMethodSyntax();
            OuterJoinQuerySyntax();
            OuterJoinMethodSyntax();
        }

        private static void InnerJoinQuerySyntax()
        {
            var query = from student in students
                        join registration in registrations
                        on student.Id equals registration.StudentId
                        select new { student.Id, student.FirstName, student.LastName, registration.CourseId, registration.DateRegistered };
        }

        private static void InnerJoinMethodSyntax()
        {
            var query = students.Join(registrations,
                    student => student.Id,
                    registration => registration.StudentId,
                    (student, registration) => new { student.Id, student.FirstName, student.LastName, registration.CourseId, registration.DateRegistered });
        }

        private static void MultipleInnerJoinQuerySyntax()
        {
            var query = from student in students
                        join registration in registrations
                        on student.Id equals registration.StudentId
                        join grade in grades
                        on new { registration.StudentId, registration.CourseId } equals new { grade.StudentId, grade.CourseId }
                        select new { student.Id, student.FirstName, student.LastName, registration.CourseId, registration.DateRegistered, grade.Grade };
        }

        private static void MultipleInnerJoinMethodSyntax()
        {
            var query = students.Join(registrations,
                    student => student.Id,
                    registration => registration.StudentId,
                    (student, registration) => new { student.Id, student.FirstName, student.LastName, registration.StudentId, registration.CourseId, registration.DateRegistered })
                .Join(grades,
                    joined => new { joined.StudentId, joined.CourseId },
                    grade => new { grade.StudentId, grade.CourseId },
                    (joined, grade) => new { joined.Id, joined.FirstName, joined.LastName, joined.CourseId, joined.DateRegistered, grade.Grade });
        }

        private static void GroupJoinQuerySyntax()
        {
            var query = from student in students
                        join registration in registrations
                        on student.Id equals registration.StudentId into registrationsForStudent
                        from registrationForStudent in registrationsForStudent
                        select new { student.Id, student.FirstName, student.LastName, registrationForStudent.CourseId, registrationForStudent.DateRegistered };
        }

        private static void GroupJoinMethodSyntax()
        {
            var query = students.GroupJoin(registrations,
                    student => student.Id,
                    registration => registration.StudentId,
                    (Student student, IEnumerable<Registration> registrationsForStudent) => new { student, registrationsForStudent })
                .SelectMany(studentWithRegistrations => studentWithRegistrations.registrationsForStudent,
                    (studentWithRegistrations, registration) => new { studentWithRegistrations.student.Id, studentWithRegistrations.student.FirstName, studentWithRegistrations.student.LastName, registration.CourseId, registration.DateRegistered });
        }

        private static void OuterJoinQuerySyntax()
        {
            var query = from student in students
                        join registration in registrations
                        on student.Id equals registration.StudentId into registrationsForStudent
                        from registrationForStudent in registrationsForStudent.DefaultIfEmpty()
                        select new { student.Id, student.FirstName, student.LastName, registrationForStudent?.CourseId, registrationForStudent?.DateRegistered };
        }

        private static void OuterJoinMethodSyntax()
        {
            var query = students.GroupJoin(registrations,
                    student => student.Id,
                    registration => registration.StudentId,
                    (Student student, IEnumerable<Registration> registrationsForStudent) => new { student, registrationsForStudent })
                .SelectMany(studentWithRegistrations => studentWithRegistrations.registrationsForStudent.DefaultIfEmpty(),
                    (studentWithRegistrations, registration) => new { studentWithRegistrations.student.Id, studentWithRegistrations.student.FirstName, studentWithRegistrations.student.LastName, registration?.CourseId, registration?.DateRegistered });
        }
    }
}
