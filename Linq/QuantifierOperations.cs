using System;
using System.Collections.Generic;
using System.Linq;
using Linq.DataSources;

namespace Linq
{
    /// <summary>
    /// Considers the use quantifier operators (methods 'All', 'Any', 'SequenceEqual' and `Contains`) in LINQ queries.
    /// Quantifier operation definition:
    /// <see cref="IEnumerable{T}"/> → bool
    /// Quantifier operations return a Boolean value that indicates whether some or all of the elements
    /// in a sequence satisfy a condition.
    /// </summary>
    public static class QuantifierOperations
    {
        /// <summary>
        /// Checks if two sequences match on all elements in the same order.
        /// </summary>
        /// <returns>true.</returns>
        public static bool EqualSequence()
        {
            var wordsA = new[] { "cherry", "apple", "blueberry" };
            var wordsB = new[] { "cherry", "apple", "blueberry" };

            return wordsA.SequenceEqual(wordsB);
        }

        /// <summary>
        /// Checks if two sequences match on all elements in the same order.
        /// </summary>
        /// <returns>false.</returns>
        public static bool NotEqualSequence()
        {
            var wordsA = new[] { "cherry", "apple", "blueberry" };
            var wordsB = new[] { "apple", "blueberry", "cherry" };

            return wordsA.SequenceEqual(wordsB);
        }

        /// <summary>
        /// Determines if there is at least one word in the list containing “ei”.
        /// </summary>
        /// <returns>true.</returns>
        public static bool AnyMatchingElements()
        {
            string[] words = { "believe", "relief", "receipt", "field" };

#pragma warning disable CA1307
            return words.Any(word => word.Contains("ei"));
#pragma warning restore CA1307
        }

        /// <summary>
        /// Creates product categories with zero units in stock.
        /// </summary>
        /// <returns>Grouped product categories with zero units in stock.</returns>
        public static IEnumerable<(string category, IEnumerable<Product> products)> GroupedAnyMatchedElements()
        {
            List<Product> products = Products.ProductList;

            var query =
                from product in products
                group product by product.Category into categoryGroup
                where categoryGroup.Any(product => product.UnitsInStock == 0)
                select (categoryGroup.Key, categoryGroup);

            return (IEnumerable<(string category, IEnumerable<Product> products)>)query;
        }

        /// <summary>
        /// Determines whether all elements are odd.
        /// </summary>
        /// <returns>true.</returns>
        public static bool AllMatchedElements()
        {
            int[] numbers = { 1, 11, 3, 19, 41, 65, 19 };

            return numbers.All(number => number % 2 == 1);
        }

        /// <summary>
        /// Creates product categories with more than zero units in stock.
        /// </summary>
        /// <returns>Grouped product categories with more than zero units in stock.</returns>
        public static IEnumerable<(string category, IEnumerable<Product> products)> GroupedAllMatchedElements()
        {
            List<Product> products = Products.ProductList;

            var query =
                from product in products
                group product by product.Category into categoryGroup
                where categoryGroup.All(product => product.UnitsInStock > 0)
                select (categoryGroup.Key, categoryGroup);

            return (IEnumerable<(string category, IEnumerable<Product> products)>)query;
        }

        /// <summary>
        /// Determines whether the sequence contains the given element.
        /// </summary>
        /// <returns>true.</returns>
        public static bool HasAThree()
        {
            int[] numbers = { 2, 3, 4 };

            return numbers.Contains(3);
        }
    }
}
