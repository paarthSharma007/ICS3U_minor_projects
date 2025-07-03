using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CircleCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double area;
            double circumference;
            int radius = 3;
            area = Math.PI * radius * radius;
            circumference = 2 * Math.PI * radius;
            Console.WriteLine("The area of circle is " + area );
            Console.WriteLine("The circumference of circle is " + circumference );
            Console.ReadLine();
        }
    }
}
