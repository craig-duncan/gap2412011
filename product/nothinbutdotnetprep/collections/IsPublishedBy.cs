using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public class IsPublishedBy : Criteria<Movie>
    {
        ProductionStudio studio;

        public IsPublishedBy(ProductionStudio studio)
        {
            this.studio = studio;
        }

        public bool matches(Movie movie)
        {
            return movie.production_studio == studio;
        }
    }
}