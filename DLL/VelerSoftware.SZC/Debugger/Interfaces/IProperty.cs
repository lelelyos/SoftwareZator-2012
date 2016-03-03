// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




namespace VelerSoftware.SZC.Debugger.Interfaces
{
    public interface IProperty : IMethodOrProperty
    {
        DomRegion GetterRegion
        {
            get;
        }

        DomRegion SetterRegion
        {
            get;
        }

        bool CanGet
        {
            get;
        }

        bool CanSet
        {
            get;
        }

        bool IsIndexer
        {
            get;
        }

        ModifierEnum GetterModifiers
        {
            get;
        }

        ModifierEnum SetterModifiers
        {
            get;
        }
    }
}