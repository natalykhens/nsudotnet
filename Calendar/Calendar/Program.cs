using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class Program
    {
        private const int LastDay = 6;
        private const int FirstDay = 0;

        static void Main(string[] args)
        {            
            DateTime date = ReadDate();
            DisplayCalendar(date);
            Console.ReadKey();
        }

        private static void DisplayCalendar(DateTime date)
        {
            WriteCalendarTitle(date);
            WriteCalendarDays();

            DateTime firstDayInMonth = date.AddDays(- (date.Day - 1));
            int dayPosition = firstDayInMonth.DayOfWeek == DayOfWeek.Sunday ? LastDay : (int)firstDayInMonth.DayOfWeek - 1; // conversion DayOfWeek(Enum) to int given that the start of the week = Monday (not Sunday)            
            int workingDays = 0;
            var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

            FillLineWithTabs(dayPosition);
            for (int day = 1; day <= daysInMonth; day++)
            {                
                SetupConsoleColor(date, day);
                Console.Write(day);                
                ResetConsoleColor();
                                
                CountWorkingDays(dayPosition, ref workingDays);

                bool writeNewLine = false;
                ChangeDayPosition(day, daysInMonth, ref dayPosition, ref writeNewLine);
                WriteOffset(writeNewLine);
            }            

            WriteWorkingDaysInfo(workingDays);
        }

        private static void WriteWorkingDaysInfo(int workingDays)
        {
            Console.WriteLine("There are {0} working days in this month.", workingDays);
        }

        private static void WriteOffset(bool writeNewLine)
        {
            if (writeNewLine)
            {
                Console.WriteLine();
            }
            else
            {
                Console.Write("\t");
            }
        }

        private static void ChangeDayPosition(int day, int daysInMonth, ref int dayPosition, ref bool writeNewLine)
        {
            dayPosition++;
            if (dayPosition == LastDay + 1 || day == daysInMonth)
            {
                dayPosition = FirstDay;
                writeNewLine = true;
            }
            else
            {
                writeNewLine = false;
            }
        }

        private static void SetupConsoleColor(DateTime date, int day)
        {
            if (DayIsEnteredDay(date, day))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            if (DayIsToday(date, day))
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
            }
        }

        private static bool DayIsEnteredDay(DateTime date, int day)
        {
            return day == date.Day;
        }

        private static void CountWorkingDays(int dayPosition, ref int workingDays)
        {
            if (dayPosition != LastDay - 1 && dayPosition != LastDay)
            {
                workingDays++;
            }
        }

        private static bool DayIsToday(DateTime date, int day)
        {
            return 
                day == DateTime.Today.Day && 
                DateTime.Today.Month == date.Month && 
                DateTime.Today.Year == date.Year;
        }

        private static void ResetConsoleColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void FillLineWithTabs(int position)
        {
            for (int i = 0; i < position; i++)
            {
                Console.Write("\t");
            }
        }

        private static void WriteCalendarTitle(DateTime date)
        {
            Console.WriteLine("Calendar (on {0}):", date);
        }

        private static void WriteCalendarDays()
        {
            Console.Write("Mon\tTue\tWed\tThu\tFri\t");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sat\tSun");
            ResetConsoleColor();
        }

        private static DateTime ReadDate()
        {            
            DateTime date = DateTime.Today;
            bool validInput = false;
            while (!validInput)
            {
                WriteDateInputOffer();
                String input = Console.ReadLine();
                if (DateTime.TryParse(input, out date))
                {
                    validInput = true;
                }
                else
                {
                    WriteInputError();
                }
            }
            return date;
        }

        private static void WriteDateInputOffer()
        {
            Console.Write("Input date mm dd : ");
        }

        private static void WriteInputError()
        {
            Console.WriteLine("ERROR!");
        }
    }
}
