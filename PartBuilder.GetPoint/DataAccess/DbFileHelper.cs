using PartBuilder.GetPoint.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PartBuilder.GetPoint.DataAccess
{
    class DbFileHelper
    {
        /// <summary>
        /// Get the dir of files
        /// </summary>
        /// <returns></returns>
        public static string GetDirectory()
        {
            return Environment.CurrentDirectory + @"\HCsPartBuilder\Database";
        }

        public DbFileHelper()
        {
            CurrentDirectory = GetDirectory();
        }

        /// <summary>
        /// Get all db file name
        /// </summary>
        /// <returns>All names without dir and .db</returns>
        public string[] GetAllNames()
        {
            var dir = new DirectoryInfo(CurrentDirectory);
            var res = from db in dir.GetFiles()
                      where db.Extension.Equals(".db", StringComparison.OrdinalIgnoreCase)
                      select db.Name.Remove(db.Name.LastIndexOf('.'));
            return res.ToArray();
        }

        /// <summary>
        /// Create a new db file with basic data
        /// </summary>
        /// <param name="name">file name without dir and .db</param>
        /// <returns></returns>
        public bool CreateDb(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;

            var fullName = GetFullName(name);

            if (File.Exists(fullName)) return false;

            return Utils.ExecSqlScript(Resources.create_empty_database, fullName);
        }

        /// <summary>
        /// Get the full name of db
        /// </summary>
        /// <param name="name">short name, without dir and .db</param>
        /// <returns>whole path of db file</returns>
        public string GetFullName(string name)
        {
            return CurrentDirectory + "\\" + name + ".db";
        }

        /// <summary>
        /// Current dir of files
        /// </summary>
        public string CurrentDirectory { get; }
    }
}
