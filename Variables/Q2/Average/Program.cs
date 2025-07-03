using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double average;
            int student1Marks = 72;
            int student2Marks = 98;
            int student3Marks = 95;
            int student4Marks = 43;
            int student5Marks = 97;
            int student6Marks = 85;
            int student7Marks = 57;
            int student8Marks = 70;
            int student9Marks = 68;
            int student10Marks = 87;
            int student11Marks = 60;
            int student12Marks = 48;
            average = (student1Marks + student2Marks + student3Marks + student4Marks + student5Marks + student6Marks + student7Marks + student8Marks + student9Marks + student10Marks + student11Marks + student12Marks) / (double)12;
            Convert.ToDecimal(average);
            Console.WriteLine(average);
            Console.ReadLine();
        }
    }
}
