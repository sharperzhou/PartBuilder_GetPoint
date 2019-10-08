using GrxCAD.DatabaseServices;
using System;

namespace PartBuilder.GetPoint.Model
{
    /// <summary>
    /// Point model
    /// </summary>
    public class PointModel : ICloneable
    {
        /// <summary>
        /// Name or number of point, P0,P1,...
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// X value of Point3d
        /// </summary>
        public double XValue { get; set; }

        /// <summary>
        /// Y value of Point3d
        /// </summary>
        public double YValue { get; set; }

        /// <summary>
        /// Z value of Point3d
        /// </summary>
        public double ZValue { get; set; }

        /// <summary>
        /// db handle of DbPoint
        /// </summary>
        public ObjectId PointId { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
