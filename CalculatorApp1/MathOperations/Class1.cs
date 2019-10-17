using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations
{
    public interface MathOpInterface
    {
        int add(int a, int b);
        int? divide(int a, int b);
        int multiply(int a, int b);
        int subtract(int a, int b);

    
    }
    public class MathOp:MathOpInterface
    {
        public int add(int a, int b)
        {
            return a + b;
        }
        public int? divide(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("invalid : divide can't take 0 as divisor");
                return null;
            }

            return a / b;

        }
        public int multiply(int a, int b)
        {
            return a * b;
        }
        public int subtract(int a, int b)
        {
            return a - b;
        }

    }
}
