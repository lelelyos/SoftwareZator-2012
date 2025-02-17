// *****************************************************************************
// 
//  � Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

namespace VelerSoftware.SZC.TreeViewAdv.Tree
{
    public class TreePath
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
        public static readonly TreePath Empty = new TreePath();

        private object[] _path;

        public object[] FullPath
        {
            get { return _path; }
        }

        public object LastNode
        {
            get
            {
                if (_path.Length > 0)
                    return _path[_path.Length - 1];
                else
                    return null;
            }
        }

        public object FirstNode
        {
            get
            {
                if (_path.Length > 0)
                    return _path[0];
                else
                    return null;
            }
        }

        public TreePath()
        {
            _path = new object[0];
        }

        public TreePath(object node)
        {
            _path = new object[] { node };
        }

        public TreePath(object[] path)
        {
            _path = path;
        }

        public bool IsEmpty()
        {
            return (_path.Length == 0);
        }
    }
}