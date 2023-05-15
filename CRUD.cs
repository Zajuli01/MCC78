//using System.Data.SqlClient;
//using System.Data;
//using static System.Net.Mime.MediaTypeNames;
//using System;
//using TugasGG;

//public class CRUD
//{
//    private static readonly string connectionString =
//        "Data Source=ASUSVIVOBOOK\\SQLSERVER; Database=booking_rooms; Integrated Security=True;Connect Timeout=30;Encrypt=False;";

//    //public static void Main()
//    //{
//    //    Console.WriteLine("Zajuli Taupiq Bisri");
//    //    Console.WriteLine("DELETE BY ID = 7");
//    //    Console.WriteLine("Delete success");


//    //    // Untuk mengecek apakah database sudah connect atau belum 
//    //    /*SqlConnection connection = new SqlConnection(connectionString);

//    //    try
//    //    {
//    //        connection.Open();
//    //        Console.WriteLine("Connection opened successfully.");
//    //    }

//    //    catch (Exception ex)
//    //    {
//    //        Console.WriteLine(ex.Message);
//    //    }

//    //    finally
//    //    {
//    //        connection.Close();
//    //        Console.WriteLine("Connection closed successfully.");
//    //    }*/

//    //    //=== Memanggil Data Universitas ===
//    //    /*var results = GetUniversities();
//    //    foreach (var result in results)
//    //    {
//    //        Console.WriteLine("Id: " + result.Id);
//    //        Console.WriteLine("Name: " + result.Name);
//    //    }*/



//    //    /*var universities = new Universities();
//    //    universities.Name = "Akademi Konoha";

//    //    var result = InsertUniversities(universities);
//    //    if (result > 0)
//    //    {
//    //        Console.WriteLine("Insert success.");
//    //    }
//    //    else
//    //    {
//    //        Console.WriteLine("Insert failed.");
//    //    }*/
//    //}

//    // GET : Universities
//    /*public static List<Universities> GetUniversities()
//    {
//        var Universities = new List<Universities>();
//        using SqlConnection connection = new SqlConnection(connectionString);
//        try
//        {
//            SqlCommand command = new SqlCommand();
//            command.Connection = connection;
//            command.CommandText = "SELECT * FROM Universities";

//            connection.Open();

//            using SqlDataReader reader = command.ExecuteReader();
//            if (reader.HasRows)
//            {
//                while (reader.Read())
//                {
//                    var universities = new Universities();
//                    universities.Id = reader.GetInt32(0);
//                    universities.Name = reader.GetString(1);

//                    Universities.Add(universities);
//                }

//                return Universities;
//            }

//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//        finally
//        {
//            connection.Close();
//        }
//        return new List<Universities>();
//    }*/


//    // GET : Universities by ID(5)


//    // INSERT : Universities
//    /*public static int InsertUniversities(Universities universities)
//    {
//        int result = 0;
//        using var connection = new SqlConnection(connectionString);
//        connection.Open();

//        SqlTransaction transaction = connection.BeginTransaction();
//        try
//        {
//            // Command melakukan insert
//            SqlCommand command = new SqlCommand();
//            command.Connection = connection;
//            command.CommandText = "INSERT INTO Universities(name) VALUES (@name)";
//            command.Transaction = transaction;

//            // Membuat parameter
//            var pName = new SqlParameter();
//            pName.ParameterName = "@name";
//            pName.SqlDbType = SqlDbType.VarChar;
//            pName.Size = 50;
//            pName.Value = universities.Name;

//            // Menambahkan parameter ke command
//            command.Parameters.Add(pName);

//            // Menjalankan command
//            result = command.ExecuteNonQuery();
//            transaction.Commit();

//            return result;

//        }
//        catch (Exception e)
//        {
//            transaction.Rollback();
//        }
//        finally
//        {
//            connection.Close();
//        }

//        return result;
//    }*/


//    // UPDATE : Universities(obj)



//    // DELETE : Universities(5)

//    public static int DeleteUniversities(Universities universities)
//    {
//        int result = 0;
//        using var connection = new SqlConnection(connectionString);
//        connection.Open();

//        SqlTransaction transaction = connection.BeginTransaction();
//        try
//        {
//            // Command melakukan insert
//            SqlCommand command = new SqlCommand();
//            command.Connection = connection;
//            command.CommandText = "INSERT INTO Universities(name) VALUES (@name)";
//            command.Transaction = transaction;

//            // Membuat parameter
//            var pName = new SqlParameter();
//            pName.ParameterName = "@name";
//            pName.SqlDbType = SqlDbType.VarChar;
//            pName.Size = 50;
//            pName.Value = universities.Name;

//            // Menambahkan parameter ke command
//            command.Parameters.Add(pName);

//            // Menjalankan command
//            result = command.ExecuteNonQuery();
//            transaction.Commit();

//            return result;

//        }
//        catch (Exception e)
//        {
//            transaction.Rollback();
//        }
//        finally
//        {
//            connection.Close();
//        }

//        return result;
//    }

//}


