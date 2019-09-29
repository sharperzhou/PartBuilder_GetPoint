using GrxCAD.Runtime;
using PartBuilder.GetPoint.CAD;
using PartBuilder.GetPoint.View;
using PartBuilder.GetPoint.DataAccess;
using PartBuilder.GetPoint.Model;
using System.Windows;
using GrxApp = GrxCAD.ApplicationServices.Application;

[assembly: CommandClass(typeof(PartBuilder.GetPoint.Program))]
namespace PartBuilder.GetPoint
{
    class Program
    {
        [CommandMethod("GetPoint")]
        public static void GetPoint()
        {
            GrxApp.DocumentManager.MdiActiveDocument.Editor.Command("PDMODE", "35");

            var helper = new PickPartHelper();
            if (helper.Pick())
            {
                var ui = new GetPointUI();

                var ptCreator = new PointCreator();
                ptCreator.Create(helper.KeyPoints);

                GrxApp.ShowModelessWindow(GrxApp.MainWindow.Handle, ui);
            }
        }

        #region For test
        [CommandMethod("AddPoint")]
        public static void AddPoint()
        {
            var ptCreator = new PointCreator();
            ptCreator.Add();
        }

        [CommandMethod("ErasePoint")]
        public static void ErasePoint()
        {
            var ptCreator = new PointCreator();
            ptCreator.Remove();
        }

        [CommandMethod("PBTEST")]
        public static void Test()
        {
            var helper = new DbFileHelper();
            var names = helper.GetAllNames();
            MessageBox.Show(string.Join("\n", names));
        }
        #endregion
    }
}
