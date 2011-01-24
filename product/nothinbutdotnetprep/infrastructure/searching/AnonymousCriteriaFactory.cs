using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class AnonymousCriteriaFactory<ItemToSearch>
    {
        public static Criteria<ItemToSearch> create(Predicate<ItemToSearch> condition)
        {
            return new AnonymousCriteria<ItemToSearch>(condition);
        }
    }
}