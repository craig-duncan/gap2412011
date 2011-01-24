using System;
using System.Data.SqlClient;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public delegate PropertyType PropertyAccessor<ItemToSearch, PropertyType>(ItemToSearch item);

    public class Where<ItemToSearch>
    {
        public static CriteriaFactory<ItemToSearch,PropertyType> has_an<PropertyType>(
            PropertyAccessor<ItemToSearch, PropertyType> accessor) where PropertyType : IComparable<PropertyType>,new()
        {
            return new CriteriaFactory<ItemToSearch,PropertyType>(accessor);
        }
        public static CriteriaFactory<ItemToSearch,PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToSearch, PropertyType> accessor)
        {
            return new CriteriaFactory<ItemToSearch,PropertyType>(accessor);
        }
    }
}