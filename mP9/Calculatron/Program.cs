//AUthor : Paarth Sharma 
//File Name : Program.cs
//Project Name : Calculatron
//Creation Date : October 25th 2024
//Modification Date : October 25th 2024
//Description : calculator with capability of multiple operations on the same window 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatron
{
        internal class Program
        {
            static void Main(string[] args)
            {
                //creation of calculator states  
                string state;
                
                //creation of global result variable 
                double result = -999;
                
                //giveing user the context
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("CALCULATRON");
                Console.WriteLine("======================");

                //retaining menu option for game state 
                Console.ForegroundColor = ConsoleColor.Red;
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

                state = state.ToLower();

                //structure for 2 inputs or 1 input 
                if (state.Equals("a") || state.Equals("b") || state.Equals("c"))
                {
                    //creation of 2 local inputs 
                    double userInputNum1;
                    double userInputNum2;
                    
                    //retaining 2 inputs 
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.Write("Enter first number (between 15 and -15) :");
                    userInputNum1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter second number (between 15 and -15) :");
                    userInputNum2 = Convert.ToDouble(Console.ReadLine());
                
                    //structure for code of individual state
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
                    //creation of 1 local input 
                    double userInputNum1;

                    //retaining the 1 input 
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.Write("Enter a number (between 15 and -15) :");
                    userInputNum1 = Convert.ToDouble(Console.ReadLine());
                    
                    //structure for code of individual state
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

                else
                {
                    //printing for wrong input 
                    Console.WriteLine("Options should only be between a to e");
                }

                //displaying the result 
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                if(result != -999 ){
                Console.WriteLine("Your answer is :" + result);
                }
                
                Console.ReadLine();

            }
        }
}