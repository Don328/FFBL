 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DScoreAnylizer.DisplayText;
internal static class DisplayText
{
    internal const char graphChar = '-';
    
    internal static string GetBar(int score, int quantity)
    {
        var strBldr = new StringBuilder();
        strBldr.Append("[" + score + "] ");

        if (score < 10) strBldr.Append(' ');

        int i = 0;
        while (i < quantity)
        {
            strBldr.Append('\u2586');
            strBldr.Append('\u2586');
            i++;
        }

        strBldr.Append(" (");
        strBldr.Append(quantity);
        strBldr.Append(')');

        return strBldr.ToString();
    }
}
