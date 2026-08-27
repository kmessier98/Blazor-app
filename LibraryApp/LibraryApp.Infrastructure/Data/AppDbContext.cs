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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Livre>()
                .HasMany(l => l.Auteurs)
                .WithMany(a => a.Livres)
                .UsingEntity<AuteurLivre>(
                    j => j.HasOne(al => al.Auteur).WithMany().HasForeignKey(al => al.AuteurId),
                    j => j.HasOne(al => al.Livre).WithMany().HasForeignKey(al => al.LivreId),
                    j =>
                    {
                        j.HasKey(al => new { al.AuteurId, al.LivreId });
                    });

            modelBuilder.Entity<Livre>()
                .HasMany(l => l.Categories)
                .WithMany(c => c.Livres)
                .UsingEntity<CategorieLivre>(
                    j => j.HasOne(cl => cl.Categorie).WithMany().HasForeignKey(cl => cl.CategorieId),
                    j => j.HasOne(cl => cl.Livre).WithMany().HasForeignKey(cl => cl.LivreId),
                    j =>
                    {
                        j.HasKey(cl => new { cl.CategorieId, cl.LivreId });
                    });

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // --- Éditeurs ---
            modelBuilder.Entity<Editeur>().HasData(
                new Editeur { Id = 1, Nom = "Éditions Robert Laffont" },
                new Editeur { Id = 2, Nom = "Éditions J'ai lu" },
                new Editeur { Id = 3, Nom = "Éditions Gallimard" }
            );

            // --- Auteurs ---
            modelBuilder.Entity<Auteur>().HasData(
                new Auteur { Id = 1, Nom = "Herbert", Prenom = "Frank" },
                new Auteur { Id = 2, Nom = "Asimov", Prenom = "Isaac" },
                new Auteur { Id = 3, Nom = "Gibson", Prenom = "William" },
                new Auteur { Id = 4, Nom = "Camus", Prenom = "Albert" }
            );

            // --- Catégories ---
            modelBuilder.Entity<Categorie>().HasData(
                new Categorie { Id = 1, Nom = "Science-fiction" },
                new Categorie { Id = 2, Nom = "Classique" },
                new Categorie { Id = 3, Nom = "Cyberpunk" }
            );

            // --- Livres ---
            modelBuilder.Entity<Livre>().HasData(
                new Livre { Id = 1, Titre = "Dune", EditeurId = 1, EstDisponible = true },
                new Livre { Id = 2, Titre = "Le Messie de Dune", EditeurId = 1, EstDisponible = true },
                new Livre { Id = 3, Titre = "Fondation", EditeurId = 2, EstDisponible = false },
                new Livre { Id = 4, Titre = "Neuromancien", EditeurId = 2, EstDisponible = true },
                new Livre { Id = 5, Titre = "L'Étranger", EditeurId = 3, EstDisponible = true }
            );

            // --- AuteurLivre (jonction plusieurs-à-plusieurs) ---
            modelBuilder.Entity<AuteurLivre>().HasData(
                new AuteurLivre { AuteurId = 1, LivreId = 1 }, // Herbert - Dune
                new AuteurLivre { AuteurId = 1, LivreId = 2 }, // Herbert - Le Messie de Dune
                new AuteurLivre { AuteurId = 2, LivreId = 3 }, // Asimov - Fondation
                new AuteurLivre { AuteurId = 3, LivreId = 4 }, // Gibson - Neuromancien
                new AuteurLivre { AuteurId = 4, LivreId = 5 }  // Camus - L'Étranger
            );

            // --- CategorieLivre (jonction plusieurs-à-plusieurs) ---
            modelBuilder.Entity<CategorieLivre>().HasData(
                new CategorieLivre { CategorieId = 1, LivreId = 1 }, // Dune - SF
                new CategorieLivre { CategorieId = 1, LivreId = 2 }, // Messie de Dune - SF
                new CategorieLivre { CategorieId = 1, LivreId = 3 }, // Fondation - SF
                new CategorieLivre { CategorieId = 1, LivreId = 4 }, // Neuromancien - SF
                new CategorieLivre { CategorieId = 3, LivreId = 4 }, // Neuromancien - Cyberpunk
                new CategorieLivre { CategorieId = 2, LivreId = 5 }  // L'Étranger - Classique
            );

            // --- Utilisateurs ---
            modelBuilder.Entity<Utilisateur>().HasData(
                new Utilisateur { Id = 1, Nom = "Marc Tremblay", Courriel = "marc.tremblay@example.com" },
                new Utilisateur { Id = 2, Nom = "Julie Bouchard", Courriel = "julie.bouchard@example.com" }
            );

            // --- Emprunts ---
            modelBuilder.Entity<Emprunt>().HasData(
                new Emprunt
                {
                    Id = 1,
                    LivreId = 1,
                    UtilisateurId = 1,
                    DateEmprunt = new DateTime(2026, 1, 3),
                    DateRetour = new DateTime(2026, 1, 17)
                },
                new Emprunt
                {
                    Id = 2,
                    LivreId = 1,
                    UtilisateurId = 2,
                    DateEmprunt = new DateTime(2026, 3, 2),
                    DateRetour = new DateTime(2026, 3, 9)
                },
                new Emprunt
                {
                    Id = 3,
                    LivreId = 3, // Fondation
                    UtilisateurId = 1,
                    DateEmprunt = new DateTime(2026, 8, 15),
                    DateRetour = null // emprunt actif
                }
            );
        }
    }
}
