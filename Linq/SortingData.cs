using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Comparers;
using Linq.DataSources;

namespace Linq
{
    /// <summary>
    /// Considers the use sorting operations (methods 'OrderBy','OrderByDescending', 'ThenBy', 'ThenByDescending', and 'Reverse'
    /// and 'orderby', 'descending' keywords) in LINQ queries.
    /// Sorting operation definition:
    /// <see cref="IEnumerable{TSource}"/> → <see cref="IOrderedEnumerable{TSource}"/>.
    /// A sorting operation orders the elements of a sequence based on one or more attributes.
    /// </summary>
    public static class SortingData
    {
        public static IEnumerable<string> OrderBy()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var result = words.OrderBy(word => word);
            return result;
        }

        public static IEnumerable<string> OrderByProperty()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var result = words.OrderBy(word => word.Length);
            return result;
        }

        public static IEnumerable<Product> OrderByProducts()
        {
            List<Product> products = Products.ProductList;

            var result = products.OrderBy(product => product.ProductName);
            return result;
        }

        public static IEnumerable<string> OrderByWithCustomComparer()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var result = words.OrderBy(word => word, StringComparer.OrdinalIgnoreCase);
            return result;
        }

        public static IEnumerable<double> OrderByDescending()
        {
            double[] doubles = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            var result = doubles.OrderByDescending(number => number);
            return result;
        }

        public static IEnumerable<Product> OrderProductsDescending()
        {
            List<Product> products = Products.ProductList;

            var result = products.OrderByDescending(product => product.UnitsInStock);
            return result;
        }

        public static IEnumerable<string> DescendingCustomComparer()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var result = words.OrderByDescending(word => word, StringComparer.OrdinalIgnoreCase);
            return result;
        }

        public static IEnumerable<string> ThenBy()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var result = digits.OrderBy(digit => digit.Length).ThenBy(digit => digit);
            return result;
        }

        /// <summary>
        /// Sorts a list of words, first by length of their name, and then alphabetically case insensitive by the name itself.
        /// </summary>
        /// <returns>Sorted sequence of words.</returns>
        public static IEnumerable<string> ThenByCustom()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var result = words.OrderBy(word => word.Length).ThenBy(word => word, StringComparer.OrdinalIgnoreCase);
            return result;
        }

        /// <summary>
        /// Sorts a list of products, first by category, and then by unit price, from highest to lowest.
        /// </summary>
        /// <returns>Sorted sequence of products.</returns>
        public static IEnumerable<Product> ThenByDifferentOrdering()
        {
            List<Product> products = Products.ProductList;

            var result = products.OrderBy(product => product.Category)
                .ThenByDescending(product => product.UnitPrice);
            return result;
        }

        /// <summary>
        /// Sorts a list of words, first by length of their name, and then descending alphabetically case insensitive by the name itself.
        /// </summary>
        /// <returns>Sorted sequence of words.</returns>
        public static IEnumerable<string> CustomThenByDescending()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var result = words.OrderBy(word => word.Length)
                .ThenByDescending(word => word, StringComparer.OrdinalIgnoreCase);
            return result;
        }

        /// <summary>
        /// Gets a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
        /// </summary>
        /// <returns>Reverse sequence of digits whose second letter is 'i'.</returns>
        public static IEnumerable<string> OrderingReversal()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var result = digits.Where(digit => digit.Length > 1 && digit[1] == 'i')
                .Reverse();
            return result;
        }
    }
}
