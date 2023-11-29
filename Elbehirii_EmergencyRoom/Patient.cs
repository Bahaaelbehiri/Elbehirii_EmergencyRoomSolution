using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elbehirii_EmergencyRoom
{
    internal class Patient
    {

        private string lastName;
        private string firstName;
        private string birthday;
        private DateOnly DOB;
        public int priority; // smaller values are higher priority


        public Patient(string lastName, string firstName, string birthday, int priority) //, int priority
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.birthday = birthday;
            int[] test = { int.Parse(birthday.Split('/')[2]), int.Parse(birthday.Split('/')[0]), int.Parse(birthday.Split('/')[1]) };
            //[year, month, day]
            DOB = DateOnly.FromDateTime(Convert.ToDateTime(birthday));
            int age = DateOnly.FromDateTime(DateTime.Now).Year - DOB.Year;
            if (age < 21 || age > 65)
            {
                priority += 1;
            }
            this.priority = priority;

        }
        public Patient(int priority)
        {
            this.priority = priority;
        }
        public override string ToString()
        {
            //    return (lastName + firstName + " ," + birthday + priority);// toString LINE
            return " " + lastName + "," + firstName + "," + birthday + "," + priority.ToString() + " ";
        }
        public int CompareTo(Patient other)
        {
            if (this.priority < other.priority) return -1;
            else if (this.priority > other.priority) return 1;
            else return 0;
        }

    }
}
