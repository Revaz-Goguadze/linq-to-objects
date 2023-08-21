using System;
using System.Collections.Generic;
using System.Linq;
using Linq.DataSources;
using Linq.EqualityComparers;

namespace Linq
{
    /// <summary>
    /// Considers how to group elements of sequences into buckets ( `group by` and `into` keywords, methods GroupBy, GroupJoin ) in LINQ queries.
    /// Grouping definition: <see cref="IEnumerable{TSource}"/> → <see cref="IEnumerable{IGrouping{TKey,TElement}}"/>
    /// Grouping refers to the operation of putting data into groups so that the elements in each group share a common attribute.
    /// </summary>
    public static class GroupingData
    {
        /// <summary>
        /// Partitions a list of words by their first letter ans sorts by it.
        /// </summary>
        /// <returns>Sorted by key (first letter) sequence of words grouped by first letter.</returns>
        public static IEnumerable<IGrouping<char, string>> GroupByProperty()
        {
            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

            return words.GroupBy(w => w[0]).OrderBy(g => g.Key);
        }

        /// <summary>
        /// Groups elements on the remainder of an integer when dividing it by 5.
        /// </summary>
        /// <returns>The sequence of pairs: the remainder of an integer when dividing it by 5 and the numbers with a given remainder.</returns>
        public static IEnumerable<(int remainder, IEnumerable<int> numbers)> Grouping()
        {
            // ReSharper disable once UnusedVariable
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            throw new NotImplementedException();
        }

        /// <summary>
        /// Partitions a list of products by category.
        /// </summary>
        /// <returns>The sequences of products grouped by categories in which the number of products is less than or equal to 7.</returns>
        public static IEnumerable<(string category, IEnumerable<string> productsName)> GroupByCategory()
        {
            List<Product> products = Products.ProductList;

            return products.GroupBy(p => p.Category)
                .Where(g => g.Count() <= 7)
                .Select(g => (category: g.Key, productsName: g.Select(p => p.ProductName)));
        }

        /// <summary>
        /// Partitions a list of words by custom comparer <see cref="AnagramEqualityComparer"/>.
        /// </summary>
        /// <returns>The sequences of words grouped by anagram comparer.</returns>
        public static IEnumerable<IGrouping<string, string>> GroupByCustomComparer()
        {
            string[] anagrams = { "from   ", "  mane", " salt", " earn ", "name   ", "  last   ", " near ", " form  ", "mean" };

            var comparer = new AnagramEqualityComparer();
            return anagrams.GroupBy(w => w.Trim(), comparer);
        }

        /// <summary>
        /// Partitions a list of words by custom comparer <see cref="AnagramEqualityComparer"/>.
        /// </summary>
        /// <returns>The sequences of words in upper case grouped by anagram comparer.</returns>
        public static IEnumerable<IGrouping<string, string>> NestedGroupByCustom()
        {
            string[] anagrams = { "from   ", "  mane", " salt", " earn ", "name   ", "  last   ", " near ", " form  ", "mean" };

            var comparer = new AnagramEqualityComparer();
#pragma warning disable CA1304
            return anagrams.Select(w => w.Trim().ToUpper())
#pragma warning restore CA1304
                .GroupBy(w => w, comparer);
        }
    }
}
