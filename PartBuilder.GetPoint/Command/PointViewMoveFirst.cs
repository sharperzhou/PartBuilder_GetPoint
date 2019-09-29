using PartBuilder.GetPoint.Model;
using System;
using System.Windows.Input;

namespace PartBuilder.GetPoint.Command
{
    /// <summary>
    /// Commanding class of moving row into first in data grid
    /// </summary>
    public class PointViewMoveFirst : ICommand
    {
        public PointViewMoveFirst(PointViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly PointViewModel _viewModel;

        bool ICommand.CanExecute(object parameter)
        {
            var sel = _viewModel.SelectedItem;
            if (sel == null) return false;

            var list = _viewModel.PointModelList;
            return list.IndexOf(sel) > 0;
        }

        void ICommand.Execute(object parameter)
        {
            var sel = _viewModel.SelectedItem;
            var list = _viewModel.PointModelList;
            if (list.Remove(sel))
                list.Insert(0, sel);
            _viewModel.SelectedItem = sel;
            _viewModel.RaisePropertyChanged("SelectedItem");
        }
    }
}
