using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khenkina.Nsudotnet.NumberGuesser
{
    class Program
    {
        private const int MinNumber = 0;
        private const int MaxNumber = 100;
        public static String userName;
        static void Main(string[] args)
        {
            var random = new Random();
            userName = GameIO.ReadPlayerName();

            bool playAgain = true;
            while (playAgain)
            {
                int hiddenNumber = random.Next(MinNumber, MaxNumber);
                int attempts = 0;
                GameIO.WriteRules(MinNumber, MaxNumber);

                bool won = false;
                DateTime startTime = DateTime.Now;
                while (!won)
                {
                    int number = GameIO.ReadNumber();
                    attempts++;

                    if (number == hiddenNumber)
                    {
                        EndGame(attempts, DateTime.Now - startTime, ref playAgain);
                        won = true;
                    }
                    else
                    {
                        if (number < hiddenNumber)
                        {
                            NumberIsMore();
                        }
                        else
                        {
                            NumberIsLess();
                        }
                        if (attempts % 4 == 0) GameIO.WriteSwearing(random);
                    }
                }
            }

        }

        private static void NumberIsLess()
        {
            GameIO.WriteNumberIsLess();
        }

        private static void NumberIsMore()
        {
            GameIO.WriteNumberIsMore();
        }

        private static void EndGame(int attempts, TimeSpan playedTime, ref bool playAgain)
        {
            GameIO.WriteResult(attempts, playedTime);
            playAgain = GameIO.ReadYesNo();
        }
    }
}
