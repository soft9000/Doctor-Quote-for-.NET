using Microsoft.Data.Sqlite;
using Ordered;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Quote2020
{

    public class QuoteBook
    {
        public static readonly string STATE_DELETED = "DELETED"; // BOOK INCLUSION STATE
        public static readonly string STATE_READY = "READY";
        public static readonly string STATE_IGNORE = "UNLOVED";


        public static readonly string GBU_BEST = "GBU_BEST";
        public static readonly string GBU_GOOD = "GBU_GOOD";

        public static List<string> GetQuoteAuthors()
        {
            return QuoteStringField.Query("SELECT DISTINCT AUTHOR FROM {QuoteTable} ORDER BY AUTHOR;");
        }

        public static List<string> GetQuoteSources()
        {
            return QuoteStringField.Query("SELECT DISTINCT SOURCE FROM {QuoteTable} ORDER BY SOURCE;");
        }

        public static readonly string GBU_BAD = "GBU_BAD";


        public static readonly string GBU_UGLY = "GBU_UGLY";
        public static readonly string GBU_NONE = ""; // 2020 CONSTRAINED: NULL is no longer - ever - in the table.
        public static readonly string QuoteTable = "NojQuote4";

        public static bool Read(Int64 zid, out Quote quote)
        {
            SqliteConnection conn = Connect();
            if (conn == null)
            {
                quote = new Quote();
                return false;
            }
            conn.Open();
            try
            {
                var cmd = new SqliteCommand("SELECT * FROM {QuoteTable} WHERE ID = {zid} LIMIT 1;", conn);
                SqliteDataReader results = cmd.ExecuteReader();
                while (results.Read())
                {
                    if (Quote.CreateFrom(results, out quote))
                    {
                        return true;
                    }
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
            quote = new Quote();
            return false;
        }

        public static bool SetStateReady(Int64 zid)
        {
            SqliteConnection conn = Connect();
            if (conn == null) return false;
            conn.Open();
            SqliteTransaction trans = conn.BeginTransaction();
            bool br = Update(conn, trans, "UPDATE  {QuoteTable} SET STATE = '{STATE_READY}' WHERE ID = {zid};");
            if (br)
                trans.Commit();
            conn.Close();
            return br;
        }

        public static bool SetGbuCode(long zid, string gbucode)
        {
            SqliteConnection conn = Connect();
            if (conn == null) return false;
            conn.Open();
            SqliteTransaction trans = conn.BeginTransaction();
            bool br = Update(conn, trans, "UPDATE  {QuoteTable} SET GBUCODE = '{gbucode}' WHERE ID = {zid};");
            if (br)
                trans.Commit();
            conn.Close();
            return br;
        }

        public static bool SetStateDeleted(Int64 zid)
        {
            return SetState(zid, STATE_DELETED);
        }

        public static bool SetState(long zid, string BookStateCode)
        {
            SqliteConnection conn = Connect();
            if (conn == null) return false;
            conn.Open();
            SqliteTransaction trans = conn.BeginTransaction();
            bool br = Update(conn, trans, "UPDATE  {QuoteTable} SET STATE = '{BookStateCode}' WHERE ID = {zid};");
            if (br) trans.Commit();
            conn.Close();
            return br;
        }

        public static SortedDictionary<string, int> AddTopics(SortedDictionary<string, int> reader)
        {
             SortedDictionary<string, int> topics;
            GetTopics(out topics);
            return SorterSet.Combine(reader, topics);
        }

        private static void GetTopics(out SortedDictionary<string, int> topics)
        {
            topics = new SortedDictionary<string, int>();
            var con = Connect();
            con.Open();
            List<Quote> quotes;
            if (LoadSelection(out quotes, "SELECT * FROM  {QuoteTable} WHERE TOPICS <> '';"))
            {
                foreach (var quote in quotes)
                {
                    List<string> zwords;
                    quote.GetTopics(out zwords);
                    foreach (var word in zwords)
                    {
                        if (word.Trim().Length == 0) continue;
                        if (topics.Keys.Contains<string>(word))
                        {
                            topics[word] = topics[word] + 1;
                        }
                        else
                        {
                            topics[word] = 1;
                        }
                    }

                }
            }
            con.Close();
        }

        public static bool LoadTodoSortedLtd(out List<Quote> quotes, int limit = 100)
        {
            return LoadSelection(out quotes, "SELECT * FROM  {QuoteTable} WHERE GBUCODE IS '{QuoteBook.GBU_NONE}' ORDER BY QUOTE LIMIT {limit};");
        }

        public static bool LoadTodoLtd(out List<Quote> quotes, int limit = 100)
        {
            return LoadSelection(out quotes, "SELECT * FROM  {QuoteTable} WHERE GBUCODE IS '{QuoteBook.GBU_NONE}' LIMIT {limit};");
        }

        public static bool SearchTodoLtd(out List<Quote> quotes, string ntopic, int limit = 100)
        {
            return LoadSelection(out quotes,
                "SELECT * FROM  {QuoteTable} WHERE QUOTE LIKE '%{ntopic}%' AND GBUCODE IS '{QuoteBook.GBU_NONE}' LIMIT {limit};");
        }

        public static bool SearchTodoUnLtd(out List<Quote> quotes, string ntopic)
        {
            return LoadSelection(out quotes,
                "SELECT * FROM  {QuoteTable} WHERE QUOTE LIKE '%{ntopic}%' AND GBUCODE IS '{QuoteBook.GBU_NONE}';");
        }

        public static bool UpdateKeywords(List<Quote> quotes)
        {
            SqliteConnection conn = Connect();
            if (conn == null) return false;
            conn.Open();
            SqliteTransaction trans = conn.BeginTransaction();

            foreach (var quote in quotes)
            {
                if (UpdateKeywords(conn, trans, quote.ID, quote.KEYWORDS) == false)
                {
                    trans.Rollback();
                    conn.Close();
                    return false;
                }
            }
            trans.Commit();
            conn.Close();
            return true;
        }

        public static bool UpdateTopics(List<Quote> quotes)
        {
            SqliteConnection conn = Connect();
            if (conn == null) return false;
            conn.Open();
            SqliteTransaction trans = conn.BeginTransaction();
            foreach (var quote in quotes)
            {
                if (UpdateTopics(conn, trans, quote.ID, quote.TOPICS) == false)
                {
                    trans.Rollback();
                    conn.Close();
                    return false;
                }
            }
            trans.Commit();
            conn.Close();
            return true;
        }


        public static bool CreateKeywords()
        {
            /* JIC -  
            if (QuoteBook.LoadUnBest(out List<Quote> quotes) == false)
                return false;

            if (QuoteBook.DropKeywords(quotes) == false)
            {
                Console.WriteLine("Unable to DropKeywords");
                return false;
            }
            quotes.Clear();
            */
            if (!QuoteBook.MkKeywords())
            {
                Console.WriteLine("Unable to MkKeywords");
                return false;
            }
            //ReDelete(); // might have none?
            return true;

        }

        public static bool LoadUnBest(out List<Quote> zresults)
        {
            return LoadSelection(out zresults, "SELECT * FROM  {QuoteTable} WHERE GBUCODE <> '{QuoteBook.GBU_BEST}';");
        }

        static bool UpdateKeywords(SqliteConnection conn, SqliteTransaction trans, Int64 zid, string ztags)
        {
            return Update(conn, trans, "UPDATE  {QuoteTable} SET KEYWORDS = '{ztags}' WHERE ID = {zid};");
        }

        static bool UpdateTopics(SqliteConnection conn, SqliteTransaction trans, Int64 zid, string ztags)
        {
            return Update(conn, trans, "UPDATE  {QuoteTable} SET TOPICS = '{ztags}' WHERE ID = {zid};");
        }

        static bool Update(SqliteConnection conn, SqliteTransaction trans, string sql)
        {

            try
            {
                var cmd = new SqliteCommand(sql, conn, trans);
                if (cmd.ExecuteNonQuery() >= 1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public static bool LoadAll(out List<Quote> zresults)
        {
            return LoadSelection(out zresults, "SELECT * FROM  {QuoteTable};");
        }

        public static bool LoadGBU(out List<Quote> zresults, string GBUCODE)
        {
            return LoadSelection(out zresults, "SELECT * FROM  {QuoteTable} WHERE GBUCODE = '{GBUCODE}';");
        }

        public static bool LoadDone(out List<Quote> zresults)
        {
            return LoadSelection(out zresults, "SELECT * FROM  {QuoteTable} WHERE (GBUCODE = '{QuoteBook.GBU_BEST}' AND STATE = 'READY') ORDER BY QUOTE;");
        }

        public static bool LoadUnDone(out List<Quote> zresults)
        {
            return LoadSelection(out zresults, "SELECT * FROM  {QuoteTable} WHERE (GBUCODE = '{QuoteBook.GBU_BEST}' AND STATE <> '{STATE_READY}' AND STATE <> '{STATE_DELETED}');");
        }

        public static bool LoadDeleted(out List<Quote> zresults)
        {
            return LoadSelection(out zresults, "SELECT * FROM  {QuoteTable} WHERE STATE = '{STATE_DELETED}';");
        }

        public static bool LoadTopic(string Topic, out List<Quote> zresults)
        {
            return LoadSelection(out zresults, "SELECT * FROM  {QuoteTable} WHERE KEYWORDS LIKE '%{Topic}%';");
        }

        public static bool LoadUnkeyed(out List<Quote> zresults)
        {
            return LoadSelection(out zresults, "SELECT * FROM  {QuoteTable} WHERE KEYWORDS = '';");
        }

        public static bool LoadSelection(out List<Quote> zresults, string sql)
        {
            zresults = new List<Quote>();
            SqliteConnection conn = Connect();
            if (conn == null) {
                return false;
            }
            conn.Open();
            try
            {
                var cmd = new SqliteCommand(sql, conn);
                SqliteDataReader results = cmd.ExecuteReader();
                while (results.Read())
                {
                     Quote quote;
                    if (Quote.CreateFrom(results, out quote))
                    {
                        zresults.Add(quote);
                    }
                    else
                    {
                        results.Close();
                        return false;
                    }
                }
                results.Close();

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public static Quote CreateQuoteMin(Quote quote)
        {
            SqliteConnection conn = Connect();
            if (conn == null) return new Quote();
            conn.Open();
            try
            {
                quote.AUTHOR = QuoteStringField.Encode(quote.AUTHOR);
                quote.QUOTE = QuoteStringField.Encode(quote.QUOTE);
                quote.CITATION = QuoteStringField.Encode(quote.CITATION);
                quote.SOURCE = QuoteStringField.Encode(quote.SOURCE);

                string sql = "INSERT INTO {QuoteTable} (AUTHOR, QUOTE, CITATION, SOURCE) VALUES " +
                    "('{quote.AUTHOR}', '{quote.QUOTE}', '{quote.CITATION}', '{quote.SOURCE}')";
                var cmd = new SqliteCommand(sql, conn);
                int val = cmd.ExecuteNonQuery();
                if (val != 1)
                {
                    return null;
                }
                cmd = new SqliteCommand("SELECT last_insert_rowid();", conn); /// SQLITE feature.
                SqliteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    long zid = rdr.GetInt64(0);
                    Quote result;
                    if (QuoteBook.Read(zid, out result))
                    {
                        return result;
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public static bool UpdateQuoteMin(Quote quote)
        {
            SqliteConnection conn = Connect();
            if (conn == null) return false;
            conn.Open();
            try
            {
                quote.AUTHOR = QuoteStringField.Encode(quote.AUTHOR);
                quote.QUOTE = QuoteStringField.Encode(quote.QUOTE);
                quote.CITATION = QuoteStringField.Encode(quote.CITATION);
                quote.SOURCE = QuoteStringField.Encode(quote.SOURCE);

                string sql = "UPDATE {QuoteTable} SET AUTHOR='{quote.AUTHOR}', " +
                    "QUOTE='{quote.QUOTE}', CITATION ='{quote.CITATION}', SOURCE='{quote.SOURCE}' " +
                    "WHERE ID={quote.ID};";
                var cmd = new SqliteCommand(sql, conn);
                int val = cmd.ExecuteNonQuery();
                if (val == 1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        internal static SqliteConnection Connect()
        {
            SqliteConnectionStringBuilder bldr = new SqliteConnectionStringBuilder
            {
                DataSource = DataFiles.GetDbFile()
            };
            try
            {
                return new SqliteConnection(bldr.ToString());
            } catch
            {
                return null;
            };
        }

        static bool DropKeywords(List<Quote> quotes)
        {
            foreach (var quote in quotes)
            {
                quote.KEYWORDS = "";
            }
            return QuoteBook.UpdateKeywords(quotes);
        }

        static bool MkKeywords()
        {
            List<Quote> quotes;
            if (QuoteBook.LoadUnkeyed(out quotes))
            {
                Dictionary<string, int> keyWords = new Dictionary<string, int>();
                SortedDictionary<string, int> keyAuthors = new SortedDictionary<string, int>();
                Console.WriteLine("Got: " + quotes.Count);
                foreach (Quote quote in quotes)
                {
                    if (quote.GetKeywords(keyWords) == false)
                    {
                        Console.WriteLine("Kw Error: " + quote.ID);
                        break;
                    }
                    quote.GetAuthors(keyAuthors);
                }
                Console.WriteLine("Got: " + keyWords.Count + " keywords.");
                Console.WriteLine("Got: " + keyAuthors.Count + " authors.");
                /*
                var sorted = SorterSet.Sort(keyWords);
                foreach(var word in sorted)
                {
                    Console.WriteLine(word.Key + " " +  word.Value);
                }
                */

                foreach (Quote quote in quotes)
                {
                    quote.AssignKeywords(keyWords);
                    //Console.WriteLine(quote.KEYWORDS);
                    //Console.WriteLine(quote.QUOTE);
                    //Console.WriteLine(":::::");
                }


                if (QuoteBook.UpdateKeywords(quotes))
                {
                    Console.WriteLine("Keywords Added");
                    return true;
                }
                else
                {
                    Console.WriteLine("Keyword Error");
                }
            }
            return false;

        }
    }

}
