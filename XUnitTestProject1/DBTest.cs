using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using Microsoft.Data.SqlClient;
using BusinessLogic;

namespace XUnitTests
{
    [Collection("db")]
    public class DBTest
    {
        DatabaseFixture databaseFixture;

        public DBTest(DatabaseFixture databaseFixture)
        {
            this.databaseFixture = databaseFixture;
        }

        [Fact]
        public void Add_writes_to_database()
        {
            var connection = databaseFixture.connection;
                var options = new DbContextOptionsBuilder<BloggingContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new BloggingContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new BloggingContext(options))
                {
                    var service = new BlogService(context);
                    service.Add("https://example.com");
                    context.SaveChanges();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new BloggingContext(options))
                {
                    Assert.Equal(1, context.Blogs.Count());
                    Assert.Equal("https://example.com", context.Blogs.Single().Url);
                }
        }
    }
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            // ... initialize data in the test database ...
        }

        public void Dispose()
        {
            connection.Close();

            // ... clean up test data from the database ...
        }

        public SqliteConnection connection { get; private set; }
    }

    [CollectionDefinition("db")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

}


namespace BusinessLogic
{
    public class BlogService
    {
        private BloggingContext _context;

        public BlogService(BloggingContext context)
        {
            _context = context;
        }

        public void Add(string url)
        {
            var blog = new Blog { Url = url };
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        public IEnumerable<Blog> Find(string term)
        {
            return _context.Blogs
                .Where(b => b.Url.Contains(term))
                .OrderBy(b => b.Url)
                .ToList();
        }
    }
    #region Constructors
    public class BloggingContext : DbContext
    {
        public BloggingContext()
        { }

        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }
        #endregion

        public DbSet<Blog> Blogs { get; set; }

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }
        #endregion
    }
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
    }
}
