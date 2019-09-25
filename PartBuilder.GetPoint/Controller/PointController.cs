using GrxCAD.Geometry;
using PartBuilder.GetPoint.DataAccess;
using PartBuilder.GetPoint.Model;
using System.Collections.Generic;

namespace PartBuilder.GetPoint.Controller
{
    class PointController
    {
        public static bool AddPoints(IList<PointModel> points, Point3d basePt, int partId, string dbName)
        {
            if (partId < 0) return false;

            var transPt = new List<PointModel>(points);

            transPt.ForEach(m =>
            {
                m.XValue -= basePt.X;
                m.YValue -= basePt.Y;
                m.ZValue -= basePt.Z;
            });

            return PointDao.AddPoints(points, partId, dbName);
        }
    }
}
