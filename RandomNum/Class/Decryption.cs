using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNum.Class
{
    class Decryption
    {
        static public string[] Dec()
        {
            string path = @"C:data.txt";
            string[] falseret = new string[1];

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string date = sr.ReadToEnd();
                    string[] dateArray = date.Split('呈');
                    string[] result = new string[dateArray.Length];

                    ushort Key = 0x5463;
                    for (int i = 0; i < dateArray.Length; i++)
                    {
                        result[i] = EncodeDecrypt(dateArray[i], Key);
                    }
                    result = result.Where(x => x != null).ToArray();
                    return result;
                }
            }
            catch (Exception )
            {
                return falseret;
            }

            



        }
        public static string EncodeDecrypt(string str, ushort secretKey)
        {
            var ch = str.ToArray();
            string newStr = "";
            foreach (var c in ch)
                newStr += TopSecret(c, secretKey);
            return newStr;
        }

        public static char TopSecret(char character, ushort secretKey)
        {
            character = (char)(character ^ secretKey);
            return character;
        }
    }
}
