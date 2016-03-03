// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




namespace VelerSoftware.SZC.Debugger.Core
{
    public abstract class AbstractComboBoxCommand : AbstractCommand, IComboBoxCommand
    {
        bool isEnabled = true;
        object comboBox;

        public virtual bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
            }
        }

        public virtual object ComboBox
        {
            get { return comboBox; }
            set
            {
                comboBox = value;
                OnComboBoxChanged();
            }
        }

        protected virtual void OnComboBoxChanged()
        {
        }

        public override void Run()
        {
        }
    }
}