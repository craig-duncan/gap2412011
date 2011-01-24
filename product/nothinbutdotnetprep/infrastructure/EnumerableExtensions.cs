using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> all_matching<T>(this IEnumerable<T> items, Criteria<T> condition)
        {
            return items.all_matching(condition.matches);
        }

        public static IEnumerable<T> all_matching<T>(this IEnumerable<T> items, Predicate<T> condition)
        {
            foreach (var item in items)
                if (condition(item)) yield return item;
        }

        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}