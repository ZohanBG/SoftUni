using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Console.ReadLine();
            string[] fileNames = Directory.GetFiles(directoryPath);
            Dictionary<string, Dictionary<string, double>> files = new Dictionary<string, Dictionary<string, double>>();
            foreach (var fileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                string extension = fileInfo.Extension;
                double fileSize = (double)fileInfo.Length/1024.0;
                if (!files.ContainsKey(extension))
                {
                    files.Add(extension, new Dictionary<string, double>());
                }               
                files[extension].Add(fileInfo.Name,fileSize);
            }
            files = files.OrderByDescending(x => x.Value.Count).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            List<string> info = new List<string>();
            foreach (var file in files)
            {
                info.Add(file.Key);
                foreach (var item in file.Value.OrderBy(x=>x.Value))
                {
                    info.Add($"--{item.Key} - {item.Value:f3}kb");
                }
            }
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.txt");
            File.WriteAllLines(filePath, info);
        }
    }
}
