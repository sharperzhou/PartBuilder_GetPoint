using PartBuilder.GetPoint.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartBuilder.GetPoint.DataAccess
{
    class PartsDao : IDisposable
    {
        public PartsDao(string dbName)
        {
            _conn = Utils.GetConnection(new DbFileHelper().GetFullName(dbName));
        }

        public IList<PartsModel> GetParts()
        {
            var ret = new List<PartsModel>();
            try
            {
                using (var ap = new SQLiteDataAdapter("SELECT * FROM HCParts;", _conn))
                {
                    var ds = new DataSet();
                    ap.Fill(ds);
                    var dt = ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        ret.Add(new PartsModel()
                        {
                            Id = Convert.ToInt32(dr["PartID"]),
                            PId = Convert.ToInt32(dr["DictID"]),
                            SortPos = Convert.ToInt32(dr["SortPos"]),
                            PartsType = PartsModel.Type.PART,
                            Name = dr["PartName"].ToString()
                        });
                    }
                }

            }
            catch { }

            return ret;
        }

        public IList<PartsModel> GetDirectory()
        {
            var ret = new List<PartsModel>();
            try
            {
                using (var ap = new SQLiteDataAdapter("SELECT * FROM HCParts_Directory;", _conn))
                {
                    var ds = new DataSet();
                    ap.Fill(ds);
                    var dt = ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        ret.Add(new PartsModel()
                        {
                            Id = Convert.ToInt32(dr["DictID"]),
                            PId = Convert.ToInt32(dr["FatherID"]),
                            SortPos = Convert.ToInt32(dr["SortPos"]),
                            PartsType = Convert.ToBoolean(dr["IsHide"])
                                            ? PartsModel.Type.DIRECTORY_HIDE
                                            : PartsModel.Type.DIRECTORY,
                            Name = dr["DictName"].ToString()
                        });
                    }
                }

            }
            catch { }

            return ret;
        }

        public bool AddDirectory(int parentId, string newName)
        {
            try
            {
                using (var ap = new SQLiteDataAdapter("SELECT * FROM HCParts_Directory;", _conn))
                {
                    var dt = new DataTable();
                    ap.Fill(dt);

                    var enu = dt.AsEnumerable();

                    var maxId = enu.Count() <= 0
                        ? 0
                        : enu.Select(t => Convert.ToInt32(t["DictID"])).Max();

                    var maxSortPos = 0;
                    if (enu.Count() > 0)
                    {
                        var where = enu.Where(t => Convert.ToInt32(t["FatherID"]) == parentId);
                        if (where.Count() > 0)
                            maxSortPos = where.Select(t => Convert.ToInt32(t["SortPos"])).Max();
                    }


                    var newRow = dt.NewRow();
                    newRow["DictID"] = maxId + 1;
                    newRow["FatherID"] = parentId;
                    newRow["DictName"] = newName;
                    newRow["SortPos"] = maxSortPos + 1;
                    newRow["IsHide"] = false;

                    dt.Rows.Add(newRow);
                    var sqlCmdBuilder = new SQLiteCommandBuilder(ap);
                    ap.Update(dt);
                }

            }
            catch { return false; }

            return true;
        }

        public bool AddPart(int parentId, string newName, out int newPartId)
        {
            newPartId = -1;
            try
            {
                using (var ap = new SQLiteDataAdapter("SELECT * FROM HCParts;", _conn))
                {
                    var dt = new DataTable();
                    ap.Fill(dt);

                    int partId = dt.Rows.Count == 0 
                        ? 0 
                        : dt.AsEnumerable().Select(t => Convert.ToInt32(t["PartID"])).Max();

                    int sortPos = dt.Rows.Count == 0
                        ? 0
                        : dt.AsEnumerable().Select(t => Convert.ToInt32(t["SortPos"])).Max();

                    var dr = dt.NewRow();
                    dr["PartID"] = partId + 1;
                    dr["PartName"] = newName;
                    dr["DictID"] = parentId;
                    dr["SortPos"] = sortPos + 1;
                    dr["PartType"] = 0;

                    dt.Rows.Add(dr);
                    var sqlCmdBuilder = new SQLiteCommandBuilder(ap);
                    if (ap.Update(dt) > 0)
                        newPartId = partId + 1;
                }
            }
            catch { return false; }

            return true;
        }


        public void Dispose()
        {
            _conn.Dispose();
        }

        private readonly SQLiteConnection _conn;
    }
}
