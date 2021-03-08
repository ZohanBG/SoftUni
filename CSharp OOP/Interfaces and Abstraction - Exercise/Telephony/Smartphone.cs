using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICaller, IBrowser
    {
        public void Call(string phoneNumber)
        {
            if(int.TryParse(phoneNumber,out int number))
            {
                Console.WriteLine($"Calling... {phoneNumber}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }

        public void Browse(string url)
        {
            if (url.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {url}!");
            }
        }

    }
}
