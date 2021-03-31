using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           //Defining many-to-many movie-actor relationship
            modelBuilder.Entity<MovieActor>()             
            .HasKey(x => new {x.MovieId , x.ActorId});

            modelBuilder.Entity<MovieActor>() 
            .HasOne(pt => pt.Movie)
            .WithMany(p => p.ActorsLink)
            .HasForeignKey(pt => pt.MovieId);
 
            modelBuilder.Entity<MovieActor>() 
            .HasOne(pt => pt.Actor) 
            .WithMany(t => t.MoviesLink)
            .HasForeignKey(pt => pt.ActorId);

            // many-to-many movie-writer relationship
            modelBuilder.Entity<MovieWriter>()             
            .HasKey(x => new {x.MovieId , x.WriterId});

            modelBuilder.Entity<MovieWriter>() 
            .HasOne(pt => pt.Movie)
            .WithMany(p => p.WritersLink)
            .HasForeignKey(pt => pt.MovieId);
 
            modelBuilder.Entity<MovieWriter>() 
            .HasOne(pt => pt.Writer) 
            .WithMany(t => t.MoviesLink)
            .HasForeignKey(pt => pt.WriterId);

            //many-to-many movie-director relatonship
            modelBuilder.Entity<MovieDirector>()             
            .HasKey(x => new {x.MovieId , x.DirectorId});

            modelBuilder.Entity<MovieDirector>() 
            .HasOne(pt => pt.Movie)
            .WithMany(p => p.DirectorsLink)
            .HasForeignKey(pt => pt.MovieId);
 
            modelBuilder.Entity<MovieDirector>() 
            .HasOne(pt => pt.Director) 
            .WithMany(t => t.MoviesLink)
            .HasForeignKey(pt => pt.DirectorId);
        }
    }
}