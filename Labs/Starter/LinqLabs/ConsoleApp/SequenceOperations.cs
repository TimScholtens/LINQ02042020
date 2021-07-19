using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataHelper;

namespace ConsoleApp
{
    public static class SequenceOperations
    {
        public static void EqualSequence()
        {
            IEnumerable<string> categoriesA = DataSource.BuildingCategories.Select(c => c.Category).OrderBy(c => c);
            IEnumerable<string> categoriesB = DataSource.Buildings.Select(c => c.Category).Distinct().OrderBy(c => c);

            //are the categories in the BuildingCategories table equal to the categories in the buildings table?

            bool match = categoriesA.SequenceEqual(categoriesB);

            Console.WriteLine($"The sequences match: {match}");
        }

        public static void ConcatProjection()
        {
            IEnumerable<int> firstRolls = from p in DataSource.DicePlayers
                from d in p.DiceRolls
                select d.Item1;

            IEnumerable<int> secondRolls = from p in DataSource.DicePlayers
                from d in p.DiceRolls
                select d.Item2;

            // select a collection with all the item1 followed by all the item2 from the dice rolls

            IEnumerable<int> allRolls = firstRolls.Concat(secondRolls);

            Console.WriteLine("All rolls from both dices:");
            foreach (var n in allRolls)
            {
                Console.WriteLine(n);
            }
        }
    }
}