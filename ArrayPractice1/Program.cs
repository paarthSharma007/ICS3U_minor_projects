using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayPractice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] studentIDS = new int[10];
            studentIDS[0] = 100;

            double[] bankBalance = new double[5] ;
            bankBalance[0] = 1.35;
            bankBalance[1] = 1.35;
            bankBalance[2] = 1.35;
            bankBalance[3] = 1.35;
            bankBalance[4] = 1.35;

            string[] userNames = new string[3] ;
            Console.WriteLine("Enter first Username");
            userNames[0] = Console.ReadLine();
            Console.WriteLine("Enter second Username");
            userNames[1] = Console.ReadLine();
            Console.WriteLine("Enter third Username");
            userNames[2] = Console.ReadLine();
        }
    }
}
