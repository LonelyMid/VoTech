using Microsoft.EntityFrameworkCore;

namespace VoTech.Models
{
    public class VotacaoDbContext : DbContext
    {
        public VotacaoDbContext(DbContextOptions<VotacaoDbContext> options) : base (options) 
        {
            
        }
    }
}