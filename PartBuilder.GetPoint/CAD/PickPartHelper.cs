using GrxCAD.ApplicationServices;
using GrxCAD.DatabaseServices;
using GrxCAD.EditorInput;
using GrxCAD.Geometry;
using System;
using System.Collections.Generic;

namespace PartBuilder.GetPoint.CAD
{
    /// <summary>
    /// Pick Part Helper class
    /// </summary>
    class PickPartHelper
    {
        /// <summary>
        /// Pick entities of Part
        /// </summary>
        /// <returns>Pick success return true, else false</returns>
        public bool Pick()
        {
            var editor = Application.DocumentManager.MdiActiveDocument.Editor;
            PickedEntities = null;
            try
            {
                var filter = new SelectionFilter(new TypedValue[]
                {
                    new TypedValue((int)DxfCode.Operator, "<or"),
                    new TypedValue((int)DxfCode.Start, "LINE"),
                    new TypedValue((int)DxfCode.Start, "CIRCLE"),
                    new TypedValue((int)DxfCode.Start, "ARC"),
                    new TypedValue((int)DxfCode.Start, "ELLIPSE"),
                    new TypedValue((int)DxfCode.Start, "LWPOLYLINE"),
                    new TypedValue((int)DxfCode.Operator, "or>")
                });
                var selRes = editor.GetSelection(filter);
                if (selRes.Status == PromptStatus.OK)
                {
                    // get selected entities
                    PickedEntities = selRes.Value.GetObjectIds();
                }
                else if (selRes.Status == PromptStatus.Cancel)
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                editor.WriteMessage($"\n{e.Message}");
                return false;
            }

            if (PickedEntities != null)
                // get point of selected entities
                GetPoint();

            return true;
        }

        /// <summary>
        /// Get the base point
        /// </summary>
        /// <returns></returns>
        public static Point3d GetBasePoint()
        {
            var editor = Application.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                var res = editor.GetPoint("\n指定基点");
                if (res.Status == PromptStatus.OK)
                {
                    return res.Value;
                }
            }
            catch (Exception e)
            {
                editor.WriteMessage($"\n{e.Message}");
            }

            return Point3d.Origin;
        }

        /// <summary>
        /// Ids of picked entities
        /// </summary>
        public ObjectId[] PickedEntities { get; private set; }

        private HashSet<Point3d> _keyPoints = new HashSet<Point3d>();
        /// <summary>
        /// Selected key points
        /// </summary>
        public HashSet<Point3d> KeyPoints
        {
            get
            {
                return _keyPoints;
            }
        }

        /// <summary>
        /// Get the point of selected entities
        /// </summary>
        private void GetPoint()
        {
            if (PickedEntities == null) return;

            using (var trans = HostApplicationServices.WorkingDatabase.TransactionManager.StartTransaction())
            {
                foreach (var id in PickedEntities)
                {
                    DBObject obj = null;
                    try
                    {
                        obj = trans.GetObject(id, OpenMode.ForRead);
                    }
                    catch (Exception e)
                    {
                        Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage($"\n{e.Message}");
                    }

                    if (obj is Line)
                    {
                        var line = obj as Line;
                        _keyPoints.Add(line.StartPoint);
                        _keyPoints.Add(line.EndPoint);
                    }
                    else if (obj is Circle)
                    {
                        var circle = obj as Circle;
                        _keyPoints.Add(circle.Center);
                    }
                    else if (obj is Arc)
                    {
                        var arc = obj as Arc;
                        var a = new CircularArc3d(arc.Center, arc.Normal, arc.Radius);
                        _keyPoints.Add(a.Center);
                        _keyPoints.Add(a.StartPoint);
                        _keyPoints.Add(a.EndPoint);
                    }
                    else if (obj is Ellipse)
                    {
                        var ellipse = obj as Ellipse;
                        var e = new EllipticalArc3d(ellipse.Center, ellipse.MajorAxis, ellipse.MinorAxis,
                            ellipse.MajorRadius, ellipse.MinorRadius);
                        _keyPoints.Add(ellipse.Center);

                        // ellipse arc
                        if (!e.IsCircular())
                        {
                            _keyPoints.Add(e.StartPoint);
                            _keyPoints.Add(e.EndPoint);
                        }
                        
                    }
                    else if (obj is Polyline)
                    {
                        var poly = obj as Polyline;
                        for (var i = 0; i < poly.NumberOfVertices; i++)
                        {
                            _keyPoints.Add(poly.GetPoint3dAt(i));

                            // Closed polyline only has NumberOfVertices-1 segments
                            if (!poly.Closed && i == poly.NumberOfVertices - 1) continue;

                            var segType = poly.GetSegmentType(i);
                            if (segType == SegmentType.Arc)
                            {
                                var arc = poly.GetArcSegmentAt(i);
                                _keyPoints.Add(arc.Center);
                            }
                        }
                    }
                }
            }
        }
    }
}
