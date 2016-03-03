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
    public abstract class AbstractCheckableMenuCommand : AbstractMenuCommand, ICheckableMenuCommand
    {
        bool isChecked = false;

        public virtual bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
            }
        }

        public override void Run()
        {
            IsChecked = !IsChecked;
        }
    }
}