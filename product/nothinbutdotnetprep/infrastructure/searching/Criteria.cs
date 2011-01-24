namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface Criteria<T>
    {
        bool matches(T item);
    }
}