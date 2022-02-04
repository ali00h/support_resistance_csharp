using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace support_resistance_csharp
{
    using System;

    public static class Extensions
    {
        public static string ToString(this List<double> obj,string seperator)
        {
            StringBuilder result = new StringBuilder();

            foreach(var item in obj){
                result.Append(item);
                result.Append(seperator);                
            }

            return result.ToString();
        }
    }
}