using System;
using System.Collections.Generic;

namespace Rino.Shared.Utils
{
    public static class StringHelper
    {
        public static List<string> FastSplit(this string str, string splitStr, bool ignoreSpace = false)
        {
            var strSpan = str.AsSpan();
            var splitSpan = splitStr.AsSpan();
            var list = new List<string>();

            while (true)
            {
                var n = strSpan.IndexOf(splitSpan);
                if (n > -1)
                {
                    var s = strSpan[..n].ToString();
                    if (!ignoreSpace || s.IsValid()) list.Add(s);
                    strSpan = strSpan[(n + splitSpan.Length)..];
                }
                else
                {
                    list.Add(strSpan.ToString());
                    break;
                }
            }

            return list;
        }

        public static string[] FastSplit(this string str, string splitStr, int length, bool ignoreSpace = false)
        {
            var strSpan = str.AsSpan();
            var splitSpan = splitStr.AsSpan();
            var array = new string[length];

            var i = 0;
            while (i < length)
            {
                var n = strSpan.IndexOf(splitSpan);
                
                if (n > -1)
                {
                    var s = strSpan[..n].ToString();
                    if (!ignoreSpace || s.IsValid()) array[i] = strSpan[..n].ToString();
                    strSpan = strSpan[(n + splitSpan.Length)..];
                }
                else
                {
                    array[i] = strSpan.ToString();
                    break;
                }
                i++;
            }

            return array;
        }
        
        public static void FastSplitTo(this string str, string splitStr, string[] array, out int count, bool ignoreSpace = false)
        {
            var strSpan = str.AsSpan();
            var splitSpan = splitStr.AsSpan();

            int i = 0, c = 0;
            while (i < array.Length)
            {
                var n = strSpan.IndexOf(splitSpan);
                
                if (n > -1)
                {
                    var s = strSpan[..n].ToString();
                    if (!ignoreSpace || s.IsValid()) array[i] = strSpan[..n].ToString();
                    strSpan = strSpan[(n + splitSpan.Length)..];
                    c++;
                }
                else
                {
                    array[i] = strSpan.ToString();
                    break;
                }
                i++;
            }

            count = c;
        }

        public static string FastReplace(this string str, string originStr, string desStr)
        {
            var replaceStr = str.FastSplit(originStr);
            return string.Join(desStr, replaceStr);
        }
    }
}