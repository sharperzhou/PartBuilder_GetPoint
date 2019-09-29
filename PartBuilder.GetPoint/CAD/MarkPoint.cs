using GrxCAD.ApplicationServices;
using GrxCAD.DatabaseServices;
using GrxCAD.EditorInput;

namespace PartBuilder.GetPoint.CAD
{
    /// <summary>
    /// Mark point helper class
    /// </summary>
    public static class MarkPoint
    {
        /// <summary>
        /// Mark point in cad
        /// </summary>
        /// <param name="objectId">get point id</param>
        /// <returns>Prompt status is ok return true, otherwise return false</returns>
        public static bool Mark(out ObjectId objectId)
        {
            var editor = Application.DocumentManager.MdiActiveDocument.Editor;

            var options = new PromptEntityOptions("\n请选择点");
            options.SetRejectMessage("\n您选择的不是点");
            options.AddAllowedClass(typeof(DBPoint), true);

            var res = editor.GetEntity(options);

            objectId = res.ObjectId;

            return res.Status == PromptStatus.OK;
        }
    }
}
