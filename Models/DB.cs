using Microsoft.EntityFrameworkCore;

namespace webtintuc.Models
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) { }

        public DbSet<Article> Articles { get; set; } // Đảm bảo thuộc tính này tồn tại
    }
}