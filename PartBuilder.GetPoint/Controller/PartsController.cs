using PartBuilder.GetPoint.DataAccess;
using PartBuilder.GetPoint.Model;
using System.Collections.Generic;
using System.Linq;

namespace PartBuilder.GetPoint.Controller
{
    /// <summary>
    /// Part or directory controller class
    /// </summary>
    class PartsController
    {
        public PartsController(string dbName)
        {
            _dbName = dbName;
        }

        /// <summary>
        /// get a parts and directories tree (root node)
        /// </summary>
        /// <returns>root node</returns>
        public PartsModel BuildPartsTree()
        {
            IList<PartsModel> directories = null;
            IList<PartsModel> parts = null;
            using (var dao = new PartsDao(_dbName))
            {
                directories = dao.GetDirectory();
                parts = dao.GetParts();
            }

            var dictNodes = directories.ToDictionary(m => m.Id, m => m);
            var root = new PartsModel()
            {
                Name = _dbName,
                Id = 0,
                PId = 0,
                SortPos = 0,
                PartsType = PartsModel.Type.ROOT,
            };

            // build directory tree
            foreach (var node in dictNodes)
            {
                var pid = node.Value.PId;
                if (pid == 0)
                {
                    root.Children.Add(node.Value);
                    node.Value.Parent = root;
                }
                else
                {
                    if (dictNodes.ContainsKey(pid))
                    {
                        var parentItem = dictNodes[pid];
                        parentItem.Children.Add(node.Value);
                        node.Value.Parent = parentItem;
                    }
                }
            }

            // build part tree under the directory
            foreach (var part in parts)
            {
                if (dictNodes.ContainsKey(part.PId))
                {
                    var parentItem = dictNodes[part.PId];
                    parentItem.Children.Add(part);
                    part.Parent = parentItem;
                }
            }

            return root;
        }

        /// <summary>
        /// get directories
        /// </summary>
        /// <returns></returns>
        public IList<PartsModel> GetDirectory()
        {
            using (var dao = new PartsDao(_dbName))
            {
                return dao.GetDirectory();
            }
        }

        /// <summary>
        /// add directory
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        public bool AddDirectory(int parentId, string newName)
        {
            using (var dao = new PartsDao(_dbName))
            {
                return dao.AddDirectory(parentId, newName);
            }
        }

        /// <summary>
        /// add part
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="newName"></param>
        /// <param name="newPartId"></param>
        /// <returns></returns>
        public bool AddPart(int parentId, string newName, out int newPartId)
        {
            using (var dao = new PartsDao(_dbName))
            {
                return dao.AddPart(parentId, newName, out newPartId);
            }
        }

        private string _dbName;
    }
}
