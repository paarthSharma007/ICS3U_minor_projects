using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Use the Convert method to convert the following data to specified type
            string value1 = "15";     //to int <- Done for you as an example
            string value2 = "12.1";   //to double
            bool value3 = true;       //to string
            double value4 = 1.5;      //to bool
            double value1Converted;
            double value2Converted;
            string value3Converted;
            bool value4Converted;
            value1Converted = Convert.ToDouble(value1);
            value1Converted = (int)Convert.ToInt32(value1Converted);



            //Use the Cast method to convert the following data to the specified type
            byte value5 = 7;          //to double
            int value6 = 7;           //to byte
            double value7 = 1.6;      //to int

            //Use the TryParse method to convert the following data to the specified type
            bool isValid; //<- Do not convert, this is needed for each TryParse conversion
            string value8 = "37.3";  //to double
            string value9 = "15";    //to byte
            string value10 = "7.77";  //to int

            //Example: Convert value1 to an int (as requested)
            //Ex: 1. Create your variables to store the result of each conversion here
            int result1;


            //Ex: 2. Perform each conversion here
            result1 = Convert.ToInt32(value1);
            result2 = Convert.ToDouble(value2);
            result3= Convert.ToString(value3);
            result4 = Convert.ToBoolean(value4);


            //3. For EACH conversion display the following on a separate line 
            //PRO-TIP: All 5 lines below and just change the data as needed to speed up your work

            //A subtitle stating the conversion number you are on
            //Conversion goal in the format of: start type -> end Type, e.g. double -> int
            //The conversion method
            //The original value
            //The final value using the variable in the output
            //A blank line to separate it from the next output

            //Ex: Display final results of the value1 conversion
            Console.WriteLine("Conversion 1");
            Console.WriteLine("string -> int");
            Console.WriteLine("Conversion Method: Convert.To");
            Console.WriteLine("Original value: " + value1);
            Console.WriteLine("Final Value: " + result1);
            Console.WriteLine();



            //Keep the Console up to view the results
            Console.ReadLine();
        }
    }
}
