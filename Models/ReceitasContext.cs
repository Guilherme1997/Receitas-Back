using Microsoft.EntityFrameworkCore;

namespace Receitas_Fiap.Models
{

    public class ReceitasContext : DbContext
    {
        public ReceitasContext(DbContextOptions<ReceitasContext> options): base(options){ }

        public DbSet<ReceitasModel> Receitas { get; set; }
           
    }
}
