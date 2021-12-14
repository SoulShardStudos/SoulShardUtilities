using System;
namespace SoulShard.Utils
{
    /// <summary>
    /// contains various helper functions for modifying strings
    /// </summary>
    public static class StringUtility
    {
        /// <summary>
        /// reverses a string. hahaha becomes ahahah
        /// </summary>
        /// <param name="str">the string to reverse</param>
        /// <returns>the reversed string</returns>
        public static string ReverseString(ref string str) => str = ReverseString(str);
        /// <summary>
        /// reverses a string. hahaha becomes ahahah
        /// </summary>
        /// <param name="str">the string to reverse</param>
        /// <returns>the reversed string</returns>
        public static string ReverseString(string str)
        {
            char[] chararr = str.ToCharArray();
            Array.Reverse(chararr);
            return new string(chararr);
        }
        /// <summary>
        /// gets the number of characters in a string
        /// </summary>
        /// <param name="str">the string to analyze</param>
        /// <param name="delim">the delimiter</param>
        /// <returns>the number of char occurences</returns>
        public static int GetNumberOfCharsInStr(string str, char delim)
        {
            int @return = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] == delim)
                    @return++;
            return @return;
        }
    }

}
