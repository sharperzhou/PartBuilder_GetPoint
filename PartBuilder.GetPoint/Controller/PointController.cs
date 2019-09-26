using PartBuilder.GetPoint.DataAccess;
using PartBuilder.GetPoint.Model;
using System.Collections.Generic;

namespace PartBuilder.GetPoint.Controller
{
    /// <summary>
    /// Point controller class
    /// </summary>
    class PointController
    {
        /// <summary>
        /// Add points
        /// </summary>
        /// <param name="points">point list model</param>
        /// <param name="partId"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static bool AddPoints(IList<PointModel> points, int partId, string dbName)
        {
            if (partId < 0) return false;

            var transPt = new List<PointModel>(points);
            var basePt = transPt[0];

            transPt.ForEach(m =>
            {
                m.XValue -= basePt.XValue;
                m.YValue -= basePt.YValue;
                m.ZValue -= basePt.ZValue;
            });

            return PointDao.AddPoints(points, partId, dbName);
        }
    }
}
