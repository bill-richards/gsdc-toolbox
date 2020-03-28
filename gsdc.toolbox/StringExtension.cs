using System.Collections.Generic;

namespace gsdc.toolbox
{
    public static class StringExtension
    {
        public static string UppercaseWords(this string value)
        {
            var array = value.StripHtmlEncoding();

            if (array.Length >= 1)
            {
                if (char.IsLower(array[0])) array[0] = char.ToUpper(array[0]);
            }

            for (var i = 1; i < array.Length; i++)
            {
                if (array[i - 1] != ' ') continue;
                if (char.IsLower(array[i])) array[i] = char.ToUpper(array[i]);
            }

            return new string(array);
        }

        private static char[] StripHtmlEncoding(this string value)
        {
            var inArray = value.ToCharArray();
            var outArray = new List<char>();

            for (var inCounter = 0; inCounter < inArray.Length; inCounter++)
            {
                if (inArray[inCounter] == '%' && inArray[inCounter+1] == '2' && inArray[inCounter+2] == '0')
                {
                    outArray.Add(' ');
                    inCounter += 3;
                }
                outArray.Add(inArray[inCounter]);
            }
            return outArray.ToArray();
        }
    }
}