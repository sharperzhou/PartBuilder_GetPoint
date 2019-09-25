using PartBuilder.GetPoint.CAD;
using PartBuilder.GetPoint.Model;
using System.Collections.Generic;
using System.Windows;

namespace PartBuilder.GetPoint.View
{
    /// <summary>
    /// Interaction logic for GetPointUI.xaml
    /// </summary>
    public partial class GetPointUI : Window
    {
        public GetPointUI()
        {
            InitializeComponent();

            _pointManager = new PointManager();
        }

        private readonly PointManager _pointManager;

        /// <summary>
        /// Exit UI window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Pick the base point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pick_Base(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var basePt = PickPartHelper.GetBasePoint();
            BasePoint.Text = basePt.ToString();
            BasePoint.Tag = basePt;
            this.Show();
        }

        /// <summary>
        /// Add point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Point(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var pointCreator = new PointCreator();
            pointCreator.Add();
            this.Show();
        }

        /// <summary>
        /// remove point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove_Point(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var pointCreator = new PointCreator();
            pointCreator.Remove();
            this.Show();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            _pointManager.Dispose();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            var savePtUI = new SavePointUI();

            var data = new List<object> { (DataContext as PointViewModel).PointModelList };
            if (BasePoint.Tag != null) data.Add(BasePoint.Tag);

            savePtUI.DataContext = data;


            savePtUI.ShowDialog();
        }
    }
}
