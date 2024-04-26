using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Domain.Entities.SQLContext;

public partial class DbA9ccf0AdmindrrContext : DbContext
{
    public DbA9ccf0AdmindrrContext()
    {
    }

    public DbA9ccf0AdmindrrContext(DbContextOptions<DbA9ccf0AdmindrrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApiHistory> ApiHistories { get; set; }

    public virtual DbSet<ApiUser> ApiUsers { get; set; }

    public virtual DbSet<AttachmentsNotSend> AttachmentsNotSends { get; set; }

    public virtual DbSet<CompanyImage> CompanyImages { get; set; }

    public virtual DbSet<EmailConfiguration> EmailConfigurations { get; set; }

    public virtual DbSet<EmailHistory> EmailHistories { get; set; }

    public virtual DbSet<WebQuery> WebQueries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=sql5063.site4now.net;Initial Catalog=db_a9ccf0_admindrr;User ID=db_a9ccf0_admindrr_admin;Password=drrti2023;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiHistory>(entity =>
        {
            entity.HasKey(e => e.IdApiHistory).HasName("PK__ApiHisto__390D0AC989B0E817");

            entity.ToTable("ApiHistory");

            entity.Property(e => e.IdApiHistory).HasColumnName("idApiHistory");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdApiUser).HasColumnName("idApiUser");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("insertDate");
            entity.Property(e => e.Languaje)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('EN')")
                .HasColumnName("languaje");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.Search)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("search");
            entity.Property(e => e.Success).HasColumnName("success");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdApiUserNavigation).WithMany(p => p.ApiHistories)
                .HasForeignKey(d => d.IdApiUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ApiHistor__idApi__282DF8C2");
        });

        modelBuilder.Entity<ApiUser>(entity =>
        {
            entity.HasKey(e => e.IdApiUser).HasName("PK__ApiUser__11F8EBB83303C561");

            entity.ToTable("ApiUser");

            entity.Property(e => e.IdApiUser).HasColumnName("idApiUser");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.CodigoAbonado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigoAbonado");
            entity.Property(e => e.Enable)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.Environment)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("environment");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("insertDate");
            entity.Property(e => e.Token)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("token");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<AttachmentsNotSend>(entity =>
        {
            entity.HasKey(e => e.IdAttachmentsNotSend).HasName("PK__Attachme__7F41A4DD1143FDB6");

            entity.ToTable("AttachmentsNotSend");

            entity.Property(e => e.IdAttachmentsNotSend).HasColumnName("idAttachmentsNotSend");
            entity.Property(e => e.AttachmentsUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("attachmentsUrl");
            entity.Property(e => e.FileName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fileName");
            entity.Property(e => e.IdEmailHistory).HasColumnName("idEmailHistory");

            entity.HasOne(d => d.IdEmailHistoryNavigation).WithMany(p => p.AttachmentsNotSends)
                .HasForeignKey(d => d.IdEmailHistory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attachmen__idEma__2739D489");
        });

        modelBuilder.Entity<CompanyImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyI__3213E83FD8FA642A");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("deleteDate");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.Img1)
                .IsUnicode(false)
                .HasColumnName("img1");
            entity.Property(e => e.Img2)
                .IsUnicode(false)
                .HasColumnName("img2");
            entity.Property(e => e.Img3)
                .IsUnicode(false)
                .HasColumnName("img3");
            entity.Property(e => e.Img4)
                .IsUnicode(false)
                .HasColumnName("img4");
            entity.Property(e => e.ImgDesc1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("imgDesc1");
            entity.Property(e => e.ImgDesc2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("imgDesc2");
            entity.Property(e => e.ImgDesc3)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("imgDesc3");
            entity.Property(e => e.ImgDesc4)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("imgDesc4");
            entity.Property(e => e.ImgDescEng1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("imgDescEng1");
            entity.Property(e => e.ImgDescEng2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("imgDescEng2");
            entity.Property(e => e.ImgDescEng3)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("imgDescEng3");
            entity.Property(e => e.ImgDescEng4)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("imgDescEng4");
            entity.Property(e => e.ImgPrint1).HasColumnName("imgPrint1");
            entity.Property(e => e.ImgPrint2).HasColumnName("imgPrint2");
            entity.Property(e => e.ImgPrint3).HasColumnName("imgPrint3");
            entity.Property(e => e.ImgPrint4).HasColumnName("imgPrint4");
            entity.Property(e => e.LastUserUpdate).HasColumnName("lastUserUpdate");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<EmailConfiguration>(entity =>
        {
            entity.HasKey(e => e.IdEmailConfiguration).HasName("PK__EmailCon__23D609DB92657426");

            entity.ToTable("EmailConfiguration");

            entity.Property(e => e.IdEmailConfiguration).HasColumnName("idEmailConfiguration");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.FlagFooter).HasColumnName("flagFooter");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("insertDate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.Value)
                .IsUnicode(false)
                .HasColumnName("value");
        });

        modelBuilder.Entity<EmailHistory>(entity =>
        {
            entity.HasKey(e => e.IdEmailHistory).HasName("PK__EmailHis__E0A96BD4539068E0");

            entity.ToTable("EmailHistory");

            entity.Property(e => e.IdEmailHistory).HasColumnName("idEmailHistory");
            entity.Property(e => e.CcMails)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ccMails");
            entity.Property(e => e.CcoMails)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ccoMails");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Domain)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("domain");
            entity.Property(e => e.Enable)
                .HasDefaultValueSql("((1))")
                .HasColumnName("enable");
            entity.Property(e => e.FromMails)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("fromMails");
            entity.Property(e => e.Htmlbody)
                .IsUnicode(false)
                .HasColumnName("htmlbody");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("insertDate");
            entity.Property(e => e.InsertUser)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("insertUser");
            entity.Property(e => e.Subject)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("subject");
            entity.Property(e => e.Success).HasColumnName("success");
            entity.Property(e => e.ToMails)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("toMails");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.UpdateUser)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("updateUser");
        });

        modelBuilder.Entity<WebQuery>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.CodigoEmpresa }).HasName("PK__WebQuery__499C40374042DC7A");

            entity.ToTable("WebQuery");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CodigoEmpresa)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigoEmpresa");
            entity.Property(e => e.Actividad)
                .IsUnicode(false)
                .HasColumnName("actividad");
            entity.Property(e => e.ActividadIngles)
                .IsUnicode(false)
                .HasColumnName("actividadIngles");
            entity.Property(e => e.AnoFundacion)
                .IsUnicode(false)
                .HasColumnName("anoFundacion");
            entity.Property(e => e.Calidad)
                .IsUnicode(false)
                .HasColumnName("calidad");
            entity.Property(e => e.CalidadCodigo).HasColumnName("calidadCodigo");
            entity.Property(e => e.Ciudad)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.CodigoEmpresaWeb)
                .IsUnicode(false)
                .HasColumnName("codigoEmpresaWeb");
            entity.Property(e => e.CodigoIdioma).HasColumnName("codigoIdioma");
            entity.Property(e => e.Direccion)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Exporta)
                .IsUnicode(false)
                .HasColumnName("exporta");
            entity.Property(e => e.FechaBalance1)
                .IsUnicode(false)
                .HasColumnName("fechaBalance1");
            entity.Property(e => e.FechaBalance2)
                .IsUnicode(false)
                .HasColumnName("fechaBalance2");
            entity.Property(e => e.FechaBalance3)
                .IsUnicode(false)
                .HasColumnName("fechaBalance3");
            entity.Property(e => e.FechaInforme)
                .HasColumnType("datetime")
                .HasColumnName("fechaInforme");
            entity.Property(e => e.Importa)
                .IsUnicode(false)
                .HasColumnName("importa");
            entity.Property(e => e.Migrado)
                .HasDefaultValueSql("((1))")
                .HasColumnName("migrado");
            entity.Property(e => e.NombreEmpresa)
                .IsUnicode(false)
                .HasColumnName("nombreEmpresa");
            entity.Property(e => e.NumeroRegistro)
                .IsUnicode(false)
                .HasColumnName("numeroRegistro");
            entity.Property(e => e.Pais)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.PaisAbreviatura)
                .IsUnicode(false)
                .HasColumnName("paisAbreviatura");
            entity.Property(e => e.PaisCodigo)
                .IsUnicode(false)
                .HasColumnName("paisCodigo");
            entity.Property(e => e.PaisesExporta)
                .IsUnicode(false)
                .HasColumnName("paisesExporta");
            entity.Property(e => e.PaisesImporta)
                .IsUnicode(false)
                .HasColumnName("paisesImporta");
            entity.Property(e => e.Persona)
                .IsUnicode(false)
                .HasColumnName("persona");
            entity.Property(e => e.Ramo)
                .IsUnicode(false)
                .HasColumnName("ramo");
            entity.Property(e => e.RamoActividad)
                .IsUnicode(false)
                .HasColumnName("ramoActividad");
            entity.Property(e => e.RamoActividadIngles)
                .IsUnicode(false)
                .HasColumnName("ramoActividadIngles");
            entity.Property(e => e.RamoCodigo)
                .IsUnicode(false)
                .HasColumnName("ramoCodigo");
            entity.Property(e => e.RamoIngles)
                .IsUnicode(false)
                .HasColumnName("ramoIngles");
            entity.Property(e => e.Sector)
                .IsUnicode(false)
                .HasColumnName("sector");
            entity.Property(e => e.SectorIngles)
                .IsUnicode(false)
                .HasColumnName("sectorIngles");
            entity.Property(e => e.Telefono)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
