using System;
using nothinbutdotnetprep.utility;

namespace nothinbutdotnetprep.collections
{
    public class Movie : IEquatable<Movie>
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

            return ReferenceEquals(this, other) || is_equal_to_non_null_instance_of(other);
        }

        bool is_equal_to_non_null_instance_of(Movie other)
        {
            return this.title == other.title;
        }

        public override int GetHashCode()
        {
            return title.GetHashCode();
        }

        public static IMatch<Movie> is_published_by(ProductionStudio studio)
        {
            return new IsPublishedBy(studio);
        }

        public static IMatch<Movie> is_in_genre(Genre genre)
        {
            return new IsInGenre(genre);
        }

        public static IMatch<Movie> is_published_by_pixar_or_disney
        {
            get
            {
                return is_published_by(ProductionStudio.Pixar)
                    .or(is_published_by(ProductionStudio.Disney))
                    .or(is_in_genre(Genre.comedy));
            }
        }
    }
}