using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    /// <summary>
    /// Considers how to create sequences of integers (methods 'Empty', 'Range', and 'Repeat') in LINQ queries.
    /// Generation Methods: void → <see cref="IEnumerable{TResult}"/>
    /// Generation refers to creating a new sequence of values.
    /// </summary>
    public static class GenerationOperations
    {
        /// <summary>
        /// Creates an empty sequence of integral numbers.
        /// </summary>
        /// <returns>Empty sequence of integral numbers.</returns>
        public static IEnumerable<int> EmptySequence()
        {
            return Enumerable.Empty<int>();
        }

        /// <summary>
        /// Generates a sequence of integral numbers within a specified range with additional information about their parity-oddness.
        /// </summary>
        /// <returns> The sequence of integral numbers in the specified range with additional information about their parity-oddness.
        /// </returns>
        public static IEnumerable<(int number, string oddEven)> RangeOfIntegers()
        {
            var result = Enumerable.Range(1, 10)
                .Select(number => (
                    number,
                    oddEven: number % 2 == 0 ? "Even" : "Odd"));
            return result;
        }

        /// <summary>
        /// Generates a sequence that contains one repeated value.
        /// </summary>
        /// <returns>The sequence that contains one repeated value. </returns>
        public static IEnumerable<int> RepeatNumber()
        {
            return Enumerable.Repeat(5, 3);
        }
    }
}
