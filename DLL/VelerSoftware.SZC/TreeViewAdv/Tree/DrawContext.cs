// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using System.Drawing;
using VelerSoftware.SZC.TreeViewAdv.Tree.NodeControls;

namespace VelerSoftware.SZC.TreeViewAdv.Tree
{
    public struct DrawContext
    {
        private Graphics _graphics;

        public Graphics Graphics
        {
            get { return _graphics; }
            set { _graphics = value; }
        }

        private Rectangle _bounds;

        public Rectangle Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }

        private Font _font;

        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        private DrawSelectionMode _drawSelection;

        public DrawSelectionMode DrawSelection
        {
            get { return _drawSelection; }
            set { _drawSelection = value; }
        }

        private bool _drawFocus;

        public bool DrawFocus
        {
            get { return _drawFocus; }
            set { _drawFocus = value; }
        }

        private NodeControl _currentEditorOwner;

        public NodeControl CurrentEditorOwner
        {
            get { return _currentEditorOwner; }
            set { _currentEditorOwner = value; }
        }

        private bool _enabled;

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
    }
}