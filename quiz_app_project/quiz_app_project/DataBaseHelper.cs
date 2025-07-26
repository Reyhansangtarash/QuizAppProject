using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace quiz_app_project
{
    internal class DataBaseHelper
    {
        public static class DatabaseHelper
        {
            private static string connectionString =
                                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\quizapp.mdf;Integrated Security=True;";


            // گرفتن همه‌ی کاربران
            public static List<Users> GetUsers()
            {
                var users = new List<Users>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM [User]";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        users.Add(new Users(
                            Convert.ToInt32(reader["Id"]),
                            reader["UserName"].ToString(),
                            reader["Password"].ToString()
                        ));
                    }
                }
                return users;
            }

            // گرفتن همه‌ی سوالات
            public static List<Question> GetQuestions()
            {
                var questions = new List<Question>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Questions";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        questions.Add(new Question
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Text = reader["Text"].ToString(),
                            OptionA = reader["Option1"].ToString(),
                            OptionB = reader["Option2"].ToString(),
                            OptionC = reader["Option3"].ToString(),
                            OptionD = reader["Option4"].ToString(),
                            CorrectAnswer = Convert.ToChar(reader["CorrectAnswer"])
                        });
                    }
                }
                return questions;
            }

            // ذخیره نتیجه
            public static void SaveResult(Result result)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Result (UserId, Score, DateTaken) VALUES (@UserId, @Score, @DateTaken)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserId", result.UserId);
                    cmd.Parameters.AddWithValue("@Score", result.Score);
                    cmd.Parameters.AddWithValue("@DateTaken", result.DateTaken);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
