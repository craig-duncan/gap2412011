namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface CriteriaFactory<ItemToSearch, PropertyType>
    {
        Criteria<ItemToSearch> equal_to(PropertyType value);
        Criteria<ItemToSearch> equal_to_any(params PropertyType[] values);
        Criteria<ItemToSearch> not_equal_to_any(params PropertyType[] values);
    }
}