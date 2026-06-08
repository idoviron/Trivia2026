using Npgsql;

namespace TriviaServer2
{
    public class DatabaseManager
    {
        public async Task<List<Question>> GetQuestions()
        {
            List<Question> result = new List<Question>();
            string connectionString = "Host=aws-1-ap-northeast-1.pooler.supabase.com;Database=postgres;Username=postgres.ghbgzbbcdtxzdlzaqvov;Password=TiltanQq123!@#;SSL Mode=Require;Trust Server Certificate=true";



            /*var connectionString =
                "Host=aws-xxx.pooler.supabase.com;" +
                "Port=6543;" +
                "Database=postgres;" +
                "Username=postgres.xxxxxxxxxxxxxxxx;" +
                "Password=YOUR_PASSWORD;" +
                "SSL Mode=Require;" +
                "Trust Server Certificate=true;";*/

            await using var conn = new NpgsqlConnection(connectionString);
            await conn.OpenAsync();

            await using var cmd = new NpgsqlCommand(
                "SELECT * FROM \"Questions\" LIMIT 10",
                conn
            );

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                //Console.WriteLine($"{reader["id"]}: {reader["text"]}");
                Question curr_question = new Question();
                curr_question.Id = reader.GetInt16(reader.GetOrdinal("Id"));
                curr_question.Text = reader.GetString(reader.GetOrdinal("text"));
                curr_question.Ans1 = reader.GetString(reader.GetOrdinal("ans1"));
                curr_question.Ans2 = reader.GetString(reader.GetOrdinal("ans2"));
                curr_question.Ans3 = reader.GetString(reader.GetOrdinal("ans3"));
                curr_question.Ans4 = reader.GetString(reader.GetOrdinal("ans4"));
                curr_question.CorrectAns = reader.GetInt16(reader.GetOrdinal("correct_ans"));

                result .Add(curr_question);
            }
            return result;
        }

        public async Task<List<Question>> GetQuestion(string id)
        {
            List<Question> result = new List<Question>();
            string connectionString = "Host=aws-1-ap-northeast-1.pooler.supabase.com;Database=postgres;Username=postgres.ghbgzbbcdtxzdlzaqvov;Password=TiltanQq123!@#;SSL Mode=Require;Trust Server Certificate=true";



            /*var connectionString =
                "Host=aws-xxx.pooler.supabase.com;" +
                "Port=6543;" +
                "Database=postgres;" +
                "Username=postgres.xxxxxxxxxxxxxxxx;" +
                "Password=YOUR_PASSWORD;" +
                "SSL Mode=Require;" +
                "Trust Server Certificate=true;";*/

            await using var conn = new NpgsqlConnection(connectionString);
            await conn.OpenAsync();

            await using var cmd = new NpgsqlCommand(
                "SELECT * FROM \"Questions\" WHERE ID = " + id + " LIMIT 10;",
                conn
            );

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                //Console.WriteLine($"{reader["id"]}: {reader["text"]}");
                Question curr_question = new Question();
                curr_question.Id = reader.GetInt16(reader.GetOrdinal("Id"));
                curr_question.Text = reader.GetString(reader.GetOrdinal("text"));
                curr_question.Ans1 = reader.GetString(reader.GetOrdinal("ans1"));
                curr_question.Ans2 = reader.GetString(reader.GetOrdinal("ans2"));
                curr_question.Ans3 = reader.GetString(reader.GetOrdinal("ans3"));
                curr_question.Ans4 = reader.GetString(reader.GetOrdinal("ans4"));
                curr_question.CorrectAns = reader.GetInt16(reader.GetOrdinal("correct_ans"));

                result.Add(curr_question);
            }
            return result;
        }
    }
}
