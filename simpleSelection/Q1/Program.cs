using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    internal class Program
    {
        static int CONSENT_AGE = 18 ;
        static void Main(string[] args)
        {
            int age ; 
            Console.WriteLine("Eligibility checker ");
            Console.Write("Enter your age :");
            age = Convert.ToInt32(Console.ReadLine());

            if (age >= CONSENT_AGE)
            {
                Console.WriteLine("you are eligible to vote");
            }
            else
            {
                Console.WriteLine("you are not eligible to vote ");
            }

            Console.ReadLine();
        }
    }
}
