using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class CriteriaFactory<ItemToSearch, PropertyType>
    {
        PropertyAccessor<ItemToSearch, PropertyType> accessor;

        public CriteriaFactory(PropertyAccessor<ItemToSearch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToSearch> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public Criteria<ItemToSearch> equal_to_any(params PropertyType[] values)
        {
            return new AnonymousCriteria<ItemToSearch>(x => new List<PropertyType>(values).Contains(accessor(x)));
        }

        public Criteria<ItemToSearch> not_equal_to_any(params PropertyType[] values)
        {
            return new NotCriteria<ItemToSearch>(equal_to_any(values));
        }

        public object greater_than(int p)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ComparableCriteriaFactory<ItemToSearch, PropertyType> where PropertyType : IComparable<PropertyType>,new()
    {
        PropertyAccessor<ItemToSearch, PropertyType> accessor;
        private CriteriaFactory<ItemToSearch, PropertyType> criteriaFactory;
        public ComparableCriteriaFactory(PropertyAccessor<ItemToSearch, PropertyType> accessor)
        {
            this.accessor = accessor;
            criteriaFactory = new CriteriaFactory<ItemToSearch, PropertyType>(accessor);
        }

        public Criteria<ItemToSearch> equal_to(PropertyType value)
        {
            return criteriaFactory.equal_to_any(value);
        }

        public Criteria<ItemToSearch> equal_to_any(params PropertyType[] values)
        {
            return criteriaFactory.equal_to_any(values);
        }

        public Criteria<ItemToSearch> not_equal_to_any(params PropertyType[] values)
        {
            return criteriaFactory.not_equal_to_any(values);
        }

        public Criteria<ItemToSearch> greater_than(PropertyType p)
        {
            return new AnonymousCriteria<ItemToSearch>(x => accessor(x).CompareTo(p) > 0);
        }

        public Criteria<ItemToSearch> between(PropertyType start, PropertyType end )
        {
            return new AnonymousCriteria<ItemToSearch>(x => accessor(x).CompareTo(start) >= 0 && accessor(x).CompareTo(end) <= 0);
        }
    }
}