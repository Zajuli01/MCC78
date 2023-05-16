using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasGG.View
{
    public class TablesView
    {
        
        public static void GetJoinTables()
        {
            var Employee = new Employee();
            var Education = new Education();
            var University = new University();
            Console.WriteLine("Menampilkan Tabel Join");

            var emp = Employee.GetEmployees();
            var profiling = Profiling.GetProfilings();
            var education = Education.GetEducation();
            var university = University.GetUniv();
            var result = from edu in education
                         join uni in university on edu.UniversityId equals uni.Id
                         join p in profiling on edu.Id equals p.EducationId
                         join em in emp on p.EmployeeId equals em.Id
                         select new
                         {
                             NIK = em.Nik,
                             FullName = em.FirstName + " " + em.LastName,
                             Birthdate = em.Birthdate,
                             Gender = em.Gender,
                             HiringDate = em.HiringDate,
                             Email = em.Email,
                             PhoneNumber = em.PhoneNumber,
                             Major = edu.Major,
                             Degree = edu.Degree,
                             GPA = edu.Gpa,
                             UniversityName = uni.Name

                         };

            foreach (var result2 in result)
            {
                Console.WriteLine("NIK: " + result2.NIK);
                Console.WriteLine("FullName: " + result2.FullName);
                Console.WriteLine("Birthdate: " + result2.Birthdate);
                Console.WriteLine("Gender: " + result2.Gender);
                Console.WriteLine("HiringDate: " + result2.HiringDate);
                Console.WriteLine("Email: " + result2.Email);
                Console.WriteLine("PhoneNumber: " + result2.PhoneNumber);
                Console.WriteLine("Major: " + result2.Major);
                Console.WriteLine("Degree: " + result2.Degree);
                Console.WriteLine("GPA: " + result2.GPA);
                Console.WriteLine("UniversityName: " + result2.UniversityName);
                Console.WriteLine("-----------------------------------------");

            }
        }
    }
}
