using System;
using System.Collections.Generic;
using Linq.DataSources;

namespace Linq
{
    /// <summary>
    /// Considers use partition operations (methods 'Take', 'Skip', 'TakeWhile' and 'SkipWhile') in LINQ queries.
    /// Partitioning : <see cref="IEnumerable{TSource}"/> → <see cref="IEnumerable{TSource}"/>
    /// The operation of dividing an input sequence into two sections, without rearranging the elements,
    /// and then returning one of the sections.
    /// </summary>
    public static class PartitioningData
    {
        public static IEnumerable<int> Take()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            return numbers.Take(3);
        }

        public static IEnumerable<(string customerId, int orderId, DateTime orderDate)> CustomersTake()
        {
            // ReSharper disable once UnusedVariable
            List<Customer> customers = Customers.CustomerList;
            throw new NotImplementedException();
        }

        public static IEnumerable<int> Skip()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            return numbers.Skip(4);
        }

        public static IEnumerable<(string customerId, int orderId, DateTime orderDate)> CustomersSkip()
        {
            // ReSharper disable once UnusedVariable
            List<Customer> customers = Customers.CustomerList;
            throw new NotImplementedException();
        }

        public static IEnumerable<int> TakeWhile()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            return numbers.TakeWhile(num => num < 6);
        }

        public static IEnumerable<int> IndexedTakeWhile()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            return numbers.TakeWhile((num, index) => num >= index);
        }

        public static IEnumerable<int> SkipWhile()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            return numbers.SkipWhile(num => num % 3 != 0);
        }

        public static IEnumerable<int> IndexedSkipWhile()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            return numbers.SkipWhile((n, index) => n >= index);
        }
    }
}
