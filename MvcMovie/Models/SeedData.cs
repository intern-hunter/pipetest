using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MvcMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "The Count of Monte Cristo",
                         ReleaseDate = DateTime.Parse("2002-1-25"),
                         Genre = "Drama",
                         Price = 4.99M
                     },

                     new Movie
                     {
                         Title = "Godzilla",
                         ReleaseDate = DateTime.Parse("2014-5-16"),
                         Genre = "Action/Thriller",
                         Price = 6.99M
                     },

                     new Movie
                     {
                         Title = "Now You See Me",
                         ReleaseDate = DateTime.Parse("2013-5-31"),
                         Genre = "Action/Mystery",
                         Price = 5.99M
                     },

                   new Movie
                   {
                       Title = "Avengers: Age of Ultron",
                       ReleaseDate = DateTime.Parse("2015-5-01"),
                       Genre = "Action",
                       Price = 5.99M
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
