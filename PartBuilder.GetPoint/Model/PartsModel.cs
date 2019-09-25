using PartBuilder.GetPoint.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartBuilder.GetPoint.Model
{
    public class PartsModel
    {
        public enum Type { PART, DIRECTORY, DIRECTORY_HIDE, ROOT }

        public int Id { get; set; }

        public int PId { get; set; }

        public int SortPos { get; set; }

        public Type PartsType { get; set; }

        public string Name { get; set; }

        public string _iconPath;
        public string IconPath
        {
            get
            {
                switch (PartsType)
                {

                    case Type.ROOT: _iconPath = "/PartBuilder.GetPoint;component/Images/database_open.png"; break;
                    case Type.DIRECTORY: _iconPath = "/PartBuilder.GetPoint;component/Images/catalog_normal.png"; break;
                    case Type.DIRECTORY_HIDE: _iconPath = "/PartBuilder.GetPoint;component/Images/catalog_hide.png"; break;
                    default: _iconPath = "/PartBuilder.GetPoint;component/Images/part.png"; break;
                }

                return _iconPath;
            }
        }

        public PartsModel Parent { get; set; }
        public ObservableCollection<PartsModel> Children { get; set; } = new ObservableCollection<PartsModel>();
    }
}
