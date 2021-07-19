using DataHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp {
    public static class ElementOperations {
        
        public static void FirstElement() {
            IEnumerable<Building> buildings = DataSource.Buildings.Where(p => p.Price < 439_000M);

            /*
             * Select only the first element from the buildings whose price is less than 439.000
             */

            Building product = buildings.First(p => p.Price < 439_000M);

            Console.WriteLine(product);
        }

        public static void FirstMatchingElement() {
            IEnumerable<Building> buildings = DataSource.Buildings;
            
            /*
             * Select the first building of the "Storage Area" category
             */

            Building building = buildings.First(b => b.Category == "Storage area");

            Console.WriteLine($"First Storage Area Building: {building}");

        }

        public static void MaybeFirstElement() {
            IEnumerable<Building> buildings = DataSource.Buildings.Where(b => b.Price < 10_000M);

            /*
             * Select the first building whose price is less than 10_000M.
             * Should there be no building matching this criteria, select null instead
             */

            Building building = buildings.FirstOrDefault(b => b.Price < 10_000M);

            Console.WriteLine(building);
        }

        public static void MaybeFirstMatchingElement() {
            IEnumerable<Building> buildings = DataSource.Buildings;
            /*
             * Select the first building whose price is less than 10_000M.
             * Should there be no building matching this criteria, select null instead
             */

            Building building = buildings.FirstOrDefault(b => b.Price <= 10_000M);

            Console.WriteLine(building);
        }

        public static void ElementAtPosition() {
            IEnumerable<string> titles = DataSource.RoyalTitleTitles;
            /*
             * Extract the 6th title of Prince Philip
             */

            string title = titles.ElementAt(5);

            Console.WriteLine($"The 6th title is: {title}");
        }
    }
}
