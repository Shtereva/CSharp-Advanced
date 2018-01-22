using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace Demo
{
    public class Program
    {
        public static void Main()
        {
            var list = new List<string[]>();
            var xlsPackage = new ExcelPackage();

            var worksheet = xlsPackage.Workbook.Worksheets.Add("Students");

            using (var reader = new StreamReader(@"D:\StudentData.txt"))
            {
                while (!reader.EndOfStream)
                {
                    list.Add(reader.ReadLine().Split('\t'));
                }
            }


            //worksheet.Cells[1, 1].Value = "ID";
            //worksheet.Cells[1, 2].Value = "First Name";
            //worksheet.Cells[1, 3].Value = "Last Name";
            //worksheet.Cells[1, 4].Value = "Email";
            //worksheet.Cells[1, 5].Value = "Gender";
            //worksheet.Cells[1, 6].Value = "Student Type";
            //worksheet.Cells[1, 7].Value = "Exam Result";
            //worksheet.Cells[1, 8].Value = "Homework sent";
            //worksheet.Cells[1, 9].Value = "Homework evaluated";
            //worksheet.Cells[1, 10].Value = "Teamwork score";
            //worksheet.Cells[1, 11].Value = "Attendances count";
            //worksheet.Cells[1, 12].Value = "Bonus";

            for (var i = 0; i < list.Count; i++)
            {
                int countCol = 0;

                foreach (var item in list[i])
                {
                    worksheet.Cells[1 + i, 1 + countCol].Value = item;
                    countCol++;
                }

            }

            var output = new FileStream("students.xlsx", FileMode.Create);
            xlsPackage.SaveAs(output);
        }
    }
}
