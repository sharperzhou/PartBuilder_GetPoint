namespace PartBuilder.GetPoint.Model
{
    /// <summary>
    /// Point model
    /// </summary>
    class PointModel
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
    }
}
