using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Estudiante> Estudiante { get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-NFDMETJ;Database=Progra2;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true;");
    }
}
