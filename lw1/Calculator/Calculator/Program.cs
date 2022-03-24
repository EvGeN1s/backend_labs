using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter command: ");
            string command = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter args: ");
            string calcualtedArgs = Console.ReadLine();

            double[] argsArr = new double[2];
            try
            {
                argsArr = parseArgs(calcualtedArgs);

            }
            catch (Exception)
            {
                Console.WriteLine("Invalid arguments");
            }

            try
            {
                double result = CalculatorApi.CalculatorApi.Calculate(command, argsArr);
                Console.WriteLine("Your result: " + String.Format("{0:F2}", result));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Command");
            }

        }

        private static double[] parseArgs(string args)
        {
            double[] result = new double[2];
            int iterator = 0;

            string argStr;
            int start = 0;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == ' ')
                {
                    argStr = args.Substring(start, i - start);
                    start = i + 1;

                    result[iterator] = Double.Parse(argStr);
                    iterator++;
                }

                if (i + 1 == args.Length)
                {
                    argStr = args.Substring(start, i + 1 - start);

                    result[iterator] = Double.Parse(argStr);
                }
            }

            return result;
        }
    }
}
