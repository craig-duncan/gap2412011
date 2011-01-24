using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public delegate PropertyType PropertyAccessor<ItemToSearch, PropertyType>(ItemToSearch item);

    public class Where<ItemToSearch>
    {
        public static ComparableCriteriaFactory<ItemToSearch, PropertyType> has_an<PropertyType>(
            PropertyAccessor<ItemToSearch, PropertyType> accessor) where PropertyType : IComparable<PropertyType>, new()
        {
            return new ComparableCriteriaFactory<ItemToSearch, PropertyType>(accessor,
                has_a(accessor));
        }

        public static BasicCriteriaFactory<ItemToSearch, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToSearch, PropertyType> accessor)
        {
            return new BasicCriteriaFactory<ItemToSearch, PropertyType>(accessor);
        }
    }
}