﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TugasGG.Context;

public class Employee
{
    
    public string Id { get; set; }
    public string Nik { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public string Gender { get; set; }
    public DateTime HiringDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string departement_id { get; set; }

    /* CREATE */
    public int InsertEmployee(Employee employees)
    {
        int result = 0;
        using var connection = ConnectionDatabase.Get();
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO Employees (nik, first_name, last_name, birthdate, gender, hiring_date, email, phone_number, departement_id) " +
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
            pDepid.Value = employees.departement_id;
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

    // Mengambil NIK pada employee, untuk nanti menyesuaikan dengan ID nya. Karena ID pada employee bertipe data GUID
    public  string GetEmpId(string NIK)
    {
        using SqlConnection connection = ConnectionDatabase.Get();
        connection.Open();

        SqlCommand command = new SqlCommand("SELECT id FROM Employees WHERE nik=(@NIK)", connection);

        var niks = new SqlParameter();
        niks.ParameterName = "@NIK";
        niks.Value = NIK;
        command.Parameters.Add(niks);

        string lastEmpId = Convert.ToString(command.ExecuteScalar());
        connection.Close();

        return lastEmpId;
    }


    public int GetUnivEduId(int choice)
    {
        using var connection = ConnectionDatabase.Get();
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
            SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM Educations ORDER BY id DESC", connection);

            int id = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return id;
        }
    }

    /* READ*/
    public List<Employee> GetEmployees()
    {
        var emp = new List<Employee>();
        using SqlConnection connection = ConnectionDatabase.Get();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select*from Employees";
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var emplo = new Employee();
                    emplo.Id = reader.GetGuid(0).ToString();
                    emplo.Nik = reader.GetString(1);
                    emplo.FirstName = reader.GetString(2);
                    emplo.LastName = reader.GetString(3);
                    emplo.Birthdate = reader.GetDateTime(4);
                    emplo.Gender = reader.GetString(5);
                    emplo.HiringDate = reader.GetDateTime(6);
                    emplo.Email = reader.GetString(7);
                    emplo.PhoneNumber = reader.GetString(8);
                    emplo.departement_id = reader.GetString(9);

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
        return new List<Employee>();
    }
}







