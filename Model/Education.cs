using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasGG.Context;

public class Education
{
    public int Id { get; set; }
    public string Major { get; set; }
    public string Degree { get; set; }
    public string Gpa { get; set; }
    public int UniversityId { get; set; }

    /*CREATE*/
    public int InsertEduc(Education educations)
    {
        int result = 0;
        using var connection = ConnectionDatabase.Get();
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO Educations (id,major,degree,gpa,university_id) VALUES (@id,@major, @degree, @gpa, @university_id)";
            command.Transaction = transaction;

            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Size = 100;
            pId.Value = educations.Id;
            command.Parameters.Add(pId);

            var pMajor = new SqlParameter();
            pMajor.ParameterName = "@major";
            pMajor.SqlDbType = SqlDbType.VarChar;
            pMajor.Size = 100;
            pMajor.Value = educations.Major;
            command.Parameters.Add(pMajor);

            var pDegree = new SqlParameter();
            pDegree.ParameterName = "@degree";
            pDegree.SqlDbType = SqlDbType.VarChar;
            pDegree.Size = 100;
            pDegree.Value = educations.Degree;
            command.Parameters.Add(pDegree);

            var pGpa = new SqlParameter();
            pGpa.ParameterName = "@gpa";
            pGpa.SqlDbType = SqlDbType.VarChar;
            pGpa.Size = 5;
            pGpa.Value = educations.Gpa;
            command.Parameters.Add(pGpa);

            var pUniversity_id = new SqlParameter();
            pUniversity_id.ParameterName = "@university_id";
            pUniversity_id.SqlDbType = SqlDbType.Int;
            pUniversity_id.Value = educations.UniversityId;
            command.Parameters.Add(pUniversity_id);

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
    public List<Education> GetEducation()
    {
        var educations = new List<Education>();
        using SqlConnection connection = ConnectionDatabase.Get();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Educations";
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var education = new Education();
                    education.Id = reader.GetInt32(0);
                    education.Major = reader.GetString(1);
                    education.Degree = reader.GetString(2);
                    education.Gpa = reader.GetString(3);
                    education.UniversityId = reader.GetInt32(4);

                    educations.Add(education);
                }
                return educations;
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
        return new List<Education>();
    }


    /*UPDATE*/
    public int UpdateEducation(Education education)
    {
        int result = 0;
        using var connection = ConnectionDatabase.Get();
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE Educations SET major = @major, degree = @degree, gpa = @gpa, university_id = @univ_id WHERE id = @id";
            command.Transaction = transaction;

            var pMajor = new SqlParameter();
            pMajor.ParameterName = "@major";
            pMajor.Value = education.Major;

            var pDegree = new SqlParameter();
            pDegree.ParameterName = "@degree";
            pDegree.Value = education.Degree;

            var pGpa = new SqlParameter();
            pGpa.ParameterName = "@gpa";
            pGpa.Value = education.Gpa;

            var pUniversity_id = new SqlParameter();
            pUniversity_id.ParameterName = "@univ_id";
            pUniversity_id.Value = education.UniversityId;

            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = education.Id;

            command.Parameters.Add(pGpa);
            command.Parameters.Add(pDegree);
            command.Parameters.Add(pMajor);
            command.Parameters.Add(pUniversity_id);
            command.Parameters.Add(pId);

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

    /*DELETE*/
    public int DeleteEducation(Education educations)
    {
        int result = 0;
        using var connection = ConnectionDatabase.Get();
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM Educations WHERE id = (@id)";
            command.Transaction = transaction;

            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = educations.Id;

            command.Parameters.Add(pId);
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

}
