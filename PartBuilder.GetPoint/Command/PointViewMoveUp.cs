using PartBuilder.GetPoint.Model;
using System;
using System.Windows.Input;

namespace PartBuilder.GetPoint.Command
{
    class PointViewMoveUp : ICommand
    {
        public PointViewMoveUp(PointViewModel viewModel)
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
            return (_viewModel.SelectedItem != null
                && _viewModel.PointModelList.IndexOf(_viewModel.SelectedItem) > 0);
        }

        public void Execute(object parameter)
        {
            var sel = _viewModel.SelectedItem;
            var list = _viewModel.PointModelList;
            var index = list.IndexOf(sel);
            list.RemoveAt(index);
            list.Insert(index - 1, sel);
            _viewModel.SelectedItem = sel;
            _viewModel.RaisePropertyChanged("SelectedItem");
        }

        private PointViewModel _viewModel;
    }
}
