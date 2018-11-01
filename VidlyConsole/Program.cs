using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VidlyConsole
{
    public class Program
    {
        static void Main(string[] args)
        {

            var listFileItem = new List<FileItem>
            {
                new FileItem(){ name = "FileItem1 ", fileDate = DateTime.Today},
                new FileItem(){ name = "FileItem2", fileDate = DateTime.Today.AddDays(1)},
                new FileItem(){ name = "FileItem3", fileDate = DateTime.Today.AddDays(1)},
                new FileItem(){ name = "FileItem4", fileDate = DateTime.Today.AddDays(2)},
                new FileItem(){ name = "FileItem5", fileDate = DateTime.Today.AddDays(2)},
                new FileItem(){ name = "FileItem6", fileDate = DateTime.Today.AddDays(2)},
                new FileItem(){ name = "FileItem6", fileDate = DateTime.Today.AddDays(4)},
                new FileItem(){ name = "FileItem6", fileDate = DateTime.Today.AddDays(4)},
                
                new FileItem(){ name = "FileItem1_match_tables.done", fileDate = DateTime.Today},
                new FileItem(){ name = "FileItem3_match_tables.done", fileDate = DateTime.Today.AddDays(1)},
                new FileItem(){ name = "FileItem4_match_tables.done", fileDate = DateTime.Today.AddDays(2)},
                new FileItem(){ name = "FileItem6_match_tables.done", fileDate = DateTime.Today.AddDays(4)}
            };

            var listFileLogItemDates = new List<string>
            {
                { DateTime.Today.ToShortDateString() },
                { DateTime.Today.AddDays(1).ToShortDateString()},
                { DateTime.Today.AddDays(1).ToShortDateString()},
                { DateTime.Today.AddDays(2).ToShortDateString()},
                { DateTime.Today.AddDays(2).ToShortDateString()},
                { DateTime.Today.AddDays(2).ToShortDateString()},
                { DateTime.Today.AddDays(3).ToShortDateString()}
            };



            var data =
            listFileItem.
            Where(f => f.name.Contains("_match_tables.done")).
            GroupBy(fileItems => fileItems.fileDate).
            ToDictionary(dictionaryFileItem => dictionaryFileItem.Key.ToShortDateString(), fileItem => fileItem.ToList());

            var data2 =
             listFileItem.
             GroupBy(fileItems => fileItems.fileDate).
             ToDictionary(dictionaryFileItem => dictionaryFileItem.Key.ToShortDateString(), fileItem => fileItem.ToList());
            
            var data3 = data.Keys.Intersect(data2.Keys);


            var data4 = data.
                Where(d => !listFileLogItemDates.Any(l => l == d.Key)).ToDictionary(d => d.Key, d => d.Value);


            foreach (var item in data2)
            {
                Console.WriteLine(item.Key);

                foreach (var item2 in item.Value)
                {
                    Console.WriteLine(item2.name);
                    Console.WriteLine(item2.fileDate);
                }
            }
        
            Console.ReadLine();
        }
    }


    public class FileItem
    {
        public string name { get; set; }
        public DateTime fileDate { get; set; }
    }
}
