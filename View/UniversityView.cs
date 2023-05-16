using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasGG.View
{
    public class UniversityView
    {
        public static void InsertUni()
        {
            var university = new University();
            Console.Write("Masukkan nama : ");
            string nama = Console.ReadLine();
            university.Name = nama;
            university.Id = 22;

            var result = university.InsertUniv(university);
            if (result > 0)
            {
                Console.WriteLine("Insert success.");
            }
            else
            {
                Console.WriteLine("Insert failed.");
            }
        }
        public static void Update()
        {
            University university1 = new();
            Console.Write("Masukkan ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            university1.Id = id;

            Console.Write("Masukkan Nama : ");
            var name3 = Console.ReadLine();
            university1.Name = name3;

            var result = university1.UpdateUniversity(university1);
            if (result > 0)
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
            var university2 = new University();
            Console.Write("Masukkan ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            university2.Id = id;

            var result = university2.DeleteUniversity(university2);
            if (result > 0)
            {
                Console.WriteLine("Delete success");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }
        }

        public void Output(University university)
        {
            Console.WriteLine("");
            Console.WriteLine("Id: " + university.Id);
            Console.WriteLine("Name: " + university.Name);
            Console.WriteLine("-----------------------------------------");
        }

        public void Output(List<University> universities)
        {
            foreach (var university in universities)
            {
                Output(university);
            }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }


        //Berbeda logika

        //public static void GetAllUni()
        //{
        //    var university = new University();
        //    Console.WriteLine("Menampilkan semua data");
        //    var results = university.GetUniv();
        //    foreach (var result in results)
        //    {
        //        Console.WriteLine("Id: " + result.Id);
        //        Console.WriteLine("Name: " + result.Name);
        //    }
        //}
    }
}
