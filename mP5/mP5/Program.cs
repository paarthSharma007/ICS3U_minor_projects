using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mP5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declaration 
            byte userAge;
            double userWeight;
            double userHeight;

            double userBmi;
            double femaleBfp;
            double maleBfp;

            //starting 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("BMI Calculator");
            Console.WriteLine("---------------------------");

            //input
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.Write("Enter your age :");
            userAge= Convert.ToByte(Console.ReadLine());

            Console.Write("Enter your weight(kg) :");
            userWeight= Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter your height(m) :");
            userHeight= Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("---------------------------");
            Console.Clear();

            //storage and processing 
            userBmi = userWeight / Math.Pow(userHeight, 2) ;

            femaleBfp = (1.2 * userBmi) + (0.23 * userAge) - 5.4;
            maleBfp = (1.2 * userBmi) + (0.23 * userAge) - 16.2;

            //output
            Console.ForegroundColor =(ConsoleColor) ConsoleColor.Red;
            Console.WriteLine("---------------------------");
            Console.WriteLine("your age is :" + userAge);
            Console.WriteLine("your weight is :" + userWeight);
            Console.WriteLine("your height is :" + userHeight + "\n");

            Console.WriteLine("your BMI is :"+ Math.Round(userBmi,2));
            Console.WriteLine("if you are female your BFP is :" + Math.Round(femaleBfp,2));
            Console.WriteLine("if you are male your BFP is :" + Math.Round(maleBfp,2));

            Console.WriteLine("---------------------------");
            Console.ReadLine();
        }
    }
}
