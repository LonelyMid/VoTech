using Microsoft.EntityFrameworkCore;

namespace VoTech.Models
{
    public class TemasDbContext : DbContext
    {
        public TemasDbContext(DbContextOptions<TemasDbContext> options) : base (options) 
        {
            
        }
    }
}