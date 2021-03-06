using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The Chosen, Season 1",
                        ReleaseDate = DateTime.Parse("2017-01-01"),
                        Genre = "History",
                        Rating = "TV-PG",
                        Price = 0M
                    },

                    new Movie
                    {
                        Title = "The Saratov Approach",
                        ReleaseDate = DateTime.Parse("2013-10-09"),
                        Genre = "Thriller",
                        Rating = "PG-13",
                        Price = 10.77M
                    },

                    new Movie
                    {
                        Title = "The Singles Ward",
                        ReleaseDate = DateTime.Parse("2002-01-30"),
                        Genre = "Comedy",
                        Rating = "NR",
                        Price = 19.75M
                    },

                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("2015-03-31"),
                        Genre = "Documentary",
                        Rating = "PG",
                        Price = 9.97M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}