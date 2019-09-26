using System.Collections.ObjectModel;

namespace PartBuilder.GetPoint.Model
{
    /// <summary>
    /// part or directory model
    /// </summary>
    public class PartsModel
    {
        public enum Type { PART, DIRECTORY, DIRECTORY_HIDE, ROOT }

        #region Data area
        /// <summary>
        /// part or directory id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// part or directory parent id
        /// </summary>
        public int PId { get; set; }

        /// <summary>
        /// part or directory sort pos
        /// </summary>
        public int SortPos { get; set; }

        /// <summary>
        /// type (PART, DIRECTORY, DIRECTORY_HIDE, ROOT)
        /// </summary>
        public Type PartsType { get; set; }

        /// <summary>
        /// show name
        /// </summary>
        public string Name { get; set; }

        public string _iconPath;
        /// <summary>
        /// icon in tree ctrl
        /// </summary>
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
        #endregion

        #region Tree node op

        /// <summary>
        /// parent item
        /// </summary>
        public PartsModel Parent { get; set; }

        /// <summary>
        /// children, the default is zero child
        /// </summary>
        public ObservableCollection<PartsModel> Children { get; set; } = new ObservableCollection<PartsModel>();

        #endregion
    }
}
