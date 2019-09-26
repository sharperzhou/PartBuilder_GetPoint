using PartBuilder.GetPoint.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace PartBuilder.GetPoint.DataAccess
{
    /// <summary>
    /// Point data access class
    /// </summary>
    class PointDao
    {
        /// <summary>
        /// add point into db
        /// </summary>
        /// <param name="points">point model list</param>
        /// <param name="partId">part id</param>
        /// <param name="dbName">db name</param>
        /// <returns></returns>
        public static bool AddPoints(IList<PointModel> points, int partId, string dbName)
        {
            try
            {
                using (var conn = Utils.GetConnection(new DbFileHelper().GetFullName(dbName)))
                {
                    using (var ap = new SQLiteDataAdapter("SELECT * FROM HCPara_PointDef ORDER BY PartID DESC LIMIT 1;", conn))
                    {
                        var dt = new DataTable();
                        ap.Fill(dt);

                        //int partId = dt.Rows.Count == 0 ? 1 : int.Parse(dt.Rows[0]["PartID"].ToString()) + 1;

                        for (int i = 0; i < points.Count; i++)
                        {
                            var dr = dt.NewRow();
                            dr["PartID"] = partId;
                            dr["PointID"] = i + 1;
                            dr["PointName"] = points[i].Name;
                            dr["PointType"] = i == 0 ? 0 : 1;
                            dr["XValue"] = points[i].XValue;
                            dr["YValue"] = points[i].YValue;
                            dr["ZValue"] = points[i].ZValue;
                            dr["SortPos"] = i + 1;
                            dr["NodeID"] = 0;
                            dr["CalcOrder"] = 0;
                            dt.Rows.Add(dr);
                        }

                        var sqlCmdBuilder = new SQLiteCommandBuilder(ap);

                        ap.Update(dt);
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
