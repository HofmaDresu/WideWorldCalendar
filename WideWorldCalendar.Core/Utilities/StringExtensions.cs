using System;
using System.Collections.Generic;
using System.Text;

namespace WideWorldCalendar.Utilities
{
    public static class StringExtensions
    {
        public static string[] Split(this string str, params string[] args)
        {
            return str.Split(args, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
