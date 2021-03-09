using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataBaseFirst.Models
{
    public partial class dbpdvContext : DbContext
    {
        public dbpdvContext()
        {
        }

        public dbpdvContext(DbContextOptions<dbpdvContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fornecedore> Fornecedores { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<ProdutosFornecedore> ProdutosFornecedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MAQ18\\SQLEXPRESS;Initial Catalog=dbpdv;Persist Security Info=True;User ID=sa;Password=21044321");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Fornecedore>(entity =>
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
            });

            modelBuilder.Entity<ProdutosFornecedore>(entity =>
            {
                entity.HasKey(e => new { e.IdProduto, e.IdFornec, e.FornecCodProd, e.FornecEanTrib });

                entity.ToTable("Produtos_Fornecedores");

                entity.Property(e => e.FornecCodProd)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FornecEanTrib)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFornecNavigation)
                    .WithMany(p => p.ProdutosFornecedores)
                    .HasForeignKey(d => d.IdFornec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produtos_Fornecedores_Fornec");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ProdutosFornecedores)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produtos_Fornecedores_Prod");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
