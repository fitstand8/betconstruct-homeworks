using System;

namespace StringExtensionFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "aaaaaaaaaaaaahavi budaaaaaaa";
            Console.WriteLine(a);
            string b = a.MyTrim('a');
            Console.WriteLine(b);
            Console.WriteLine(b.MyEndsWith("bud"));
            Console.WriteLine("last index of a " + a.MyLastIndexOf('a'));
            Console.WriteLine(b.MyReplace('u','o'));
            Console.WriteLine(b.MySubstring(5));
            Console.WriteLine(b.MySubstring(2, 4));
            Console.WriteLine(b.MyToUpper());
            Console.WriteLine("HAVI BUD".MyToLower());
        }
    }

    public static class StringExtensions
    {
        public static string MyTrim(this string str)
        {
            int rightCount = 0;
            int leftCount = 0;
            if(str[0] == ' ')
            {
                int i = 0;
                while (str[i] == ' ')
                {
                    leftCount++;
                    i++;
                }
            }
            if(str[str.Length - 1] == ' ')
            {
                int i = str.Length - 1;
                while (str[i] == ' ')
                {
                    rightCount++;
                    i--;
                }
            }

            int newLength = str.Length - rightCount - leftCount;
            char[] c = new char[newLength];

            for (int i = 0, j = leftCount; i < newLength; i++, j++)
            {
                c[i] = str[j];
            }
            return new string(c);
        }
        public static string MyTrim(this string str, char c)
        {
            int rightCount = 0;
            int leftCount = 0;
            if (str[0] == c)
            {
                int i = 0;
                while (str[i] == c)
                {
                    leftCount++;
                    i++;
                }
            }
            if (str[str.Length - 1] == c)
            {
                int i = str.Length - 1;
                while (str[i] == c)
                {
                    rightCount++;
                    i--;
                }
            }

            int newLength = str.Length - rightCount - leftCount;
            char[] charArray = new char[newLength];

            for (int i = 0, j = leftCount; i < newLength; i++, j++)
            {
                charArray[i] = str[j];
            }
            return new string(charArray);
        }
        public static bool MyEndsWith(this string str, char value)
        {
            if (str[str.Length - 1] == value) return true;
            return false;
        }
        public static bool MyEndsWith(this string str, string value)
        {
            if (str.Length < value.Length) return false;
            for (int i = str.Length - value.Length, j = 0; j < value.Length; i++, j++)
            {
                if (str[i] != value[j]) return false;
            }
            return true;
        }
        public static int MyIndexOf(this string str, char value)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == value) return i;
            }
            return -1;
        }
        public static int MyLastIndexOf(this string str, char value)
        {
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] == value) return i;
            }
            return -1;
        }
        public static string MyReplace(this string str, char oldChar, char newChar)
        {
            char[] result = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                result[i] = str[i];
                if (result[i] == oldChar) result[i] = newChar;
            }
            return new string(result);
        }
        public static string[] MySplit(this string str, char splitChar)
        {
            return str.Split(splitChar);
        }
        public static bool MyStartsWith(this string str, char value)
        {
            return str[0] == value;
        }
        public static string MySubstring(this string str, int startPos)
        {
            if (startPos < 0 || startPos >= str.Length) throw new ArgumentException();

            char[] result = new char[str.Length - startPos];
            for (int i = startPos, j = 0; i < str.Length; i++, j++)
            {
                result[j] = str[i];
            }
            return new string(result);
        }
        public static string MySubstring(this string str, int startPos, int endPos)
        {
            if (startPos < 0 || startPos >= str.Length || startPos > endPos) throw new ArgumentException();

            char[] result = new char[str.Length - startPos - endPos];
            for (int i = startPos, j = 0; j < result.Length; i++, j++)
            {
                result[j] = str[i];
            }
            return new string(result);
        }
        public static string MyToUpper(this string str)
        {
            int UpperAIndex = 'A';
            int LoweraIndex = 'a';
            int LowerzIndex = 'z';
            int letterCount = LoweraIndex - UpperAIndex;
            char[] c = new char[str.Length];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = str[i];
                if (c[i] >= LoweraIndex && c[i] <= LowerzIndex)
                {
                    c[i] = (char)((int)c[i] - letterCount);
                }
            }
            return new string(c);
        }
        public static string MyToLower(this string str)
        {
            int UpperAIndex = 'A';
            int LoweraIndex = 'a';
            int UpperZIndex = 'Z';
            int letterCount = LoweraIndex - UpperAIndex;
            char[] c = new char[str.Length];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = str[i];
                if (c[i] >= UpperAIndex && c[i] <= UpperZIndex)
                {
                    c[i] = (char)((int)c[i] + letterCount);
                }
            }
            return new string(c);
        }
    }
}
