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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace VelerSoftware.SZC.Obfuscator.Confuser.Core
{
    public static class ObfuscationHelper
    {
        static MD5 md5 = MD5.Create();

        public static string GetNewName(string originalName)
        {
            BitArray arr = new BitArray(md5.ComputeHash(Encoding.UTF8.GetBytes(originalName)));

            Random rand = new Random(originalName.GetHashCode());
            byte[] xorB = new byte[arr.Length / 8];
            rand.NextBytes(xorB);
            BitArray xor = new BitArray(xorB);

            BitArray result = arr.Xor(xor);
            byte[] ret = new byte[result.Length / 8];
            result.CopyTo(ret, 0);

            return Encoding.Unicode.GetString(ret).Replace("\0", "").Replace(".", "").Replace("/", "");
        }
    }
}
