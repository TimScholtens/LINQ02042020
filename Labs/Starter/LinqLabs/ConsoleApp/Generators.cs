using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    public static class Generators
    {
        public static void RangeOfIntegers()
        {
            /*
             * Select the odd numbers between 50 (included) and 100 (excluded)
             */

            IEnumerable<int> numbersBetween50And100 = Enumerable.Range(50, 50);

            IEnumerable<int> numbers =
                from n in numbersBetween50And100
                where n % 2 == 1
                select n;

            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
        }

        public static void RepeatEnemy()
        {
            /*
             * Spawn three enemies with 100 healthpoints each to start attacking them
             */

            IEnumerable<Enemy> enemies = Enumerable.Repeat(new Enemy() {HealthPoints = 100}, 3);
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                foreach (var enemy in enemies)
                {
                    enemy.Fight(random.Next(30, 50));
                }
            }
        }
    }
}