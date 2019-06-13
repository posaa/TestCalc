using System;
using System.Reflection;
using System.Collections.Generic;
using System.Globalization;

namespace CalcEngine
{
    /// <summary>
	/// Represents a node in the expression tree.
    /// </summary>
    internal class Token
	{
        // ** fields
		public TKID ID;
        public TKTYPE Type;
        public object Value;
        public int decimals = 0;

        // ** ctor
        public Token(object value, TKID id, TKTYPE type)
        {
            Value = value;
            ID = id;
			Type = type;
            double d;
            if (value is double)
            {
                d = (double)value;
                string sd = d.ToString();
                sd = sd.Substring(sd.ToString().IndexOf(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)+1);
                decimals = sd.Length;
            }
		}
    }
    /// <summary>
    /// Token types (used when building expressions, sequence defines operator priority)
    /// </summary>
    internal enum TKTYPE
    {
        COMPARE,	// < > = <= >=
        ADDSUB,		// + -
        MULDIV,		// * /
        POWER,		// ^
        GROUP,		// ( ) , .
        LITERAL,	// 123.32, "Hello", etc.
        IDENTIFIER  // functions, external objects, bindings
    }
    /// <summary>
    /// Token ID (used when evaluating expressions)
    /// </summary>
    internal enum TKID
    {
        GT, LT, GE, LE, EQ, NE, // COMPARE
        ADD, SUB, // ADDSUB
        MUL, DIV, DIVINT, MOD, // MULDIV
        POWER, // POWER
        OPEN, CLOSE, END, COMMA, PERIOD, // GROUP
        ATOM, // LITERAL, IDENTIFIER
    }
}
