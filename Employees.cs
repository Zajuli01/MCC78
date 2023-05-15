﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms;

public class Employees
{
    private static readonly string connectionString =
     "Data Source=E5\\MSSQLSERVER2; Database=BookingRoom;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    public int Id { get; set; }
    public string Nik { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public string Gender { get; set; }
    public DateTime HiringDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int DepartmentId { get; set; }

    public static int InsertEmployee(Employees employees)
    {
        int result = 0;
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO Employees(nik, first_name, last_name, birthdate, gender, hiring_date, email, phone_number, department_id) " +
                "VALUES (@NIK, @FirstName, @LastName, @Birthdate, @Gender, @HiringDate, @Email, @PhoneNumber, @DepartmentId)";
            command.Transaction = transaction;

            var pNIK = new SqlParameter();
            pNIK.ParameterName = "@NIK";
            pNIK.SqlDbType = SqlDbType.VarChar;
            pNIK.Size = 6;
            pNIK.Value = employees.Nik;
            command.Parameters.Add(pNIK);

            var pFname = new SqlParameter();
            pFname.ParameterName = "@FirstName";
            pFname.SqlDbType = SqlDbType.VarChar;
            pFname.Size = 50;
            pFname.Value = employees.FirstName;
            command.Parameters.Add(pFname);

            var pLname = new SqlParameter();
            pLname.ParameterName = "@LastName";
            pLname.SqlDbType = SqlDbType.VarChar;
            pLname.Size = 50;
            pLname.Value = employees.LastName;
            command.Parameters.Add(pLname);

            var pBday = new SqlParameter();
            pBday.ParameterName = "@Birthdate";
            pBday.Value = employees.Birthdate;
            pBday.SqlDbType = SqlDbType.DateTime;
            command.Parameters.Add(pBday);

            var pGender = new SqlParameter();
            pGender.ParameterName = "@Gender";
            pGender.SqlDbType = SqlDbType.VarChar;
            pGender.Size = 10;
            pGender.Value = employees.Gender;
            command.Parameters.Add(pGender);

            var pHdate = new SqlParameter();
            pHdate.ParameterName = "@HiringDate";
            pBday.SqlDbType = SqlDbType.DateTime;
            pHdate.Value = employees.HiringDate;
            command.Parameters.Add(pHdate);

            var pEmail = new SqlParameter();
            pEmail.ParameterName = "@Email";
            pEmail.SqlDbType = SqlDbType.VarChar;
            pEmail.Size = 50;
            pEmail.Value = employees.Email;
            command.Parameters.Add(pEmail);

            var pNumber = new SqlParameter();
            pNumber.ParameterName = "@PhoneNumber";
            pNumber.SqlDbType = SqlDbType.VarChar;
            pNumber.Size = 20;
            pNumber.Value = employees.PhoneNumber;
            command.Parameters.Add(pNumber);

            var pDepid = new SqlParameter();
            pDepid.ParameterName = "@DepartmentId";
            pDepid.SqlDbType = SqlDbType.Int;
            pDepid.Size = 4;
            pDepid.Value = employees.DepartmentId;
            command.Parameters.Add(pDepid);

            result = command.ExecuteNonQuery();
            transaction.Commit();

            return result;
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            transaction.Rollback();
        }
        finally
        {
            connection.Close();
        }
        return result;
    }

    public static string GetEmpId(string NIK)
    {
        using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM Universities ORDER BY id DESC", connection);

        var niks = new SqlParameter();
        niks.ParameterName = "@NIK";
        niks.Value = NIK;
        command.Parameters.Add(niks);

        string lastEmpId = Convert.ToString(command.ExecuteScalar());
        connection.Close();

        return lastEmpId;
    }

    public static int GetUnivEduId(int choice)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        if (choice == 1)
        {
            SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM Universities ORDER BY id DESC", connection);

            int id = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return id;
        }
        else
        {
            SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM Universities ORDER BY id DESC", connection);

            int id = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return id;
        }
    }
    public static void PrintOutEmployee()
    {
        var employee = new Employees();
        var profiling = new Profillings();
        var education = new Educations();
        var university = new Universities();

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
        employee.DepartmentId = Convert.ToInt32(Console.ReadLine());

       

        //EDUCATION
        Console.Write("Major : ");
        education.Major = Console.ReadLine();

        Console.Write("Degree : ");
        education.Degree = Console.ReadLine();

        Console.Write("GPA : ");
        education.Gpa = Console.ReadLine();

        Console.Write("University Name : ");
        university.Name = Console.ReadLine();

         var result = Employees.InsertEmployee(employee);
        if (result > 0)
        {
            Console.WriteLine("Insert Success");
        }
        else
        {
            Console.WriteLine("Insert Failed");
        }
        Universities.InsertUniv(university);

        education.UniversityId = GetUnivEduId(1);
        Educations.InsertEduc(education);

        profiling.EmployeeId = GetEmpId(niks);
        profiling.EducationId = GetUnivEduId(2);
        Profillings.InsertProfiling(profiling);

    }


    /*READ*/
    /*public static List<Employees> GetEmployees()
    {
        var emp = new List<Employees>();
        using SqlConnection connection = new SqlConnection(connectionString);
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Employees";
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var emplo = new Employees();
                    emplo.Id = reader.GetGuid(0).ToString();
                    emplo.Nik = reader.GetString(1);
                    emplo.FirstName = reader.GetString(2);
                    emplo.LastName = reader.GetString(3);
                    emplo.BirthDate = reader.GetDateTime(4);
                    emplo.Gender = reader.GetString(5);
                    emplo.HiringDate = reader.GetDateTime(6);
                    emplo.Email = reader.GetString(7);
                    emplo.PhoneNumber = reader.GetString(8);
                    emplo.DepartementId = reader.GetString(9);

                    emp.Add(emplo);
                }
                return emp;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return new List<Employees>();
    }*/
}
