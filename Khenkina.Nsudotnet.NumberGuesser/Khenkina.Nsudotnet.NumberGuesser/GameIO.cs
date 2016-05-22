using System;

namespace Khenkina.Nsudotnet.NumberGuesser
{
    class GameIO
    {
        private static readonly string[] OATH =
        {
         
                    "BYSTREE, %NAME!",
                    " ESCHO BYSTREE, %NAME?",
                    "%NAME, TORMOZ!"
        };

        public static void WriteResult(int attempts, TimeSpan playedTime)
        {
            Console.WriteLine("DONE {0} ITER ( {1}). PLAY MORE?",attempts,playedTime);
            // Console.WriteLine($"Хорош, отгадал за {attempts} попыток (за {playedTime}). Ещё будешь играть?");
        }

        public static void WriteNumberIsMore()
        {
            Console.WriteLine("MORE");
        }

        public static void WriteNumberIsLess()
        {
            Console.WriteLine("LESS");
        }

        public static void WriteRules(int minNumber, int maxNumber)
        {
            Console.WriteLine(" Guess the number ({0}-{1}).",minNumber,maxNumber);
        }

        public static string ReadPlayerName()
        {
            WriteInputNameMessage();
            return Console.ReadLine();
        }

        private static void WriteInputNameMessage()
        {
            Console.Write("NAME:");
        }

        public static void WriteSwearing(String userName, Random random)
        {
            Console.WriteLine(OATH[random.Next(0, OATH.Length)].Replace("%NAME", userName));
        }

        public static bool ReadYesNo()
        {
            for (; ; )
            {
                WriteInputMessage("y/n");
                var input = Console.ReadLine().ToLower();
                if (input.Equals("y"))
                {
                    return true;
                }
                else if (input.Equals("n"))
                {
                    return false;
                }
                else
                {
                    WriteInputError();
                }
            }
        }

        private static void WriteInputError()
        {
            Console.WriteLine("Invalid input. Try again.");
        }

        private static void WriteInputMessage(String options = "")
        {
            Console.Write("INPUT");
            if (options != "")
            {
                Console.Write("({0})", options);
            }
            Console.Write(": ");
        }

        public static int ReadNumber()
        {
            int result = 0;
            bool correctInput = false;
            while (!correctInput)
            {
                WriteInputMessage();
                try
                {
                    result = int.Parse(Console.ReadLine());
                    correctInput = true;
                }
                catch (Exception e)
                {
                    WriteInputError();
                }
            }
            return result;
        }
    }
}