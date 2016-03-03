// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using System.ComponentModel;
using System.Windows.Forms;

namespace VelerSoftware.SZC.TreeViewAdv.Tree.NodeControls
{
    public class NodeDecimalTextBox : NodeTextBox
    {
        private bool _allowDecimalSeperator = true;

        [DefaultValue(true)]
        public bool AllowDecimalSeperator
        {
            get { return _allowDecimalSeperator; }
            set { _allowDecimalSeperator = value; }
        }

        private bool _allowNegativeSign = true;

        [DefaultValue(true)]
        public bool AllowNegativeSign
        {
            get { return _allowNegativeSign; }
            set { _allowNegativeSign = value; }
        }

        protected NodeDecimalTextBox()
        {
        }

        protected override TextBox CreateTextBox()
        {
            NumericTextBox textBox = new NumericTextBox();
            textBox.AllowDecimalSeperator = AllowDecimalSeperator;
            textBox.AllowNegativeSign = AllowNegativeSign;
            return textBox;
        }

        protected override void DoApplyChanges(TreeNodeAdv node, Control editor)
        {
            SetValue(node, (editor as NumericTextBox).DecimalValue);
        }
    }
}