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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace VelerSoftware.SZC.Obfuscator.Confuser.Core.Engines.Baml
{
    class BamlDocument : Collection<BamlRecord>
    {
        public struct BamlVersion
        {
            public ushort Major;
            public ushort Minor;
        }
        public string Signature { get; set; }
        public BamlVersion ReaderVersion { get; set; }
        public BamlVersion UpdaterVersion { get; set; }
        public BamlVersion WriterVersion { get; set; }
    }
}
