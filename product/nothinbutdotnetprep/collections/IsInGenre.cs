using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public class IsInGenre : Criteria<Movie>
    {
        Genre genre;

        public IsInGenre(Genre genre)
        {
            this.genre = genre;
        }

        public bool matches(Movie movie)
        {
            return movie.genre == genre;
        }
    }
}