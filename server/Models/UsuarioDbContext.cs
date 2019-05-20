using Microsoft.EntityFrameworkCore;

namespace VoTech.Models
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<TechshotDbContext> options) : base (options) 
        {
            
        }
    }
}