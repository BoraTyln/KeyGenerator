using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGenerator
{
    public class Password
    {
        private static Random random = new Random();
        public static string GetRandomStringPassword(int length)
        {
            const string lower = "abcdefghijklmnoprstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPRSTUVWXYZ";
            const string number = "1234567890";
            const string symbol = ".,?#/{[]}=!*+-";

            string allChars = lower + upper + number + symbol;

            string password = lower[random.Next(lower.Length)].ToString()
                + upper[random.Next(upper.Length)].ToString()
                + number[random.Next(number.Length)].ToString()
                + symbol[random.Next(symbol.Length)].ToString();
            password += new string(Enumerable.Repeat(allChars, length - 4).Select(s => s[random.Next(s.Length)]).ToArray());

            password = new string(password.ToCharArray().OrderBy(s => (random.Next(2) % 2) == 0).ToArray());
            return password;
        }
    }
}
