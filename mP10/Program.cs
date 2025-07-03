//Author: Paarth Sharma
//File Name: Program.cs
//Project Name: mP10
//Creation Date: november 3 2024
//Modification Date: november 3 2024
//Description: displaying time in minutes and seconds if input is given in seconds
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mP10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Retaining user input
            double userInt;

            //Retaining the values for time in minutes and seconds 
            double timeMin;
            double timeSec;

            //Formating 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("TIME IN MINUTES AND SECONDS");
            Console.WriteLine();

            //Taking input
            Console.Write("Enter time in seconds (from 1 to 500) : ");
            userInt = Convert.ToDouble(Console.ReadLine());
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("====================");

            //Coverting time to minutes and seconds after last minute 
            timeSec = ConvertSec(userInt);
            timeMin = ConvertMin(userInt);

            //Displaying the output
            Console.WriteLine("Time in minutes : "+ timeMin);
            Console.WriteLine("Time in seconds : "+ timeSec);

            //Formating
            Console.WriteLine("====================");

            Console.ReadLine();
        }

        //function for converting time to minutes
        private static double ConvertMin(double userInt)
        {
            double timeMin = 0;
            timeMin = Math.Floor(userInt / 60);
            return timeMin;
        }

        //function for converting time given to seconds after last minute
        private static double ConvertSec(double userInt)
        {
            double timeSec = 0;
            timeSec = userInt % 60;
            return timeSec;
        }
    }
}
