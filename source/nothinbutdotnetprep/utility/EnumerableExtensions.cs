using System.Collections.Generic;

namespace nothinbutdotnetprep.utility
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) yield return item;
        }

        public static IEnumerable<ItemToMatch> all_items_matching<ItemToMatch>(this IEnumerable<ItemToMatch> items,Condition<ItemToMatch> criteria)
        {
            foreach (var item in items)
            {
                if (criteria(item)) yield return item;
            }
        }

        public static IEnumerable<ItemToMatch> all_items_matching<ItemToMatch>(this IEnumerable<ItemToMatch> items,IMatch<ItemToMatch> criteria)
        {
            return items.all_items_matching(criteria.matches);
        }
    }
}