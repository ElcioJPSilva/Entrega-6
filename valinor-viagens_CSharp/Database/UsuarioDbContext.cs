using Microsoft.EntityFrameworkCore;
using valinor_viagens_CSharp.Model;

namespace valinor_viagens_CSharp.Database
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext>
        options) : base(options) {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            var usuario = modelBuilder.Entity<Usuario>();
            usuario.ToTable("usuario");
            usuario.HasKey(x => x.id_cliente);
            usuario.Property(x => x.id_cliente).HasColumnName("id_cliente").ValueGeneratedOnAdd();
            usuario.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            usuario.Property(x => x.cpf).HasColumnName("cpf");





        }
    }
}