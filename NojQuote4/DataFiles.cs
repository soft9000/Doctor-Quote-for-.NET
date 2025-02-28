using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System;
using System.IO;

/*
 * Observed:
 * Without the transaction object - even multiple ops on an ever-open connection, are horiffically slow.
 */

namespace Quote2020
{
    public static class DataFiles
    {
        /* Schema Updated - Added KEYWORDS, TOPICS, and STATE:

            CREATE TABLE NojQuote4(
              ID INT,
              GBUCODE TEXT,
              UCANHC NUM,
              QUOTE TEXT,
              AUTHOR TEXT,
              CITATION TEXT,
              SOURCE TEXT,
              WEIGHT TEXT, 
              KEYWORDS TEXT, TOPICS TEXT, STATE TEXT);
        */
        private static string Found_db = null;
        private static readonly string MAIN_DB = "C:\\d_drive\\USR\\code\\2019_07_10_tqftd.all\\2019_06_08_SqliteSite\\tqftd_2020A.sqlt3";
        public static string GetDbFile()
        {
            if (Found_db != null)
                return Found_db;
            if(File.Exists(MAIN_DB))
                return MAIN_DB;
            string pwd = Directory.GetCurrentDirectory();
            int pos = MAIN_DB.LastIndexOf('\\');
            pwd += MAIN_DB.Substring(pos);
            if (File.Exists(pwd))
            {
                Found_db = pwd;
                return Found_db;
            }
            else
            {
                // different / same drive - default location
                pwd = pwd[0] + pwd.Substring(1);
                if (File.Exists(pwd))
                {
                    Found_db = pwd;
                    return Found_db;
                }
            }
            return MAIN_DB;
        }


    }

}

