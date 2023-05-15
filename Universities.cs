using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRooms;

public class Universities
{

    public int Id { get; set; }
    public string Name { get; set; }

    /*    Connection SQL Server*/

    private static readonly string connectionString =
        "Data Source=E5\\MSSQLSERVER2; Database=BookingRoom; Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    /*CREATE*/
    public static int InsertUniv(Universities universities)
    {
        int result = 0;
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO Universities(id,name) VALUES (@id,@name)";
            command.Transaction = transaction;

            var pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Size = 50;
            pName.Value = universities.Name;
            command.Parameters.Add(pName);
            var pName2 = new SqlParameter();
            pName2.ParameterName = "@id";
            pName2.SqlDbType = SqlDbType.Int;
            pName2.Size = 50;
            pName2.Value = universities.Id;
            command.Parameters.Add(pName2);

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
    public static List<Universities> GetUniv()
    {
        var universities = new List<Universities>();
        using SqlConnection connection = new SqlConnection(connectionString);
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Universities";
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var university = new Universities();
                    university.Id = reader.GetInt32(0);
                    university.Name = reader.GetString(1);

                    universities.Add(university);
                }
                return universities;
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
        return new List<Universities>();
    }

    /*UPDATE*/
    public static int UpdateUniversity(Universities university)
    {
        int result = 0;
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE Universities SET name = (@name) WHERE id = (@id)";
            command.Transaction = transaction;

            var pName = new SqlParameter();
            var pId = new SqlParameter();

            pName.ParameterName = "@name";
            pId.ParameterName = "@id";
            pName.Value = university.Name;
            pId.Value = university.Id;

            command.Parameters.Add(pName);
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
    public static int DeleteUniversity(Universities university)
    {
        int result = 0;
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM Universities WHERE id = (@id)";
            command.Transaction = transaction;

            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = university.Id;

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

