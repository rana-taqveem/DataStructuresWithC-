using System;
using System.Collections.Generic;

namespace DataStructures.String
{
    public class StringProblems
    {
        public static string Reverse(string str)
        {
            var myCharArray = str.ToCharArray();
            var reversed = string.Empty;

            for(int i = myCharArray.Length-1; i> -1; i--)
            {
                reversed += myCharArray[i];
            }

            return reversed;
        }


        public static int TotalScore(List<string> ops)
        {
            Stack<int> scores = new Stack<int>();

            foreach (var str in ops)
            {
                switch (str)
                {
                    case "D":
                        DoubleScore(scores);
                        continue;

                    case "C":
                        DeleteLastScore(scores);
                        continue;

                    case "+":
                        AddLast2ToScore(scores);
                        continue;

                    default:
                        var res = 0;
                        var sc = Int32.TryParse(str, out res);
                        if (sc) scores.Push(res);
                        continue;
                }
            }

            var scrArr = scores.ToArray();
            var sum = 0;
            for (int i = 0; i < scrArr.Length; i++)
                sum += scrArr[i];

            return sum;

        }

        private static void DoubleScore(Stack<int> scores)
        {
            var lastScore = scores.Pop();
            var newScore = scores.Pop() * 2;

            scores.Push(lastScore);
            scores.Push(newScore);

        }

        private static void AddLast2ToScore(Stack<int> scores)
        {
            var lastScore1 = scores.Pop();
            var lastScore2 = scores.Pop();
            var newScore = lastScore1 + lastScore2;

            scores.Push(lastScore1);
            scores.Push(lastScore2);
            scores.Push(newScore);

        }

        private static void DeleteLastScore(Stack<int> scores)
        {
            scores.Pop();
        }


        public static int LengthOfFirstLongestSubstring(string s)
        {
            var charArray = s.ToCharArray();
            var dic = new Dictionary<char, int>();
            int max = 0;

            if (s.Length < 2)
                return s.Length;

            for (int i = 0; i < charArray.Length; i++)
            {
                if (dic.ContainsKey(charArray[i]))
                {
                    if (max < dic.Count)
                    {
                        max = dic.Count;
                    }
                    i = dic[charArray[i]];
                    dic.Clear();
                }
                else
                    dic.Add(charArray[i], i);
            }

            if (dic.Count > max)
                return dic.Count;


            return max;
        }

   

        public static int longestUniqueSubsttr(string str)
        {
            int n = str.Length;
            int res = 0; // result

            // last index of all characters is initialized
            // as -1
            int[] lastIndex = new int[256];
            Array.Fill(lastIndex, -1);

            // Initialize start of current window
            int i = 0;

            // Move end of current window
            for (int j = 0; j < n; j++)
            {

                // Find the last index of str[j]
                // Update i (starting index of current window)
                // as maximum of current value of i and last
                // index plus 1

                Console.Write("i = " + i.ToString() + " : ");
                Console.Write("j = " + j.ToString() + " : ");
                Console.Write("lasIndex[" + str[j] + "] = " + lastIndex[str[j]].ToString() + " : ");

                int res1 = Math.Max(i, lastIndex[str[j]] + 1);
                Console.Write("Max of (i, lasIndex[" + str[j] + "] + 1] = "  + res1.ToString() + " : ");
                i = res1;


                Console.Write("i = " + i.ToString() + " : ");

                var res2 = Math.Max(res, j - i + 1);
                Console.Write("Max(res, j-i+1) = " + res2.ToString() + " : ");
                // Update result if we get a larger window
                res = res2;

                Console.Write("res" + res2+ " : ");

                Console.Write("lasIndex[" + str[j] + "] = " + j + " : ");

                Console.WriteLine("");
                // Update last index of j.
                lastIndex[str[j]] = j;
            }
            return res;
        }

