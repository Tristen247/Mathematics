using Mathematics;
using System;

namespace MathematicsConsole
{
    class Program
    {
        private static double _num1;
        private static double _num2;
        private static string? _operand;
        private static List<double>? _numbers;

        static void Main()
        {
            // Grab all command-line arguments
            string[] args = Environment.GetCommandLineArgs();

            //at least 2 arguments: [0] is the execution name name, [1] is operand.
            if (args.Length < 2)
            {
                Console.WriteLine("Not enough arguments provided.");
                Environment.Exit(99);
            }

            // We’ll store the operand here. such as "add", "sub", "mul", "div", "area", "average", "square", "pythagorean"
            _operand = args[1].ToLower();

            // Decide which parsing method to use.
            if (_operand == "add" || _operand == "sub" || _operand == "mul" || _operand == "div")
            {
                AreArgumentsValid(args);      // sets _num1, _num2
            }
            else
            {
                ValidArgumentDataType(args);  // populates _numbers
            }

            // Initiate math classes
            var math = new BasicMath();
            var advMath = new AdvMath();

            // handle each operand case
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

                case "area":
                    if (_numbers != null && ValidArgumentCount(_numbers.Count, 2))
                    {
                        Console.WriteLine($"Area = {AdvMath.CalculateArea(_numbers[0], _numbers[1])}.");
                    }
                    break;

                case "average":
                    if (_numbers != null && ValidArgumentCount(_numbers.Count, 2))
                    {
                        Console.WriteLine($"Average: The result is {AdvMath.CalculateAverage(_numbers)}.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough arguments.");
                        Environment.Exit(99);
                    }
                    break;

                case "square":
                    if (_numbers != null && ValidArgumentCount(_numbers.Count, 1))
                    {
                        Console.WriteLine($"Square: {AdvMath.SquareValue(_numbers[0])}.");
                    }
                    break;

                case "pythagorean":
                    if (_numbers != null && ValidArgumentCount(_numbers.Count, 2))
                    {
                        Console.WriteLine($"Pythagorean: {AdvMath.CalculatePythagorean(_numbers[0], _numbers[1])}.");
                    }
                    break;

                default:
                    Console.WriteLine($"{_operand} is not a valid operator. Please enter Add, Sub, Mul, Div, Area, Average, Square, or Pythagorean.");
                    break;
            }

            // Pause 
            Console.ReadLine();
        }
       
        /// Parses two numbers for basic operations. Exits if invalid.
        public static void AreArgumentsValid(string[] args)
        {
            //expects at least 4 total args: exe, operand, num1, num2
            if (args.Length < 4)
            {
                Console.WriteLine("Not enough arguments for a basic operation.");
                Environment.Exit(99);
            }

            _num1 = NumParser(args[2]);
            _num2 = NumParser(args[3]);
            Console.WriteLine("All arguments are valid for basic math.");
        }

        public static void ValidArgumentDataType(string[] args)
        {
            
            if (args.Length < 3)
            {
                Console.WriteLine("Not enough arguments for an advanced operation.");
                Environment.Exit(99);
            }

            _numbers = new List<double>();

            // Start from arg[2] 
            for (int i = 2; i < args.Length; i++)
            {
                double number = NumParser(args[i]);
                _numbers.Add(number);
            }

            Console.WriteLine($"Operand: {_operand}");
            Console.WriteLine($"Arguments: {string.Join(", ", _numbers)}");
        }

        /// Attempts to parse a string into a double; exits if it fails.
        public static double NumParser(string arg)
        {
            if (double.TryParse(arg, out double number))
            {
                return number;
            }
            else
            {
                Console.WriteLine($"Unable to parse '{arg}'.");
                Environment.Exit(99);

                return 0;
            }
        }

        /// Checks if the count of parsed arguments matches what we need.
        private static bool ValidArgumentCount(int argCount, int argsRequired)
        {
            if (argCount > argsRequired)
            {
                Console.WriteLine("Too many arguments.");
                Environment.Exit(99);
                return false;
            }
            else if (argCount < argsRequired)
            {
                Console.WriteLine("Not enough arguments.");
                Environment.Exit(99);
                return false;
            }

            return true;
        }
    }
}
