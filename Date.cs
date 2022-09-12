using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date
{
    internal class Date
    {
        private DateTime _date;
        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }

        private int _year;
        public int year
        {
            get { return _year; }
            set
            {
                if (value == -1)
                    _year = 1;
                else
                    _year = value;
            }
        }
        private int _month;
        public int month
        {
            get { return _month; }
            set
            {
                while (value > 12)
                {
                    year++;
                    value -= 12;
                }
                _month = value;

                if (value == -1)
                    _month = 1;
                if (value == 0 && year != 1)
                {
                    _month = 12;
                    year--;
                }
                else if (value == 0)
                {
                    _month = 1;
                }
            }
        }
        private int _day;
        public int day
        {
            get { return _day; }
            set
            {
                int max = dayOfMonth(month);
                while (value > max)
                {
                    month++;
                    value -= max;
                    max = dayOfMonth(month);
                }
                _day = value;

                if (value == -1)
                    _day = 1;

                if (value == 0 && year == 1 && month == 1)
                {
                    day = 1;
                }
                else if (value == 0)
                {
                    month--;
                    day = dayOfMonth(month);
                }
            }
        }

        private int dayOfMonth(int month)
        {
            int max = int.MaxValue;
            if (month == 2)
            {
                if (leapYear())
                    max = 29;
                else
                    max = 28;
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
                max = 30;
            else
                max = 31;
            return max;
        }

        public bool leapYear()
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }
            else
                return false;
        }

        public Date(int Day, int Month, int Year)
        {
            year = Year;
            month = Month;
            day = Day;
            date = new DateTime(year, month, day);
        }

        public void Print()
        {
            Console.WriteLine($"The {date.Day} of {(Month)date.Month} {date.Year}");
        }

        public Date Next()
        {
            return new Date(day + 1, month, year);
        }

        public Date Previous()
        {
            return new Date(day - 1, month, year);
        }

        public void PrintForward(int n)
        {
            var A = new Date(day, month, year);
            for (int i = 0; i < n; i++)
            {
                A = A.Next();
                A.Print();
            }
        }

        public void PrintBackward(int n)
        {
            var A = new Date(day, month, year);
            for (int i = 0; i < n; i++)
            {
                A = A.Previous();
                A.Print();
            }
        }
    }
}
enum Month
{
    January = 1,
    February,
    Marсh,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December,
}
