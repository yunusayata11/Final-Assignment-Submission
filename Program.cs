using System;
using CodeFirstDemo.Data;
using CodeFirstDemo.Models;

namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Code First Örneği - Öğrenci Veritabanı");
            
            using (var context = new SchoolContext())
            {
                // Veritabanını sil ve yeniden oluştur
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                Console.WriteLine("Veritabanı silindi ve yeniden oluşturuldu.");
                
                // Yeni bir Grade ekle
                var grade = new Grade
                {
                    GradeName = "Grade 1",
                    Section = "Section A"
                };
                context.Grades.Add(grade);
                
                // Yeni bir öğrenci ekle
                var student = new Student
                {
                    Name = "Sabun Cangur",
                    DateOfBirth = new DateTime(2000, 11, 15),
                    Height = 175.5m,
                    Weight = 75.5f,
                    Grade = grade
                };
                context.Students.Add(student);
                
                // Değişiklikleri kaydet
                context.SaveChanges();
                
                // Kaydedilen öğrenci bilgisini görüntüle
                Console.WriteLine($"Öğrenci eklendi: {student.StudentID} - {student.Name}");
                Console.WriteLine("Veritabanı oluşturuldu ve bir öğrenci kaydı eklendi!");
            }
        }
    }
}
