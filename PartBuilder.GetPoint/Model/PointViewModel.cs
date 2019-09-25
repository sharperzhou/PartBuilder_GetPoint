using GrxCAD.DatabaseServices;
using GrxCAD.Geometry;
using PartBuilder.GetPoint.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace PartBuilder.GetPoint.Model
{
    class PointViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PointViewModel()
        {
            _pointModelList = new ObservableCollection<PointModel>();

            HostApplicationServices.WorkingDatabase.ObjectAppended += (o, e) =>
            {
                if (!(e.DBObject is DBPoint)) return;

                var pt = e.DBObject as DBPoint;
                var pos = pt.Position;

                var hasPt = _pointModelList.Any(p => new Point3d(p.XValue, p.YValue, p.ZValue) == pos);
                if (!hasPt)
                {

                    var maxId = _pointModelList.Count == 0 ? -1 : _pointModelList.Max(p => int.Parse(p.Name.Trim('P', 'p')));
                    _pointModelList.Add(new PointModel()
                    {
                        Name = $"P{maxId + 1}",
                        XValue = pos.X,
                        YValue = pos.Y,
                        ZValue = pos.Z
                    });
                }
            };

            HostApplicationServices.WorkingDatabase.ObjectErased += (o, e) =>
            {
                if (!(e.DBObject is DBPoint)) return;

                var pos = (e.DBObject as DBPoint).Position;
                var query = _pointModelList.Where(
                        p => new Point3d(p.XValue, p.YValue, p.ZValue) == pos
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

        public Point3d BasePoint { get; set; } = Point3d.Origin;

        /// <summary>
        /// Selected item of view, only support single row
        /// </summary>
        public PointModel SelectedItem { get; set; }

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
    }
}
