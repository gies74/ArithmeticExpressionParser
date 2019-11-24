using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    class Expression
    {
        public decimal Value { get; set; }
        private string _text { get; set; }

        public Expression(string text)
        {
            _text = text;
            Value = Parse(text);
        }

        private decimal Parse(string text)
        {
            int posS = text.IndexOf('(');
            PlusMinExpression final;
            if (posS >= 0)
            {
                char[] chars = text.ToCharArray();
                int depth = 1;
                int posE = posS + 1;
                for (; posE < chars.Length; posE++)
                {
                    if (chars[posE] == '(')
                        depth++;
                    if (chars[posE] == ')')
                        depth--;
                    if (depth == 0)
                        break;
                }

                Expression subExpr1 = new Expression(text.Substring(posS + 1, posE - posS - 1));
                Expression subExpr2 = new Expression(text.Substring(0, posS) + subExpr1.Value.ToString() + text.Substring(posE + 1));
                final = new PlusMinExpression(subExpr2.Value.ToString());
            }
            else
                final = new PlusMinExpression(text);

            return final.Value;
        }


        private bool ValidateParentheses(string text)
        {
            int depth = 0;
            char[] chars = text.ToCharArray();
            foreach (char c in chars)
            {
                if (c == '(')
                {
                    depth++;
                }
                else if (c == ')')
                    depth--;
                if (depth < 0)
                    return false;
            }
            return (depth == 0);
        }

    }

}
