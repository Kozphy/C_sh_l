using Microsoft.EntityFrameworkCore;

namespace mvc_api.Data
{
    public class BlogContext : DbContext
    {
        private readonly IConfiguration _config;


        public BlogContext(IConfiguration config) {
            _config = config;
        }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine(_config.GetConnectionString("DefaultConnection"));

            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
