using DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp {
    class Program {
        static void Main(string[] args) {
            // LeftJoin.CrossGroupJoin();
            // Generators.RangeOfIntegers();
            // Generators.RepeatEnemy();
            // AggregateOperators.CountSyntax();
            // AggregateOperators.CountConditional();
            // AggregateOperators.SickLeaveHours();
            // AggregateOperators.SumSyntax();
            
            Console.ReadLine();
        }


        

        static void GroupBy_ManagersEmployees() {
            var employees = DataHelper.DataSource.Employees;

            var q1 = from e in employees
                     join m in employees
                     on e.Manager equals m.ID //this excludes the boss, since he has no manager
                     orderby e.Manager
                     group new { Employee = e, Manager = m }  by m ;

            Console.WriteLine("*******************Manager and employees****************");
            foreach (var group in q1) {
                Console.WriteLine($"Manager: {group.Key?.Name ?? "SELF EMPLOYED"}");
                foreach (var e in group) {
                    Console.WriteLine($"\t{e.Employee.Name}");
                }
            }
        }

        static void RecursiveManagers() {
            var employees = DataHelper.DataSource.Employees;
            
            var lookup = employees.ToLookup(x => x.Manager);
            var res = lookup[null].SelectRecursive(x => lookup[x.ID]).ToList();

            foreach (var item in res) {
                Console.WriteLine($"{item.Name} - {item.Manager}"); 
            }
        }
        static void OMG() {
            var vendors = DataHelper.DataSource.Vendors;
            var products = DataHelper.DataSource.Products;
            var productVendors = DataHelper.DataSource.ProductVendors;

            Console.WriteLine("*****STEP 1: ALL PRODUCTS, GROUPED BY Product ID**************");
            var q1 = from pv in productVendors
                     group pv by pv.ProductID;

            foreach (var group in q1) {
                Console.WriteLine(group.Key);
                foreach (var item in group) {
                    Console.WriteLine(item);
                }
            }


            Console.WriteLine("*****STEP 2: PRODUCT NEXT TO MINIMUM PRICES**************");
            var q2 = from pv in productVendors
                     group pv by pv.ProductID
                     into allOffers
                     select new {
                         PID = allOffers.Key,
                         Offers = from offer in allOffers
                                  where offer.Price == allOffers.Min(p => p.Price)
                                  select offer
                     };


            foreach (var item in q2) {
                Console.WriteLine(item.PID);
                foreach (var pv in item.Offers) {
                    Console.WriteLine($"\t{pv}");
                }
            }


            Console.WriteLine("*****STEP 3: PRODUCT NAME NEXT TO MINIMUM PRICES**************");
            var q3 = from pv in productVendors
                     join p in products
                     on pv.ProductID equals p.ID
                     group pv by p
                     into allOffers
                     select new {
                         Product = allOffers.Key,
                         Offers = from offer in allOffers
                                              where offer.Price == allOffers.Min(p => p.Price)
                                              select offer
                     };


            foreach (var item in q3) {
                Console.WriteLine(item.Product);
                foreach (var pv in item.Offers) {
                    Console.WriteLine($"\t{pv}");
                }
            }

            Console.WriteLine("*****STEP 4: PRODUCT NAME NEXT TO MINIMUM PRICES AND VENDOR NAMES**************");
            var q4 = from pv in productVendors
                     join p in products
                     on pv.ProductID equals p.ID
                     group pv by p
                     into allOffers
                     select new {
                         Product = allOffers.Key,
                         VendorsWithPrices = from offer in allOffers
                                             join v in vendors
                                             on offer.VendorID equals v.ID
                                             where offer.Price == allOffers.Min(p => p.Price)
                                             select new { Vendor = v, offer.Price }
                     };


            foreach (var item in q4) {
                Console.WriteLine(item.Product);
                foreach (var pv in item.VendorsWithPrices) {
                    Console.WriteLine($"\t{pv}");
                }
            }


            Console.WriteLine("*****STEP 5: FLATTEN IT OUT**************");
            var q5 = from p in q4
                     from pv in p.VendorsWithPrices
                     select new { p.Product, pv.Vendor, pv.Price };

            foreach (var item in q5) {
                Console.WriteLine($"{item.Product} - {item.Vendor} - {item.Price}");
            }

        }
    }



}
