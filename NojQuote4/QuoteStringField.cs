using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace Quote2020
{
    internal class QuoteStringField
    {
        internal static List<string> Query(string sql_query)
        {
            List<string> result = new List<string>();
            SqliteConnection conn = QuoteBook.Connect();
            if (conn == null) return new List<string>();
            conn.Open();
            try
            {
                var cmd = new SqliteCommand(sql_query, conn);
                SqliteDataReader results = cmd.ExecuteReader();
                while (results.Read())
                {
                    result.Add(results.GetString(0));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        internal static string Encode(string sql_data)
        {
            // No support for prepared Statements? Woof - here is a quick fix:
            return sql_data.Replace("'", "&#39;");
        }

        internal static string Decode(string sql_data)
        {
            // No support for prepared Statements? Woof - here is a quick fix:
            return sql_data.Replace("&#39;", "'");
        }
    }

}