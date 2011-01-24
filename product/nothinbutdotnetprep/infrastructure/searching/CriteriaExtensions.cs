namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class CriteriaExtensions
    {
        public static Criteria<ItemToSearch> equal_to<ItemToSearch, PropertyType>(
            this PropertyAccessor<ItemToSearch, PropertyType> accessor,
            PropertyType value)
        {
            return new AnonymousCriteria<ItemToSearch>(x => accessor(x).Equals(value));
        }

        public static Criteria<T> and<T>(this Criteria<T> left_side, Criteria<T> right_side)
        {
            return new AndCriteria<T>(left_side, right_side);
        }
    }
}