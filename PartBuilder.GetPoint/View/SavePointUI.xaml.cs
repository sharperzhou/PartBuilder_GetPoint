using PartBuilder.GetPoint.Controller;
using PartBuilder.GetPoint.DataAccess;
using PartBuilder.GetPoint.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PartBuilder.GetPoint.View
{
    /// <summary>
    ///     Interaction logic for SavePointUI.xaml
    /// </summary>
    public partial class SavePointUI : Window
    {
        private readonly List<string> _dbFiles = new List<string>();

        public SavePointUI()
        {
            InitializeComponent();

            DbFileListBox.ItemsSource = _dbFiles;
        }

        /// <summary>
        /// load window event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var dbFileHelper = new DbFileHelper();
            _dbFiles.AddRange(dbFileHelper.GetAllNames());
        }

        /// <summary>
        /// add new db file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// list box selected changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DbFileListBox_SelChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0) return;

            var curDb = e.AddedItems[0] as string;
            var partsController = new PartsController(curDb);
            var partsTree = partsController.BuildPartsTree();
            var dirs = partsController.GetDirectory();
            var parts = partsController.GetParts();

            PartsTreeView.ItemsSource = new List<PartsModel> { partsTree };
            CboCatalog.ItemsSource = dirs;
            CboCatalog.DisplayMemberPath = "Name";
            CboCatalog.SelectedValue = "Id";

            NewPartName.ItemsSource = parts;
            NewPartName.DisplayMemberPath = "Name";
            NewPartName.SelectedValue = "Id";
        }

        /// <summary>
        /// add new catalog in db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        PartsTreeView.ItemsSource = new List<PartsModel> { partsTree };
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

        /// <summary>
        /// close window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// save point into db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var points = DataContext as ObservableCollection<PointModel>;
            if (points == null || points.Count <= 0)
            {
                MessageBox.Show("请先选择点");
                return;
            }

            if (DbFileListBox.SelectedItem == null)
            {
                MessageBox.Show("请先选择零件库");
                return;
            }
            var db = DbFileListBox.SelectedItem.ToString();

            var selPart = NewPartName.SelectedItem as PartsModel;

            var partId = -1;
            if (selPart == null)
            {
                var selDir = CboCatalog.SelectedItem as PartsModel;
                if (selDir == null)
                {
                    MessageBox.Show("请先选择零件所属分类");
                    return;
                }

                if (!new PartsController(db).AddPart(selDir.Id, NewPartName.Text, out partId))
                {
                    MessageBox.Show("保存失败，无法新建零件库！");
                    return;
                }
            }
            else
            {
                partId = selPart.Id;
            }

            if (PointController.AddPoints(points, partId, db))
            {
                MessageBox.Show("保存成功！");
                Close();
            }
        }
    }
}