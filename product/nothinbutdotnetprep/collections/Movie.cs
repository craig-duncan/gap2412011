using System;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public class Movie  : IEquatable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }

        public Genre genre { get; set; }

        public int rating { get; set; }

        public DateTime date_published { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Movie);
        }

        public bool Equals(Movie other)
        {
            if (other == null) return false;

            return ReferenceEquals(this,other) || is_equal_to_other(other);
        }

        bool is_equal_to_other(Movie other)
        {
            return other.title == title;
        }

        public override int GetHashCode()
        {
            return title.GetHashCode();
        }

        public static Criteria<Movie> is_in_genre(Genre genre)
        {
            return new AnonymousCriteria<Movie>(x => x.genre == genre);
        }

        public static Criteria<Movie> is_published_by_pixar_or_disney(Movie movie)
        {
            return new IsPublishedBy(ProductionStudio.Pixar).and(
                new IsPublishedBy(ProductionStudio.Disney));
        }
        public static MovieCriteria is_published_by(ProductionStudio studio)
        {
            return x => x.production_studio == studio;
        }
        public static MovieCriteria is_published_by_pixar(Movie movie)
        {
            return new IsPublishedBy(ProductionStudio.Pixar).matches;
        }
    }
}