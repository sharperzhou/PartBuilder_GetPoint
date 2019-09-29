using GrxCAD.ApplicationServices;
using GrxCAD.DatabaseServices;
using PartBuilder.GetPoint.Model;
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

        /// <summary>
        /// Hightlight/Unhightlight the selected point in CAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnHighlightPoint(object sender, SelectedRowChangedEventArgs e)
        {
            var db = HostApplicationServices.WorkingDatabase;
            var editor = Application.DocumentManager.MdiActiveDocument.Editor;
            editor.Regen();

            try
            {
                using (var trans = db.TransactionManager.StartTransaction())
                {
                    var point = trans.GetObject(e.PreviousItem?.PointId ?? ObjectId.Null, OpenMode.ForWrite) as DBPoint;
                    if (point != null) point.ColorIndex = 0;
                    //point?.Unhighlight();

                    point = trans.GetObject(e.CurrentItem?.PointId ?? ObjectId.Null , OpenMode.ForWrite) as DBPoint;
                    if (point != null) point.ColorIndex = 6;
                    //point?.Highlight();

                    trans.Commit();
                }
            }
            catch (Exception ex)
            {
                editor.WriteMessage($"\n{ex.Message}");
            }
        }

        private List<ObjectId> _pointIds = new List<ObjectId>();
    }
}
