using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using 3 varibales method 
            double billWallet = 23.48 ;
            double tedWallet = 32.25 ;
            double sum;
            //before swap 
            Console.WriteLine("The wallets before swap for bill" + billWallet);
            Console.WriteLine("The wallets before swap for ted" + tedWallet);
            
            //swap using 3 variables
            sum = billWallet + tedWallet;
            tedWallet = sum - tedWallet;
            billWallet = sum - billWallet;
            
            //after swap 
            Console.WriteLine("The wallet after swap for bill" + billWallet);
            Console.WriteLine("The wallet after swao fir ted " + tedWallet);

            //using 2 varibales method 
            double ramWallet = 34.23;
            double samWallet = 92.83;

            //before swap 
            Console.WriteLine("The wallets before swap for ram" + ramWallet);
            Console.WriteLine("The wallets before swap for sam" + samWallet);

            //swap using 2 variables
            ramWallet = ramWallet + samWallet;
            samWallet = ramWallet - samWallet;
            ramWallet = ramWallet - samWallet;

            //after swap
            Console.WriteLine("The wallet after swap for ram" + ramWallet);
            Console.WriteLine("The wallet after swao fir sam " + samWallet);

            Console.ReadLine();
        }
    }
}
