using GrxCAD.ApplicationServices;
using GrxCAD.DatabaseServices;
using GrxCAD.EditorInput;
using GrxCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PartBuilder.GetPoint.CAD
{
    /// <summary>
    /// AcDbPoint creator class
    /// </summary>
    class PointCreator
    {
        /// <summary>
        /// Add point by Point3d set
        /// </summary>
        /// <param name="points"></param>
        public void Create(HashSet<Point3d> points)
        {
            if (points == null) return;
            var db = HostApplicationServices.WorkingDatabase;
            using (var trans = db.TransactionManager.StartTransaction())
            {
                var blkTbl = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                if (blkTbl == null) return;

                var rcd = trans.GetObject(blkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                if (rcd == null) return;

                foreach (var pt in points)
                {
                    var dbPt = new DBPoint(pt);
                    rcd.AppendEntity(dbPt);
                    trans.AddNewlyCreatedDBObject(dbPt, true);
                }

                trans.Commit();
            }
        }

        /// <summary>
        /// Add point by POINT command
        /// </summary>
        public void Add()
        {
            var editor = Application.DocumentManager.MdiActiveDocument.Editor;
            var db = HostApplicationServices.WorkingDatabase;
            while (true)
            {
                var res = editor.GetPoint("\n请选择点");
                if (res.Status == PromptStatus.OK)
                {
                    var dbPt = new DBPoint(res.Value);

                    using (var trans = db.TransactionManager.StartTransaction())
                    {
                        var blkTbl = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                        if (blkTbl == null) return;

                        var rcd = trans.GetObject(blkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                        if (rcd == null) return;
                        rcd.AppendEntity(dbPt);
                        trans.AddNewlyCreatedDBObject(dbPt, true);

                        trans.Commit();
                    }
                }
                else if (res.Status == PromptStatus.Cancel)
                    break;
            }

            editor.Regen();
        }

        /// <summary>
        /// Remove point by selection filter
        /// </summary>
        public void Remove()
        {
            var editor = Application.DocumentManager.MdiActiveDocument.Editor;
            ObjectId[] ids = null;
            try
            {
                var filter = new SelectionFilter(new TypedValue[]
                {
                    new TypedValue((int)DxfCode.Start, "POINT")
                });
                var selRes = editor.GetSelection(filter);
                if (selRes.Status == PromptStatus.OK)
                {
                    ids = selRes.Value.GetObjectIds();
                }

            }
            catch (Exception e)
            {
                editor.WriteMessage($"\n{e.Message}");
            }

            if (ids == null) return;

            try
            {
                var db = HostApplicationServices.WorkingDatabase;
                using (var trans = db.TransactionManager.StartTransaction())
                {
                    foreach (var id in ids)
                    {
                        var obj = trans.GetObject(id, OpenMode.ForWrite);
                        obj.Erase();
                    }

                    trans.Commit();
                }
            }
            catch (Exception e)
            {
                editor.WriteMessage($"\n{e.Message}");
            }

        }
    }

    internal class PointStyleChanger : IDisposable
    {
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("gced.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gcedGetEnv")]
        private static extern int AcedGetEnv(string envName, StringBuilder ReturnValue);

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("gced.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, EntryPoint = "gcedSetEnv")]
        private static extern int AcedSetEnv(string envName, StringBuilder NewValue);

        public void Dispose()
        {
            AcedSetEnv("PDMODE", new StringBuilder("0"));
        }

        public PointStyleChanger()
        {
            AcedSetEnv("PDMODE", new StringBuilder("35"));
        }
    }
}
