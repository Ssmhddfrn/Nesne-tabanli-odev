using System;

namespace OddEvenApp
{
    enum InputType
    {
        Exit,
        Number,
        Invalid
    }

    class InputReader
    {
        public InputType Read(out long number)
        {
            number = 0;

            Console.Write("Enter a number, or n/N to exit: ");
            string input = (Console.ReadLine() ?? "").Trim();

            if (input.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                return InputType.Exit;
            }

            if (long.TryParse(input, out number))
            {
                return InputType.Number;
            }

            return InputType.Invalid;
        }
    }

    class OddEvenChecker
    {
        public bool IsEven(long number)
        {
            return number % 2 == 0;
        }

        public string ResultText(long number)
        {
            return IsEven(number)
                ? $"{number} is an even number."
                : $"{number} is an odd number.";
        }
    }

    class Application
    {
        private readonly InputReader _reader = new InputReader();
        private readonly OddEvenChecker _checker = new OddEvenChecker();

        public void Run()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                InputType type = _reader.Read(out long number);

                switch (type)
                {
                    case InputType.Exit:
                        Console.WriteLine("Program terminated.");
                        keepRunning = false;
                        break;

                    case InputType.Number:
                        Console.WriteLine(_checker.ResultText(number));
                        break;

                    default:
                        Console.WriteLine("Invalid input, enter a number or n/N.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Application application = new Application();
            application.Run();
        }
    }
}
