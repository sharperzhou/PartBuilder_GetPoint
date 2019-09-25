using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GrxCAD.Geometry;
using PartBuilder.GetPoint.Controller;
using PartBuilder.GetPoint.DataAccess;
using PartBuilder.GetPoint.Model;

namespace PartBuilder.GetPoint.View
{
    /// <summary>
    ///     Interaction logic for SavePointUI.xaml
    /// </summary>
    public partial class  SavePointUI : Window
    {
        private readonly List<string> _dbFiles = new List<string>();

        public SavePointUI()
        {
            InitializeComponent();

            DbFileListBox.ItemsSource = _dbFiles;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var dbFileHelper = new DbFileHelper();
            _dbFiles.AddRange(dbFileHelper.GetAllNames());
        }

        private void AddDbBtn_Click(object sender, RoutedEventArgs e)
        {
            var dbFileHelper = new DbFileHelper();
            var newDb = NewDbTextBox.Text.Trim();
            if (!dbFileHelper.CreateDb(newDb))
            {
                MessageBox.Show("零件库创建失败！");
                return;
            }

            _dbFiles.Add(newDb);
            DbFileListBox.SelectedIndex = _dbFiles.IndexOf(newDb);
        }

        private void DbFileListBox_SelChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0) return;

            var curDb = e.AddedItems[0] as string;
            var partsController = new PartsController(curDb);
            var partsTree = partsController.BuildPartsTree();
            var dirs = partsController.GetDirectory();

            PartsTreeView.ItemsSource = new List<PartsModel> {partsTree};
            CboCatalog.ItemsSource = dirs;
            CboCatalog.DisplayMemberPath = "Name";
            CboCatalog.SelectedValue = "Id";
        }

        private void AddDirBtn_Click(object sender, RoutedEventArgs e)
        {
            var selPart = PartsTreeView.SelectedItem as PartsModel;
            if (selPart == null) return;


            var selType = selPart.PartsType;
            if (selType == PartsModel.Type.PART) return;

            if (selType == PartsModel.Type.ROOT ||
                selPart.Parent.PartsType == PartsModel.Type.ROOT)
                try
                {
                    var dbName = (PartsTreeView.Items[0] as PartsModel).Name;
                    var controller = new PartsController(dbName);
                    if (controller.AddDirectory(selPart.Id, NewCatalogTextBox.Text))
                    {
                        var partsTree = controller.BuildPartsTree();
                        var dirs = controller.GetDirectory();
                        PartsTreeView.ItemsSource = new List<PartsModel> {partsTree};
                        CboCatalog.ItemsSource = dirs;
                        CboCatalog.DisplayMemberPath = "Name";
                        CboCatalog.SelectedValue = "Id";

                        NewCatalogTextBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("零件分类添加失败！");
                    }
                }
                catch
                {
                }
        }

        private void CancleBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var selItem = CboCatalog.SelectedItem as PartsModel;
            if (selItem == null)
            {
                MessageBox.Show("请先选择零件所属分类");
                return;
            }

            var obj = DataContext as List<object>;

            if (obj == null || obj.Count != 2)
            {
                MessageBox.Show("请先选择点");
                return;
            }

            var db = DbFileListBox.SelectedItem.ToString();
            var partId = -1;
            if (new PartsController(db).AddPart(selItem.Id, NewPartName.Text, out partId) &&
                PointController.AddPoints(obj[0] as IList<PointModel>, (Point3d) obj[1], partId, db))
            {
                MessageBox.Show("保存成功！");
                Close();
            }
        }
    }
}