using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    class StationaryPhone : ICaller
    {
        public void Call(string phoneNumber)
        {
            if (int.TryParse(phoneNumber, out int number))
            {
                Console.WriteLine($"Dialing... {phoneNumber}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}
