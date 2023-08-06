using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DScoreAnylizer;
internal static class ArgResolver
{
    internal static int Convert_StrToInt(string str)
    {
        var success = Int32.TryParse(str, out int result);
        if (success) return result;

        return -1;
    }
}
