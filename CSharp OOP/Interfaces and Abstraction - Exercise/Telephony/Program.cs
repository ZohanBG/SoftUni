using System;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();
            foreach (var number in numbers)
            {
                if (number.Length == 10)
                {
                    smartphone.Call(number);
                }
                else
                {
                    stationaryPhone.Call(number);
                }
            }
            foreach (var url in urls)
            {
                smartphone.Browse(url);
            }
        }
    }
}
