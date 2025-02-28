using Microsoft.Data.Sqlite; // System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quote2020
{
    public class Quote
    {
        /*
         * 2020 Changed the NojQuote4 to accept additional keywords, topics, and state fields.
         * 2020 CONSTRAINED: NULL is no longer - ever - in any NojQuote4 field.
         */
        private Int64 iD;
        private string gBUCODE;
        private Int64 uCANHC;
        private string qUOTE;
        private string aUTHOR;
        private string cITATION;
        private string sOURCE;
        private string wEIGHT;
        private string kEYWORDS; // 2020 - KEY WORDS IN QUOTE
        private string tOPICS;   // 2020 - OFFICIAL CATEGORIZATION(s)
        private string sTATE;    // 2020 - BOOK INCLUSION STATE

        private readonly char SEP_KEYWORDS = '|';

        public Int64 ID { get {return iD;} set { iD = value;} }
        public string GBUCODE { get { return gBUCODE;} set { gBUCODE = value;} }
        public Int64 UCANHC { get {return uCANHC;} set {uCANHC = value;} }
        public string QUOTE { get {return qUOTE;} set { qUOTE = value;} }
        public string AUTHOR { get {return aUTHOR;} set { aUTHOR = value;} }
        public string CITATION { get {return cITATION;} set { cITATION = value;} }
        public string SOURCE { get {return sOURCE;} set { sOURCE = value;} }
        public string WEIGHT { get {return wEIGHT;} set { wEIGHT = value;} }
        public string KEYWORDS { get {return kEYWORDS;} set { kEYWORDS = value;} }
        public string TOPICS { get { return tOPICS;} set { tOPICS = value;} }
        public string STATE { get { return sTATE; } set { sTATE = value; } }

        public Quote()
        {

        }

        public Quote(int ID, string GBUCODE, int UCANHC, string QUOTE, string AUTHOR, string CITATION, string SOURCE, string WEIGHT, string KEYWORDS, string TOPICS, string STATE)
        {
            this.ID = ID;
            this.GBUCODE = GBUCODE;
            this.UCANHC = UCANHC;
            this.QUOTE = QUOTE;
            this.AUTHOR = AUTHOR;
            this.CITATION = CITATION;
            this.SOURCE = SOURCE;
            this.WEIGHT = WEIGHT;
            this.KEYWORDS = KEYWORDS;
            this.TOPICS = TOPICS;
            this.STATE = STATE;
        }

        public void GetKeywords(out List<KeyValuePair<string, bool>> keywords)
        {
            Dictionary<string, int> zdict = new Dictionary<string, int>();
            GetKeywords(zdict);
            List<string> used;
            GetKeywords(out used);
            keywords = new List<KeyValuePair<string, bool>>();
            foreach (var key in zdict.Keys)
            {
                bool bFound = false;
                foreach (var use in used)
                {
                    if (use == key)
                    {
                        keywords.Add(new KeyValuePair<string, bool>(key, true));
                        bFound = true;
                        break;
                    }
                }
                if (!bFound)
                {
                    keywords.Add(new KeyValuePair<string, bool>(key, false));
                }
            }
        }
        public void GetKeywords(out List<string> keywords)
        {
            keywords = new List<string>();
            if (KEYWORDS != null)
            {
                var words = KEYWORDS.Split(SEP_KEYWORDS);
                foreach (var word in words)
                {
                    keywords.Add(word);
                }
            }
        }

        public void SetKeywords(List<string> keywords)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var word in keywords)
            {
                if (sb.Length != 0)
                    sb.Append(SEP_KEYWORDS);
                sb.Append(word);
            }
            KEYWORDS = sb.ToString();
        }

        public void GetTopics(out List<string> keywords)
        {
            keywords = new List<string>();
            if (WEIGHT != null)
            {
                var words = TOPICS.Split(SEP_KEYWORDS);
                foreach (var word in words)
                {
                    keywords.Add(word);
                }
            }
        }

        public void SetTopics(List<string> keywords)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var word in keywords)
            {
                if (sb.Length != 0)
                    sb.Append(SEP_KEYWORDS);
                sb.Append(word);
            }
            TOPICS = sb.ToString();
        }

        public static bool CreateFrom(SqliteDataReader row, out Quote obj)
        {
            obj = new Quote();
            try
            {
                obj.ID = row.GetInt64(0);
                obj.GBUCODE = FixString(row, 1);
                obj.UCANHC = FixInt(row, 2);
                obj.QUOTE = QuoteStringField.Decode((string)row.GetValue(3));
                obj.AUTHOR = QuoteStringField.Decode((string)row.GetValue(4));
                obj.CITATION = FixString(row, 5);
                obj.SOURCE = FixString(row, 6);
                obj.WEIGHT = FixString(row, 7);
                obj.KEYWORDS = FixString(row, 8);
                obj.TOPICS = FixString(row, 9);
                obj.STATE = FixString(row, 10);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        private static int FixInt(SqliteDataReader row, int iCol)
        {
            if (row.IsDBNull(iCol))
            {
                return 0;
            }
            else
            {
                return (int)row.GetInt64(iCol);
            }
        }

        private static string FixString(SqliteDataReader row, int iCol)
        {
            if (row.IsDBNull(iCol))
            {
                return "";
            }
            else
            {
                return QuoteStringField.Decode((string)row.GetValue(iCol));
            }
        }
        public bool GetAuthors(SortedDictionary<string, int> zdict)
        {
            if (AUTHOR == null)
                return false;

            string zkey = AUTHOR.Trim();
            if (zkey.Length == 0)
                zkey = "Anonymous";
            if (zdict.ContainsKey(zkey))
            {
                zdict[zkey] += 1;
            }
            else
            {
                zdict[zkey] = 1;
            }
            return true;
        }

        public bool AssignKeywords(Dictionary<string, int> zdict, StringBuilder zBuilder = null, int times = 1)
        {
            if (zBuilder == null)
                zBuilder = new StringBuilder();
            Dictionary<string, int> zSet = new Dictionary<string, int>();
            if (!GetKeywords(zSet)) return false;
            KeyValuePair<string, int> pair = new KeyValuePair<string, int>("", -1);
            foreach (string key in zSet.Keys)
            {
                try
                {
                    int value = zdict[key];
                    if (pair.Value == -1)
                    {
                        // Primt it.
                        pair = new KeyValuePair<string, int>(key, zdict[key]);
                        continue;
                    }
                    if (value == -1) continue;
                    if (value == pair.Value && key.Length > pair.Key.Length)
                    {
                        // Prefer a larger keyword
                        pair = new KeyValuePair<string, int>(key, zdict[key]);
                        continue;
                    }
                    if (value < pair.Value)
                    {
                        // Prefer a "tighter" / more unique keyword
                        pair = new KeyValuePair<string, int>(key, zdict[key]);
                        continue;
                    }
                }
                catch (Exception)
                {

                }
            }
            if (pair.Key.Length > 0)
            {
                if (zBuilder.Length != 0)
                    zBuilder.Append(SEP_KEYWORDS);
                zBuilder.Append(pair.Key);
            }
            if (times > 3)
            {
                this.KEYWORDS = zBuilder.ToString();
                return true;
            }
            zdict[pair.Key] = -1;
            bool result = AssignKeywords(zdict, zBuilder, ++times);
            zdict[pair.Key] = pair.Value;
            return result;
        }

        public bool GetKeywords(Dictionary<string, int> zdict)
        {
            if (QUOTE == null)
                return false;
            var sb = new System.Text.StringBuilder();
            foreach (char ch in QUOTE)
            {
                if (char.IsPunctuation(ch) || char.IsControl(ch))
                    continue;
                sb.Append(ch);
            }
            string zQuote = sb.ToString().Trim().ToUpper();
            if (zQuote.Length < 10)
                return false;
            string[] words = zQuote.Split(' ');
            foreach (string word in words)
            {
                if (word.Length < 3) continue;
                string zkey = word.Trim();
                if (zkey.Length == 0)
                    continue;
                if (zdict.ContainsKey(zkey))
                {
                    zdict[zkey] = zdict[zkey] + 1;
                }
                else
                {
                    zdict[zkey] = 1;
                }
            }
            return true;
        }
    }


}
