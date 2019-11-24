using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    class PlusMinExpression
    {
        string _text;
        public decimal Value { get; set; }

        public PlusMinExpression(string text)
        {
            _text = text;
            Value = Parse(_text);
        }

        decimal Parse(string text)
        {

            int startPos = text.Length;
                
            int pos = text.LastIndexOfAny(new char[] { '+', '-' }, startPos-1);
            while (pos > 0 && !Char.IsDigit(text.ToCharArray()[pos - 1]))
            {
                startPos = pos;
                pos = text.LastIndexOfAny(new char[] { '+', '-' }, startPos - 1);
            }
            if (pos > 0 && Char.IsDigit(text.ToCharArray()[pos - 1]))
            {
                //string textAlt = Regex.Replace(text, @"\-([1-9]\d*)", @"+~$1");
                //if (text != textAlt)
                //    return new PlusMinExpression(textAlt).Value;
                if (pos >= 0 && text.ToCharArray()[pos] == '+')
                    return new PlusMinExpression(text.Substring(0, pos)).Value + new PlusMinExpression(text.Substring(pos + 1)).Value;
                if (pos >= 0 && text.ToCharArray()[pos] == '-')
                    return new PlusMinExpression(text.Substring(0, pos)).Value - new PlusMinExpression(text.Substring(pos + 1)).Value;
            }
            return new MultDivExpression(text).Value;
        }

    }
}
