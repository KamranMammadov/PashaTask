using System;
using System.Collections.Generic;
using System.Text;

namespace PashaTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set UTF8 for Azerbaijani letters
            Console.OutputEncoding = Encoding.UTF8;

            //Get list of months for showhing client
            var months = GetListofMonths();
            Console.WriteLine("Zəhmət olmasa hədəf qoyulan ayı rəqəmlə seçin");
            for (int i = 1; i <= months.Count; i++)
            {
                Console.WriteLine($"{i}. {months[i - 1]}");
            }


            //Check is valid month index
            bool IsValidMonth(int x) => x is <= 0 or > 12;


            //Get month from client
            int indexOfMonth = 0;
            decimal totalTarget = 0;

            Console.Write("Ay seçin ->    ");
            indexOfMonth = int.Parse(Console.ReadLine());

            if (IsValidMonth(indexOfMonth))
            {
                Console.WriteLine("Ay seçimi düzgün deyil!");
            }
            else
            {
                //Get total target from client
                Console.Write("Hədəf məbləğ ->    ");
                totalTarget = decimal.Parse(Console.ReadLine());

                //Get quarters amounts
                var quarters = GetQuarterylyTargets(indexOfMonth, totalTarget);

                //Show client
                for (int i = 1; i <= quarters.Length; i++)
                {
                    Console.WriteLine($"{i} rüb {quarters[i - 1].ToString()}");
                }
            }

        }

        public static decimal[] GetQuarterylyTargets(int MonthIndex, decimal TotalTarget)
        {
            decimal[] Quarters = { 0, 0, 0, 0 };

            //Hədəf rüblərə rübdə qalan ay nisbətində bölünəcək
            var remainingMonths = 12 - MonthIndex;


            switch (MonthIndex)
            {
                case <= 3:
                    Quarters[0] = (3 - MonthIndex) * (TotalTarget / remainingMonths);
                    Quarters[1] = 3 * (TotalTarget / remainingMonths);
                    Quarters[2] = Quarters[1];
                    Quarters[3] = Quarters[1];
                    break;
                case <= 6:
                    Quarters[0] = 0;
                    Quarters[1] = (6 - MonthIndex) * (TotalTarget / remainingMonths);
                    Quarters[2] = 3 * (TotalTarget / remainingMonths);
                    Quarters[3] = Quarters[2];
                    break;
                case <= 9:
                    Quarters[0] = 0;
                    Quarters[1] = 0;
                    Quarters[2] = (9 - MonthIndex) * (TotalTarget / remainingMonths);
                    Quarters[3] = 3 * (TotalTarget / remainingMonths);
                    break;
                case < 12:
                    Quarters[0] = 0;
                    Quarters[1] = 0;
                    Quarters[2] = 0;
                    Quarters[3] = (12 - MonthIndex) * (TotalTarget / remainingMonths);
                    break;
                default:
                    Quarters[0] = (TotalTarget * 3) / 12;
                    Quarters[1] = Quarters[0];
                    Quarters[2] = Quarters[0];
                    Quarters[3] = Quarters[0];
                    break;
            }
            return Quarters;
        }

        public static List<string> GetListofMonths()
        {
            List<string> monhts = new List<string>()
            {
               "Yanvar",
               "Fevral",
               "Mart",
               "Aprel",
               "May",
               "Iyun",
               "Iyul",
               "Avqust",
               "Sentyabr",
               "Oktyabr",
               "Noyabr",
               "Dekabr"
            };
            return monhts;
        }
    }
}
