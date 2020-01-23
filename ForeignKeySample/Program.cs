using ForeignKeySample.Entity;
using System;
using System.Linq;

namespace ForeignKeySample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            UpdateStudentDetails();
        }

        public static void UpdateStudentDetails()
        {
            var context = new SampleDbContext();
            var id = context.Students.Max(c => c.Id) + 1;
            var student = new Students()
            {
                Name = "Seetha_" + id,
                Place = "Chennai",
                Country = "India"
            };

            context.Students.Add(student);

            var studentId = context.Entry(student).Property(i => i.Id).CurrentValue;

            var personalDetails = new StudentsPersonalDetails()
            {
                UserId = studentId,  // Foreign Key. Mapped to Id column in the Students table.
                Department = "IT",
                Year = DateTime.Now
            };

            context.StudentsPersonalDetails.Add(personalDetails);

            var book = new Books()
            {
                Name = "Programming in C#",
                Category = "Programming Language",
                Author = "E Balagurusamy"
            };

            context.Books.Add(book);

            var bookId = context.Entry(book).Property(i => i.Id).CurrentValue;

            var studentBookMapper = new StudentBookMapper()
            {
                UserId = studentId, // Not a foreign key.
                BookId = bookId,
                IsPgstudent = false,
                IsActive = true
            };

            context.StudentBookMapper.Add(studentBookMapper);
            context.SaveChanges();
        }
    }
}
