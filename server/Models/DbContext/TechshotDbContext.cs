using Microsoft.EntityFrameworkCore;

namespace VoTech.Models
{
    public class TechshotDbContext : DbContext
    {
        public TechshotDbContext(DbContextOptions<TechshotDbContext> options) : base (options) 
        {
            
        }
    }
}