using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasGG.View
{
    public class EmployeeView
    {
        // Insert ALL
        public static void InsertEmp()
        {
            var employee = new Employee();
            var profiling = new Profiling();
            var education = new Education();
            var university = new University();

            Console.Write("NIK : ");
            var niks = Console.ReadLine();
            employee.Nik = niks;

            Console.Write("First Name : ");
            employee.FirstName = Console.ReadLine();

            Console.Write("Lame Name : ");
            employee.LastName = Console.ReadLine();

            Console.Write("Birthdate : ");
            employee.Birthdate = DateTime.Parse(Console.ReadLine());

            Console.Write("Gender : ");
            employee.Gender = Console.ReadLine();

            Console.Write("Hiring Date : ");
            employee.HiringDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Email : ");
            employee.Email = Console.ReadLine();

            Console.Write("Phone Number : ");
            employee.PhoneNumber = Console.ReadLine();

            Console.Write("Department ID : ");
            employee.departement_id = Console.ReadLine();



            //EDUCATION
            Console.Write("Major : ");
            education.Major = Console.ReadLine();

            Console.Write("Degree : ");
            education.Degree = Console.ReadLine();

            Console.Write("GPA : ");
            education.Gpa = Console.ReadLine();

            Console.Write("University Name : ");
            university.Name = Console.ReadLine();

            university.InsertUniv(university);

            education.UniversityId = employee.GetUnivEduId(1);
            education.InsertEduc(education);

            var result = employee.InsertEmployee(employee);
            if (result > 0)
            {
                Console.WriteLine("INSERT Success");
            }
            else
            {
                Console.WriteLine("INSERT Failed");
            }

            university.InsertUniv(university);
            education.UniversityId = employee.GetUnivEduId(1);
            education.InsertEduc(education);

            profiling.EmployeeId = employee.GetEmpId(niks);
            profiling.EducationId = employee.GetUnivEduId(2);
            Profiling.InsertProfiling(profiling);

        }
        public static void GetAllEmp()
        {
            var Employee = new Employee();
            var results = Employee.GetEmployees();
            foreach (var result in results)
            {
                Console.WriteLine("Id: " + result.Id);
                Console.WriteLine("Nik: " + result.Nik);
                Console.WriteLine("First Name: " + result.FirstName);
                Console.WriteLine("Last Name: " + result.LastName);
                Console.WriteLine("BirthDate : " + result.Birthdate);
                Console.WriteLine("-----------------------------------------");
            }
        }
        public void Output(Employee employee)
        {
            Console.WriteLine("Id: " + employee.Id);
            Console.WriteLine("Nik: " + employee.Nik);
            Console.WriteLine("First Name: " + employee.FirstName);
            Console.WriteLine("Last Name: " + employee.LastName);
            Console.WriteLine("BirthDate : " + employee.Birthdate);
            Console.WriteLine("-----------------------------------------");
        }

        public void Output(List<Employee> employee)
        {
            foreach (var emp in employee)
            {
                Output(employee);
            }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}
