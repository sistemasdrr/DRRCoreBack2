using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Domain.Entities.MySqlContextFotos;

public partial class FotoContext : DbContext
{
    public FotoContext()
    {
    }

    public FotoContext(DbContextOptions<FotoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<REmpVsFoto> REmpVsFotos { get; set; }

    public virtual DbSet<RPerVsFoto> RPerVsFotos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=192.168.250.4;TLS Version=TLS 1.2;user id=dbrisre;password=K31@78va,.;database=Fotos;persist security info=True;SSL Mode=None;Convert Zero Datetime=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<REmpVsFoto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rEmpVsFoto");

            entity.HasIndex(e => e.EmCodigo, "Em_Codigo").IsUnique();

            entity.Property(e => e.EfLocal)
                .HasColumnType("mediumblob")
                .HasColumnName("EF_Local");
            entity.Property(e => e.EfLocal2)
                .HasColumnType("mediumblob")
                .HasColumnName("EF_Local2");
            entity.Property(e => e.EfLocal2txt)
                .HasMaxLength(200)
                .HasColumnName("EF_Local2txt");
            entity.Property(e => e.EfLocal2txtIng)
                .HasMaxLength(200)
                .HasColumnName("EF_Local2txt_Ing");
            entity.Property(e => e.EfLocal3)
                .HasColumnType("mediumblob")
                .HasColumnName("EF_Local3");
            entity.Property(e => e.EfLocal3txt)
                .HasMaxLength(200)
                .HasColumnName("EF_Local3txt");
            entity.Property(e => e.EfLocal3txtIng)
                .HasMaxLength(200)
                .HasColumnName("EF_Local3txt_Ing");
            entity.Property(e => e.EfLocal4)
                .HasColumnType("mediumblob")
                .HasColumnName("EF_Local4");
            entity.Property(e => e.EfLocal4txt)
                .HasMaxLength(200)
                .HasColumnName("EF_Local4txt");
            entity.Property(e => e.EfLocal4txtIng)
                .HasMaxLength(200)
                .HasColumnName("EF_Local4txt_Ing");
            entity.Property(e => e.EfLocalGnralTxt)
                .HasMaxLength(400)
                .HasColumnName("EF_Local_Gnral_txt");
            entity.Property(e => e.EfLocalGnralTxtIng)
                .HasMaxLength(400)
                .HasColumnName("EF_Local_Gnral_txt_Ing");
            entity.Property(e => e.EfLocaltxt)
                .HasMaxLength(200)
                .HasColumnName("EF_Localtxt");
            entity.Property(e => e.EfLocaltxtIng)
                .HasMaxLength(200)
                .HasColumnName("EF_Localtxt_Ing");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("Em_Codigo");
        });

        modelBuilder.Entity<RPerVsFoto>(entity =>
        {
            entity.HasKey(e => e.PeCodigo).HasName("PRIMARY");

            entity.ToTable("rPerVsFoto");

            entity.HasIndex(e => e.PeCodigo, "Pe_Codigo").IsUnique();

            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasDefaultValueSql("''")
                .HasColumnName("Pe_Codigo");
            entity.Property(e => e.PfFoto)
                .HasColumnType("mediumblob")
                .HasColumnName("PF_Foto");
            entity.Property(e => e.PfFoto2)
                .HasColumnType("mediumblob")
                .HasColumnName("PF_Foto2");
            entity.Property(e => e.PfFoto2Txt)
                .HasMaxLength(50)
                .HasColumnName("PF_Foto2_txt");
            entity.Property(e => e.PfFoto2TxtIng)
                .HasMaxLength(50)
                .HasColumnName("PF_Foto2_txt_Ing");
            entity.Property(e => e.PfFoto3)
                .HasColumnType("mediumblob")
                .HasColumnName("PF_Foto3");
            entity.Property(e => e.PfFoto3Txt)
                .HasMaxLength(50)
                .HasColumnName("PF_Foto3_txt");
            entity.Property(e => e.PfFoto3TxtIng)
                .HasMaxLength(50)
                .HasColumnName("PF_Foto3_txt_Ing");
            entity.Property(e => e.PfFotoTxt)
                .HasMaxLength(50)
                .HasColumnName("PF_Foto_txt");
            entity.Property(e => e.PfFotoTxtIng)
                .HasMaxLength(50)
                .HasColumnName("PF_Foto_txt_Ing");
            entity.Property(e => e.PfImprimir)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .IsFixedLength()
                .HasColumnName("PF_Imprimir");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
