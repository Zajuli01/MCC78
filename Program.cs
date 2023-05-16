using System.Data.SqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System;
using TugasGG;
using TugasGG.View;
using TugasGG.Controller;

public class Program
{
    private static readonly string connectionString =
        "Data Source=E5\\MSSQLSERVER2; Database=BookingRoom;; Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    private static UniversityController universityController = new();
    private static EducationController educationController = new();
    private static EmployeeController employeeController = new();


    public static void Main()
    {

        int choice;
        do
        {
            MenuView.Menu1();
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    MenuView.MenuInsert();

                    int tabel = Convert.ToInt32(Console.ReadLine());
                    if (tabel == 1)
                    {
                        UniversityView.InsertUni();
                    }

                    else if (tabel == 2)
                    {
                        EducationView.InsertEdu();
                    }

                    else if (tabel == 3)
                    {
                        EmployeeView.InsertEmp();
                        break;

                    }
                    else if (tabel == 4)
                    {
                        MenuView.Menu1();
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case 2:
                    MenuView.MenuGetAll();
                    int tabel2 = Convert.ToInt32(Console.ReadLine());
                    if (tabel2 == 1)
                    {
                        universityController.GetAll();
                    }

                    else if (tabel2 == 2)
                    {
                        educationController.GetAll();

                    }

                    else if (tabel2 == 3)
                    {
                        employeeController.GetAll();
                    }

                    else if (tabel2 == 4)
                    {
                        ProfilingView.GetAllProfil();
                    }
                    else if (tabel2 == 5)
                    {
                        TablesView.GetJoinTables();

                    }

                    else if (tabel2 == 6)
                    {
                        MenuView.Menu1();
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case 3:
                    MenuView.MenuUpdate();
                    int tabel3 = Convert.ToInt32(Console.ReadLine());
                    if (tabel3 == 1)
                    {
                        UniversityView.Update();
                    }
                    else if (tabel3 == 2)
                    {
                        EducationView.Update();
                    }
                    else if (tabel3 == 3)
                    {
                        MenuView.Menu1();
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case 4:
                    MenuView.MenuDelete();
                    int tabel4 = Convert.ToInt32(Console.ReadLine());
                    if (tabel4 == 1)
                    {
                        UniversityView.Delete();
                    }

                    else if (tabel4 == 2)
                    {
                        EducationView.Delete();
                    }

                    else if (tabel4 == 3)
                    {
                        MenuView.Menu1();
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