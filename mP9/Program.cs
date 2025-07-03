//Author : Paarth Sharma 
//File Name : Program.cs
//Project Name : calculatron
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mP9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string state;
            double result = 0;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("CALCULATRON");
            Console.WriteLine("======================");
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Enter a Menu Option");
            Console.WriteLine("1) add");
            Console.WriteLine("2) subtract");
            Console.WriteLine("3) multiply");
            Console.WriteLine("4) absolute value");
            Console.WriteLine("5) round up");
            Console.WriteLine();
            Console.Write("Choice : ");
            state = Console.ReadLine();

            if ( state.Equals("a") || state.Equals("b") || state.Equals("c"))
            {
                double userInputNum1;
                double userInputNum2;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.Write("Enter first number :");
                userInputNum1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter second number :");
                userInputNum2 = Convert.ToDouble(Console.ReadLine());

                switch (state)
                {
                    case "a":
                        //add
                        result = userInputNum1 + userInputNum2;
                        break;
                    case "b":
                        //subtract
                        result = userInputNum1 - userInputNum2;
                        break;
                    case "c":
                        //multiply
                        result = userInputNum1 * userInputNum2;
                        break;
                }
            }
            else if (state.Equals("d") || state.Equals("e"))
            {
                double userInputNum1;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.Write("Enter a number :");
                userInputNum1 = Convert.ToDouble(Console.ReadLine());
               
                switch (state)
                {
                    case "d":
                        //absolute value 
                        result = Math.Abs(userInputNum1);
                        break;
                    case "e":
                        //round up 
                        result = Math.Ceiling(userInputNum1);
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Your answer is :" + result);

            Console.ReadLine();

        }
    }
}
