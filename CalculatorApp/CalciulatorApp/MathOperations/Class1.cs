using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations
{
    public static  class MathOp
    {
        public static int add(int a, int b)
        {
            return a + b;
        }
        public static int? divide(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("invalid : divide can't take 0 as divisor");
                return null;
            }

            return a / b;

        }
        public static int multiply(int a, int b)
        {
            return a * b;
        }
        public static int subtract(int a, int b)
        {
            return a - b;
        }

    }
}
