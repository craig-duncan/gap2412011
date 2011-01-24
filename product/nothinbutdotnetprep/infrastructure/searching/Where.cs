namespace nothinbutdotnetprep.infrastructure.searching
{
    public delegate PropertyType PropertyAccessor<ItemToSearch, PropertyType>(ItemToSearch item);

    public class Where<ItemToSearch>
    {
        public static PropertyAccessor<ItemToSearch, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToSearch, PropertyType> accessor)
        {
            return accessor;
        }
    }
}