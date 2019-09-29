using GrxCAD.DatabaseServices;
using GrxCAD.Geometry;
using PartBuilder.GetPoint.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace PartBuilder.GetPoint.Model
{
    /// <summary>
    /// Point view model (Data Grid control)
    /// </summary>
    public class PointViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event SelectedRowEventHandler SelectedRowChanged;

        public PointViewModel()
        {
            _pointModelList = new ObservableCollection<PointModel>();

            // Point added event
            HostApplicationServices.WorkingDatabase.ObjectAppended += (o, e) =>
            {
                if (!(e.DBObject is DBPoint)) return;

                var pt = e.DBObject as DBPoint;
                var pos = pt.Position;

                var hasPt = _pointModelList.Any(p => new Point3d(p.XValue, p.YValue, p.ZValue) == pos);
                if (!hasPt)
                {

                    var maxId = _pointModelList.Count == 0 ? -1 : _pointModelList.Max(p =>
                        int.TryParse(p.Name.Trim('P', 'p'), out int ret) ? ret : 0);

                    _pointModelList.Add(new PointModel()
                    {
                        Name = "P" + (++maxId == 0 ? string.Empty : maxId.ToString()),
                        XValue = pos.X,
                        YValue = pos.Y,
                        ZValue = pos.Z,
                        PointId = e.DBObject.ObjectId
                    });
                }
            };

            // point erased event
            HostApplicationServices.WorkingDatabase.ObjectErased += (o, e) =>
            {
                if (!(e.DBObject is DBPoint)) return;

                var pos = (e.DBObject as DBPoint).Position;
                var query = _pointModelList.Where(
                        p => (new Point3d(p.XValue, p.YValue, p.ZValue) == pos)
                        || (e.DBObject.ObjectId == p.PointId)
                    ).Select(p => p).ToList();

                foreach (var res in query)
                {
                    _pointModelList.Remove(res);
                }
            };
        }

        /// <summary>
        /// Invoke property changed event
        /// </summary>
        /// <param name="propertyName"></param>
        public void RaisePropertyChanged(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName) && PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ObservableCollection<PointModel> _pointModelList;
        /// <summary>
        /// item source of grid view
        /// </summary>
        public ObservableCollection<PointModel> PointModelList
        {
            get { return _pointModelList; }
            set
            {
                _pointModelList = value;
                RaisePropertyChanged("PointModelList");
            }
        }


        private PointModel _selectedItem;
        /// <summary>
        /// Selected item of view, only support single row
        /// </summary>
        public PointModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    if (SelectedRowChanged != null)
                        SelectedRowChanged.Invoke(this, new SelectedRowChangedEventArgs(value, _selectedItem));
                    _selectedItem = value;
                    RaisePropertyChanged(nameof(SelectedItem));
                }
            }
        }

        /// <summary>
        /// Command for move up button
        /// </summary>
        public ICommand MoveUpCommand => new PointViewMoveUp(this);

        /// <summary>
        /// Command for move down button
        /// </summary>
        public ICommand MoveDownCommand => new PointViewMoveDown(this);

        /// <summary>
        /// Command for rename all names button
        /// </summary>
        public ICommand RenameCommand => new PointViewRenameItems(this);

        /// <summary>
        /// Command for move into first
        /// </summary>
        public ICommand MoveFirstCommand { get => new PointViewMoveFirst(this); }

        /// <summary>
        /// Command for move into last
        /// </summary>
        public ICommand MoveLastCommand { get => new PointViewMoveLast(this); }

        /// <summary>
        /// Mark point in CAD and heighlint selection in data grid ctrl
        /// </summary>
        public ICommand MartPointCommand { get => new PointViewMarkPoint(this); }
    }

    /// <summary>
    /// Data grid selection changed event args
    /// </summary>
    public class SelectedRowChangedEventArgs : EventArgs
    {
        public SelectedRowChangedEventArgs(PointModel current, PointModel previous)
        {
            CurrentItem = current;
            PreviousItem = previous;
        }

        /// <summary>
        /// current item
        /// </summary>
        public PointModel CurrentItem { get; }

        /// <summary>
        /// previous item
        /// </summary>
        public PointModel PreviousItem { get; }
    }

    public delegate void SelectedRowEventHandler(object sender, SelectedRowChangedEventArgs e);
}
