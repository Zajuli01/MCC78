using System.Data.SqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System;
using TugasGG;

public class Program
{
    private static readonly string connectionString =
        "Data Source=E5\\MSSQLSERVER2; Database=BookingRoom;; Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    public static void Menu()
    {
        Console.WriteLine("=============================");
        Console.WriteLine("=           MENU            =");
        Console.WriteLine("=============================");
        Console.WriteLine("=                           =");
        Console.WriteLine("=        1. Create          =");
        Console.WriteLine("=        2. Read            =");
        Console.WriteLine("=        3. Update          =");
        Console.WriteLine("=        4. Delete          =");
        Console.WriteLine("=        5. Exit            =");
        Console.WriteLine("=                           =");
        Console.WriteLine("=============================");
        Console.WriteLine("Pilih menu (1/2/3/4/5): ");
    }

    public static void Main()
    {
        int choice;
        do
        {
            Menu();
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("===== INGIN MELAKUKAN INSERT PADA TABEL =====");
                    Console.WriteLine("=====                                   =====");
                    Console.WriteLine("=====        1. Universities            =====");
                    Console.WriteLine("=====        2. Educations              =====");
                    Console.WriteLine("=====        3. Employees (Khusus)      =====");
                    Console.WriteLine("=====        4. Back                    =====");
                    Console.WriteLine("=====                                   =====");
                    Console.WriteLine("Pilih menu (1/2/3/4): ");

                    int tabel = Convert.ToInt32(Console.ReadLine());
                    if (tabel == 1)
                    {
                        var university = new Universities();
                        Console.Write("Masukkan nama : ");
                        string nama = Console.ReadLine();
                        university.Name = nama;
                        university.Id = 22;

                        var result = Universities.InsertUniv(university);
                        if (result > 0)
                        {
                            Console.WriteLine("Insert success.");
                        }
                        else
                        {
                            Console.WriteLine("Insert failed.");
                        }
                    }

                    else if (tabel == 2)
                    {
                        var education = new Educations();
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

                        var result = Educations.InsertEduc(education);
                        if (result > 0)
                        {
                            Console.WriteLine("Insert success.");
                        }
                        else
                        {
                            Console.WriteLine("Insert failed.");
                        }
                    }

                    else if (tabel == 3)
                    {
                        Employees.PrintOutEmployee();
                        break;

                        /*var employees = new Employees();
                        ///Console.Write("Id : ");/
                        //Guid guid = Guid.NewGuid();
                        //string guidString = $"{guid}";

                        /*Console.Write("Masukkan NIK : ");
                        string nik = Console.ReadLine();
                        employees.Nik = nik; 

                        Console.Write("Masukkan First Name : ");
                        string fn = Console.ReadLine();
                        employees.FirstName = fn;

                        Console.Write("Masukkan Last Name : ");
                        string ln = Console.ReadLine();
                        employees.LastName = ln;

                        Console.Write("Masukkan Birthdate : ");
                        DateTime bd = DateTime.Parse(Console.ReadLine());
                        employees.BirthDate = bd;

                        Console.Write("Masukkan Gender : ");
                        string gen = Console.ReadLine();
                        employees.Gender = gen;

                        Console.Write("Masukkan Hiring Date : ");
                        DateTime hd = DateTime.Parse(Console.ReadLine());
                        employees.HiringDate = hd;

                        Console.Write("Masukkan Email : ");
                        string mail = Console.ReadLine();
                        employees.Email = mail;

                        Console.Write("Masukkan Phone Number : ");
                        string pn = Console.ReadLine();
                        employees.PhoneNumber = pn;

                        Console.Write("Masukkan Departement ID : ");
                        string deptId = Console.ReadLine();
                        employees.DepartementId = deptId;

                        var hasil = Create.InsertEmplo(employees);
                        if (hasil > 0)
                        {
                            Console.WriteLine("Insert success.");
                        }
                        else
                        {
                            Console.WriteLine("Insert failed.");
                        }*/
                    }
                    else if (tabel == 4)
                    {
                        Menu();
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case 2:
                    Console.WriteLine("===== PILIH TABEL YANG AKAN DITAMPILKAN =====");
                    Console.WriteLine("=====                                   =====");
                    Console.WriteLine("=====        1. Universities            =====");
                    Console.WriteLine("=====        2. Educations              =====");
                    Console.WriteLine("=====        3. Employees               =====");
                    Console.WriteLine("=====        4. Profillings             =====");
                    Console.WriteLine("=====        5. Tampil Semua Tabel      =====");
                    Console.WriteLine("=====        6. Back                    =====");
                    Console.WriteLine("=====                                   =====");
                    Console.WriteLine("Pilih menu (1/2/3/4/5): ");

                    int tabel2 = Convert.ToInt32(Console.ReadLine());
                    if (tabel2 == 1)
                    {
                        Console.WriteLine("Menampilkan semua data");
                        var results = Universities.GetUniv();
                        foreach (var result in results)
                        {
                            Console.WriteLine("Id: " + result.Id);
                            Console.WriteLine("Name: " + result.Name);
                        }
                    }

                    else if (tabel2 == 2)
                    {
                        Console.WriteLine("Menampilkan semua data");
                        var results = Educations.GetEducation();
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

                    else if (tabel2 == 3)
                    {
                        var results = Employees.GetEmployees();
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

                    else if (tabel2 == 4)
                    {
                        Console.WriteLine("Menampilkan Data Profilings");
                        var resultss = Profilings.GetProfilings();
                        foreach (var result in resultss)
                        {
                            Console.WriteLine("EmployeeId: " + result.EmployeeId);
                            Console.WriteLine("EducationId: " + result.EducationId);
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("");
                        }
                    }
                    else if (tabel2 == 5)
                    {
                        Console.WriteLine("Menampilkan Tabel Join");

                        var emp = Employees.GetEmployees();
                        var profiling = Profilings.GetProfilings();
                        var education = Educations.GetEducation();
                        var university = Universities.GetUniv();
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
                                         Degree =  edu.Degree,
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

                    else if (tabel2 == 6)
                    {
                        Menu();
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case 3:
                    Console.WriteLine("===== PILIH TABEL YANG AKAN DIUBAH =====");
                    Console.WriteLine("=====                              =====");
                    Console.WriteLine("=====        1. Universities       =====");
                    Console.WriteLine("=====        2. Educations         =====");
                    Console.WriteLine("=====        3. Back               =====");
                    Console.WriteLine("=====                              =====");
                    Console.WriteLine("Pilih menu (1/2): ");
                    int tabel3 = Convert.ToInt32(Console.ReadLine());
                    if (tabel3 == 1)
                    {
                        var university1 = new Universities();
                        Console.Write("Masukkan ID : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        university1.Id = id;

                        Console.Write("Masukkan Nama : ");
                        var name3 = Console.ReadLine();
                        university1.Name = name3;

                        var result = Universities.UpdateUniversity(university1);
                        if (result > 0)
                        {
                            Console.WriteLine("Update success");
                        }
                        else
                        {
                            Console.WriteLine("Update Failed");
                        }
                    }
                    else if (tabel3 == 2)
                    {
                        var education1 = new Educations();
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

                        var results = Educations.UpdateEducation(education1);
                        if (results > 0)
                        {
                            Console.WriteLine("Update success");
                        }
                        else
                        {
                            Console.WriteLine("Update Failed");
                        }
                    }
                    else if (tabel3 == 3)
                    {
                        Menu();
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case 4:
                    Console.WriteLine("===== PILIH TABEL YANG AKAN DIHAPUS =====");
                    Console.WriteLine("=====                               =====");
                    Console.WriteLine("=====        1. Universities        =====");
                    Console.WriteLine("=====        2. Educations          =====");
                    Console.WriteLine("=====        3. Back                =====");
                    Console.WriteLine("=====                               =====");
                    Console.WriteLine("Pilih menu (1/2): ");
                    int tabel4 = Convert.ToInt32(Console.ReadLine());
                    if (tabel4 == 1)
                    {
                        var university2 = new Universities();
                        Console.Write("Masukkan ID : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        university2.Id = id;

                        var result = Universities.DeleteUniversity(university2);
                        if (result > 0)
                        {
                            Console.WriteLine("Delete success");
                        }
                        else
                        {
                            Console.WriteLine("Delete Failed");
                        }
                    }

                    else if (tabel4 == 2)
                    {
                        var education2 = new Educations();
                        Console.Write("Masukkan ID : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        education2.Id = id;

                        var result = Educations.DeleteEducation(education2);
                        if (result > 0)
                        {
                            Console.WriteLine("Delete success");
                        }
                        else
                        {
                            Console.WriteLine("Delete Failed");
                        }
                    }

                    else if (tabel4 == 3)
                    {
                        Menu();
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                default:
                    Console.WriteLine();
                    break;

            }

        } while (choice != 5);
    }
}