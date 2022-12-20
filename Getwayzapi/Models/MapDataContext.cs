using Microsoft.EntityFrameworkCore;

namespace Getwayzapi.Models
{
    public class MapDataContext : DbContext
    {

        public MapDataContext(DbContextOptions<MapDataContext> options)
       : base(options)
        {

        }

        public DbSet<MapData> MapData { get; set; } = null!;
    }
}

