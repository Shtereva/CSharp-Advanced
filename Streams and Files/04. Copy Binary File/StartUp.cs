using System;
using System.IO;

namespace _04._Copy_Binary_File
{
    public class StartUp
    {
        public static void Main()
        {
            using (var file = new FileStream(@"..\files\copyMe.png", FileMode.Open))
            {
                using (var copyFile = new FileStream(@"..\files\copyPicture.png", FileMode.Create))
                {
                    var buffer = new byte[4096];
                    int readData;

                    while ((readData = file.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        copyFile.Write(buffer, 0, readData);
                    }
                }
            }
        }
    }
}
