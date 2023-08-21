using System;
using System.Collections.Generic;
using System.Linq;
using Linq.DataSources;

namespace Linq
{
    /// <summary>
    /// Considers the use of set operations (methods 'Distinct', 'Union', 'Intersect', and 'Except') in LINQ queries.
    /// Set operation definition:
    /// <see cref="IEnumerable{TSource}"/>, <see cref="IEnumerable{TSource}"/> → <see cref="IEnumerable{TSource}"/>
    /// Set operations refer to query operations that produce a result set that is based on the presence or
    /// absence of equivalent elements within the same or separate collections (or sets).
    /// </summary>
    public static class SetOperations
    {
        /// <summary>
        /// Removes duplicate elements in the sequence.
        /// </summary>
        /// <returns>Returns only unique numbers.</returns>
        public static IEnumerable<int> Distinct()
        {
            int[] numbers = { 2, 2, 3, 5, 5 };

            return numbers.Distinct();
        }

        /// <summary>
        /// Defines the unique Category names.
        /// </summary>
        /// <returns>Returns only unique Category names.</returns>
        public static IEnumerable<string> DistinctPropertyValues()
        {
            List<Product> products = Products.ProductList;

            return products.Select(p => p.Category).Distinct();
        }

        /// <summary>
        /// Creates one sequence that contains the unique values from both arrays.
        /// </summary>
        /// <returns>Sequence that contains only unique values from both arrays.</returns>
        public static IEnumerable<int> Union()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            return numbersA.Union(numbersB);
        }

        /// <summary>
        /// Creates one sequence that contains the unique first letter from both product and customer names.
        /// </summary>
        /// <returns>The sequence that contains the unique first letter from both product and customer names.</returns>
        public static IEnumerable<char> UnionOfQueryResults()
        {
            List<Product> products = Products.ProductList;
            List<Customer> customers = Customers.CustomerList;

            return products.Select(p => p.ProductName[0])
                .Union(customers.Select(c => c.CompanyName[0]));
        }

        /// <summary>
        /// Creates one sequence that contains the common values shared by both arrays.
        /// </summary>
        /// <returns>The sequence that contains the common values shared by both arrays.</returns>
        public static IEnumerable<int> Intersect()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            return numbersA.Intersect(numbersB);
        }

        /// <summary>
        /// Create one sequence that contains the common first letter from both product and customer names.
        /// </summary>
        /// <returns>The sequence that contains the common first letter from both product and customer names.</returns>
        public static IEnumerable<char> IntersectQueryResults()
        {
            List<Product> products = Products.ProductList;
            List<Customer> customers = Customers.CustomerList;

            return products.Select(p => p.ProductName[0])
                .Intersect(customers.Select(c => c.CompanyName[0]));
        }

        /// <summary>
        /// Creates a sequence that contains the values from `numbersA` that are not also in `numbersB`.
        /// </summary>
        /// <returns>The sequence that contains the values from `numbersA` that are not also in `numbersB`.</returns>
        public static IEnumerable<int> DifferenceOfSets()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            return numbersA.Except(numbersB);
        }

        /// <summary>
        /// Creates one sequence that contains the first letters of product names that are not also first letters of customer names.
        /// </summary>
        /// <returns>The sequence that contains the first letters of product names that are not also first letters of customer names.</returns>
        public static IEnumerable<char> DifferenceOfQueries()
        {
            List<Product> products = Products.ProductList;
            List<Customer> customers = Customers.CustomerList;

            return products.Select(p => p.ProductName[0])
                .Except(customers.Select(c => c.CompanyName[0]));
        }
    }
}
