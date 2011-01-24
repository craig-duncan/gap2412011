namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NotCriteria<T> : Criteria<T>
    {
        Criteria<T> original;

        public NotCriteria(Criteria<T> original)
        {
            this.original = original;
        }

        public bool matches(T item)
        {
            return ! original.matches(item);
        }
    }
}