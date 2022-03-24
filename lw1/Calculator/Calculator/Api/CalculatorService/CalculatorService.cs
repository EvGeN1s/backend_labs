using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.CalculatorApi
{
    class CalculatorApi
    {
        public static double Calculate(string command, double[] args)
        {
            switch (command)
            {
                case "+":
                    return args[0] + args[1];
                case "-":
                    return args[0] - args[1];
                case "*":
                    return args[0] * args[1];
                case "/":
                    return args[0] / args[1];
                default:
                    throw new InvalidOperationException(command + " not found");
                    
            }               
        }
    }
}
