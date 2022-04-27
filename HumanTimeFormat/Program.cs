using System;
using System.Linq;

namespace HumanTimeFormat
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int seconds = 1;
            int years = seconds / (365 * 24 * 60 * 60);
            int day = (seconds - years * 365 * 24 * 60 * 60) / (24 * 60 * 60);
            int hour = (seconds - years * 365 * 24 * 60 * 60 - day * 24 * 60 * 60) / (60 * 60);
            int minute = (seconds - years * 365 * 24 * 60 * 60 - day * 24 * 60 * 60 - hour * 60 * 60) / 60;
            seconds = seconds - years * 365 * 24 * 60 * 60 - day * 24 * 60 * 60 - hour * 60 * 60 - minute * 60;
            int[] timeArray = new int[] { years, day, hour, minute, seconds };
            string[] dateNameArray = new string[] { "year", "day", "hour", "minute", "second" };
            bool dontCommaAdd = true;
            string[] dateName = new string[5];
            int numberOfZero = timeArray.Where(x => x == 0).Count();
            string answer = "";
            if (numberOfZero == 5)
            {
                answer = "now";
            }


            for (int i = 0; i < 5; i++)
            {
                if (timeArray[i] != 0 && dontCommaAdd)
                {
                    dateName[i] = $"{timeArray[i]} {dateNameArray[i]}";
                    numberOfZero++;
                    dontCommaAdd = false;
                }
                else if (timeArray[i] != 0 && numberOfZero == 4)
                {
                    dateName[i] = $" and {timeArray[i]} {dateNameArray[i]}";
                }
                else if (timeArray[i] != 0 && numberOfZero < 4)
                {
                    dateName[i] = $", {timeArray[i]} {dateNameArray[i]}";
                    numberOfZero++;
                }

            }
            for (int i = 0; i < 5; i++)
            {
                if (timeArray[i] != 1 && timeArray[i] != 0)
                {
                    dateName[i] = String.Concat(dateName[i], "s");
                }
            }
           answer= string.Concat(dateName);
            Console.WriteLine(answer);
          




        }
    }
}
