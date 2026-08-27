using LibraryApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Editeur> Editeurs { get; set; }
        public DbSet<Emprunt> Emprunts { get; set; }
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Parcourt toutes les entités et force le nom de la table au nom de la classe (au singulier)
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }
    }
}
