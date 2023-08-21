using System;
using System.Collections.Generic;
using System.Linq;
using Linq.DataSources;

namespace Linq
{
    /// <summary>
    /// Considers the use aggregate operations (methods 'Min', 'Max', 'Count', 'Sum', 'Average', and `Aggregate`) in LINQ queries.
    /// Aggregation operation definition:
    /// <see cref="IEnumerable{TSource}"/> → scalar.
    /// An aggregation operation computes a single value from a collection of values.
    /// </summary>
    public static class AggregationOperations
    {
        /// <summary>
        /// Calculates the count of elements in sequence.
        /// </summary>
        /// <returns>Count of elements in sequence.</returns>
        public static int CountNumbers()
        {
            int[] numbers = { 2, 2, 3, 5, 5 };

            int distinctCount = numbers.Length;

            return distinctCount;
        }

        /// <summary>
        /// Calculates the number of odd numbers in the array.
        /// </summary>
        /// <returns>Count of of odd numbers in the array.</returns>
        public static int CountOddNumbers()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            return numbers.Count(n => n % 2 != 0);
        }

        /// <summary>
        /// Calculates for each customer count of his orders.
        /// </summary>
        /// <returns>The sequence of customers and how many orders each has.</returns>
        public static IEnumerable<(string customerId, int orderCount)> CustomersOrdersCount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Defines a sequence of categories and how many products each has.
        /// </summary>
        /// <returns>The sequence of categories and how many products each has.</returns>
        public static IEnumerable<(string category, int productCount)> ProductsInCategoryCount()
        {
            List<Product> products = Products.ProductList;

            var result = products
                .GroupBy(product => product.Category)
                .Select(group => (
                    category: group.Key,
                    productCount: group.Count()));

            return result;
        }

        /// <summary>
        /// Calculates the sum of the numbers in an array.
        /// </summary>
        /// <returns>Sum of elements of numbers.</returns>
        public static int Sum()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            return numbers.Sum();
        }

        /// <summary>
        /// Calculates the total number of characters of all words in the array.
        /// </summary>
        /// <returns>The total number of characters of all words in the array.</returns>
        public static int SumByLength()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            int totalLength = words.Sum(word => word.Length);

            return totalLength;
        }

        /// <summary>
        /// Calculates the total units in stock for each product category.
        /// </summary>
        /// <returns>The total units in stock for each product category.</returns>
        public static IEnumerable<(string category, int totalUnitsInStock)> TotalUnitsInStock()
        {
            List<Product> products = Products.ProductList;

            var result = products
                .GroupBy(product => product.Category)
                .Select(group => (
                    category: group.Key,
                    totalUnitsInStock: group.Sum(product => product.UnitsInStock)));

            return result;
        }

        /// <summary>
        /// Calculates the lowest number in an array.
        /// </summary>
        /// <returns>The lowest number in an array.</returns>
        public static int Min()
        {
            // ReSharper disable once UnusedVariable
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            return numbers.Min();
        }

        public static int MinByLength()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            int minLength = words.Min(word => word.Length);

            return minLength;
        }

        /// <summary>
        /// Calculates the cheapest price among each category's products.
        /// </summary>
        /// <returns>The cheapest price among each category's products.</returns>
#pragma warning disable CA1024
        public static IEnumerable<(string category, decimal cheapestPrice)> GetCheapestPrice()
#pragma warning restore CA1024
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the highest number in an array.
        /// </summary>
        /// <returns>The highest number in an array.</returns>
        public static int Max()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            return numbers.Max();
        }

        /// <summary>
        /// Calculates the length of the longest word in an array.
        /// </summary>
        /// <returns>The length of the longest word in an array.</returns>
        public static int MaxByLength()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            int maxLength = words.Max(word => word.Length);

            return maxLength;
        }

        /// <summary>
        /// Calculates the most expensive price among each category's products.
        /// </summary>
        /// <returns>The most expensive price among each category's products.</returns>
#pragma warning disable CA1024
        public static IEnumerable<(string category, decimal mostExpensivePrice)> GetMostExpensivePrice()
#pragma warning restore CA1024
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the average of all numbers in an array.
        /// </summary>
        /// <returns>The average of all numbers in an array.</returns>
        public static double Average()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            return numbers.Average();
        }

        /// <summary>
        /// Gets the average length of the words in the array.
        /// </summary>
        /// <returns>The average length of the words in the array.</returns>
        public static double AverageByLength()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            return words.Average(word => word.Length);
        }

        /// <summary>
        /// Gets the average price of each category's products.
        /// </summary>
        /// <returns>The average price of each category's products.</returns>
        public static IEnumerable<(string Category, decimal averagePrice)> AveragePrice()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the total product of all elements.
        /// </summary>
        /// <returns>The total product of all elements.</returns>
        public static double Aggregate()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            return doubles.Aggregate((acc, current) => acc * current);
        }

        /// <summary>
        /// Subtracts each withdrawal from the initial balance of 100, as long as the balance never drops below 0.
        /// </summary>
        /// <returns>Final balance.</returns>
        public static double SeededAggregate()
        {
            double startBalance = 100.0;

            int[] attemptedWithdrawals = { 20, 10, 40, 50, 10, 70, 30 };

            return attemptedWithdrawals.Aggregate(startBalance, (balance, withdrawal) => balance - withdrawal > 0 ? balance - withdrawal : balance);
        }
    }
}
