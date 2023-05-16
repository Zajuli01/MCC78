﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Profilings
{
    public string EmployeeId { get; set; }
    public int EducationId { get; set; }

    private static readonly string connectionString =
     "Data Source=E5\\MSSQLSERVER2; Database=BookingRoom;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
    public static int InsertProfiling(Profilings profilings)
    {
        int result = 0;
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var employee = new Employees();
        var education = new Educations();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO Profilings(employee_id, education_id) VALUES (@EmployeeId, @EducationId)";
            command.Transaction = transaction;

            var pEmpId = new SqlParameter();
            pEmpId.ParameterName = "@EmployeeId";
            pEmpId.Value = profilings.EmployeeId;
            command.Parameters.Add(pEmpId);

            var pEduId = new SqlParameter();
            pEduId.ParameterName = "@EducationId";
            pEduId.Value = profilings.EducationId;
            command.Parameters.Add(pEduId);

            result = command.ExecuteNonQuery();
            transaction.Commit();

            return result;
        }

        catch (Exception e)
        {
            transaction.Rollback();
        }
        finally
        {
            connection.Close();
        }
        return result;
    }

    /*READ*/
public static List<Profilings> GetProfilings()
    {
        var pro = new List<Profilings>();
        using SqlConnection connection = new SqlConnection(connectionString);
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Profilings";
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var prof = new Profilings();
                    prof.EmployeeId = reader.GetGuid(0).ToString();
                    prof.EducationId = reader.GetInt32(1);

                    pro.Add(prof);
                }
                return pro;
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
        return new List<Profilings>();
    }
}





