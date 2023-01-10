using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DB
{
    public class DbConnection
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\ForceOfArt\\DB\\Database1.mdf;Integrated Security=True";

        public async void CreateDB()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string expr = "CREATE DATABASE artobj";
                SqlCommand command = new SqlCommand(expr,connection);
                await command.ExecuteNonQueryAsync();
            }
        }
        public async void FillData(List<ArtObject> objects)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string expr = "DROP TABLE IF EXISTS objects CREATE TABLE objects(artist NVARCHAR(200),classification NVARCHAR(100),continent NVARCHAR(100),country NVARCHAR(100),creditline NVARCHAR(100),culture NVARCHAR(100)," +
                    "dated NVARCHAR(100),department NVARCHAR(100),imagepath NVARCHAR(100),image NVARCHAR(100),inscription NVARCHAR(100)," +
                    "markings NVARCHAR(100),medium NVARCHAR(100),objectname NVARCHAR(100), portfolio NVARCHAR(100),rights_type NVARCHAR(100),signed NVARCHAR(100),style NVARCHAR(100),tytle NVARCHAR(100))";
                SqlCommand command = new SqlCommand(expr, connection);
                command.ExecuteNonQuery();
                expr = "DROP TABLE IF EXISTS artists CREATE TABLE artists (artist NVARCHAR(200),life_date NVARCHAR(100),role NVARCHAR(100),nationality NVARCHAR(100))";
                command = new SqlCommand(expr, connection);
                command.ExecuteNonQuery();
                foreach (var obj in objects){
                    string exp = $"INSERT INTO objects VALUES('{obj.artist}','{obj.classification}','{obj.continent}','{obj.country}','{obj.creditline}','{obj.culture}'," +
                        $"'{obj.dated}','{obj.department}','{obj.id}','{obj.image}','{obj.inscription}','{obj.markings}'," +
                        $"'{obj.medium}','{obj.object_name}','{obj.portfolio}','{obj.rights_type}'," +
                        $"'{obj.signed}','{obj.style}','{obj.title}')";
                    exp = exp.Replace("''", "NULL");
                    SqlCommand cmd = new SqlCommand(exp, connection);
                    cmd.ExecuteNonQuery();
                    exp = $"INSERT INTO artists VALUES('{obj.artist}','{obj.life_date}','{obj.role}','{obj.nationality}')";
                    cmd = new SqlCommand(exp, connection);
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public  List<object[]> Find(string keyword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string expr = $"Select * from objects WHERE tytle LIKE '%{keyword}%'";
                SqlCommand command = new SqlCommand(expr, connection);
                var res = new List<object[]>();
                var reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    res.Add(values);
                    }
                    return res;
                
            }
        }
    }
}
