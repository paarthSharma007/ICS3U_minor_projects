using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userSex;
            double userWeight;
            double userHeight;
            double userAge;
            double userBMI;
            double userBFP = 0;

            Console.WriteLine("Enter your sex :");
            Console.WriteLine("1) Male ");
            Console.WriteLine("2) Female");
            userSex = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your age(20-79) :");
            userAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your height (cm):");
            userHeight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter your weight (kg):");
            userWeight = Convert.ToDouble(Console.ReadLine());

            userBMI = (userWeight / userHeight*userHeight);
            
            if (userSex == 1)
            {
                userBFP = (1.20 * userBMI) + (0.23 * userAge) - 16.2;
            }
            else if (userSex == 2) 
            { 
                userBFP = (1.20 * userBMI) + (0.23 * userAge) - 5.4;
            }

            Console.Clear();
            Console.WriteLine("======================");
            Console.WriteLine("Your BMI is :" + userBMI);
            Console.WriteLine("Your BFP is :" + userBFP);
            Console.ReadLine();
        }
    }
}
