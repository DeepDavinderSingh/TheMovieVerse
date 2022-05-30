using Microsoft.EntityFrameworkCore;
using System;
using TheMovieVerse.Model;

namespace TheMovieVerse.DB
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext()
        {

        }
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
