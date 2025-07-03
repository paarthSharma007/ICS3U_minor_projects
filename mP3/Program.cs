using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinorPortfolio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sLength = "5.9" ;
            string sWidth = "11.7" ;
            double convertedsLength;
            double convertedsWidth;
            double areaOfRectangle;

            convertedsLength = Convert.ToDouble(sLength);
            convertedsWidth = Convert.ToDouble(sWidth);
            areaOfRectangle = convertedsLength*convertedsWidth;
            
            Console.WriteLine("The area of rectangle is " + areaOfRectangle + "cm^2");
            
            Console.ReadLine() ;
        }
    }
}
