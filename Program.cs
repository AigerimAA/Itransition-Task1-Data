using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace ItransitionDataIngest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ItransitionData;Trusted_Connection=True;TrustServerCertificate=True;";
            string filePath = "task1_d.json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден!");
                return;
            }

            string fullContent = File.ReadAllText(filePath);
                        
            fullContent = Regex.Replace(fullContent, @":(\w+)\s*=>", @"""$1"":");

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var books = System.Text.Json.JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(fullContent);

            if (books == null || books.Count == 0)
            {
                Console.WriteLine("Ошибка парсинга или пустой список");
                return;
            }

            foreach (var book in books)
            {
                try
                {
                    var cmd = new SqlCommand(
                        "INSERT INTO RawBooks (Title, PublicationYear, PriceRaw) VALUES (@t, @y, @p)",
                        connection);
                    cmd.Parameters.AddWithValue("@t", book["title"].GetString() ?? "Unknown");
                    cmd.Parameters.AddWithValue("@y", book["year"].GetInt32());
                    cmd.Parameters.AddWithValue("@p", book["price"].GetString() ?? "");
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при вставке: {ex.Message}");
                }
            }
            Console.WriteLine("\n--- Работа завершена ---");
            Console.ReadLine();
            
        }
    }
}
