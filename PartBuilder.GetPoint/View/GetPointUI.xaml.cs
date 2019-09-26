using PartBuilder.GetPoint.CAD;
using PartBuilder.GetPoint.Model;
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

            _pointManager = new PointMonitor();
        }

        private readonly PointMonitor _pointManager;

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

        /// <summary>
        /// close window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, System.EventArgs e)
        {
            _pointManager.Dispose();
        }

        /// <summary>
        /// into next step
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            var savePtUI = new SavePointUI();

            savePtUI.DataContext = (DataContext as PointViewModel).PointModelList;

            savePtUI.ShowDialog();
        }
    }
}
