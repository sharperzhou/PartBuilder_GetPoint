using PartBuilder.GetPoint.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

namespace PartBuilder.GetPoint.Command
{
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

        public void Execute(object parameter)
        {
            var newList =  new ObservableCollection<PointModel>(_viewModel.PointModelList);

            for (int i = 0; i < newList.Count; i++)
            {
                newList[i].Name = $"P{i}";
            }

            _viewModel.PointModelList = newList;
        }

        private PointViewModel _viewModel;
    }
}
