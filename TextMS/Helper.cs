using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMS
{
    public static class Helper //to  check availability of |
    {
        public static string ReadLine()
        {
            string line;

            while (true)
            {
                line = Console.ReadLine();
                if (!line.Contains("|")) return line;
                else
                {
                    Console.Write("You can't use \"|\", please, try again");
                }
            }
        } 

        public static string Join(string separator, string[] strings)
        {
            for (int i = 0; i < strings.Length - 1; i++)
            {
                for (int j = 0; j < strings[i].Length; j++)
                {
                    if (strings[i][j] == separator[0])
                    {
                        strings[i] = strings[i].Insert(strings[i].IndexOf(separator[0]), separator);
                        i++;
                    }
                }
            }
            return string.Join(separator, strings);
        }

        public static string[] Split(string str, char separator)
        {
            List<string> res = new List<string>();
            string word = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Equals(separator))
                {
                    if (!str[i + 1].Equals(separator))
                    {
                        res.Add(word);
                        word = "";
                    }
                    else
                    {

                        while (str[i].Equals(separator))
                        {
                            i++;
                            word += str[i];
                        }
                        //word.Remove(word.Length - 1, 1);
                    }
                }
                else
                {
                    word += str[i];
                }
            }
            if (word != "") res.Add(word);
            return res.ToArray();
        }
    }
}