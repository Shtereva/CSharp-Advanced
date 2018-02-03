using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07._Directory_Traversal
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var files = Directory.GetFiles(path);

            var report = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;

                if (!report.ContainsKey(extension))
                {
                    report[extension] = new List<FileInfo>();
                }

                

                report[extension].Add(fileInfo);
            }

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string resultPath = desktop + @"\report.txt";
            //desktop = @"%USERPROFILE%\Desktop";

            using (var writer = new StreamWriter(resultPath))
            {
                foreach (var kvp in report
                    .OrderByDescending(x => x.Value.Count)
                    .ThenBy(x => x.Key))
                {
                    writer.WriteLine(kvp.Key);


                    foreach (var item in kvp.Value.OrderBy(x => x.Length))
                    {
                        writer.WriteLine($"--{item.Name} - {(double)item.Length / 1024}kb");
                    }
                }
            }

            
        }
    }
}
