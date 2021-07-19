using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataHelper;

namespace ConsoleApp
{
    public static class SetOperations
    {
        public static void DistinctSyntax()
        {
            IEnumerable<int?> managerIds = DataSource.Employees.Select(e => e.Manager);

            /*
             * Select a list of the managerIds without repetition
             */

            IEnumerable<int?> uniqueManagerIds = managerIds.Distinct();

            Console.WriteLine("Unique manager Ids:");
            foreach (var mid in uniqueManagerIds)
            {
                Console.WriteLine(mid);
            }
        }

        public static void DistinctPropertyValues()
        {
            IEnumerable<Building> buildings = DataSource.Buildings;
            IEnumerable<string> categoryNamesRepeated = buildings.Select(b => b.Category);

            /*
             * Select all the category names without repetitions
             */

            IEnumerable<string> categoryNames = categoryNamesRepeated.Distinct();

            Console.WriteLine("Category names:");
            foreach (var n in categoryNames)
            {
                Console.WriteLine(n);
            }
        }

        public static void UnionSyntax()
        {
            IEnumerable<Building> buildings = DataSource.Buildings;
            IEnumerable<string> categories = DataSource.BuildingCategories.Select(c => c.Category);
            IEnumerable<string> categoryNamesFromProducts = buildings.Select(b => b.Category);

            /*
             * Select all category names from both the sequences, without repetition
             */

            IEnumerable<string> uniqueCategories = categories.Union(categoryNamesFromProducts).Distinct();

            Console.WriteLine("Unique categories from both lists:");
            foreach (var n in uniqueCategories)
            {
                Console.WriteLine(n);
            }
        }

        public static void IntersectSynxtax()
        {
            IEnumerable<Building> buildings = DataSource.Buildings;
            IEnumerable<string> categories = DataSource.BuildingCategories.Select(c => c.Category);
            IEnumerable<string> categoryNamesFromProducts = buildings.Select(b => b.Category);

            /*
             * Select the categories from both sequences, without repetition 
             */

            IEnumerable<string> commonCategories = categories.Intersect(categoryNamesFromProducts).Distinct();

            Console.WriteLine("Common categories shared by both lists:");
            foreach (var n in commonCategories)
            {
                Console.WriteLine(n);
            }
        }

        public static void DifferenceOfSets()
        {
            IEnumerable<Building> buildings = DataSource.Buildings;
            IEnumerable<string> categories = DataSource.BuildingCategories.Select(c => c.Category);
            IEnumerable<string> categoryNamesFromProducts = buildings.Select(b => b.Category);

            /*
             * Select all the categories appearing in the Categories table and not in the Buildings table
             */
            IEnumerable<string> CategoriesOnly = categories.Except(categoryNamesFromProducts);

            /*
             * Select all the categories appearing in the Buildings table and not in the Categories table
             */
            IEnumerable<string> buildingOnly = categoryNamesFromProducts.Except(CategoriesOnly);

            Console.WriteLine("Categories from Categories table not present in Buildings table:");
            foreach (var n in CategoriesOnly)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("Categories from Buildings table not present in Categories table:");
            foreach (var n in buildingOnly)
            {
                Console.WriteLine(n);
            }
        }
    }
}