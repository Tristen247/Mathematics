using Mathematics;
using System;

namespace MathematicsConsole
{
    class Program
    {

        // Declare static fields here
        private static double _num1;
        private static double _num2;
        private static string _operand;

        static void Main()
        {

            String[] args = Environment.GetCommandLineArgs();
            /*foreach(var a in args)
            {
                Console.WriteLine(a);
            }
            Console.ReadLine(); 
            */

            AreArgumentsValid(args);

            var math = new BasicMath();
            switch (_operand)
            {
                case "add":
                    Console.WriteLine($"{_num1} + {_num2} = {math.AddNumbers(_num1, _num2)}");
                    break;
                case "sub":
                    Console.WriteLine($"{_num1} - {_num2} = {math.SubtractNumbers(_num1, _num2)}");
                    break;
                case "mul":
                    Console.WriteLine($"{_num1} * {_num2} = {math.MultiplyNumbers(_num1, _num2)}");
                    break;
                case "div":
                    Console.WriteLine($"{_num1} / {_num2} = {math.DivideNumbers(_num1, _num2)}");
                    break;
                default:
                    Console.WriteLine($"{_operand} is not a valid operator. Please enter Add, Sub, Mul or Div");
                    break;
            }

            Console.ReadLine();

        }

        public static void AreArgumentsValid(string[] args)
        {
            _operand = args[1].ToLower();
            _num1 = NumParser(args[2]);
            _num2 = NumParser(args[3]);
            Console.WriteLine("All arguments are valid.");
            // Console.ReadLine();
        }

        public static double NumParser(string arg)
        {
            double number;
            if (Double.TryParse(arg, out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine($"Unable to parse {arg}.");
                Environment.Exit(99);
            }

            return 0;
        }


    }
}
