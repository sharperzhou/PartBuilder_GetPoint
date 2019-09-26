using PartBuilder.GetPoint.Model;
using System;
using System.Windows.Input;

namespace PartBuilder.GetPoint.Command
{
    /// <summary>
    /// move down
    /// </summary>
    class PointViewMoveDown : ICommand
    {
        public PointViewMoveDown(PointViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            var sel = _viewModel.SelectedItem;
            if (sel == null) return false;

            var list = _viewModel.PointModelList;

            return list.IndexOf(sel) < list.Count - 1;
        }

        /// <summary>
        /// move down logic
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            var sel = _viewModel.SelectedItem;
            var list = _viewModel.PointModelList;
            var index = list.IndexOf(sel);
            list.RemoveAt(index);
            list.Insert(index + 1, sel);
            _viewModel.SelectedItem = sel;
            _viewModel.RaisePropertyChanged("SelectedItem");
        }

        private PointViewModel _viewModel;
    }
}
