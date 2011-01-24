using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                var list = new List<Movie>(movies);
                list.Sort((m, n) => n.title.CompareTo(m.title));
                return list;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return movies.all_matching(movie => movie.production_studio == ProductionStudio.Pixar);
        }


        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
        	return movies.all_matching(m => m.production_studio == ProductionStudio.Disney || m.production_studio == ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                var list = new List<Movie>(movies);
                list.Sort((m, n) => m.title.CompareTo(n.title));
                return list;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            var list = new List<Movie>(movies); //Studio Ratings (highest to lowest)
            //MGM
            //Pixar
            //Dreamworks
            //Universal
            //Disney
            var production_order = new Dictionary<ProductionStudio, int>
            {
                {ProductionStudio.MGM, 5},
                {ProductionStudio.Pixar, 4},
                {ProductionStudio.Dreamworks, 3},
                {ProductionStudio.Universal, 2},
                {ProductionStudio.Disney, 1}
            };

            list.Sort((m, n) =>
            {
                var same =
                    production_order[n.production_studio] - production_order[m.production_studio];
                if (same == 0)
                    same = m.date_published.CompareTo(n.date_published);
                return same;
            });
            return list;
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
        	return movies.all_matching(m => m.production_studio != ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
        	return movies.all_matching(m => m.date_published.Year > year);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
        	return movies.all_matching(m => m.date_published.Year >= startingYear && m.date_published.Year <= endingYear);
        }

        public IEnumerable<Movie> all_kid_movies()
        {
        	return movies.all_matching(m => m.genre == Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
        	return movies.all_matching(m => m.genre == Genre.action);
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var list = new List<Movie>(movies);
            list.Sort((m, n) => n.date_published.CompareTo(m.date_published));
            return list;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var list = new List<Movie>(movies);
            list.Sort((m, n) => m.date_published.CompareTo(n.date_published));
            return list;
        }
    }
}