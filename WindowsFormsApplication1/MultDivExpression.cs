using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class MultDivExpression
    {
        string _text;
        public decimal Value { get; set; }

        public MultDivExpression(string text)
        {
            _text = text;
            Value = Parse(_text);
        }

        decimal Parse(string text)
        {
            int pos = text.LastIndexOfAny(new char[] { '*', '/' });
            if (pos >= 0 && text.ToCharArray()[pos] == '*')
                return new MultDivExpression(text.Substring(0, pos)).Value * new MultDivExpression(text.Substring(pos + 1)).Value;
            if (pos >= 0 && text.ToCharArray()[pos] == '/')
                return new MultDivExpression(text.Substring(0, pos)).Value / new MultDivExpression(text.Substring(pos + 1)).Value;
            return new NumericExpression(text).Value;
        }

    }
}
