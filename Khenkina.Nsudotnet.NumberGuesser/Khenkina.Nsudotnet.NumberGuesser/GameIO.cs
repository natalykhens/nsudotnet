using System;

namespace Khenkina.Nsudotnet.NumberGuesser
{
    class GameIO
    {
        static string[] OATH = new String[4] { "{0}, BYSTREE \n",
                                               "{0}, ESCHO BYSTREE \n",
                                               "FAIL, {0}\n", 
                                               "{0},TORMOZ!\n"};


        public static void WriteResult(int attempts, TimeSpan playedTime)
        {
            Console.WriteLine("DONE {0} ITER ( {1}). PLAY MORE?",attempts,playedTime);
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
            Console.WriteLine(String.Format("{0},TORMOZ!\n", Program.userName));
            Console.WriteLine(" name {0}", Program.userName);
            Console.WriteLine(" Guess the number ({0}-{1}).",minNumber,maxNumber);
        }

        public static string ReadPlayerName()
        {
            WriteInputNameMessage();
            String userName = Console.ReadLine();
            return userName;
        }

        private static void WriteInputNameMessage()
        {
            Console.Write("NAME:");
        }

        public static void WriteSwearing( Random random)
        {
            int n = random.Next(0,3);
            Console.WriteLine(String.Format(OATH[n], Program.userName));
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
                String res = Console.ReadLine();
                if (!int.TryParse(res, out result))
                {
                    WriteInputError();
                } 
                else
                {
                    correctInput = true;
                }
            }
            return result;
        }
    }
}