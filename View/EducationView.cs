using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasGG.View
{
    public class EducationView
    {
        
        public static void InsertEdu()
        {
            Education Education = new();
            var education = new Education();
            Console.Write("Masukkan Id : ");
            var id = Convert.ToInt32(Console.ReadLine());
            education.Id = id;

            Console.Write("Masukkan Major : ");
            var major = Console.ReadLine();
            education.Major = major;

            Console.Write("Masukkan Degree : ");
            var degree = Console.ReadLine();
            education.Degree = degree;

            Console.Write("Masukkan GPA : ");
            var gpa = Console.ReadLine();
            education.Gpa = gpa;

            Console.Write("University ID : ");
            var university_id = Convert.ToInt32(Console.ReadLine());
            education.UniversityId = university_id;

            var result = Education.InsertEduc(education);
            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }
        }
        public static void GetAllEdu()
        {
            Education Education = new();
            Console.WriteLine("Menampilkan semua data");
            var results = Education.GetEducation();
            foreach (var result in results)
            {
                Console.WriteLine("Id: " + result.Id);
                Console.WriteLine("Major: " + result.Major);
                Console.WriteLine("Degree: " + result.Degree);
                Console.WriteLine("GPA: " + result.Gpa);
                Console.WriteLine("Universty Id : " + result.UniversityId);
                Console.WriteLine("-----------------------------------------");
            }
        }
        public static void Update()
        {
            Education Education = new();
            var education1 = new Education();
            Console.Write("Masukkan ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Major: ");
            string major = Console.ReadLine();
            Console.Write("Degree: ");
            string degree = Console.ReadLine();
            Console.Write("GPA: ");
            string gpa = Console.ReadLine();
            Console.Write("Universty Id : ");
            int univ_id = Convert.ToInt32(Console.ReadLine());

            education1.Id = id;
            education1.Major = major;
            education1.Degree = degree;
            education1.Gpa = gpa;
            education1.UniversityId = univ_id;

            var results = Education.UpdateEducation(education1);
            if (results > 0)
            {
                Console.WriteLine("Update success");
            }
            else
            {
                Console.WriteLine("Update Failed");
            }
        }
        public static void Delete()
        {
            Education Education = new();
            var education2 = new Education();
            Console.Write("Masukkan ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            education2.Id = id;

            var result = Education.DeleteEducation(education2);
            if (result > 0)
            {
                Console.WriteLine("Delete success");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }
        }

        public void Output(Education education)
        {
            Console.WriteLine("Id: " + education.Id);
            Console.WriteLine("Major: " + education.Major);
            Console.WriteLine("Degree: " + education.Degree);
            Console.WriteLine("GPA: " + education.Gpa);
            Console.WriteLine("Universty Id : " + education.UniversityId);
            Console.WriteLine("-----------------------------------------");
        }

        public void Output(List<Education> education)
        {
            foreach (var edu in education)
            {
                Output(education);
            }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}
