using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathOperations;

namespace CalciulatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Two integer values for possible operations add and divide");
            int a = Convert.ToInt32(Console.ReadLine());
            int b= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter operation add(a) \n subtract(s) \n multiply(m) \n divide(d) \n ans?");
            string op = Console.ReadLine();
            if (op == "a")
                Console.WriteLine(MathOp.add(a, b));
            else if (op == "d")
            {
                if (MathOp.divide(a, b) != null)
                {
                    Console.WriteLine(MathOp.divide(a, b));
                }


            }
            else if (op == "m")
            {
                Console.WriteLine(MathOp.multiply(a, b));
            }
            else if (op == "s")
            {
                Console.WriteLine(MathOp.subtract(a, b));
            }
            else
                Console.WriteLine("Not Valid!");

            Console.WriteLine("Press Enter to exit");
            Console.ReadKey(); 
        }

    }
}
