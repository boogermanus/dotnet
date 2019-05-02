using System;
using System.Collections.Generic;

namespace ReferencingNamespaceLib
{
    public static class ExtensionMethods
    {
        public static byte[] ConvertToHex(this string pString)
        {
            int i = 0;
            byte[] hexArray = new byte[pString.Length];

            foreach(char c in pString)
                hexArray[i++] = Convert.ToByte(c);
            
            return hexArray;
        }
    }
}
