using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataHelper;

namespace ConsoleApp {
    public static class Quantifiers {
        public static void AnyMatchingElements() {
            IEnumerable<string> words = DataHelper.DataSource.RoyalTitleWords;

            /*
             * Is there any word in the royal title of Prince Philip with an i after an e?
             */

            bool iAfterE = words.Any(w => w.Contains("ie"));

            Console.WriteLine($"There is at least a word in the list that contains 'ei': {iAfterE}");
        }

        public static void SickLeaveHoursLessThan21() {
            IEnumerable<Employee> employees = DataSource.Employees;
            //Are there any employees with less than 21 sick leave hours?

            bool areThere = employees.Any(e => e.SickLeaveHours < 21);
            Console.WriteLine("Are there any employees with less than 21 sick leave hours?: " +
            (areThere ? "Yes" : "No"));
        }

        public static void AllMatchedElements() {
            IEnumerable<Employee> employees = DataSource.Employees;

            /*
             * Discover if there are underage employees 
             */

            bool AllMoreThan18 = employees.All(e => calculateAge(e.BirthDate) > 18);

            Console.WriteLine($"All employees have age > 18: {AllMoreThan18}");
        }

        private static int calculateAge(DateTime dateOfBirth) {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age -= 1;

            return age;
        }
    }
}
