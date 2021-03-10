using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataBaseFirst.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ProdutoFornecedor> ProdutoFornecedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=MAQ18\\SQLEXPRESS;Initial Catalog=dbpdv;Persist Security Info=True;User ID=sa;Password=21044321");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasKey(e => e.IdFornec);

                entity.Property(e => e.NomeFornec)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto);

                entity.Property(e => e.NomeProd)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecoCusto).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.PrecoVenda).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.Quantidade).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.Unidade)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProdutoFornecedor>(entity =>
            {
                entity.HasKey(e => new { e.IdProduto, e.IdFornec, e.FornecCodProd, e.FornecEanTrib });

                entity.Property(e => e.FornecCodProd)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FornecEanTrib)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFornecNavigation)
                    .WithMany(p => p.ProdutoFornecedor)
                    .HasForeignKey(d => d.IdFornec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produtos_Fornecedores_Fornec");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ProdutoFornecedor)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produtos_Fornecedores_Prod");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
