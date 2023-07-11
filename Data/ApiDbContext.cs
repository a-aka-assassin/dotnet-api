using FighterApi.Models;
using Microsoft.EntityFrameworkCore;
namespace FighterApi.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<FighterModel> Fighters { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
        {

        }
    }
}