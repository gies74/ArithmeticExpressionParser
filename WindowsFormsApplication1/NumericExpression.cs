using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class NumericExpression
    {
        string _text;
        public decimal Value { get; set; }

        public NumericExpression(string text)
        {
            _text = text;
            Value = Parse(_text);
        }

        decimal Parse(string text)
        {
            //if (text == "")
            //    return 0m;
            //int pos = text.IndexOf('~');
            //if (pos == 0)
            //    return 0 - new NumericExpression(text.Substring(pos + 1)).Value;
            //if (pos >= 0)
            //    return new NumericExpression(text.Substring(0, pos)).Value - new NumericExpression(text.Substring(pos + 1)).Value;
            return Decimal.Parse(text);
        }

    }
}
