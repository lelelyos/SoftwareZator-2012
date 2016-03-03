// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System;

namespace VelerSoftware.SZC.Debugger.Core
{
    /// <summary>
    /// Abstract implementation of the <see cref="ICommand"/> interface.
    /// </summary>
    public abstract class AbstractCommand : ICommand
    {
        object owner = null;

        /// <summary>
        /// Returns the owner of the command.
        /// </summary>
        public virtual object Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
                OnOwnerChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Invokes the command.
        /// </summary>
        public abstract void Run();

        protected virtual void OnOwnerChanged(EventArgs e)
        {
            if (OwnerChanged != null)
            {
                OwnerChanged(this, e);
            }
        }

        public event EventHandler OwnerChanged;
    }
}