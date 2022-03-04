using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using move_ofertas.webAPI.Domains;

#nullable disable

namespace move_ofertas.webAPI.Contexts
{
    public partial class MoveOfertasContext : DbContext
    {
        public MoveOfertasContext()
        {
        }

        public MoveOfertasContext(DbContextOptions<MoveOfertasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Imagemofertum> Imagemoferta { get; set; }
        public virtual DbSet<Ofertum> Oferta { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<Tipousuario> Tipousuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=NOTE0113E1\\SQLEXPRESS; initial catalog=Move_Ofertas; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__CATEGORI__8A3D240C4A11CB6F");

                entity.ToTable("CATEGORIA");

                entity.HasIndex(e => e.NomeCategoria, "UQ__CATEGORI__8FC1D737A5D787C6")
                    .IsUnique();

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.NomeCategoria)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("nomeCategoria");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__CLIENTE__885457EE804CE056");

                entity.ToTable("CLIENTE");

                entity.HasIndex(e => e.Rg, "UQ__CLIENTE__321537C8FAB676DE")
                    .IsUnique();

                entity.HasIndex(e => e.NomeCliente, "UQ__CLIENTE__8182EFAEC70EAC9D")
                    .IsUnique();

                entity.HasIndex(e => e.Endereco, "UQ__CLIENTE__9456D406F6F6F625")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__CLIENTE__C1F897316D3A88F0")
                    .IsUnique();

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("CPF")
                    .IsFixedLength(true);

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("datetime")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeCliente)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeCliente");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("RG")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefone");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__CLIENTE__idUsuar__4D94879B");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__EMPRESA__75D2CED491A275EC");

                entity.ToTable("EMPRESA");

                entity.HasIndex(e => e.Telefone, "UQ__EMPRESA__2A16D97F27206F1D")
                    .IsUnique();

                entity.HasIndex(e => e.Endereco, "UQ__EMPRESA__9456D40650965E58")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial, "UQ__EMPRESA__9BF93A30A19150B4")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__EMPRESA__AA57D6B4E88D7D78")
                    .IsUnique();

                entity.HasIndex(e => e.NomeEmpresa, "UQ__EMPRESA__D79C08880ACD2724")
                    .IsUnique();

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeEmpresa)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeEmpresa");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("telefone");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__EMPRESA__idUsuar__46E78A0C");
            });

            modelBuilder.Entity<Imagemofertum>(entity =>
            {
                entity.ToTable("IMAGEMOFERTA");

                entity.HasIndex(e => e.IdOferta, "UQ__IMAGEMOF__05A1245FB86FB57F")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Binario)
                    .IsRequired()
                    .HasColumnName("binario");

                entity.Property(e => e.DataInclusao)
                    .HasColumnType("datetime")
                    .HasColumnName("data_inclusao")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdOferta).HasColumnName("idOferta");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mimeType");

                entity.Property(e => e.NomeArquivo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nomeArquivo");

                entity.HasOne(d => d.IdOfertaNavigation)
                    .WithOne(p => p.Imagemofertum)
                    .HasForeignKey<Imagemofertum>(d => d.IdOferta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__IMAGEMOFE__idOfe__5AEE82B9");
            });

            modelBuilder.Entity<Ofertum>(entity =>
            {
                entity.HasKey(e => e.IdOferta)
                    .HasName("PK__OFERTA__05A1245E4484B7CE");

                entity.ToTable("OFERTA");

                entity.Property(e => e.IdOferta).HasColumnName("idOferta");

                entity.Property(e => e.DataFabricacao)
                    .HasColumnType("date")
                    .HasColumnName("dataFabricacao");

                entity.Property(e => e.DataValidade)
                    .HasColumnType("date")
                    .HasColumnName("dataValidade");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(260)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.NomeProduto)
                    .IsRequired()
                    .HasMaxLength(160)
                    .IsUnicode(false)
                    .HasColumnName("nomeProduto");

                entity.Property(e => e.Quantidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("quantidade");

                entity.Property(e => e.Valor)
                    .HasColumnType("money")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__OFERTA__idCatego__5070F446");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__OFERTA__idEmpres__5165187F");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__OFERTA__idSituac__52593CB8");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__RESERVA__94D104C876578430");

                entity.ToTable("RESERVA");

                entity.Property(e => e.IdReserva).HasColumnName("idReserva");

                entity.Property(e => e.DataReserva)
                    .HasColumnType("datetime")
                    .HasColumnName("dataReserva");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdOferta).HasColumnName("idOferta");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__RESERVA__idClien__5535A963");

                entity.HasOne(d => d.IdOfertaNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdOferta)
                    .HasConstraintName("FK__RESERVA__idOfert__571DF1D5");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__RESERVA__idSitua__5629CD9C");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__SITUACAO__12AFD197D2436FA4");

                entity.ToTable("SITUACAO");

                entity.HasIndex(e => e.NomeSituacao, "UQ__SITUACAO__557603FFC4D12B7D")
                    .IsUnique();

                entity.Property(e => e.IdSituacao)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSituacao");

                entity.Property(e => e.NomeSituacao)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("nomeSituação");
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPOUSUA__03006BFF2D651F30");

                entity.ToTable("TIPOUSUARIO");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__TIPOUSUA__A017BD9F6AB849FA")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__645723A63E1A0424");

                entity.ToTable("USUARIO");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIO__idTipoU__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
