using GrxCAD.DatabaseServices;
using System;
using System.Collections.Generic;

namespace PartBuilder.GetPoint.CAD
{
    /// <summary>
    /// Point monitor class
    /// </summary>
    public class PointMonitor : IDisposable
    {
        public PointMonitor()
        {
            HostApplicationServices.WorkingDatabase.ObjectAppended += (o, e) =>
            {
                if (e.DBObject is DBPoint)
                {
                    _pointIds.Add(e.DBObject.ObjectId);
                }
            };

            HostApplicationServices.WorkingDatabase.ObjectErased += WorkingDatabase_ObjectErased;
        }

        private void WorkingDatabase_ObjectErased(object sender, ObjectErasedEventArgs e)
        {
            if (e.DBObject is DBPoint)
            {
                _pointIds.Remove(e.DBObject.ObjectId);
            }
        }

        /// <summary>
        /// Erase all the points before disposing
        /// </summary>
        public void Dispose()
        {
            if (_pointIds.Count == 0) return;

            var db = HostApplicationServices.WorkingDatabase;
            if (db == null) return;

            db.ObjectErased -= WorkingDatabase_ObjectErased;

            using (var trans = db.TransactionManager.StartTransaction())
            {
                foreach (var id in _pointIds)
                {
                    var obj = trans.GetObject(id, OpenMode.ForWrite);
                    if (obj != null) obj.Erase();
                }

                trans.Commit();
            }
        }

        private List<ObjectId> _pointIds = new List<ObjectId>();
    }
}
