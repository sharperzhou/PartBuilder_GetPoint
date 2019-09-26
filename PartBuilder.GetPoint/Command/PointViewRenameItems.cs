using PartBuilder.GetPoint.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PartBuilder.GetPoint.Command
{
    /// <summary>
    /// Rename point list from the first point to the last one, e.g. P0, P1, ..., Pn
    /// </summary>
    class PointViewRenameItems : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public PointViewRenameItems(PointViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.PointModelList.Count > 0;
        }

        /// <summary>
        /// rename logic
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            var newList = new ObservableCollection<PointModel>(_viewModel.PointModelList);

            for (int i = 0; i < newList.Count; i++)
            {
                newList[i].Name = "P" + (i == 0 ? string.Empty : i.ToString());
            }

            _viewModel.PointModelList = newList;
        }

        private PointViewModel _viewModel;
    }
}
