using PartBuilder.GetPoint.Model;
using System;
using System.Windows.Input;

namespace PartBuilder.GetPoint.Command
{
    /// <summary>
    /// Commanding class of moving row into last in data grid
    /// </summary>
    public class PointViewMoveLast : ICommand
    {
        public PointViewMoveLast(PointViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly PointViewModel _viewModel;

        public bool CanExecute(object parameter)
        {
            var sel = _viewModel.SelectedItem;
            if (sel == null) return false;

            var list = _viewModel.PointModelList;
            return list.IndexOf(sel) < list.Count - 1;
        }

        public void Execute(object parameter)
        {
            var sel = _viewModel.SelectedItem;
            var list = _viewModel.PointModelList;
            if (list.Remove(sel))
                list.Add(sel);
            _viewModel.SelectedItem = sel;
            _viewModel.RaisePropertyChanged("SelectedItem");
        }
    }
}