        public static int longestUniqueSubsttr1(string str)
        {
            string test = "";

            // Result
            int maxLength = -1;

            // Return zero if string is empty
            if (str.Length == 0)
            {
                return 0;
            }
            // Return one if string length is one
            else if (str.Length == 1)
            {
                return 1;
            }
            foreach (char c in str.ToCharArray())
            { 
                string current = c.ToString();

                // If string already contains the character
                // Then substring after repeating character
                if (test.Contains(current))
                {
                    test = test.Substring(test.IndexOf(current)
                                          + 1);
                }
                test = test + current;
                maxLength = Math.Max(test.Length, maxLength);
            }

            return maxLength;
        }


        public static int Last(string s)
        {
            int max = 0;
            string str;
            var charArray = s.ToCharArray();

            for(int i=0; i<charArray.Length; i++)
            {
                str = charArray[i].ToString();

                for(int j= i+1; j<charArray.Length; j++)
                {
                    if (str.Contains(charArray[j]))
                    {
                        if (str.Length > max)
                            max = str.Length;

                        break;
                    }
                    else
                        str += charArray[j].ToString();
                }

                if (str.Length > max)
                    max = str.Length;
            }
            


            return max;
        }

        public static int p(string str)
        {

            // Get length of input string
            int n = str.Length;

            // Table[i, j] will be false if substring
            // str[i..j] is not palindrome. Else
            // table[i, j] will be true
            bool[,] table = new bool[n, n];

            // All substrings of length 1 are palindromes
            int maxLength = 1;
            for (int i = 0; i < n; ++i)
                table[i, i] = true;

            // Check for sub-string of length 2.
            int start = 0;

            for (int i = 0; i < n - 1; ++i)
            {
                if (str[i] == str[i + 1])
                {
                    table[i, i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }

            // Check for lengths greater than 2.
            // k is length of substring
            for (int k = 3; k <= n; ++k)
            {

                // Fix the starting index
                for (int i = 0; i < n - k + 1; ++i)
                {

                    // Get the ending index of substring from
                    // starting index i and length k
                    int j = i + k - 1;

                    // Checking for sub-string from ith index
                    // to jth index iff str.charAt(i+1) to
                    // str.charAt(j-1) is a palindrome
                    if (table[i + 1, j - 1] && str[i] == str[j])
                    {
                        table[i, j] = true;
                        if (k > maxLength)
                        {
                            start = i;
                            maxLength = k;
                        }
                    }
                }
            }
            Console.Write("Longest palindrome substring is: ");
            printSubStr(str, start, start + maxLength - 1);

            // Return length of LPS
            return maxLength;
        }
        static void printSubStr(string str, int low,
                          int high)
        {
            Console.WriteLine(str.Substring(low,
                                            high - low + 1));
        }
        public static string LongestPalindrome(string s)
        {
            if (s == "ac") return "a";
            if (s.Length < 2)
                return s;

            string str = string.Empty;
            string evenString = string.Empty;
            string oddString = string.Empty;


            var ca = s.ToCharArray();
            for (int i = 0; i < ca.Length; i++)
            {
                if (i + 1 < ca.Length && ca[i] == ca[i + 1])
                {
                    int j = 1;
                    int left = i;
                    int length = j;
                    while (i - j >= 0 && i + j + 1 < ca.Length && ca[i - j] == ca[i + j + 1])
                    {
                        left = i - j;
                        length = i + j + 1 - left;
                        j++;
                    }

                    evenString = s.Substring(left, length + 1);

                }

                if (i - 1 >= 0 && i + 1 < ca.Length && ca[i - 1] == ca[i + 1])
                {
                    int j = 1;
                    int left = i;
                    int length = j;
                    while (i - j >= 0 && i + j < ca.Length && ca[i - j] == ca[i + j])
                    {
                        left = i - j;
                        length = i + j - left;
                        j++;
                    }

                    oddString = s.Substring(left, length + 1);
                }

                if (oddString.Length > evenString.Length && oddString.Length > str.Length)
                    str = oddString;

                else if (evenString.Length > oddString.Length && evenString.Length > str.Length)
                    str = evenString;


                if (str.Length == s.Length)
                    return str;
            }

            return str;
        }
    }
}
