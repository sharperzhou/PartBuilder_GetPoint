using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace PartBuilder.GetPoint.DataAccess
{
    class Utils
    {
        /// <summary>
        /// Execute sql script to create an empty db file with basic data
        /// </summary>
        /// <param name="sqlFile"></param>
        /// <param name="dbFile"></param>
        /// <returns></returns>
        public static bool ExecSqlScript(string script, string dbFile)
        {
            var lines = script.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            SQLiteTransaction trans = null;
            try
            {
                using (SQLiteConnection conn = GetConnection(dbFile))
                {
                    conn.Open();
                    trans = conn.BeginTransaction();

                    using (var cmd = new SQLiteCommand(conn))
                    {
                        foreach (var line in lines)
                        {
                            var trimmed = line.Trim();
                            if (trimmed.Length == 0) continue;

                            cmd.CommandText = trimmed;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                }
            }
            catch
            {
                trans.Rollback();
                return false;
            }

            return true;
        }


        public static SQLiteConnection GetConnection(string dbFile)
        {
            return new SQLiteConnection($"Data Source={dbFile};");
        }
    }
}
