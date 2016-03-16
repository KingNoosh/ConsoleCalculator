using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Program m = new Program();
            m.runCore();
        }

        private void startMagic(bool bFailed = false)
        {
            double d;
            if (bFailed)
            {
                Console.WriteLine("I didn't understand that, I also only undestand the operands + - / * and numeral characters");
            }
            Console.WriteLine("Please type in your sum to calculate, e.g \"1+2\" or \"10*2\"\n");
            try
            {
                d = evaluateSum(Console.ReadLine());
                Console.WriteLine("Your answer is {0}\n", d);
            }
            catch (Exception)
            {
                startMagic(true);
            }
            restartChoice();
        }

        public void runCore()
        {
            Console.WriteLine("Welcome to a better calculator");
            startMagic();
        }

        private void restartChoice()
        {
            string str;
            Console.WriteLine("Do you want to calculate something else? (Y/n)");
            str = Console.ReadLine();
            if ((str == "") || (str == "Y") || (str == "y"))
            {
                startMagic();
            } else
            {
                Environment.Exit(0);
            }
        }

        private static double evaluateSum(string sum)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("sum", typeof(string), sum);
            DataRow row = tbl.NewRow();
            tbl.Rows.Add(row);
            return double.Parse((string)row["sum"]);
        }
    }
}
