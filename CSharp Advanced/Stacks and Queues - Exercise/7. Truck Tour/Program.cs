using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> pumpsData = new Queue<string>();
            for (int i = 0; i < n; i++)
            {
                pumpsData.Enqueue(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                int currentPatrolAmmount = 0;
                bool isSuccesful = true;
                for (int j = 0; j < n; j++)
                {
                    string pumpDatas = pumpsData.Dequeue();
                    int[] pumpData = pumpDatas.Split().Select(int.Parse).ToArray();
                    pumpsData.Enqueue(pumpDatas);
                    currentPatrolAmmount += pumpData[0];
                    currentPatrolAmmount -= pumpData[1];
                    if (currentPatrolAmmount < 0)
                    {
                        isSuccesful = false;
                    }
                }
                if (isSuccesful)
                {
                    Console.WriteLine(i);
                    break;
                }
                string tempData = pumpsData.Dequeue();
                pumpsData.Enqueue(tempData);
            }           
        }
    }
}
