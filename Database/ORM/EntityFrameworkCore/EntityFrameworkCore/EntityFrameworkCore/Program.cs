namespace EntityFrameworkCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    internal static class DatabaseFacadeExentions
    {
        /// <remarks>
        /// Once database is created without migrations than it can't be added
        /// </remarks>
        public static void InitDatabase(this DatabaseFacade db, bool create, bool clear = false, bool migrate = false)
        {
            if (clear)
            {
                db.EnsureDeleted();
            }

            if (create)
            {
                if (migrate)
                {
                    if (!db.GetMigrations().Any())
                    {
                        throw new InvalidOperationException("Can't use migrations while having zero migrations because first migration should init database. Use: dotnet ef migrations add Init");
                    }

                    db.Migrate();
                }
                else
                {
                    db.EnsureCreated();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                db.Database.InitDatabase(create: true, clear: true, migrate: true);

                var blogs = db.Blogs
                    .Where(b => b.Rating > 3)
                    .OrderBy(b => b.Url)
                    .ToList();

                var blog = new Blog { Url = "http://sample.com" };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }

            Console.WriteLine("Hello World!");
        }
    }


    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Blog>()
                .HasIndex(u => u.Url)
                .IsUnique();

            builder.Entity<Post>();
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public List<Post> Posts { get; set; }

        public string Descrition { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
