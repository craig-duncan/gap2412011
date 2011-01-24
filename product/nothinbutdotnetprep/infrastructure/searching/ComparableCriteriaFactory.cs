using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToSearch, PropertyType> : CriteriaFactory<ItemToSearch,PropertyType>
        where PropertyType : IComparable<PropertyType>,new()
    {
        PropertyAccessor<ItemToSearch, PropertyType> accessor;
        BasicCriteriaFactory<ItemToSearch, PropertyType> basic_criteria_factory;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToSearch, PropertyType> accessor, BasicCriteriaFactory<ItemToSearch, PropertyType> basic_criteria_factory)
        {
            this.accessor = accessor;
            this.basic_criteria_factory = basic_criteria_factory;
        }


        public Criteria<ItemToSearch> greater_than(PropertyType value_to_be_greater_than)
        {
            return new AnonymousCriteria<ItemToSearch>(x => accessor(x).CompareTo(value_to_be_greater_than) > 0);
        }

        public Criteria<ItemToSearch> equal_to(PropertyType value)
        {
            return basic_criteria_factory.equal_to(value);
        }

        public Criteria<ItemToSearch> equal_to_any(params PropertyType[] values)
        {
            return basic_criteria_factory.equal_to_any(values);
        }

        public Criteria<ItemToSearch> not_equal_to_any(params PropertyType[] values)
        {
            return basic_criteria_factory.not_equal_to_any(values);
        }

        public Criteria<ItemToSearch> between(PropertyType start, PropertyType end )
        {
            return new AnonymousCriteria<ItemToSearch>(x => accessor(x).CompareTo(start) >= 0 && accessor(x).CompareTo(end) <= 0);
        }
    }
}