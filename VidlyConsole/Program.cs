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
            var pattern = @"^(?<EntityId>[A-Za-z0-9_]+)_(?<Year>20\d{2})(?<Month>0[1-9]|1[012])(?<Day>0[1-9]|[12][0-9]|3[01])_00.dat.gz|(?<EntityId>[A-Za-z0-9_]+)_(?<Year>20\d{2})(?<Month>0[1-9]|1[012])(?<Day>0[1-9]|[12][0-9]|3[01])_00.dat.gz.md5$";
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(pattern);
            Console.WriteLine(r.IsMatch("925175_20181031_00.dat.gz"));
            Console.WriteLine(r.IsMatch("925175_20181031_00.dat.gz.md5"));
            Console.WriteLine(r.IsMatch("925175_20181031_00.dat.gz.metadata.txt"));

            var listFileItem1 = new List<FileItem>
            {
                new FileItem(){ name = "2018-11-01_match_OS.log.gz", fileDate = new DateTime(2018, 11, 1)},
 };
            var listFileItem2 = new List<FileItem>
            {    new FileItem(){ name = "2018-11-02_match_OS.log.gz", fileDate = new DateTime(2018, 11, 2)},
                new FileItem(){ name = "2018-11-02_match_OS.log.gz", fileDate = new DateTime(2018, 11, 2)},
 };
            var listFileItem3 = new List<FileItem>
            {
                new FileItem(){ name = "2018-11-03_match_OS.log.gz", fileDate = new DateTime(2018, 11, 3)},
                new FileItem(){ name = "2018-11-03_match_OS.log.gz", fileDate = new DateTime(2018, 11, 3)},
                new FileItem(){ name = "2018-11-03_match_OS.log.gz", fileDate = new DateTime(2018, 11, 3)},
                 };
            var listFileItem4 = new List<FileItem>
            {
                new FileItem(){ name = "2018-11-04_match_OS.log.gz", fileDate = new DateTime(2018, 11, 4)},
                new FileItem(){ name = "2018-11-04_match_OS.log.gz", fileDate = new DateTime(2018, 11, 4)},
                new FileItem(){ name = "2018-11-04_match_OS.log.gz", fileDate = new DateTime(2018, 11, 4)},
                new FileItem(){ name = "2018-11-04_match_OS.log.gz", fileDate = new DateTime(2018, 11, 4)},

            };

            Dictionary<string, List<FileItem>> d = new Dictionary<string, List<FileItem>>();
            d.Add("2018-11-01", listFileItem1);
            d.Add("2018-11-02", listFileItem2);
            d.Add("2018-11-03", listFileItem3);
            d.Add("2018-11-04", listFileItem4);


            var PendingDates = new List<string>
            {
               "2018-11-01",
               "2018-11-02",
               "2018-11-03"

            };

            var ProcessDates = listFileItem1.Concat(listFileItem2.Concat(listFileItem3.Concat(listFileItem4))).ToList();

            var d2 = ProcessDates.GroupBy(fileItems => fileItems.fileDate).
                ToDictionary(dic => dic.Key, file => file.ToList());


            //listFileLogItemDates.RemoveAll(date => allList.Any(l => l.name.Contains(date)));

            ProcessDates.RemoveAll(file => !PendingDates.Any(date => file.name.Contains(date)));

            Console.ReadLine();
        }
    }


    public class FileItem
    {
        public string name { get; set; }
        public DateTime fileDate { get; set; }


        public override string ToString()
        {
            return name.ToString(); 
        }
    }
}
