using GrxCAD.DatabaseServices;
using PartBuilder.GetPoint.CAD;
using PartBuilder.GetPoint.Model;
using System;
using System.Linq;
using System.Windows.Input;

namespace PartBuilder.GetPoint.Command
{
    /// <summary>
    /// Mark point command class
    /// </summary>
    public class PointViewMarkPoint : ICommand
    {
        public PointViewMarkPoint(PointViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private PointViewModel _viewModel;

        public bool CanExecute(object parameter)
        {
            return _viewModel.PointModelList.Count > 0 && !_marking;
        }

        public void Execute(object parameter)
        {
            _marking = true;
            while (MarkPoint.Mark(out ObjectId objectId))
            {
                var found = from item in _viewModel.PointModelList
                            where item.PointId == objectId
                            select item;

                _viewModel.SelectedItem = found.FirstOrDefault();
            }

            _marking = false;
        }

        /// <summary>
        /// Button is enabled indicator
        /// </summary>
        private static bool _marking = false;
    }
}
