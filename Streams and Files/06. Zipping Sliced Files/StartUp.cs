using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace _06._Zipping_Sliced_Files
{
    public class StartUp
    {
        public static void Main()
        {
            int parts = int.Parse(Console.ReadLine());


            Zip(@"..\files\sliceMe.mp4", @"..\files\", parts);

            var files = new List<string>();

            for (int i = 1; i <= parts; i++)
            {
                files.Add($@"..\files\part{i}.mp4.gz");
            }

            Asseble(files, @"..\files\");
        }


        private static void Zip(string sourceFile, string destinationDirectory, int parts)
        {
            using (var video = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf("."));

                long partLen = (long)Math.Ceiling((double)video.Length / parts);

                for (int i = 1; i <= parts; i++)
                {
                    long currentPartSize = 0;

                    if (destinationDirectory == String.Empty)
                    {
                        destinationDirectory = "./";
                    }

                    string path = $"{destinationDirectory}part{i}{extension}.gz";

                    using (var writer = new GZipStream(new FileStream(path, FileMode.Create), CompressionLevel.Optimal))
                    {
                        var buffer = new byte[4096];
                        int readData;

                        while ((readData = video.Read(buffer, 0, buffer.Length)) == 4096)
                        {
                            writer.Write(buffer, 0, buffer.Length);
                            currentPartSize += buffer.Length;

                            if (currentPartSize >= partLen)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }


        private static void Asseble(List<string> files, string destinationDirectory)
        {

            if (destinationDirectory == String.Empty)
            {
                destinationDirectory = "./";
            }

            string assebled = $"{destinationDirectory}Assebled.mp4";

            using (var writer = new FileStream(assebled, FileMode.Create, FileAccess.Write))
            {
                var buffer = new byte[4096];

                foreach (var file in files)
                {
                    using (var reader = new GZipStream(new FileStream(file, FileMode.Open, FileAccess.Read), CompressionMode.Decompress))
                    {
                        while (reader.Read(buffer, 0, buffer.Length) == 4096)
                        {
                            writer.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }

    }
}
