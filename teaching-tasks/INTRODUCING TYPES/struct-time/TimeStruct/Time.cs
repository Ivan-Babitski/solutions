#pragma warning disable CA1815

using System;
using System.Globalization;

namespace TimeStruct
{
    public struct Time
    {
        public Time(int minutes)
    : this(0, minutes)
        {
        }

        public Time(int hours, int minutes)
        {
            int tempHours = 0;

            if (minutes < 0)
            {
                tempHours = (minutes / 60) - 1;
            }
            else if (minutes > 0)
            {
                tempHours = (minutes / 60) + 1;
            }

            if (minutes < 0)
            {
                minutes = minutes - (tempHours * 60);
                if (minutes == 60)
                {
                    minutes = 0;
                    tempHours = -1;
                }

                hours += tempHours;
            }
            else if (minutes > 59)
            {
                tempHours = minutes / 60;
                minutes = minutes - (tempHours * 60);
                hours += tempHours;
            }

            if (hours < 0)
            {
                hours = hours - (((hours / 24) - 1) * 24);
            }
            else if (hours > 23)
            {
                hours = hours - ((hours / 24) * 24);
            }

            this.Hours = hours;
            this.Minutes = minutes;
        }

        public int Hours { get; private set; }

        public int Minutes { get; private set; }

        public new string ToString()
        {
            return $"{this.Hours.ToString("D" + "2", CultureInfo.InvariantCulture)}:{this.Minutes.ToString("D" + "2", CultureInfo.InvariantCulture)}";
        }

        public void Deconstruct(out int hours, out int minutes)
        {
            hours = this.Hours;
            minutes = this.Minutes;
        }
    }
}
