namespace nothinbutdotnetprep.infrastructure.searching
{
    public class AndCriteria<T> : Criteria<T>
    {
        Criteria<T> left_side;
        Criteria<T> right_side;

        public AndCriteria(Criteria<T> left_side, Criteria<T> right_side)
        {
            this.left_side = left_side;
            this.right_side = right_side;
        }

        public bool matches(T item)
        {
            return left_side.matches(item) && right_side.matches(item);
        }
    }
}