using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DRRCore.Domain.Entities.MYSQLContext;

public partial class MySqlContext : DbContext
{
    public MySqlContext()
    {
    }

    public MySqlContext(DbContextOptions<MySqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<IntranetIncidencia> IntranetIncidencias { get; set; }

    public virtual DbSet<IntranetValore> IntranetValores { get; set; }

    public virtual DbSet<MAbonado> MAbonados { get; set; }

    public virtual DbSet<MAgente> MAgentes { get; set; }

    public virtual DbSet<MAuditorium> MAuditoria { get; set; }

    public virtual DbSet<MBanco> MBancos { get; set; }

    public virtual DbSet<MCliente> MClientes { get; set; }

    public virtual DbSet<MEmpRegVsProv> MEmpRegVsProvs { get; set; }

    public virtual DbSet<MEmpresa> MEmpresas { get; set; }

    public virtual DbSet<MEmpresaB> MEmpresaBs { get; set; }

    public virtual DbSet<MEmpresaC> MEmpresaCs { get; set; }

    public virtual DbSet<MEmpresaNoWeb> MEmpresaNoWebs { get; set; }

    public virtual DbSet<MEmpresaRegistro> MEmpresaRegistros { get; set; }

    public virtual DbSet<MPersona> MPersonas { get; set; }

    public virtual DbSet<MPersonal> MPersonals { get; set; }

    public virtual DbSet<MPivot> MPivots { get; set; }

    public virtual DbSet<MTiendaDrr> MTiendaDrrs { get; set; }

    public virtual DbSet<MUsuVsEmp> MUsuVsEmps { get; set; }

    public virtual DbSet<MUsuarioRegistrado> MUsuarioRegistrados { get; set; }

    public virtual DbSet<OlRAccionista> OlRAccionistas { get; set; }

    public virtual DbSet<OlREmpVsB> OlREmpVsBs { get; set; }

    public virtual DbSet<OlREmpVsBa> OlREmpVsBas { get; set; }

    public virtual DbSet<OlREmpVsBc> OlREmpVsBcs { get; set; }

    public virtual DbSet<OlREmpVsBi> OlREmpVsBis { get; set; }

    public virtual DbSet<OlREmpVsEmp> OlREmpVsEmps { get; set; }

    public virtual DbSet<OlREmpVsEmpPj> OlREmpVsEmpPjs { get; set; }

    public virtual DbSet<OlREmpVsExp> OlREmpVsExps { get; set; }

    public virtual DbSet<OlREmpVsFoto> OlREmpVsFotos { get; set; }

    public virtual DbSet<OlREmpVsFotoIndicadore> OlREmpVsFotoIndicadores { get; set; }

    public virtual DbSet<OlREmpVsImp> OlREmpVsImps { get; set; }

    public virtual DbSet<OlREmpVsLit> OlREmpVsLits { get; set; }

    public virtual DbSet<OlREmpVsMorCom> OlREmpVsMorComs { get; set; }

    public virtual DbSet<OlREmpVsPer> OlREmpVsPers { get; set; }

    public virtual DbSet<OlREmpVsProAcep> OlREmpVsProAceps { get; set; }

    public virtual DbSet<OlREmpVsProv> OlREmpVsProvs { get; set; }

    public virtual DbSet<OlREmpVsProvSec> OlREmpVsProvSecs { get; set; }

    public virtual DbSet<OlREmpVsRepCom> OlREmpVsRepComs { get; set; }

    public virtual DbSet<OlREmpVsSbd> OlREmpVsSbds { get; set; }

    public virtual DbSet<OlTCiiu1> OlTCiiu1s { get; set; }

    public virtual DbSet<OlTCiiu2> OlTCiiu2s { get; set; }

    public virtual DbSet<OlTTempBalanceEmpresa> OlTTempBalanceEmpresas { get; set; }

    public virtual DbSet<OlTTempSeguro> OlTTempSeguros { get; set; }

    public virtual DbSet<OlTTemporalEmpresa> OlTTemporalEmpresas { get; set; }

    public virtual DbSet<RAboBan> RAboBans { get; set; }

    public virtual DbSet<RAboVsCup> RAboVsCups { get; set; }

    public virtual DbSet<RAboVsIng> RAboVsIngs { get; set; }

    public virtual DbSet<RCupVsAbo> RCupVsAbos { get; set; }

    public virtual DbSet<RCuponesOffLine> RCuponesOffLines { get; set; }

    public virtual DbSet<REmpBvsPro> REmpBvsPros { get; set; }

    public virtual DbSet<REmpBvsVta> REmpBvsVtas { get; set; }

    public virtual DbSet<REmpVsAct> REmpVsActs { get; set; }

    public virtual DbSet<REmpVsAspLeg> REmpVsAspLegs { get; set; }

    public virtual DbSet<REmpVsB> REmpVsBs { get; set; }

    public virtual DbSet<REmpVsBa> REmpVsBas { get; set; }

    public virtual DbSet<REmpVsBc> REmpVsBcs { get; set; }

    public virtual DbSet<REmpVsBi> REmpVsBis { get; set; }

    public virtual DbSet<REmpVsEmp> REmpVsEmps { get; set; }

    public virtual DbSet<REmpVsExp> REmpVsExps { get; set; }

    public virtual DbSet<REmpVsImp> REmpVsImps { get; set; }

    public virtual DbSet<REmpVsInfFin> REmpVsInfFins { get; set; }

    public virtual DbSet<REmpVsLit> REmpVsLits { get; set; }

    public virtual DbSet<REmpVsMorCom> REmpVsMorComs { get; set; }

    public virtual DbSet<REmpVsPe> REmpVsPes { get; set; }

    public virtual DbSet<REmpVsPeAnt> REmpVsPeAnts { get; set; }

    public virtual DbSet<REmpVsPeBk> REmpVsPeBks { get; set; }

    public virtual DbSet<REmpVsProAcep> REmpVsProAceps { get; set; }

    public virtual DbSet<REmpVsProAcepC> REmpVsProAcepCs { get; set; }

    public virtual DbSet<REmpVsProv> REmpVsProvs { get; set; }

    public virtual DbSet<REmpVsProvB> REmpVsProvBs { get; set; }

    public virtual DbSet<REmpVsRamNeg> REmpVsRamNegs { get; set; }

    public virtual DbSet<REmpVsRep> REmpVsReps { get; set; }

    public virtual DbSet<REmpVsSb> REmpVsSbs { get; set; }

    public virtual DbSet<REmpVsSbd> REmpVsSbds { get; set; }

    public virtual DbSet<REmpVsSbdB> REmpVsSbdBs { get; set; }

    public virtual DbSet<REmpVsSbdC> REmpVsSbdCs { get; set; }

    public virtual DbSet<REmpVsSe> REmpVsSes { get; set; }

    public virtual DbSet<REmpVsVenta> REmpVsVentas { get; set; }

    public virtual DbSet<REmpVsVentasB> REmpVsVentasBs { get; set; }

    public virtual DbSet<RPerVsBc> RPerVsBcs { get; set; }

    public virtual DbSet<RPerVsBi> RPerVsBis { get; set; }

    public virtual DbSet<RPerVsEr> RPerVsErs { get; set; }

    public virtual DbSet<RPerVsLit> RPerVsLits { get; set; }

    public virtual DbSet<RPerVsMorCom> RPerVsMorComs { get; set; }

    public virtual DbSet<RPerVsProAcep> RPerVsProAceps { get; set; }

    public virtual DbSet<RPerVsProv> RPerVsProvs { get; set; }

    public virtual DbSet<RPerVsRep> RPerVsReps { get; set; }

    public virtual DbSet<RPerVsSbd> RPerVsSbds { get; set; }

    public virtual DbSet<RPerVsTrab> RPerVsTrabs { get; set; }

    public virtual DbSet<RUsuVsGuid> RUsuVsGuids { get; set; }

    public virtual DbSet<RUsuVsIng> RUsuVsIngs { get; set; }

    public virtual DbSet<ResumenMensual> ResumenMensuals { get; set; }

    public virtual DbSet<TAboVsKardex> TAboVsKardices { get; set; }

    public virtual DbSet<TAbonadoCupon> TAbonadoCupons { get; set; }

    public virtual DbSet<TAbonadoCuponera> TAbonadoCuponeras { get; set; }

    public virtual DbSet<TAbonadoTalonario> TAbonadoTalonarios { get; set; }

    public virtual DbSet<TActCom> TActComs { get; set; }

    public virtual DbSet<TAlerta> TAlertas { get; set; }

    public virtual DbSet<TAsigAgen> TAsigAgens { get; set; }

    public virtual DbSet<TAsigDig> TAsigDigs { get; set; }

    public virtual DbSet<TAsigRep> TAsigReps { get; set; }

    public virtual DbSet<TAsigSup> TAsigSups { get; set; }

    public virtual DbSet<TAsigTrad> TAsigTrads { get; set; }

    public virtual DbSet<TAsigVirtual> TAsigVirtuals { get; set; }

    public virtual DbSet<TAuditorium> TAuditoria { get; set; }

    public virtual DbSet<TCabEmpAval> TCabEmpAvals { get; set; }

    public virtual DbSet<TCabFactAbonado> TCabFactAbonados { get; set; }

    public virtual DbSet<TCabFactAgente> TCabFactAgentes { get; set; }

    public virtual DbSet<TCabNcabonado> TCabNcabonados { get; set; }

    public virtual DbSet<TCabObservacion> TCabObservacions { get; set; }

    public virtual DbSet<TCalidad> TCalidads { get; set; }

    public virtual DbSet<TCalifRef> TCalifRefs { get; set; }

    public virtual DbSet<TCalifSic> TCalifSics { get; set; }

    public virtual DbSet<TCampoValidacion> TCampoValidacions { get; set; }

    public virtual DbSet<TCargo> TCargos { get; set; }

    public virtual DbSet<TCatCiiu> TCatCiius { get; set; }

    public virtual DbSet<TCiiu> TCiius { get; set; }

    public virtual DbSet<TClaSoc> TClaSocs { get; set; }

    public virtual DbSet<TClasif> TClasifs { get; set; }

    public virtual DbSet<TComentProv> TComentProvs { get; set; }

    public virtual DbSet<TComentProvVario> TComentProvVarios { get; set; }

    public virtual DbSet<TComplemento> TComplementos { get; set; }

    public virtual DbSet<TConGen> TConGens { get; set; }

    public virtual DbSet<TConciliacionDeCuentum> TConciliacionDeCuenta { get; set; }

    public virtual DbSet<TConclusion> TConclusions { get; set; }

    public virtual DbSet<TConsulta> TConsultas { get; set; }

    public virtual DbSet<TConsultasTipo> TConsultasTipos { get; set; }

    public virtual DbSet<TContinente> TContinentes { get; set; }

    public virtual DbSet<TControlAsignacione> TControlAsignaciones { get; set; }

    public virtual DbSet<TControlCambio> TControlCambios { get; set; }

    public virtual DbSet<TCumplimiento> TCumplimientos { get; set; }

    public virtual DbSet<TCupon> TCupons { get; set; }

    public virtual DbSet<TCupon2> TCupon2s { get; set; }

    public virtual DbSet<TCupon3> TCupon3s { get; set; }

    public virtual DbSet<TCuponDatoAdicional> TCuponDatoAdicionals { get; set; }

    public virtual DbSet<TCuponTiendum> TCuponTienda { get; set; }

    public virtual DbSet<TDetEmpAval> TDetEmpAvals { get; set; }

    public virtual DbSet<TDetFactAbonado> TDetFactAbonados { get; set; }

    public virtual DbSet<TDetFactAgente> TDetFactAgentes { get; set; }

    public virtual DbSet<TDetObservacion> TDetObservacions { get; set; }

    public virtual DbSet<TDireccion> TDireccions { get; set; }

    public virtual DbSet<TEmpresaExc> TEmpresaExcs { get; set; }

    public virtual DbSet<TEmpresaTipoB> TEmpresaTipoBs { get; set; }

    public virtual DbSet<TEstCiv> TEstCivs { get; set; }

    public virtual DbSet<TEstLitigio> TEstLitigios { get; set; }

    public virtual DbSet<TEstOpiCred> TEstOpiCreds { get; set; }

    public virtual DbSet<TEstPer> TEstPers { get; set; }

    public virtual DbSet<TEstRegTribPer> TEstRegTribPers { get; set; }

    public virtual DbSet<TEstado> TEstados { get; set; }

    public virtual DbSet<TEstadoCupon> TEstadoCupons { get; set; }

    public virtual DbSet<TFactura> TFacturas { get; set; }

    public virtual DbSet<TGasAdmi> TGasAdmis { get; set; }

    public virtual DbSet<TGraCol> TGraCols { get; set; }

    public virtual DbSet<THistorico> THistoricos { get; set; }

    public virtual DbSet<TIdioma> TIdiomas { get; set; }

    public virtual DbSet<TJuridi> TJuridis { get; set; }

    public virtual DbSet<TKardex> TKardices { get; set; }

    public virtual DbSet<TKardexTalonario> TKardexTalonarios { get; set; }

    public virtual DbSet<TLocal> TLocals { get; set; }

    public virtual DbSet<TMatSub> TMatSubs { get; set; }

    public virtual DbSet<TMonedum> TMoneda { get; set; }

    public virtual DbSet<TNovedade> TNovedades { get; set; }

    public virtual DbSet<TObservacionTipo> TObservacionTipos { get; set; }

    public virtual DbSet<TOpcionSitFin> TOpcionSitFins { get; set; }

    public virtual DbSet<TOrdenReg> TOrdenRegs { get; set; }

    public virtual DbSet<TPago> TPagos { get; set; }

    public virtual DbSet<TPai> TPais { get; set; }

    public virtual DbSet<TParamSistema> TParamSistemas { get; set; }

    public virtual DbSet<TPartPoli> TPartPolis { get; set; }

    public virtual DbSet<TPrecioAbonado> TPrecioAbonados { get; set; }

    public virtual DbSet<TPrecioAgente> TPrecioAgentes { get; set; }

    public virtual DbSet<TPrecioAgenteExcepcionale> TPrecioAgenteExcepcionales { get; set; }

    public virtual DbSet<TPrecioRepEspecial> TPrecioRepEspecials { get; set; }

    public virtual DbSet<TPrecioTramite> TPrecioTramites { get; set; }

    public virtual DbSet<TProfesion> TProfesions { get; set; }

    public virtual DbSet<TRamo> TRamos { get; set; }

    public virtual DbSet<TRamoA> TRamoAs { get; set; }

    public virtual DbSet<TRamoB> TRamoBs { get; set; }

    public virtual DbSet<TRelacion> TRelacions { get; set; }

    public virtual DbSet<TRepCom> TRepComs { get; set; }

    public virtual DbSet<TRubro> TRubros { get; set; }

    public virtual DbSet<TSector> TSectors { get; set; }

    public virtual DbSet<TSectorEconomico> TSectorEconomicos { get; set; }

    public virtual DbSet<TSexo> TSexos { get; set; }

    public virtual DbSet<TSiNo> TSiNos { get; set; }

    public virtual DbSet<TSitFin> TSitFins { get; set; }

    public virtual DbSet<TSituacion> TSituacions { get; set; }

    public virtual DbSet<TSueldoPersonal> TSueldoPersonals { get; set; }

    public virtual DbSet<TTamano> TTamanos { get; set; }

    public virtual DbSet<TTempBalanceEmp> TTempBalanceEmps { get; set; }

    public virtual DbSet<TTempBalanceEmpresa> TTempBalanceEmpresas { get; set; }

    public virtual DbSet<TTempImprimirListadoPersona> TTempImprimirListadoPersonas { get; set; }

    public virtual DbSet<TTemporalCostosGenerale> TTemporalCostosGenerales { get; set; }

    public virtual DbSet<TTemporalDetallePedido> TTemporalDetallePedidos { get; set; }

    public virtual DbSet<TTemporalEmpresa> TTemporalEmpresas { get; set; }

    public virtual DbSet<TTemporalPersona> TTemporalPersonas { get; set; }

    public virtual DbSet<TTenden> TTendens { get; set; }

    public virtual DbSet<TTipDocIden> TTipDocIdens { get; set; }

    public virtual DbSet<TTipoLocal> TTipoLocals { get; set; }

    public virtual DbSet<TTipoTramite> TTipoTramites { get; set; }

    public virtual DbSet<TTmpEmpresa> TTmpEmpresas { get; set; }

    public virtual DbSet<TTop> TTops { get; set; }

    public virtual DbSet<TUsuario> TUsuarios { get; set; }

    public virtual DbSet<TUsuario2> TUsuario2s { get; set; }

    public virtual DbSet<TUsuarioWeb> TUsuarioWebs { get; set; }

    public virtual DbSet<TVirtual> TVirtuals { get; set; }

    public virtual DbSet<TViviendaPer> TViviendaPers { get; set; }

    public virtual DbSet<Tempo> Tempos { get; set; }

    public virtual DbSet<TemporalE> TemporalEs { get; set; }

    public virtual DbSet<TemporalP> TemporalPs { get; set; }

    public virtual DbSet<TemporalV> TemporalVs { get; set; }

    public virtual DbSet<ViewConsultaWeb> ViewConsultaWebs { get; set; }

    public virtual DbSet<WsConsulta> WsConsultas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=192.168.250.4;TLS Version=TLS 1.2;user id=dbrisre;password=K31@78va,.;database=DBSystemDelRisco;persist security info=True;SSL Mode=None;Convert Zero Datetime=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //server=170.0.82.60
        modelBuilder.Entity<IntranetIncidencia>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Intranet_Incidencias");

            entity.Property(e => e.Flag).HasColumnType("smallint(6)");
            entity.Property(e => e.IncArea)
                .HasMaxLength(100)
                .HasColumnName("inc_Area");
            entity.Property(e => e.IncAsunto)
                .HasMaxLength(200)
                .HasColumnName("inc_Asunto");
            entity.Property(e => e.IncCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("inc_Codigo");
            entity.Property(e => e.IncConsulta)
                .HasColumnType("text")
                .HasColumnName("inc_Consulta");
            entity.Property(e => e.IncCorreoDe)
                .HasMaxLength(100)
                .HasColumnName("inc_CorreoDe");
            entity.Property(e => e.IncCorreoPara)
                .HasColumnType("text")
                .HasColumnName("inc_CorreoPara");
            entity.Property(e => e.IncFecha)
                .HasColumnType("datetime")
                .HasColumnName("inc_Fecha");
            entity.Property(e => e.IncSolu)
                .HasColumnType("text")
                .HasColumnName("inc_Solu");
            entity.Property(e => e.IncSoluFecha)
                .HasColumnType("datetime")
                .HasColumnName("inc_SoluFecha");
            entity.Property(e => e.IncSoluUsCodigo)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("inc_SoluUS_CODIGO");
            entity.Property(e => e.IncStatus)
                .HasColumnType("smallint(6)")
                .HasColumnName("inc_Status");
            entity.Property(e => e.IncTipo)
                .HasColumnType("smallint(6)")
                .HasColumnName("inc_Tipo");
            entity.Property(e => e.IncUsCodigo)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("inc_US_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<IntranetValore>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Intranet_Valores");

            entity.Property(e => e.Flag).HasColumnType("int(11)");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.ValCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("val_Codigo");
            entity.Property(e => e.ValGrupo)
                .HasColumnType("int(11)")
                .HasColumnName("val_Grupo");
            entity.Property(e => e.ValImagen)
                .HasMaxLength(100)
                .HasColumnName("val_Imagen");
            entity.Property(e => e.ValItem)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("val_Item");
            entity.Property(e => e.ValNombre)
                .HasMaxLength(50)
                .HasColumnName("val_Nombre");
        });

        modelBuilder.Entity<MAbonado>(entity =>
        {
            entity.HasKey(e => e.AboCodigo).HasName("PRIMARY");

            entity.ToTable("mAbonado", tb => tb.HasComment("Tabla De Abonados"));

            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.AboActivo)
                .HasMaxLength(1)
                .HasColumnName("ABO_ACTIVO");
            entity.Property(e => e.AboCiudad)
                .HasMaxLength(200)
                .HasColumnName("ABO_CIUDAD");
            entity.Property(e => e.AboContac)
                .HasMaxLength(200)
                .HasColumnName("ABO_CONTAC");
            entity.Property(e => e.AboContac2)
                .HasMaxLength(200)
                .HasColumnName("ABO_CONTAC2");
            entity.Property(e => e.AboCremax)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("ABO_CREMAX");
            entity.Property(e => e.AboCupone)
                .HasMaxLength(2)
                .HasDefaultValueSql("'No'")
                .HasComment("Talonario.... Si o No")
                .HasColumnName("ABO_CUPONE");
            entity.Property(e => e.AboDescri)
                .HasMaxLength(25)
                .HasColumnName("ABO_DESCRI");
            entity.Property(e => e.AboDirecc)
                .HasMaxLength(200)
                .HasColumnName("ABO_DIRECC");
            entity.Property(e => e.AboEmail)
                .HasMaxLength(50)
                .HasColumnName("ABO_EMAIL");
            entity.Property(e => e.AboEmailc2)
                .HasMaxLength(100)
                .HasColumnName("ABO_EMAILC2");
            entity.Property(e => e.AboEmailci)
                .HasMaxLength(100)
                .HasColumnName("ABO_EMAILCI");
            entity.Property(e => e.AboEmailfact)
                .HasMaxLength(100)
                .HasColumnName("ABO_EMAILFACT");
            entity.Property(e => e.AboFacpara)
                .HasMaxLength(500)
                .HasColumnName("ABO_FACPARA");
            entity.Property(e => e.AboFax)
                .HasMaxLength(50)
                .HasColumnName("ABO_FAX");
            entity.Property(e => e.AboFeccre)
                .HasMaxLength(20)
                .HasColumnName("ABO_FECCRE");
            entity.Property(e => e.AboFecult)
                .HasColumnType("datetime")
                .HasColumnName("ABO_FECULT");
            entity.Property(e => e.AboIndica)
                .HasColumnType("mediumtext")
                .HasColumnName("ABO_INDICA");
            entity.Property(e => e.AboInfpara)
                .HasMaxLength(500)
                .HasColumnName("ABO_INFPARA");
            entity.Property(e => e.AboLogin)
                .HasMaxLength(20)
                .HasColumnName("ABO_LOGIN");
            entity.Property(e => e.AboNombre)
                .HasMaxLength(80)
                .HasColumnName("ABO_NOMBRE");
            entity.Property(e => e.AboObserv)
                .HasMaxLength(800)
                .HasColumnName("ABO_OBSERV");
            entity.Property(e => e.AboPnonli)
                .HasMaxLength(2)
                .HasDefaultValueSql("'No'")
                .HasComment("Si - Precio Online ")
                .HasColumnName("ABO_PNONLI");
            entity.Property(e => e.AboPrffax)
                .HasMaxLength(8)
                .HasColumnName("ABO_PRFFAX");
            entity.Property(e => e.AboPrftel)
                .HasMaxLength(8)
                .HasColumnName("ABO_PRFTEL");
            entity.Property(e => e.AboPublic)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("ABO_PUBLIC");
            entity.Property(e => e.AboPwd)
                .HasMaxLength(20)
                .HasColumnName("ABO_PWD");
            entity.Property(e => e.AboRegtrib)
                .HasMaxLength(50)
                .HasColumnName("ABO_REGTRIB");
            entity.Property(e => e.AboRevnom)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("ABO_REVNOM");
            entity.Property(e => e.AboSiglas)
                .HasMaxLength(40)
                .HasColumnName("ABO_SIGLAS");
            entity.Property(e => e.AboTalona)
                .HasMaxLength(2)
                .HasDefaultValueSql("'No'")
                .HasColumnName("ABO_TALONA");
            entity.Property(e => e.AboTelefo)
                .HasMaxLength(50)
                .HasColumnName("ABO_TELEFO");
            entity.Property(e => e.AboTelefoc2)
                .HasMaxLength(100)
                .HasColumnName("ABO_TELEFOC2");
            entity.Property(e => e.AboTelefoci)
                .HasMaxLength(100)
                .HasColumnName("ABO_TELEFOCI");
            entity.Property(e => e.AboTelefofact)
                .HasMaxLength(100)
                .HasColumnName("ABO_TELEFOFACT");
            entity.Property(e => e.AboTipfac)
                .HasMaxLength(2)
                .HasColumnName("ABO_TIPFAC");
            entity.Property(e => e.AboTipo)
                .HasMaxLength(10)
                .HasColumnName("ABO_TIPO");
            entity.Property(e => e.AboWww)
                .HasMaxLength(50)
                .HasColumnName("ABO_WWW");
            entity.Property(e => e.IdiCodigo)
                .HasMaxLength(3)
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.MonCodigo)
                .HasMaxLength(3)
                .HasColumnName("MON_CODIGO");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.RubCodigo)
                .HasMaxLength(4)
                .HasColumnName("RUB_CODIGO");
        });

        modelBuilder.Entity<MAgente>(entity =>
        {
            entity.HasKey(e => e.AgeCodigo).HasName("PRIMARY");

            entity.ToTable("mAgente");

            entity.Property(e => e.AgeCodigo)
                .HasMaxLength(3)
                .HasColumnName("AGE_CODIGO");
            entity.Property(e => e.AgeAbo)
                .HasMaxLength(2)
                .HasColumnName("AGE_ABO");
            entity.Property(e => e.AgeActivo)
                .HasColumnType("int(1)")
                .HasColumnName("AGE_ACTIVO");
            entity.Property(e => e.AgeDirecc)
                .HasMaxLength(200)
                .HasColumnName("AGE_DIRECC");
            entity.Property(e => e.AgeEmail)
                .HasMaxLength(100)
                .HasColumnName("AGE_EMAIL");
            entity.Property(e => e.AgeEncarga)
                .HasMaxLength(200)
                .HasColumnName("AGE_ENCARGA");
            entity.Property(e => e.AgeExcepc)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .IsFixedLength()
                .HasColumnName("AGE_EXCEPC");
            entity.Property(e => e.AgeFax)
                .HasMaxLength(50)
                .HasColumnName("AGE_FAX");
            entity.Property(e => e.AgeFecing)
                .HasColumnType("datetime")
                .HasColumnName("AGE_FECING");
            entity.Property(e => e.AgeNombre)
                .HasMaxLength(120)
                .HasColumnName("AGE_NOMBRE");
            entity.Property(e => e.AgeObserv)
                .HasMaxLength(4000)
                .HasColumnName("AGE_OBSERV");
            entity.Property(e => e.AgeTelefo)
                .HasMaxLength(50)
                .HasColumnName("AGE_TELEFO");
            entity.Property(e => e.IdiCodigo)
                .HasMaxLength(3)
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
        });

        modelBuilder.Entity<MAuditorium>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("mAuditoria");

            entity.Property(e => e.Accion).HasMaxLength(6);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Flag).HasMaxLength(50);
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.UsLogin)
                .HasMaxLength(20)
                .HasColumnName("Us_Login");
            entity.Property(e => e.Valor1).HasMaxLength(50);
            entity.Property(e => e.Valor2).HasMaxLength(50);
        });

        modelBuilder.Entity<MBanco>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("mBanco");

            entity.HasIndex(e => e.BanCodigo, "BAN_CODIGO");

            entity.Property(e => e.BanCodigo)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("BAN_CODIGO");
            entity.Property(e => e.BanNombre)
                .HasMaxLength(100)
                .HasColumnName("BAN_NOMBRE");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<MCliente>(entity =>
        {
            entity.HasKey(e => e.CliCodigo).HasName("PRIMARY");

            entity.ToTable("mCliente", tb => tb.HasComment("Tabla De Clientes Web"));

            entity.Property(e => e.CliCodigo)
                .HasMaxLength(8)
                .HasColumnName("CLI_CODIGO");
            entity.Property(e => e.CliActivo)
                .HasMaxLength(1)
                .HasColumnName("CLI_ACTIVO");
            entity.Property(e => e.CliCiudad)
                .HasMaxLength(200)
                .HasColumnName("CLI_CIUDAD");
            entity.Property(e => e.CliContac)
                .HasMaxLength(200)
                .HasColumnName("CLI_CONTAC");
            entity.Property(e => e.CliContac2)
                .HasMaxLength(200)
                .HasColumnName("CLI_CONTAC2");
            entity.Property(e => e.CliCremax)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("CLI_CREMAX");
            entity.Property(e => e.CliCupone)
                .HasMaxLength(2)
                .HasDefaultValueSql("'No'")
                .HasComment("Talonario.... Si o No")
                .HasColumnName("CLI_CUPONE");
            entity.Property(e => e.CliDescri)
                .HasMaxLength(25)
                .HasColumnName("CLI_DESCRI");
            entity.Property(e => e.CliDirecc)
                .HasMaxLength(200)
                .HasColumnName("CLI_DIRECC");
            entity.Property(e => e.CliEmail)
                .HasMaxLength(50)
                .HasColumnName("CLI_EMAIL");
            entity.Property(e => e.CliEmailc2)
                .HasMaxLength(100)
                .HasColumnName("CLI_EMAILC2");
            entity.Property(e => e.CliEmailci)
                .HasMaxLength(100)
                .HasColumnName("CLI_EMAILCI");
            entity.Property(e => e.CliEmailfact)
                .HasMaxLength(100)
                .HasColumnName("CLI_EMAILFACT");
            entity.Property(e => e.CliFacpara)
                .HasMaxLength(500)
                .HasColumnName("CLI_FACPARA");
            entity.Property(e => e.CliFax)
                .HasMaxLength(50)
                .HasColumnName("CLI_FAX");
            entity.Property(e => e.CliFeccre)
                .HasMaxLength(20)
                .HasColumnName("CLI_FECCRE");
            entity.Property(e => e.CliFecult)
                .HasColumnType("datetime")
                .HasColumnName("CLI_FECULT");
            entity.Property(e => e.CliIndica)
                .HasColumnType("mediumtext")
                .HasColumnName("CLI_INDICA");
            entity.Property(e => e.CliInfpara)
                .HasMaxLength(500)
                .HasColumnName("CLI_INFPARA");
            entity.Property(e => e.CliLogin)
                .HasMaxLength(20)
                .HasColumnName("CLI_LOGIN");
            entity.Property(e => e.CliNombre)
                .HasMaxLength(80)
                .HasColumnName("CLI_NOMBRE");
            entity.Property(e => e.CliObserv)
                .HasMaxLength(800)
                .HasColumnName("CLI_OBSERV");
            entity.Property(e => e.CliPnonli)
                .HasMaxLength(2)
                .HasDefaultValueSql("'No'")
                .HasComment("Si - Precio Online ")
                .HasColumnName("CLI_PNONLI");
            entity.Property(e => e.CliPrffax)
                .HasMaxLength(8)
                .HasColumnName("CLI_PRFFAX");
            entity.Property(e => e.CliPrftel)
                .HasMaxLength(8)
                .HasColumnName("CLI_PRFTEL");
            entity.Property(e => e.CliPublic)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("CLI_PUBLIC");
            entity.Property(e => e.CliPwd)
                .HasMaxLength(20)
                .HasColumnName("CLI_PWD");
            entity.Property(e => e.CliRegtrib)
                .HasMaxLength(50)
                .HasColumnName("CLI_REGTRIB");
            entity.Property(e => e.CliRevnom)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("CLI_REVNOM");
            entity.Property(e => e.CliSiglas)
                .HasMaxLength(40)
                .HasColumnName("CLI_SIGLAS");
            entity.Property(e => e.CliTalona)
                .HasMaxLength(2)
                .HasDefaultValueSql("'No'")
                .HasColumnName("CLI_TALONA");
            entity.Property(e => e.CliTelefo)
                .HasMaxLength(50)
                .HasColumnName("CLI_TELEFO");
            entity.Property(e => e.CliTelefoc2)
                .HasMaxLength(100)
                .HasColumnName("CLI_TELEFOC2");
            entity.Property(e => e.CliTelefoci)
                .HasMaxLength(100)
                .HasColumnName("CLI_TELEFOCI");
            entity.Property(e => e.CliTelefofact)
                .HasMaxLength(100)
                .HasColumnName("CLI_TELEFOFACT");
            entity.Property(e => e.CliTipfac)
                .HasMaxLength(2)
                .HasColumnName("CLI_TIPFAC");
            entity.Property(e => e.CliTipo)
                .HasMaxLength(10)
                .HasColumnName("CLI_TIPO");
            entity.Property(e => e.CliWww)
                .HasMaxLength(50)
                .HasColumnName("CLI_WWW");
            entity.Property(e => e.IdiCodigo)
                .HasMaxLength(3)
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.MonCodigo)
                .HasMaxLength(3)
                .HasColumnName("MON_CODIGO");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.RubCodigo)
                .HasMaxLength(4)
                .HasColumnName("RUB_CODIGO");
        });

        modelBuilder.Entity<MEmpRegVsProv>(entity =>
        {
            entity.HasKey(e => e.PrCodigo).HasName("PRIMARY");

            entity.ToTable("mEmpRegVsProv");

            entity.Property(e => e.PrCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("PR_CODIGO");
            entity.Property(e => e.EpCodigoPai)
                .HasMaxLength(3)
                .HasColumnName("EP_CODIGO_PAI");
            entity.Property(e => e.EpNombre)
                .HasMaxLength(150)
                .HasColumnName("EP_NOMBRE");
            entity.Property(e => e.ErCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("ER_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<MEmpresa>(entity =>
        {
            entity.HasKey(e => e.EmCodigo).HasName("PRIMARY");

            entity.ToTable("mEmpresa");

            entity.HasIndex(e => e.EmCiudad, "EM_CIUDAD");

            entity.HasIndex(e => e.EmCodigo, "EM_CODIGO");

            entity.HasIndex(e => e.EmFecinf, "EM_FECDIG");

            entity.HasIndex(e => e.EmNombre, "EM_NOMBRE");

            entity.HasIndex(e => new { e.EmNombre, e.EmLogico }, "EM_NOMBRE_2");

            entity.HasIndex(e => e.EmRegtri, "EM_RUC");

            entity.HasIndex(e => e.EmSiglas, "EM_SIGLAS");

            entity.HasIndex(e => e.EmTelef1, "EM_TELEFO");

            entity.HasIndex(e => e.EmLogico, "mempresa_em_li");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasComment("Código Interno de la Empresa PRINCIPAL")
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.CalCodigo)
                .HasMaxLength(3)
                .HasDefaultValueSql("'10'")
                .HasComment("Calidad del Informe")
                .HasColumnName("CAL_CODIGO");
            entity.Property(e => e.CpCodigo)
                .HasMaxLength(2)
                .HasDefaultValueSql("'00'")
                .HasColumnName("CP_CODIGO");
            entity.Property(e => e.CrCodigo)
                .HasMaxLength(4)
                .HasDefaultValueSql("'0004'")
                .HasComment("Código de Clasificación <=TClasif")
                .HasColumnName("CR_CODIGO");
            entity.Property(e => e.CupFecped)
                .HasMaxLength(10)
                .HasComment("Fecha de Pedido")
                .HasColumnName("CUP_FECPED");
            entity.Property(e => e.CupIdioma)
                .HasMaxLength(3)
                .HasColumnName("CUP_IDIOMA");
            entity.Property(e => e.CupNroord)
                .HasMaxLength(20)
                .HasComment("Numero de Orden")
                .HasColumnName("CUP_NROORD");
            entity.Property(e => e.CupNroref)
                .HasMaxLength(80)
                .HasComment("Numero de Referencia")
                .HasColumnName("CUP_NROREF");
            entity.Property(e => e.CupTipinf)
                .HasMaxLength(4)
                .HasColumnName("CUP_TIPINF");
            entity.Property(e => e.DiCodigo)
                .HasMaxLength(4)
                .HasDefaultValueSql("'Z'")
                .HasColumnName("DI_CODIGO");
            entity.Property(e => e.EmActivo)
                .HasDefaultValueSql("'1'")
                .HasComment("Si es Activo 1 y se elimino es 2")
                .HasColumnType("int(1)")
                .HasColumnName("EM_ACTIVO");
            entity.Property(e => e.EmAnobal)
                .HasMaxLength(4)
                .HasColumnName("EM_ANOBAL");
            entity.Property(e => e.EmAnofun)
                .HasMaxLength(4)
                .HasColumnName("EM_ANOFUN");
            entity.Property(e => e.EmAntcre)
                .HasComment("Comentario de Antecedentes Crediticios")
                .HasColumnType("text")
                .HasColumnName("EM_ANTCRE");
            entity.Property(e => e.EmAntcreIng)
                .HasColumnType("text")
                .HasColumnName("EM_ANTCRE_ING");
            entity.Property(e => e.EmArrfin)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_ARRFIN");
            entity.Property(e => e.EmArrfinMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_ARRFIN_ME");
            entity.Property(e => e.EmAudito)
                .HasMaxLength(150)
                .HasColumnName("EM_AUDITO");
            entity.Property(e => e.EmBalgen)
                .HasDefaultValueSql("'0'")
                .HasComment("Si hay o no Balance General 0=No 1=Si")
                .HasColumnType("int(1)")
                .HasColumnName("EM_BALGEN");
            entity.Property(e => e.EmBalsit)
                .HasDefaultValueSql("'0'")
                .HasComment("Si hay o no Balance Situacional 0=No 1=Si")
                .HasColumnType("int(1)")
                .HasColumnName("EM_BALSIT");
            entity.Property(e => e.EmBanco)
                .HasComment("Comentarios de Banqueros")
                .HasColumnType("text")
                .HasColumnName("EM_BANCO");
            entity.Property(e => e.EmBancoIng)
                .HasColumnType("text")
                .HasColumnName("EM_BANCO_ING");
            entity.Property(e => e.EmCalsbs)
                .HasMaxLength(20)
                .HasComment("Calificacion SBS")
                .HasColumnName("EM_CALSBS");
            entity.Property(e => e.EmCalsbsIng)
                .HasMaxLength(20)
                .HasComment("Calificacion SBS en Ingles")
                .HasColumnName("EM_CALSBS_ING");
            entity.Property(e => e.EmCenrie)
                .HasComment("Comentario de Centrar de Riesgo")
                .HasColumnType("text")
                .HasColumnName("EM_CENRIE");
            entity.Property(e => e.EmCenrieIng)
                .HasColumnType("text")
                .HasColumnName("EM_CENRIE_ING");
            entity.Property(e => e.EmChkBanco)
                .HasMaxLength(2)
                .HasDefaultValueSql("'0'")
                .IsFixedLength()
                .HasComment("Check para ver si se agrega la frase o no")
                .HasColumnName("EM_CHK_BANCO");
            entity.Property(e => e.EmChkban)
                .HasMaxLength(1)
                .HasDefaultValueSql("'0'")
                .IsFixedLength()
                .HasComment("Check para ver si se agrega la frase o no")
                .HasColumnName("EM_CHKBAN");
            entity.Property(e => e.EmCiiu)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("EM_CIIU");
            entity.Property(e => e.EmCiudad)
                .HasMaxLength(50)
                .HasColumnName("EM_CIUDAD");
            entity.Property(e => e.EmCodpos)
                .HasMaxLength(20)
                .HasColumnName("EM_CODPOS");
            entity.Property(e => e.EmComenSup)
                .HasMaxLength(3000)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_COMEN_SUP");
            entity.Property(e => e.EmComexte)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_COMEXTE");
            entity.Property(e => e.EmComexteMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_COMEXTE_ME");
            entity.Property(e => e.EmComide)
                .HasComment("Comentario de Identificación")
                .HasColumnType("text")
                .HasColumnName("EM_COMIDE");
            entity.Property(e => e.EmComideIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMIDE_ING");
            entity.Property(e => e.EmComlit)
                .HasComment("Comentario de Litigios")
                .HasColumnType("text")
                .HasColumnName("EM_COMLIT");
            entity.Property(e => e.EmComlitIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMLIT_ING");
            entity.Property(e => e.EmComprov)
                .HasComment("Comentario de Proveedores")
                .HasColumnType("text")
                .HasColumnName("EM_COMPROV");
            entity.Property(e => e.EmComprovIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMPROV_ING");
            entity.Property(e => e.EmComrep)
                .HasComment("Comentario de Reputación")
                .HasColumnType("text")
                .HasColumnName("EM_COMREP");
            entity.Property(e => e.EmComrepIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMREP_ING");
            entity.Property(e => e.EmCrerec)
                .HasMaxLength(32)
                .HasColumnName("EM_CREREC");
            entity.Property(e => e.EmCrerecIng)
                .HasMaxLength(32)
                .HasColumnName("EM_CREREC_ING");
            entity.Property(e => e.EmDepart)
                .HasMaxLength(50)
                .HasColumnName("EM_DEPART");
            entity.Property(e => e.EmDescue)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_DESCUE");
            entity.Property(e => e.EmDescueMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_DESCUE_ME");
            entity.Property(e => e.EmDirecc)
                .HasMaxLength(200)
                .HasColumnName("EM_DIRECC");
            entity.Property(e => e.EmDistri)
                .HasMaxLength(50)
                .HasColumnName("EM_DISTRI");
            entity.Property(e => e.EmEmail)
                .HasMaxLength(200)
                .HasColumnName("EM_EMAIL");
            entity.Property(e => e.EmEstado)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasComment("Manera de Despacho (02Definitiva/03Preliminar)<= tConGen")
                .HasColumnName("EM_ESTADO");
            entity.Property(e => e.EmEstadoempresa)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("EM_ESTADOEMPRESA");
            entity.Property(e => e.EmFactor)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_FACTOR");
            entity.Property(e => e.EmFactorMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_FACTOR_ME");
            entity.Property(e => e.EmFax)
                .HasMaxLength(500)
                .HasColumnName("EM_FAX");
            entity.Property(e => e.EmFecact)
                .HasComment("Fecha de la Ultima Actualizacion")
                .HasColumnType("datetime")
                .HasColumnName("EM_FECACT");
            entity.Property(e => e.EmFecbalAnu)
                .HasMaxLength(10)
                .HasColumnName("EM_FECBAL_ANU");
            entity.Property(e => e.EmFecbalAnu2)
                .HasMaxLength(10)
                .HasColumnName("EM_FECBAL_ANU2");
            entity.Property(e => e.EmFecdes)
                .HasComment("Fecha de Despacho")
                .HasColumnType("datetime")
                .HasColumnName("EM_FECDES");
            entity.Property(e => e.EmFeceli)
                .HasComment("Fecha de Eliminación")
                .HasColumnType("datetime")
                .HasColumnName("EM_FECELI");
            entity.Property(e => e.EmFecinf)
                .HasComment("Fecha del Informe")
                .HasColumnType("datetime")
                .HasColumnName("EM_FECINF");
            entity.Property(e => e.EmFecini)
                .HasComment("Fecha de Inicio del Registro")
                .HasColumnType("datetime")
                .HasColumnName("EM_FECINI");
            entity.Property(e => e.EmFecmod)
                .HasComment("Fecha de ultima modificación")
                .HasColumnType("datetime")
                .HasColumnName("EM_FECMOD");
            entity.Property(e => e.EmFecref)
                .HasComment("Fecha de la Referencias")
                .HasColumnType("date")
                .HasColumnName("EM_FECREF");
            entity.Property(e => e.EmFecreg)
                .HasMaxLength(10)
                .HasComment("Fecha de Registro en la SBS")
                .HasColumnName("EM_FECREG");
            entity.Property(e => e.EmFecsbs)
                .HasMaxLength(10)
                .HasColumnName("EM_FECSBS");
            entity.Property(e => e.EmFectra)
                .HasComment("Fecha de Traducción")
                .HasColumnType("datetime")
                .HasColumnName("EM_FECTRA");
            entity.Property(e => e.EmFoto)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(3)")
                .HasColumnName("EM_FOTO");
            entity.Property(e => e.EmGaome)
                .HasDefaultValueSql("'0'")
                .HasColumnName("EM_GAOME");
            entity.Property(e => e.EmGaomn)
                .HasDefaultValueSql("'0'")
                .HasColumnName("EM_GAOMN");
            entity.Property(e => e.EmInfgen)
                .HasComment("Informacion General")
                .HasColumnType("text")
                .HasColumnName("EM_INFGEN");
            entity.Property(e => e.EmInfgenIng)
                .HasColumnType("text")
                .HasColumnName("EM_INFGEN_ING");
            entity.Property(e => e.EmInfgenrtf)
                .HasColumnType("text")
                .HasColumnName("EM_INFGENRTF");
            entity.Property(e => e.EmIngecu)
                .HasComment("Informacion General Tabulado")
                .HasColumnType("text")
                .HasColumnName("EM_INGECU");
            entity.Property(e => e.EmIngecuIng)
                .HasColumnType("text")
                .HasColumnName("EM_INGECU_ING");
            entity.Property(e => e.EmLaspleg)
                .HasDefaultValueSql("'0'")
                .HasComment("Indicador Log de Aspectos Legales")
                .HasColumnType("int(4)")
                .HasColumnName("EM_LASPLEG");
            entity.Property(e => e.EmLbalanc)
                .HasDefaultValueSql("'0'")
                .HasComment("Indicador Log de Balances")
                .HasColumnType("int(4)")
                .HasColumnName("EM_LBALANC");
            entity.Property(e => e.EmLdatgen)
                .HasDefaultValueSql("'0'")
                .HasComment("Indicador Log de Datos Generales")
                .HasColumnType("int(4)")
                .HasColumnName("EM_LDATGEN");
            entity.Property(e => e.EmLeabac)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_LEABAC");
            entity.Property(e => e.EmLeabacMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_LEABAC_ME");
            entity.Property(e => e.EmLinffin)
                .HasDefaultValueSql("'0'")
                .HasComment("Indicador Log de Información Financiera")
                .HasColumnType("int(4)")
                .HasColumnName("EM_LINFFIN");
            entity.Property(e => e.EmLogantleg)
                .HasComment("0-> No hay datos\r\n1-> Si Hay datos")
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGANTLEG");
            entity.Property(e => e.EmLogbalance)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGBALANCE");
            entity.Property(e => e.EmLogbalsit)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGBALSIT");
            entity.Property(e => e.EmLogbanque)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGBANQUE");
            entity.Property(e => e.EmLogcenrie)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGCENRIE");
            entity.Property(e => e.EmLogcuatab)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGCUATAB");
            entity.Property(e => e.EmLoggrafico)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGGRAFICO");
            entity.Property(e => e.EmLogico)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("Identificador de Informe")
                .HasColumnName("EM_LOGICO");
            entity.Property(e => e.EmLogicoB)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("EM_LOGICO_B");
            entity.Property(e => e.EmLogicoC)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("EM_LOGICO_C");
            entity.Property(e => e.EmLogimagen)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGIMAGEN");
            entity.Property(e => e.EmLoginffin)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGINFFIN");
            entity.Property(e => e.EmLoglitigio)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGLITIGIO");
            entity.Property(e => e.EmLogpagos)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGPAGOS");
            entity.Property(e => e.EmLogpre)
                .HasDefaultValueSql("'0'")
                .HasComment("Indicador Log de Prensa (Em_ObsGen)")
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGPRE");
            entity.Property(e => e.EmLogprove)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGPROVE");
            entity.Property(e => e.EmLogramneg)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGRAMNEG");
            entity.Property(e => e.EmLogventas)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGVENTAS");
            entity.Property(e => e.EmLpagban)
                .HasDefaultValueSql("'0'")
                .HasComment("Indicador Log de Pagos y Bancos")
                .HasColumnType("int(4)")
                .HasColumnName("EM_LPAGBAN");
            entity.Property(e => e.EmLramneg)
                .HasDefaultValueSql("'0'")
                .HasComment("Indicador Log de Ramo de Negocios")
                .HasColumnType("int(4)")
                .HasColumnName("EM_LRAMNEG");
            entity.Property(e => e.EmMatriz)
                .HasMaxLength(150)
                .HasColumnName("EM_MATRIZ");
            entity.Property(e => e.EmMoteli)
                .HasComment("Motivo de eliminación")
                .HasColumnType("mediumtext")
                .HasColumnName("EM_MOTELI");
            entity.Property(e => e.EmMtopcr)
                .HasMaxLength(32)
                .HasColumnName("EM_MTOPCR");
            entity.Property(e => e.EmMtopcrIng)
                .HasMaxLength(32)
                .HasColumnName("EM_MTOPCR_ING");
            entity.Property(e => e.EmNombre)
                .HasMaxLength(120)
                .HasColumnName("EM_NOMBRE");
            entity.Property(e => e.EmNomcrr)
                .HasMaxLength(3)
                .HasComment("Nombre Correcto Si o No")
                .HasColumnName("EM_NOMCRR");
            entity.Property(e => e.EmNomsol)
                .HasMaxLength(100)
                .HasComment("Nombre Solicitado")
                .HasColumnName("EM_NOMSOL");
            entity.Property(e => e.EmNomvia)
                .HasMaxLength(100)
                .HasColumnName("EM_NOMVIA");
            entity.Property(e => e.EmNument)
                .HasMaxLength(5)
                .HasColumnName("EM_NUMENT");
            entity.Property(e => e.EmOcDescri)
                .HasColumnType("text")
                .HasColumnName("EM_OC_DESCRI");
            entity.Property(e => e.EmOcDescriIng)
                .HasColumnType("text")
                .HasColumnName("EM_OC_DESCRI_ING");
            entity.Property(e => e.EmOnline)
                .HasMaxLength(2)
                .HasDefaultValueSql("'Si'")
                .HasComment("S->Va al Online   No->No va")
                .HasColumnName("EM_ONLINE");
            entity.Property(e => e.EmOpicre)
                .HasComment("Comentario de Opinion De Credito")
                .HasColumnType("text")
                .HasColumnName("EM_OPICRE");
            entity.Property(e => e.EmOpicreIng)
                .HasColumnType("text")
                .HasColumnName("EM_OPICRE_ING");
            entity.Property(e => e.EmOtrdeu)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_OTRDEU");
            entity.Property(e => e.EmOtrdeuMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_OTRDEU_ME");
            entity.Property(e => e.EmOtros)
                .HasMaxLength(35)
                .HasColumnName("EM_OTROS");
            entity.Property(e => e.EmOtros2)
                .HasMaxLength(35)
                .HasColumnName("EM_OTROS2");
            entity.Property(e => e.EmOtros2Ing)
                .HasMaxLength(35)
                .HasColumnName("EM_OTROS2_ING");
            entity.Property(e => e.EmOtrosIng)
                .HasMaxLength(35)
                .HasColumnName("EM_OTROS_ING");
            entity.Property(e => e.EmPagweb)
                .HasMaxLength(100)
                .HasColumnName("EM_PAGWEB");
            entity.Property(e => e.EmPiso)
                .HasMaxLength(30)
                .HasColumnName("EM_PISO");
            entity.Property(e => e.EmPrensa)
                .HasComment("Prensa Observ. General Imprime si no hay Opinón de Crédito")
                .HasColumnType("text")
                .HasColumnName("EM_PRENSA");
            entity.Property(e => e.EmPrensaIng)
                .HasColumnType("text")
                .HasColumnName("Em_PRENSA_ING");
            entity.Property(e => e.EmPrensasel)
                .HasComment("Prensa Seleccionable")
                .HasColumnType("text")
                .HasColumnName("Em_PRENSASEL");
            entity.Property(e => e.EmPrensaselIng)
                .HasComment("Prensa Seleccionada en Ingles")
                .HasColumnType("text")
                .HasColumnName("Em_PRENSASEL_ING");
            entity.Property(e => e.EmPresid)
                .HasMaxLength(100)
                .HasComment("Presidente (Ficha Resumen)")
                .HasColumnName("EM_PRESID");
            entity.Property(e => e.EmPresta)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_PRESTA");
            entity.Property(e => e.EmPrestaMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_PRESTA_ME");
            entity.Property(e => e.EmPrffax)
                .HasMaxLength(500)
                .HasColumnName("EM_PRFFAX");
            entity.Property(e => e.EmPrftlf)
                .HasMaxLength(500)
                .HasColumnName("EM_PRFTLF");
            entity.Property(e => e.EmPrinci)
                .HasMaxLength(100)
                .HasComment("Principal Ejecutivo (Ficha Resumen)")
                .HasColumnName("EM_PRINCI");
            entity.Property(e => e.EmPrinciCargo)
                .HasMaxLength(25)
                .HasComment("Cargo del Principal Ejecutivo (Ficha Resumen)")
                .HasColumnName("EM_PRINCI_CARGO");
            entity.Property(e => e.EmRating)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("EM_RATING");
            entity.Property(e => e.EmRegtri)
                .HasMaxLength(18)
                .HasColumnName("EM_REGTRI");
            entity.Property(e => e.EmRubro1)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO1");
            entity.Property(e => e.EmRubro1a)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO1A");
            entity.Property(e => e.EmRubro1b)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO1B");
            entity.Property(e => e.EmRubro1c)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO1C");
            entity.Property(e => e.EmRubro1d)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO1D");
            entity.Property(e => e.EmRubro2)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO2");
            entity.Property(e => e.EmRubro2a)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO2A");
            entity.Property(e => e.EmRubro3)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO3");
            entity.Property(e => e.EmRubro3a)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO3A");
            entity.Property(e => e.EmRubro3b)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO3B");
            entity.Property(e => e.EmRubro3c)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO3C");
            entity.Property(e => e.EmRubro4)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO4");
            entity.Property(e => e.EmRubro4a)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO4A");
            entity.Property(e => e.EmRubro4b)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO4B");
            entity.Property(e => e.EmRubro4c)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO4C");
            entity.Property(e => e.EmRubro4d)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO4D");
            entity.Property(e => e.EmRubro4e)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO4E");
            entity.Property(e => e.EmRubro4f)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO4F");
            entity.Property(e => e.EmSiglas)
                .HasMaxLength(50)
                .HasColumnName("EM_SIGLAS");
            entity.Property(e => e.EmSnopcr)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasComment("Si es Apto o no la Opinion de Credito")
                .HasColumnName("EM_SNOPCR");
            entity.Property(e => e.EmSubacu)
                .HasComment("Comentario de SuperIntencia De Banca Tabulado")
                .HasColumnType("text")
                .HasColumnName("EM_SUBACU");
            entity.Property(e => e.EmSubacuIng)
                .HasColumnType("text")
                .HasColumnName("EM_SUBACU_ING");
            entity.Property(e => e.EmSupban)
                .HasComment("Comentario de SuperIntencia De Banca")
                .HasColumnType("text")
                .HasColumnName("EM_SUPBAN");
            entity.Property(e => e.EmSupbanIng)
                .HasColumnType("text")
                .HasColumnName("EM_SUPBAN_ING");
            entity.Property(e => e.EmTarcred)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TARCRED");
            entity.Property(e => e.EmTarcredMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TARCRED_ME");
            entity.Property(e => e.EmTcsbs)
                .HasDefaultValueSql("'0'")
                .HasColumnName("EM_TCSBS");
            entity.Property(e => e.EmTelef1)
                .HasMaxLength(500)
                .HasColumnName("EM_TELEF1");
            entity.Property(e => e.EmTelef2)
                .HasMaxLength(50)
                .HasComment("Segundo Teléfono")
                .HasColumnName("EM_TELEF2");
            entity.Property(e => e.EmTiopcr)
                .HasMaxLength(10)
                .HasDefaultValueSql("'0'")
                .IsFixedLength()
                .HasComment("Tipo de Opinion De Credito")
                .HasColumnName("EM_TIOPCR");
            entity.Property(e => e.EmTipcamAnu)
                .HasDefaultValueSql("'0'")
                .HasColumnName("EM_TIPCAM_ANU");
            entity.Property(e => e.EmTipcamAnu2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("EM_TIPCAM_ANU2");
            entity.Property(e => e.EmTipoa)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_TIPOA");
            entity.Property(e => e.EmTipob)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EM_TIPOB");
            entity.Property(e => e.EmTipper)
                .HasDefaultValueSql("'0'")
                .HasComment("Tipo de Personería (Natural/Con Negocio)")
                .HasColumnType("int(4)")
                .HasColumnName("EM_TIPPER");
            entity.Property(e => e.EmTipvia)
                .HasMaxLength(15)
                .HasColumnName("EM_TIPVIA");
            entity.Property(e => e.EmTotdeu)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TOTDEU");
            entity.Property(e => e.EmTotdeuMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TOTDEU_ME");
            entity.Property(e => e.EmTototr)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TOTOTR");
            entity.Property(e => e.EmTototr2)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TOTOTR2");
            entity.Property(e => e.EmTototr2Me)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TOTOTR2_ME");
            entity.Property(e => e.EmTototrMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TOTOTR_ME");
            entity.Property(e => e.EmUsuario)
                .HasMaxLength(50)
                .HasComment("Usuario del Sistema")
                .HasColumnName("EM_USUARIO");
            entity.Property(e => e.EmUsueli)
                .HasMaxLength(50)
                .HasComment("Usuario que elimino")
                .HasColumnName("EM_USUELI");
            entity.Property(e => e.EmVentas)
                .HasDefaultValueSql("'0'")
                .HasColumnName("EM_VENTAS");
            entity.Property(e => e.EmVentasAnu)
                .HasDefaultValueSql("'0'")
                .HasComment("Ventas Anuales cuando no hay balance")
                .HasColumnName("EM_VENTAS_ANU");
            entity.Property(e => e.EmVentasAnu2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("EM_VENTAS_ANU2");
            entity.Property(e => e.IdiCodigo)
                .HasDefaultValueSql("'0'")
                .HasComment("Tipo de Idioma/Traducción")
                .HasColumnType("int(2)")
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.JuCodigo)
                .HasMaxLength(3)
                .HasDefaultValueSql("'999'")
                .IsFixedLength()
                .HasComment("Personería Jurídica (Código)<= tJuridi.Ju_Codigo")
                .HasColumnName("JU_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.OcCodigo)
                .HasMaxLength(3)
                .HasDefaultValueSql("'0'")
                .IsFixedLength()
                .HasComment("Tipo de Opinion De Credito")
                .HasColumnName("OC_CODIGO");
            entity.Property(e => e.PaCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasComment("Código de Tipo de Pago (Ver rEmpVsPa)")
                .HasColumnName("PA_CODIGO");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("Pai_Codigo");
            entity.Property(e => e.PerCodage)
                .HasMaxLength(3)
                .HasColumnName("PER_CODAGE");
            entity.Property(e => e.PerCoddig)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Digitadora")
                .HasColumnName("PER_CODDIG");
            entity.Property(e => e.PerCodref)
                .HasMaxLength(100)
                .HasComment("Referencistas")
                .HasColumnName("PER_CODREF");
            entity.Property(e => e.PerCodrep)
                .HasMaxLength(3)
                .HasColumnName("PER_CODREP");
            entity.Property(e => e.PerCodsup)
                .HasMaxLength(3)
                .HasColumnName("PER_CODSUP");
            entity.Property(e => e.PerCodtra)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Traductora")
                .HasColumnName("PER_CODTRA");
            entity.Property(e => e.SitCodigo)
                .HasMaxLength(2)
                .HasDefaultValueSql("'01'")
                .IsFixedLength()
                .HasComment("Código de la Situacion del la Empresa <=tConGen")
                .HasColumnName("SIT_CODIGO");
            entity.Property(e => e.SitDesde)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("SIT_DESDE");
            entity.Property(e => e.TdCodigo)
                .HasMaxLength(2)
                .HasComment("Código de Tendencia => tTenden")
                .HasColumnName("TD_CODIGO");
            entity.Property(e => e.TramNombre)
                .HasMaxLength(2)
                .HasColumnName("TRAM_NOMBRE");
        });

        modelBuilder.Entity<MEmpresaB>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("mEmpresaB");

            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.BaCapita1).HasColumnName("BA_CAPITA1");
            entity.Property(e => e.BaCaptra).HasColumnName("BA_CAPTRA");
            entity.Property(e => e.BaFecbal1)
                .HasMaxLength(200)
                .HasColumnName("BA_FECBAL1");
            entity.Property(e => e.BaMoneda1)
                .HasMaxLength(200)
                .HasColumnName("BA_MONEDA1");
            entity.Property(e => e.BaTipcam1).HasColumnName("BA_TIPCAM1");
            entity.Property(e => e.BaTotpat1).HasColumnName("BA_TOTPAT1");
            entity.Property(e => e.BaUtiper1).HasColumnName("BA_UTIPER1");
            entity.Property(e => e.BaVentas1).HasColumnName("BA_VENTAS1");
            entity.Property(e => e.Balance)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("BALANCE");
            entity.Property(e => e.Banqueros)
                .HasMaxLength(500)
                .HasColumnName("BANQUEROS");
            entity.Property(e => e.CaCodigo)
                .HasMaxLength(50)
                .HasColumnName("CA_CODIGO");
            entity.Property(e => e.CpCodigo)
                .HasMaxLength(2)
                .HasColumnName("CP_CODIGO");
            entity.Property(e => e.CupCodigo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.CupFecped)
                .HasMaxLength(20)
                .HasColumnName("CUP_FECPED");
            entity.Property(e => e.CupTipinf)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("CUP_TIPINF");
            entity.Property(e => e.Dig)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("DIG");
            entity.Property(e => e.EmActivi)
                .HasColumnType("text")
                .HasColumnName("EM_ACTIVI");
            entity.Property(e => e.EmActiviIng)
                .HasColumnType("text")
                .HasColumnName("EM_ACTIVI_ING");
            entity.Property(e => e.EmActivo)
                .HasColumnType("int(1)")
                .HasColumnName("EM_ACTIVO");
            entity.Property(e => e.EmArea)
                .HasMaxLength(200)
                .HasColumnName("EM_AREA");
            entity.Property(e => e.EmCalsbs)
                .HasMaxLength(200)
                .HasColumnName("EM_CALSBS");
            entity.Property(e => e.EmCenrie)
                .HasColumnType("text")
                .HasColumnName("EM_CENRIE");
            entity.Property(e => e.EmCenrieIng)
                .HasColumnType("text")
                .HasColumnName("EM_CENRIE_ING");
            entity.Property(e => e.EmCiudad)
                .HasMaxLength(200)
                .HasColumnName("EM_CIUDAD");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EmCodpos)
                .HasMaxLength(200)
                .HasColumnName("EM_CODPOS");
            entity.Property(e => e.EmConinf)
                .HasColumnType("text")
                .HasColumnName("EM_CONINF");
            entity.Property(e => e.EmConinfIng)
                .HasColumnType("text")
                .HasColumnName("EM_CONINF_ING");
            entity.Property(e => e.EmDeudaFecha)
                .HasMaxLength(10)
                .HasColumnName("EM_DEUDA_FECHA");
            entity.Property(e => e.EmDeudaMe).HasColumnName("EM_DEUDA_ME");
            entity.Property(e => e.EmDeudaMn).HasColumnName("EM_DEUDA_MN");
            entity.Property(e => e.EmDeudaObs)
                .HasColumnType("text")
                .HasColumnName("EM_DEUDA_OBS");
            entity.Property(e => e.EmDeudaObsIng)
                .HasColumnType("text")
                .HasColumnName("EM_DEUDA_OBS_ING");
            entity.Property(e => e.EmDeudaTc)
                .HasMaxLength(50)
                .HasColumnName("EM_DEUDA_TC");
            entity.Property(e => e.EmDirecc)
                .HasMaxLength(200)
                .HasColumnName("EM_DIRECC");
            entity.Property(e => e.EmDistri)
                .HasMaxLength(200)
                .HasColumnName("EM_DISTRI");
            entity.Property(e => e.EmDomant)
                .HasMaxLength(150)
                .HasColumnName("EM_DOMANT");
            entity.Property(e => e.EmEmail)
                .HasMaxLength(200)
                .HasColumnName("EM_EMAIL");
            entity.Property(e => e.EmExport1)
                .HasMaxLength(500)
                .HasColumnName("EM_EXPORT1");
            entity.Property(e => e.EmExport1Ing)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_EXPORT1_ING");
            entity.Property(e => e.EmFecest)
                .HasMaxLength(10)
                .HasColumnName("EM_FECEST");
            entity.Property(e => e.EmFecinf)
                .HasColumnType("datetime")
                .HasColumnName("EM_FECINF");
            entity.Property(e => e.EmImport1)
                .HasMaxLength(500)
                .HasColumnName("EM_IMPORT1");
            entity.Property(e => e.EmImport1Ing)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_IMPORT1_ING");
            entity.Property(e => e.EmNombre)
                .HasMaxLength(200)
                .HasColumnName("EM_NOMBRE");
            entity.Property(e => e.EmPagweb)
                .HasMaxLength(200)
                .HasColumnName("EM_PAGWEB");
            entity.Property(e => e.EmRegen)
                .HasMaxLength(50)
                .HasColumnName("EM_REGEN");
            entity.Property(e => e.EmRegist)
                .HasMaxLength(50)
                .HasColumnName("EM_REGIST");
            entity.Property(e => e.EmRegistIng)
                .HasMaxLength(50)
                .HasColumnName("EM_REGIST_ING");
            entity.Property(e => e.EmRegtri)
                .HasMaxLength(50)
                .HasColumnName("EM_REGTRI");
            entity.Property(e => e.EmSiglas)
                .HasMaxLength(200)
                .HasColumnName("EM_SIGLAS");
            entity.Property(e => e.EmSitfin)
                .HasColumnType("text")
                .HasColumnName("EM_SITFIN");
            entity.Property(e => e.EmSitfinIng)
                .HasColumnType("text")
                .HasColumnName("EM_SITFIN_ING");
            entity.Property(e => e.EmSupban)
                .HasColumnType("text")
                .HasColumnName("EM_SUPBAN");
            entity.Property(e => e.EmSupbanIng)
                .HasColumnType("text")
                .HasColumnName("EM_SUPBAN_ING");
            entity.Property(e => e.EmTelef1)
                .HasMaxLength(200)
                .HasColumnName("EM_TELEF1");
            entity.Property(e => e.EmTipocu)
                .HasMaxLength(50)
                .HasColumnName("EM_TIPOCU");
            entity.Property(e => e.EmTipper)
                .HasColumnType("int(4)")
                .HasColumnName("EM_TIPPER");
            entity.Property(e => e.EmTraba1Ano)
                .HasMaxLength(30)
                .HasColumnName("EM_TRABA1_ANO");
            entity.Property(e => e.EmTraba1Cant)
                .HasMaxLength(10)
                .HasColumnName("EM_TRABA1_CANT");
            entity.Property(e => e.EmTraba2Ano)
                .HasMaxLength(30)
                .HasColumnName("EM_TRABA2_ANO");
            entity.Property(e => e.EmTraba2Cant)
                .HasMaxLength(10)
                .HasColumnName("EM_TRABA2_CANT");
            entity.Property(e => e.EmTrabaMotivo)
                .HasMaxLength(200)
                .HasColumnName("EM_TRABA_MOTIVO");
            entity.Property(e => e.EmTrabaMotivoIng)
                .HasMaxLength(200)
                .HasColumnName("EM_TRABA_MOTIVO_ING");
            entity.Property(e => e.EmpOpcComi)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("EMP_OPC_COMI");
            entity.Property(e => e.EmpOpcIndu)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("EMP_OPC_INDU");
            entity.Property(e => e.EmpOpcMayo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("EMP_OPC_MAYO");
            entity.Property(e => e.EmpOpcMino)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("EMP_OPC_MINO");
            entity.Property(e => e.EpCargo)
                .HasMaxLength(200)
                .HasColumnName("EP_CARGO");
            entity.Property(e => e.EsCia)
                .HasMaxLength(200)
                .HasColumnName("ES_CIA");
            entity.Property(e => e.EsMonto)
                .HasMaxLength(200)
                .HasColumnName("ES_Monto");
            entity.Property(e => e.EsVence)
                .HasMaxLength(200)
                .HasColumnName("ES_Vence");
            entity.Property(e => e.ExpAno)
                .HasMaxLength(50)
                .HasColumnName("EXP_ANO");
            entity.Property(e => e.ExpMonto)
                .HasMaxLength(17)
                .HasColumnName("EXP_MONTO");
            entity.Property(e => e.IdiCodigo)
                .HasColumnType("int(2)")
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.ImpAno)
                .HasMaxLength(50)
                .HasColumnName("IMP_ANO");
            entity.Property(e => e.ImpMonto)
                .HasMaxLength(17)
                .HasColumnName("IMP_MONTO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.OpcionSitfin)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("OPCION_SITFIN");
            entity.Property(e => e.PeDocide)
                .HasMaxLength(18)
                .HasColumnName("PE_DOCIDE");
            entity.Property(e => e.PeNombre)
                .HasMaxLength(100)
                .HasColumnName("PE_NOMBRE");
            entity.Property(e => e.ProvComentario)
                .HasColumnType("text")
                .HasColumnName("PROV_COMENTARIO");
            entity.Property(e => e.ProvComentarioIng)
                .HasColumnType("text")
                .HasColumnName("PROV_COMENTARIO_ING");
            entity.Property(e => e.Rep)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("REP");
            entity.Property(e => e.SfCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("SF_CODIGO");
            entity.Property(e => e.SitCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("SIT_CODIGO");
            entity.Property(e => e.Sup)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("SUP");
            entity.Property(e => e.TituCodigo)
                .HasMaxLength(2)
                .HasColumnName("TITU_CODIGO");
            entity.Property(e => e.TlCodigo)
                .HasMaxLength(2)
                .HasColumnName("TL_CODIGO");
            entity.Property(e => e.TlNombre)
                .HasMaxLength(200)
                .HasColumnName("TL_NOMBRE");
            entity.Property(e => e.TotGarMe)
                .HasColumnType("int(11)")
                .HasColumnName("TOT_GAR_ME");
            entity.Property(e => e.TotGarMn)
                .HasColumnType("int(11)")
                .HasColumnName("TOT_GAR_MN");
            entity.Property(e => e.Tra)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("TRA");
            entity.Property(e => e.TramNombre)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("TRAM_NOMBRE");
        });

        modelBuilder.Entity<MEmpresaC>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("mEmpresaC");

            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.Banqueros)
                .HasMaxLength(500)
                .HasColumnName("BANQUEROS");
            entity.Property(e => e.CaCodigo)
                .HasMaxLength(18)
                .HasColumnName("CA_CODIGO");
            entity.Property(e => e.CupCodigo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.CupFecped)
                .HasMaxLength(20)
                .HasColumnName("CUP_FECPED");
            entity.Property(e => e.Dig)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("DIG");
            entity.Property(e => e.EmActivo)
                .HasColumnType("int(1)")
                .HasColumnName("EM_ACTIVO");
            entity.Property(e => e.EmCiudad)
                .HasMaxLength(200)
                .HasColumnName("EM_CIUDAD");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(12)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EmCodpos)
                .HasMaxLength(200)
                .HasColumnName("EM_CODPOS");
            entity.Property(e => e.EmDirecc)
                .HasMaxLength(200)
                .HasColumnName("EM_DIRECC");
            entity.Property(e => e.EmExport1)
                .HasMaxLength(200)
                .HasColumnName("EM_EXPORT1");
            entity.Property(e => e.EmExport1Ing)
                .HasMaxLength(300)
                .HasColumnName("EM_EXPORT1_ING");
            entity.Property(e => e.EmFecest)
                .HasMaxLength(10)
                .HasColumnName("EM_FECEST");
            entity.Property(e => e.EmFecinf)
                .HasColumnType("datetime")
                .HasColumnName("EM_FECINF");
            entity.Property(e => e.EmImport1)
                .HasMaxLength(200)
                .HasColumnName("EM_IMPORT1");
            entity.Property(e => e.EmImport1Ing)
                .HasMaxLength(300)
                .HasColumnName("EM_IMPORT1_ING");
            entity.Property(e => e.EmNombre)
                .HasMaxLength(200)
                .HasColumnName("EM_NOMBRE");
            entity.Property(e => e.EmPagweb)
                .HasMaxLength(50)
                .HasColumnName("EM_PAGWEB");
            entity.Property(e => e.EmRamneg)
                .HasMaxLength(500)
                .HasColumnName("EM_RAMNEG");
            entity.Property(e => e.EmRamnegIng)
                .HasMaxLength(500)
                .HasColumnName("EM_RAMNEG_ING");
            entity.Property(e => e.EmRegen)
                .HasMaxLength(50)
                .HasColumnName("EM_REGEN");
            entity.Property(e => e.EmRegist)
                .HasMaxLength(50)
                .HasColumnName("EM_REGIST");
            entity.Property(e => e.EmRegtri)
                .HasMaxLength(18)
                .HasColumnName("EM_REGTRI");
            entity.Property(e => e.EmSiglas)
                .HasMaxLength(200)
                .HasColumnName("EM_SIGLAS");
            entity.Property(e => e.EmTelef1)
                .HasMaxLength(200)
                .HasColumnName("EM_TELEF1");
            entity.Property(e => e.EmTipsoc)
                .HasMaxLength(50)
                .HasColumnName("EM_TIPSOC");
            entity.Property(e => e.EmTraba1)
                .HasMaxLength(20)
                .HasColumnName("EM_TRABA1");
            entity.Property(e => e.EpCargo)
                .HasMaxLength(200)
                .HasColumnName("EP_CARGO");
            entity.Property(e => e.IdiCodigo)
                .HasColumnType("int(2)")
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.JuCodigo)
                .HasMaxLength(4)
                .HasColumnName("JU_CODIGO");
            entity.Property(e => e.MemoSunat)
                .HasColumnType("text")
                .HasColumnName("MEMO_SUNAT");
            entity.Property(e => e.MemoSunatIng)
                .HasColumnType("text")
                .HasColumnName("MEMO_SUNAT_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.MorComent)
                .HasMaxLength(400)
                .HasColumnName("MOR_COMENT");
            entity.Property(e => e.MorComentIng)
                .HasMaxLength(400)
                .HasColumnName("MOR_COMENT_ING");
            entity.Property(e => e.MorFecha)
                .HasMaxLength(20)
                .HasColumnName("MOR_FECHA");
            entity.Property(e => e.MorTotDoc)
                .HasColumnType("int(11)")
                .HasColumnName("MOR_TOT_DOC");
            entity.Property(e => e.MorTotMe)
                .HasColumnType("int(11)")
                .HasColumnName("MOR_TOT_ME");
            entity.Property(e => e.MorTotMn)
                .HasColumnType("int(11)")
                .HasColumnName("MOR_TOT_MN");
            entity.Property(e => e.MorTotPag)
                .HasColumnType("int(11)")
                .HasColumnName("MOR_TOT_PAG");
            entity.Property(e => e.PeDocide)
                .HasMaxLength(18)
                .HasColumnName("PE_DOCIDE");
            entity.Property(e => e.PeNombre)
                .HasMaxLength(200)
                .HasColumnName("PE_NOMBRE");
            entity.Property(e => e.Rep)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("REP");
            entity.Property(e => e.SbdComentarios)
                .HasMaxLength(500)
                .HasColumnName("SBD_COMENTARIOS");
            entity.Property(e => e.SbdComentariosIng)
                .HasMaxLength(500)
                .HasColumnName("SBD_COMENTARIOS_ING");
            entity.Property(e => e.SbdFecha)
                .HasMaxLength(20)
                .HasColumnName("SBD_FECHA");
            entity.Property(e => e.SbdTc)
                .HasMaxLength(50)
                .HasColumnName("SBD_TC");
            entity.Property(e => e.SbdTotGarMe)
                .HasColumnType("int(11)")
                .HasColumnName("SBD_TOT_GAR_ME");
            entity.Property(e => e.SbdTotGarMn)
                .HasColumnType("int(11)")
                .HasColumnName("SBD_TOT_GAR_MN");
            entity.Property(e => e.SbdTotMe)
                .HasColumnType("int(11)")
                .HasColumnName("SBD_TOT_ME");
            entity.Property(e => e.SbdTotMn)
                .HasColumnType("int(11)")
                .HasColumnName("SBD_TOT_MN");
            entity.Property(e => e.SitCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("SIT_CODIGO");
            entity.Property(e => e.Sup)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("SUP");
            entity.Property(e => e.Tra)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("TRA");
            entity.Property(e => e.TramNombre)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("TRAM_NOMBRE");
        });

        modelBuilder.Entity<MEmpresaNoWeb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("mEmpresa_NoWeb");

            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(20)
                .HasColumnName("em_Codigo");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Flag).HasColumnType("tinyint(4)");
            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.Usuario).HasMaxLength(100);
        });

        modelBuilder.Entity<MEmpresaRegistro>(entity =>
        {
            entity.HasKey(e => e.ErCodigo).HasName("PRIMARY");

            entity.ToTable("mEmpresaRegistro");

            entity.Property(e => e.ErCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("ER_CODIGO");
            entity.Property(e => e.ErActivo)
                .HasComment("1- Ya se migro  0- Falta Migrar 2 -Denegado")
                .HasColumnType("int(1)")
                .HasColumnName("ER_ACTIVO");
            entity.Property(e => e.ErCiudad)
                .HasMaxLength(100)
                .HasColumnName("ER_CIUDAD");
            entity.Property(e => e.ErCodigoPai)
                .HasMaxLength(3)
                .HasColumnName("ER_CODIGO_PAI");
            entity.Property(e => e.ErDirecc)
                .HasMaxLength(150)
                .HasColumnName("ER_DIRECC");
            entity.Property(e => e.ErDirgen)
                .HasMaxLength(100)
                .HasColumnName("ER_DIRGEN");
            entity.Property(e => e.ErEmail)
                .HasMaxLength(80)
                .HasColumnName("ER_EMAIL");
            entity.Property(e => e.ErExport)
                .HasMaxLength(80)
                .HasColumnName("ER_EXPORT");
            entity.Property(e => e.ErFecest)
                .HasMaxLength(10)
                .HasColumnName("ER_FECEST");
            entity.Property(e => e.ErIdioma)
                .HasMaxLength(1)
                .HasComment("C-Castellano / I-Ingles")
                .HasColumnName("ER_IDIOMA");
            entity.Property(e => e.ErImport)
                .HasMaxLength(80)
                .HasColumnName("ER_IMPORT");
            entity.Property(e => e.ErNombre)
                .HasMaxLength(150)
                .HasColumnName("ER_NOMBRE");
            entity.Property(e => e.ErPagweb)
                .HasMaxLength(100)
                .HasColumnName("ER_PAGWEB");
            entity.Property(e => e.ErPercon)
                .HasMaxLength(100)
                .HasColumnName("ER_PERCON");
            entity.Property(e => e.ErPriacc)
                .HasMaxLength(100)
                .HasColumnName("ER_PRIACC");
            entity.Property(e => e.ErRamneg)
                .HasColumnType("text")
                .HasColumnName("ER_RAMNEG");
            entity.Property(e => e.ErRegtri)
                .HasMaxLength(100)
                .HasColumnName("ER_REGTRI");
            entity.Property(e => e.ErTelefo)
                .HasMaxLength(100)
                .HasColumnName("ER_TELEFO");
            entity.Property(e => e.ErTrabaj)
                .HasMaxLength(50)
                .HasColumnName("ER_TRABAJ");
            entity.Property(e => e.Migra)
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<MPersona>(entity =>
        {
            entity.HasKey(e => e.PeCodigo).HasName("PRIMARY");

            entity.ToTable("mPersona");

            entity.HasIndex(e => e.PeCodigo, "PE_CODIGO");

            entity.HasIndex(e => e.PeDocide, "PE_DOCIDE");

            entity.HasIndex(e => e.PeNombre, "PE_NOMBRE");

            entity.HasIndex(e => e.PeNombre, "PE_PAIS");

            entity.HasIndex(e => e.PeRegtri, "PE_RUC");

            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_CODIGO");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.CalCodigoPer)
                .HasMaxLength(3)
                .HasDefaultValueSql("'10'")
                .HasColumnName("CAL_CODIGO_PER");
            entity.Property(e => e.CoCodigo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("CO_CODIGO");
            entity.Property(e => e.CrCodigo)
                .HasMaxLength(4)
                .HasColumnName("CR_CODIGO");
            entity.Property(e => e.CsoCodigo)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(2)")
                .HasColumnName("CSO_CODIGO");
            entity.Property(e => e.CupCodigo)
                .HasMaxLength(20)
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.CupFecped)
                .HasMaxLength(10)
                .HasColumnName("CUP_FECPED");
            entity.Property(e => e.CupNomsol)
                .HasMaxLength(100)
                .HasColumnName("CUP_NOMSOL");
            entity.Property(e => e.CupNroref)
                .HasMaxLength(50)
                .HasColumnName("CUP_NROREF");
            entity.Property(e => e.CupTipinf)
                .HasMaxLength(4)
                .HasColumnName("CUP_TIPINF");
            entity.Property(e => e.EcCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("EC_CODIGO");
            entity.Property(e => e.ErCodigo)
                .HasMaxLength(2)
                .HasColumnName("ER_CODIGO");
            entity.Property(e => e.EsCodigo)
                .HasMaxLength(2)
                .HasColumnName("ES_CODIGO");
            entity.Property(e => e.IdiCodigo)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(2)")
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("PA_CODIGO");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.PaiDocide)
                .HasMaxLength(6)
                .HasColumnName("PAI_DOCIDE");
            entity.Property(e => e.PeActivo)
                .HasDefaultValueSql("'1'")
                .HasComment("1 Si existe y 2 si se elimina")
                .HasColumnType("int(1)")
                .HasColumnName("PE_ACTIVO");
            entity.Property(e => e.PeAlias)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasColumnName("PE_ALIAS");
            entity.Property(e => e.PeAntCuaIng)
                .HasColumnType("text")
                .HasColumnName("Pe_AntCua_Ing");
            entity.Property(e => e.PeAntcred)
                .HasColumnType("text")
                .HasColumnName("PE_ANTCRED");
            entity.Property(e => e.PeAntcredIng)
                .HasColumnType("text")
                .HasColumnName("PE_ANTCRED_ING");
            entity.Property(e => e.PeAntcua)
                .HasColumnType("text")
                .HasColumnName("PE_ANTCUA");
            entity.Property(e => e.PeAntece)
                .HasColumnType("text")
                .HasColumnName("PE_ANTECE");
            entity.Property(e => e.PeAnteceIng)
                .HasColumnType("text")
                .HasColumnName("Pe_Antece_Ing");
            entity.Property(e => e.PeArrfin)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_ARRFIN");
            entity.Property(e => e.PeArrfinMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_ARRFIN_ME");
            entity.Property(e => e.PeAsegur)
                .HasMaxLength(60)
                .HasColumnName("PE_ASEGUR");
            entity.Property(e => e.PeBanco)
                .HasColumnType("text")
                .HasColumnName("PE_BANCO");
            entity.Property(e => e.PeBancoIng)
                .HasColumnType("text")
                .HasColumnName("Pe_Banco_Ing");
            entity.Property(e => e.PeCalsbs)
                .HasMaxLength(20)
                .HasColumnName("PE_CALSBS");
            entity.Property(e => e.PeCalsbsIng)
                .HasMaxLength(20)
                .HasColumnName("PE_CALSBS_ING");
            entity.Property(e => e.PeCelula)
                .HasMaxLength(50)
                .HasColumnName("PE_CELULA");
            entity.Property(e => e.PeCenRieIng)
                .HasColumnType("text")
                .HasColumnName("Pe_CenRie_Ing");
            entity.Property(e => e.PeCenrie)
                .HasColumnType("text")
                .HasColumnName("PE_CENRIE");
            entity.Property(e => e.PeCiudad)
                .HasMaxLength(50)
                .HasColumnName("PE_CIUDAD");
            entity.Property(e => e.PeClub)
                .HasMaxLength(300)
                .HasColumnName("PE_CLUB");
            entity.Property(e => e.PeCodpos)
                .HasMaxLength(20)
                .HasColumnName("PE_CODPOS");
            entity.Property(e => e.PeColegio)
                .HasMaxLength(50)
                .HasColumnName("PE_COLEGIO");
            entity.Property(e => e.PeColegioAnno)
                .HasMaxLength(4)
                .HasColumnName("Pe_Colegio_Anno");
            entity.Property(e => e.PeComRep)
                .HasColumnType("text")
                .HasColumnName("Pe_ComRep");
            entity.Property(e => e.PeComRepIng)
                .HasColumnType("text")
                .HasColumnName("Pe_ComRep_Ing");
            entity.Property(e => e.PeCombie)
                .HasComment("Comentario de Bienes")
                .HasColumnType("text")
                .HasColumnName("PE_COMBIE");
            entity.Property(e => e.PeCombieIng)
                .HasColumnType("text")
                .HasColumnName("PE_COMBIE_ING");
            entity.Property(e => e.PeComer)
                .HasColumnType("text")
                .HasColumnName("PE_COMER");
            entity.Property(e => e.PeComerIng)
                .HasColumnType("text")
                .HasColumnName("Pe_Comer_Ing");
            entity.Property(e => e.PeComexte)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_COMEXTE");
            entity.Property(e => e.PeComexteMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_COMEXTE_ME");
            entity.Property(e => e.PeComide)
                .HasComment("Comentario de Identificacion")
                .HasColumnType("text")
                .HasColumnName("PE_COMIDE");
            entity.Property(e => e.PeComideIng)
                .HasColumnType("text")
                .HasColumnName("PE_COMIDE_ING");
            entity.Property(e => e.PeComlit)
                .HasColumnType("text")
                .HasColumnName("PE_COMLIT");
            entity.Property(e => e.PeComlitIng)
                .HasColumnType("text")
                .HasColumnName("PE_COMLIT_ING");
            entity.Property(e => e.PeCompri)
                .HasMaxLength(200)
                .HasComment("Comentario Privado, No se imprime")
                .HasColumnName("PE_COMPRI");
            entity.Property(e => e.PeComprov)
                .HasColumnType("text")
                .HasColumnName("PE_COMPROV");
            entity.Property(e => e.PeComprovIng)
                .HasColumnType("text")
                .HasColumnName("PE_COMPROV_ING");
            entity.Property(e => e.PeCondoc)
                .HasComment("Condiciones Domiciliarias")
                .HasColumnType("text")
                .HasColumnName("PE_CONDOC");
            entity.Property(e => e.PeCondocIng)
                .HasColumnType("text")
                .HasColumnName("PE_CONDOC_ING");
            entity.Property(e => e.PeCorrecto)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("PE_CORRECTO");
            entity.Property(e => e.PeCtacte)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_CTACTE");
            entity.Property(e => e.PeCtacteMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_CTACTE_ME");
            entity.Property(e => e.PeDepart)
                .HasMaxLength(50)
                .HasColumnName("PE_DEPART");
            entity.Property(e => e.PeDescue)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_DESCUE");
            entity.Property(e => e.PeDescueMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_DESCUE_ME");
            entity.Property(e => e.PeDirecc)
                .HasMaxLength(200)
                .HasColumnName("PE_DIRECC");
            entity.Property(e => e.PeDireccCome)
                .HasMaxLength(500)
                .HasDefaultValueSql("''")
                .HasColumnName("PE_DIRECC_COME");
            entity.Property(e => e.PeDistri)
                .HasMaxLength(50)
                .HasColumnName("PE_DISTRI");
            entity.Property(e => e.PeDocide)
                .HasMaxLength(50)
                .HasColumnName("PE_DOCIDE");
            entity.Property(e => e.PeEmail)
                .HasMaxLength(50)
                .HasColumnName("PE_EMAIL");
            entity.Property(e => e.PeFactor)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_FACTOR");
            entity.Property(e => e.PeFactorMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_FACTOR_ME");
            entity.Property(e => e.PeFecest)
                .HasMaxLength(15)
                .HasColumnName("PE_FECEST");
            entity.Property(e => e.PeFecinf)
                .HasColumnType("datetime")
                .HasColumnName("PE_FECINF");
            entity.Property(e => e.PeFecnac)
                .HasMaxLength(50)
                .HasColumnName("PE_FECNAC");
            entity.Property(e => e.PeFecnacIng)
                .HasMaxLength(50)
                .HasColumnName("PE_FECNAC_ING");
            entity.Property(e => e.PeFecref)
                .HasMaxLength(10)
                .HasColumnName("PE_FECREF");
            entity.Property(e => e.PeFecreg)
                .HasMaxLength(10)
                .HasColumnName("PE_FECREG");
            entity.Property(e => e.PeFecsbs)
                .HasMaxLength(10)
                .HasColumnName("PE_FECSBS");
            entity.Property(e => e.PeFoto)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(2)")
                .HasColumnName("Pe_Foto");
            entity.Property(e => e.PeGaome)
                .HasDefaultValueSql("'0'")
                .HasColumnName("PE_GAOME");
            entity.Property(e => e.PeGaomn)
                .HasDefaultValueSql("'0'")
                .HasColumnName("PE_GAOMN");
            entity.Property(e => e.PeGrains)
                .HasMaxLength(100)
                .HasColumnName("PE_GRAINS");
            entity.Property(e => e.PeGrainsIng)
                .HasMaxLength(100)
                .HasColumnName("PE_GRAINS_ING");
            entity.Property(e => e.PeHijos)
                .HasMaxLength(80)
                .HasColumnName("PE_HIJOS");
            entity.Property(e => e.PeHijosIng)
                .HasMaxLength(80)
                .HasColumnName("PE_HIJOS_ING");
            entity.Property(e => e.PeLbienes)
                .HasComment("Indicador de Bienes/Propiedades")
                .HasColumnType("tinyint(2)")
                .HasColumnName("PE_LBIENES");
            entity.Property(e => e.PeLogactivi)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("PE_LOGACTIVI");
            entity.Property(e => e.PeLogantece)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("PE_LOGANTECE");
            entity.Property(e => e.PeLogcentra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("PE_LOGCENTRA");
            entity.Property(e => e.PeLogdomici)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("PE_LOGDOMICI");
            entity.Property(e => e.PeLogfoto)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("PE_LOGFOTO");
            entity.Property(e => e.PeLogico)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("PE_LOGICO");
            entity.Property(e => e.PeLogpre)
                .HasDefaultValueSql("'0'")
                .HasComment("Condicion de Prensa")
                .HasColumnType("int(2)")
                .HasColumnName("PE_LOGPRE");
            entity.Property(e => e.PeLogpropi)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("PE_LOGPROPI");
            entity.Property(e => e.PeLogrefere)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("PE_LOGREFERE");
            entity.Property(e => e.PeLogrelaci)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("PE_LOGRELACI");
            entity.Property(e => e.PeLrefer)
                .HasDefaultValueSql("'0'")
                .HasComment("Indicador de Referencias")
                .HasColumnType("tinyint(2)")
                .HasColumnName("PE_LREFER");
            entity.Property(e => e.PeLrefier)
                .HasComment("Indicador de Refiere(Participado)")
                .HasColumnType("tinyint(2)")
                .HasColumnName("PE_LREFIER");
            entity.Property(e => e.PeLrelac)
                .HasComment("Indicador de Relacionados")
                .HasColumnType("tinyint(2)")
                .HasColumnName("PE_LRELAC");
            entity.Property(e => e.PeLugnac)
                .HasMaxLength(50)
                .HasColumnName("PE_LUGNAC");
            entity.Property(e => e.PeMadre)
                .HasMaxLength(50)
                .HasColumnName("Pe_Madre");
            entity.Property(e => e.PeMadreVive)
                .HasMaxLength(3)
                .HasColumnName("Pe_Madre_Vive");
            entity.Property(e => e.PeNacion)
                .HasMaxLength(40)
                .HasColumnName("PE_NACION");
            entity.Property(e => e.PeNacionIng)
                .HasMaxLength(40)
                .HasColumnName("PE_NACION_ING");
            entity.Property(e => e.PeNombre)
                .HasMaxLength(100)
                .HasColumnName("PE_NOMBRE");
            entity.Property(e => e.PeNombreCome)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("PE_NOMBRE_COME");
            entity.Property(e => e.PeNomsol)
                .HasMaxLength(100)
                .HasColumnName("PE_NOMSOL");
            entity.Property(e => e.PeNomvia)
                .HasMaxLength(100)
                .HasColumnName("PE_NOMVIA");
            entity.Property(e => e.PeNument)
                .HasMaxLength(5)
                .HasColumnName("PE_NUMENT");
            entity.Property(e => e.PeObscen)
                .HasColumnType("text")
                .HasColumnName("PE_OBSCEN");
            entity.Property(e => e.PeObsdom)
                .HasColumnType("text")
                .HasColumnName("PE_OBSDOM");
            entity.Property(e => e.PeObserv)
                .HasColumnType("text")
                .HasColumnName("PE_OBSERV");
            entity.Property(e => e.PeObservIng)
                .HasColumnType("text")
                .HasColumnName("Pe_Observ_Ing");
            entity.Property(e => e.PeOtrRecIng)
                .HasColumnType("text")
                .HasColumnName("Pe_OtrRec_Ing");
            entity.Property(e => e.PeOtrdeu)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_OTRDEU");
            entity.Property(e => e.PeOtrdeuMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_OTRDEU_ME");
            entity.Property(e => e.PeOtros)
                .HasMaxLength(35)
                .HasColumnName("PE_OTROS");
            entity.Property(e => e.PeOtros2)
                .HasMaxLength(35)
                .HasColumnName("PE_OTROS2");
            entity.Property(e => e.PeOtros2Ing)
                .HasMaxLength(35)
                .HasColumnName("PE_OTROS2_ING");
            entity.Property(e => e.PeOtrosIng)
                .HasMaxLength(35)
                .HasColumnName("PE_OTROS_ING");
            entity.Property(e => e.PeOtrrec)
                .HasColumnType("text")
                .HasColumnName("PE_OTRREC");
            entity.Property(e => e.PePadre)
                .HasMaxLength(50)
                .HasColumnName("Pe_Padre");
            entity.Property(e => e.PePadreVive)
                .HasMaxLength(3)
                .HasColumnName("Pe_Padre_Vive");
            entity.Property(e => e.PeParainfo)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("PE_PARAINFO");
            entity.Property(e => e.PePerRel)
                .HasColumnType("text")
                .HasColumnName("Pe_PerRel");
            entity.Property(e => e.PePerRelIng)
                .HasColumnType("text")
                .HasColumnName("Pe_PerRel_Ing");
            entity.Property(e => e.PePiso)
                .HasMaxLength(30)
                .HasColumnName("PE_PISO");
            entity.Property(e => e.PePrensa)
                .HasComment("Comentario de Prensa")
                .HasColumnType("text")
                .HasColumnName("PE_PRENSA");
            entity.Property(e => e.PePrensaIng)
                .HasColumnType("text")
                .HasColumnName("Pe_PRENSA_ING");
            entity.Property(e => e.PePrensasel)
                .HasColumnType("mediumtext")
                .HasColumnName("Pe_PRENSASEL");
            entity.Property(e => e.PePrensaselIng)
                .HasColumnType("text")
                .HasColumnName("PE_PRENSASEL_ING");
            entity.Property(e => e.PePresta)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_PRESTA");
            entity.Property(e => e.PePrestaMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_PRESTA_ME");
            entity.Property(e => e.PePrftlf)
                .HasMaxLength(7)
                .HasColumnName("PE_PRFTLF");
            entity.Property(e => e.PeRegtri)
                .HasMaxLength(18)
                .HasColumnName("PE_REGTRI");
            entity.Property(e => e.PeRelciv)
                .HasMaxLength(50)
                .HasColumnName("PE_RELCIV");
            entity.Property(e => e.PeRelcivDni)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("PE_RELCIV_DNI");
            entity.Property(e => e.PeRelcivIng)
                .HasMaxLength(50)
                .HasColumnName("PE_RELCIV_ING");
            entity.Property(e => e.PeSer)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("PE_SER");
            entity.Property(e => e.PeSubacu)
                .HasColumnType("text")
                .HasColumnName("PE_SUBACU");
            entity.Property(e => e.PeSubacuIng)
                .HasColumnType("text")
                .HasColumnName("PE_SUBACU_ING");
            entity.Property(e => e.PeSupban)
                .HasColumnType("text")
                .HasColumnName("PE_SUPBAN");
            entity.Property(e => e.PeSupbanIng)
                .HasColumnType("text")
                .HasColumnName("PE_SUPBAN_ING");
            entity.Property(e => e.PeTarcred)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_TARCRED");
            entity.Property(e => e.PeTarcredMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_TARCRED_ME");
            entity.Property(e => e.PeTcsbs)
                .HasDefaultValueSql("'0'")
                .HasColumnName("PE_TCSBS");
            entity.Property(e => e.PeTelefo)
                .HasMaxLength(50)
                .HasColumnName("PE_TELEFO");
            entity.Property(e => e.PeTipdom)
                .HasMaxLength(50)
                .HasComment("Condicion de Prensa")
                .HasColumnName("PE_TIPDOM");
            entity.Property(e => e.PeTipdomIng)
                .HasMaxLength(50)
                .HasComment("Condicion de Prensa")
                .HasColumnName("PE_TIPDOM_ING");
            entity.Property(e => e.PeTipvia)
                .HasMaxLength(15)
                .HasColumnName("PE_TIPVIA");
            entity.Property(e => e.PeTotdeu)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_TOTDEU");
            entity.Property(e => e.PeTotdeuMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_TOTDEU_ME");
            entity.Property(e => e.PeTototr)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_TOTOTR");
            entity.Property(e => e.PeTototr2)
                .HasMaxLength(35)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_TOTOTR2");
            entity.Property(e => e.PeTototr2Me)
                .HasMaxLength(35)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_TOTOTR2_ME");
            entity.Property(e => e.PeTototrMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_TOTOTR_ME");
            entity.Property(e => e.PeUsuario)
                .HasMaxLength(50)
                .HasColumnName("PE_USUARIO");
            entity.Property(e => e.PeValdom)
                .HasMaxLength(50)
                .HasComment("Condicion de Prensa")
                .HasColumnName("PE_VALDOM");
            entity.Property(e => e.PeValdomIng)
                .HasMaxLength(50)
                .HasComment("Condicion de Prensa")
                .HasColumnName("PE_VALDOM_ING");
            entity.Property(e => e.PerCodage)
                .HasMaxLength(3)
                .HasColumnName("PER_CODAGE");
            entity.Property(e => e.PerCoddig)
                .HasMaxLength(3)
                .HasColumnName("PER_CODDIG");
            entity.Property(e => e.PerCodref)
                .HasMaxLength(3)
                .HasColumnName("PER_CODREF");
            entity.Property(e => e.PerCodrep)
                .HasMaxLength(3)
                .HasColumnName("PER_CODREP");
            entity.Property(e => e.PerCodsup)
                .HasMaxLength(3)
                .HasColumnName("PER_CODSUP");
            entity.Property(e => e.PerCodtra)
                .HasMaxLength(3)
                .HasColumnName("PER_CODTRA");
            entity.Property(e => e.PfCodigo)
                .HasMaxLength(4)
                .HasColumnName("PF_CODIGO");
            entity.Property(e => e.PfNombre)
                .HasMaxLength(60)
                .HasColumnName("PF_NOMBRE");
            entity.Property(e => e.PfNombreIng)
                .HasMaxLength(60)
                .HasColumnName("PF_NOMBRE_ING");
            entity.Property(e => e.PpCodigo)
                .HasDefaultValueSql("'21'")
                .HasColumnType("int(2)")
                .HasColumnName("PP_CODIGO");
            entity.Property(e => e.RcCodigo)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("RC_CODIGO");
            entity.Property(e => e.SexCodigo)
                .HasMaxLength(2)
                .HasColumnName("SEX_CODIGO");
            entity.Property(e => e.TiCodigo)
                .HasMaxLength(10)
                .HasColumnName("TI_CODIGO");
            entity.Property(e => e.TramNombre)
                .HasMaxLength(2)
                .HasColumnName("TRAM_NOMBRE");
        });

        modelBuilder.Entity<MPersonal>(entity =>
        {
            entity.HasKey(e => e.PerCodigo).HasName("PRIMARY");

            entity.ToTable("mPersonal");

            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("PER_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PerActdig)
                .HasColumnType("int(2)")
                .HasColumnName("PER_ACTDIG");
            entity.Property(e => e.PerActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(2)")
                .HasColumnName("PER_ACTIVO");
            entity.Property(e => e.PerActrep)
                .HasColumnType("int(2)")
                .HasColumnName("PER_ACTREP");
            entity.Property(e => e.PerActtra)
                .HasColumnType("int(2)")
                .HasColumnName("PER_ACTTRA");
            entity.Property(e => e.PerAgrrep)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("PER_AGRREP");
            entity.Property(e => e.PerApemat)
                .HasMaxLength(30)
                .HasColumnName("PER_APEMAT");
            entity.Property(e => e.PerApepat)
                .HasMaxLength(30)
                .HasColumnName("PER_APEPAT");
            entity.Property(e => e.PerCargo)
                .HasMaxLength(50)
                .HasColumnName("PER_CARGO");
            entity.Property(e => e.PerCoddig)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("PER_CODDIG");
            entity.Property(e => e.PerCodref)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("PER_CODREF");
            entity.Property(e => e.PerCodrep)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("PER_CODREP");
            entity.Property(e => e.PerCodsup)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("PER_CODSUP");
            entity.Property(e => e.PerCodtra)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("PER_CODTRA");
            entity.Property(e => e.PerCon)
                .HasMaxLength(80)
                .HasColumnName("PER_CON");
            entity.Property(e => e.PerDni)
                .HasMaxLength(8)
                .HasColumnName("PER_DNI");
            entity.Property(e => e.PerDomici)
                .HasMaxLength(150)
                .HasColumnName("PER_DOMICI");
            entity.Property(e => e.PerEmail)
                .HasMaxLength(50)
                .HasColumnName("PER_EMAIL");
            entity.Property(e => e.PerEstciv)
                .HasMaxLength(20)
                .HasColumnName("PER_ESTCIV");
            entity.Property(e => e.PerFecces)
                .HasColumnType("datetime")
                .HasColumnName("PER_FECCES");
            entity.Property(e => e.PerFecing)
                .HasColumnType("datetime")
                .HasColumnName("PER_FECING");
            entity.Property(e => e.PerFecnac)
                .HasColumnType("datetime")
                .HasColumnName("PER_FECNAC");
            entity.Property(e => e.PerGrains)
                .HasMaxLength(100)
                .HasColumnName("PER_GRAINS");
            entity.Property(e => e.PerHijos)
                .HasMaxLength(300)
                .HasColumnName("PER_HIJOS");
            entity.Property(e => e.PerLugnac)
                .HasMaxLength(100)
                .HasColumnName("PER_LUGNAC");
            entity.Property(e => e.PerMadre)
                .HasMaxLength(150)
                .HasColumnName("PER_MADRE");
            entity.Property(e => e.PerModali)
                .HasMaxLength(100)
                .HasColumnName("PER_MODALI");
            entity.Property(e => e.PerMotivo)
                .HasMaxLength(50)
                .HasColumnName("PER_MOTIVO");
            entity.Property(e => e.PerNombre)
                .HasMaxLength(30)
                .HasColumnName("PER_NOMBRE");
            entity.Property(e => e.PerNombreAbre)
                .HasMaxLength(50)
                .HasColumnName("PER_NOMBRE_ABRE");
            entity.Property(e => e.PerObserv)
                .HasMaxLength(350)
                .HasColumnName("PER_OBSERV");
            entity.Property(e => e.PerPadre)
                .HasMaxLength(150)
                .HasColumnName("PER_PADRE");
            entity.Property(e => e.PerPredig)
                .HasColumnType("double(7,2)")
                .HasColumnName("PER_PREDIG");
            entity.Property(e => e.PerPredigT1)
                .HasComment("Precio T1 de Terceras Fuentes")
                .HasColumnType("double(7,2)")
                .HasColumnName("PER_PREDIG_T1");
            entity.Property(e => e.PerPredigT2)
                .HasColumnType("double(7,2)")
                .HasColumnName("PER_PREDIG_T2");
            entity.Property(e => e.PerPredigT3)
                .HasColumnType("double(7,2)")
                .HasColumnName("PER_PREDIG_T3");
            entity.Property(e => e.PerPretra)
                .HasColumnType("double(7,2)")
                .HasColumnName("PER_PRETRA");
            entity.Property(e => e.PerSexo)
                .HasMaxLength(1)
                .HasColumnName("PER_SEXO");
            entity.Property(e => e.PerTelefo)
                .HasMaxLength(10)
                .HasColumnName("PER_TELEFO");
            entity.Property(e => e.PerTraant)
                .HasMaxLength(300)
                .HasColumnName("PER_TRAANT");
        });

        modelBuilder.Entity<MPivot>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("mPivot");

            entity.Property(e => e.Campo)
                .HasMaxLength(50)
                .HasColumnName("campo");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(50)
                .HasColumnName("em_codigo");
            entity.Property(e => e.EmDatoCad1)
                .HasMaxLength(50)
                .HasColumnName("em_dato_cad1");
            entity.Property(e => e.EmDatoCad2)
                .HasMaxLength(1000)
                .HasColumnName("em_dato_cad2");
            entity.Property(e => e.EmDatoDec)
                .HasPrecision(16)
                .HasColumnName("em_dato_dec");
            entity.Property(e => e.EmDatoInt)
                .HasColumnType("int(11)")
                .HasColumnName("em_dato_int");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.Tabla)
                .HasMaxLength(50)
                .HasColumnName("tabla");
        });

        modelBuilder.Entity<MTiendaDrr>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("m_TiendaDRR");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.InfCodigo)
                .HasMaxLength(20)
                .HasColumnName("inf_Codigo");
            entity.Property(e => e.InfFlag)
                .HasColumnType("int(11)")
                .HasColumnName("inf_Flag");
            entity.Property(e => e.InfIdioma)
                .HasMaxLength(10)
                .HasColumnName("inf_Idioma");
            entity.Property(e => e.InfNombre)
                .HasMaxLength(200)
                .HasColumnName("inf_Nombre");
            entity.Property(e => e.InfPrecio)
                .HasPrecision(8)
                .HasColumnName("inf_Precio");
            entity.Property(e => e.InfTipo)
                .HasMaxLength(10)
                .HasColumnName("inf_Tipo");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.Proveedor).HasMaxLength(10);
            entity.Property(e => e.TxCantidad)
                .HasColumnType("int(11)")
                .HasColumnName("tx_Cantidad");
            entity.Property(e => e.TxContacto)
                .HasMaxLength(100)
                .HasColumnName("tx_Contacto");
            entity.Property(e => e.TxEmail)
                .HasMaxLength(100)
                .HasColumnName("tx_Email");
            entity.Property(e => e.TxEmpresa)
                .HasMaxLength(100)
                .HasColumnName("tx_Empresa");
            entity.Property(e => e.TxFecha)
                .HasMaxLength(50)
                .HasColumnName("tx_Fecha");
            entity.Property(e => e.TxId)
                .HasMaxLength(50)
                .HasColumnName("tx_ID");
            entity.Property(e => e.TxIdioma)
                .HasMaxLength(10)
                .HasColumnName("tx_Idioma");
            entity.Property(e => e.TxPais)
                .HasMaxLength(10)
                .HasColumnName("tx_Pais");
            entity.Property(e => e.TxPrecioTotal)
                .HasPrecision(8)
                .HasColumnName("tx_PrecioTotal");
            entity.Property(e => e.TxRuc)
                .HasMaxLength(50)
                .HasColumnName("tx_RUC");
        });

        modelBuilder.Entity<MUsuVsEmp>(entity =>
        {
            entity.HasKey(e => e.UeCodigo).HasName("PRIMARY");

            entity.ToTable("mUsuVsEmp");

            entity.Property(e => e.UeCodigo)
                .HasColumnType("int(10)")
                .HasColumnName("UE_CODIGO");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.UeFecdes)
                .HasColumnType("datetime")
                .HasColumnName("UE_FECDES");
            entity.Property(e => e.UrCodigo)
                .HasMaxLength(6)
                .HasColumnName("UR_CODIGO");
        });

        modelBuilder.Entity<MUsuarioRegistrado>(entity =>
        {
            entity.HasKey(e => e.UrCodigo).HasName("PRIMARY");

            entity.ToTable("mUsuarioRegistrado");

            entity.Property(e => e.UrCodigo)
                .HasMaxLength(6)
                .HasColumnName("UR_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.UrActivo)
                .HasDefaultValueSql("'0'")
                .HasComment("1- Inactivo")
                .HasColumnType("int(10)")
                .HasColumnName("UR_ACTIVO");
            entity.Property(e => e.UrCantid)
                .HasColumnType("int(10)")
                .HasColumnName("UR_CANTID");
            entity.Property(e => e.UrEmail)
                .HasMaxLength(100)
                .HasDefaultValueSql("'0'")
                .HasColumnName("UR_EMAIL");
            entity.Property(e => e.UrNombre)
                .HasMaxLength(150)
                .HasColumnName("UR_NOMBRE");
            entity.Property(e => e.UrPasswo)
                .HasMaxLength(10)
                .HasColumnName("UR_PASSWO");
            entity.Property(e => e.UrUsuario)
                .HasMaxLength(10)
                .HasColumnName("UR_USUARIO");
        });

        modelBuilder.Entity<OlRAccionista>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rAccionistas");

            entity.Property(e => e.Cargo).HasMaxLength(50);
            entity.Property(e => e.Desde).HasMaxLength(20);
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EpNumero)
                .HasColumnType("int(11)")
                .HasColumnName("EP_NUMERO");
            entity.Property(e => e.EpPrinci)
                .HasMaxLength(1)
                .HasColumnName("EP_PRINCI");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Participacion).HasMaxLength(50);
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsB>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsBs");

            entity.Property(e => e.BsActCorOtr1).HasColumnName("BS_ActCorOtr1");
            entity.Property(e => e.BsActCorOtr2).HasColumnName("BS_ActCorOtr2");
            entity.Property(e => e.BsActCorOtr3).HasColumnName("BS_ActCorOtr3");
            entity.Property(e => e.BsActCorOtr4).HasColumnName("BS_ActCorOtr4");
            entity.Property(e => e.BsActotr1).HasColumnName("BS_ACTOTR1");
            entity.Property(e => e.BsActotr2).HasColumnName("BS_ACTOTR2");
            entity.Property(e => e.BsActotr3).HasColumnName("BS_ACTOTR3");
            entity.Property(e => e.BsActotr4).HasColumnName("BS_ACTOTR4");
            entity.Property(e => e.BsBanpro1).HasColumnName("BS_BANPRO1");
            entity.Property(e => e.BsBanpro2).HasColumnName("BS_BANPRO2");
            entity.Property(e => e.BsBanpro3).HasColumnName("BS_BANPRO3");
            entity.Property(e => e.BsBanpro4).HasColumnName("BS_BANPRO4");
            entity.Property(e => e.BsCajban1).HasColumnName("BS_CAJBAN1");
            entity.Property(e => e.BsCajban2).HasColumnName("BS_CAJBAN2");
            entity.Property(e => e.BsCajban3).HasColumnName("BS_CAJBAN3");
            entity.Property(e => e.BsCajban4).HasColumnName("BS_CAJBAN4");
            entity.Property(e => e.BsCapita1).HasColumnName("BS_CAPITA1");
            entity.Property(e => e.BsCapita2).HasColumnName("BS_CAPITA2");
            entity.Property(e => e.BsCapita3).HasColumnName("BS_CAPITA3");
            entity.Property(e => e.BsCapita4).HasColumnName("BS_CAPITA4");
            entity.Property(e => e.BsCapital).HasColumnName("BS_CAPITAL");
            entity.Property(e => e.BsCorotr1).HasColumnName("BS_COROTR1");
            entity.Property(e => e.BsCorotr2).HasColumnName("BS_COROTR2");
            entity.Property(e => e.BsCorotr3).HasColumnName("BS_COROTR3");
            entity.Property(e => e.BsCorotr4).HasColumnName("BS_COROTR4");
            entity.Property(e => e.BsEndeudamiento).HasColumnName("BS_ENDEUDAMIENTO");
            entity.Property(e => e.BsFecbal1)
                .HasMaxLength(10)
                .HasColumnName("BS_FECBAL1");
            entity.Property(e => e.BsFecbal2)
                .HasMaxLength(10)
                .HasColumnName("BS_FECBAL2");
            entity.Property(e => e.BsFecbal3)
                .HasMaxLength(10)
                .HasColumnName("BS_FECBAL3");
            entity.Property(e => e.BsFecbal4)
                .HasMaxLength(10)
                .HasColumnName("BS_FECBAL4");
            entity.Property(e => e.BsFijo1).HasColumnName("BS_FIJO1");
            entity.Property(e => e.BsFijo2).HasColumnName("BS_FIJO2");
            entity.Property(e => e.BsFijo3).HasColumnName("BS_FIJO3");
            entity.Property(e => e.BsFijo4).HasColumnName("BS_FIJO4");
            entity.Property(e => e.BsIndliq1).HasColumnName("BS_INDLIQ1");
            entity.Property(e => e.BsIndliq2).HasColumnName("BS_INDLIQ2");
            entity.Property(e => e.BsIndliq3).HasColumnName("BS_INDLIQ3");
            entity.Property(e => e.BsIndliq4).HasColumnName("BS_INDLIQ4");
            entity.Property(e => e.BsInvent1).HasColumnName("BS_INVENT1");
            entity.Property(e => e.BsInvent2).HasColumnName("BS_INVENT2");
            entity.Property(e => e.BsInvent3).HasColumnName("BS_INVENT3");
            entity.Property(e => e.BsInvent4).HasColumnName("BS_INVENT4");
            entity.Property(e => e.BsLarpla1).HasColumnName("BS_LARPLA1");
            entity.Property(e => e.BsLarpla2).HasColumnName("BS_LARPLA2");
            entity.Property(e => e.BsLarpla3).HasColumnName("BS_LARPLA3");
            entity.Property(e => e.BsLarpla4).HasColumnName("BS_LARPLA4");
            entity.Property(e => e.BsLiquidez).HasColumnName("BS_LIQUIDEZ");
            entity.Property(e => e.BsMoneda1)
                .HasMaxLength(17)
                .HasColumnName("BS_MONEDA1");
            entity.Property(e => e.BsMoneda2)
                .HasMaxLength(17)
                .HasColumnName("BS_MONEDA2");
            entity.Property(e => e.BsMoneda3)
                .HasMaxLength(17)
                .HasColumnName("BS_MONEDA3");
            entity.Property(e => e.BsMoneda4)
                .HasMaxLength(17)
                .HasColumnName("BS_MONEDA4");
            entity.Property(e => e.BsPasotr1).HasColumnName("BS_PASOTR1");
            entity.Property(e => e.BsPasotr2).HasColumnName("BS_PASOTR2");
            entity.Property(e => e.BsPasotr3).HasColumnName("BS_PASOTR3");
            entity.Property(e => e.BsPasotr4).HasColumnName("BS_PASOTR4");
            entity.Property(e => e.BsPatOtr1).HasColumnName("BS_PatOtr1");
            entity.Property(e => e.BsPatOtr2).HasColumnName("BS_PatOtr2");
            entity.Property(e => e.BsPatOtr3).HasColumnName("BS_PatOtr3");
            entity.Property(e => e.BsPatOtr4).HasColumnName("BS_PatOtr4");
            entity.Property(e => e.BsPorcob1).HasColumnName("BS_PORCOB1");
            entity.Property(e => e.BsPorcob2).HasColumnName("BS_PORCOB2");
            entity.Property(e => e.BsPorcob3).HasColumnName("BS_PORCOB3");
            entity.Property(e => e.BsPorcob4).HasColumnName("BS_PORCOB4");
            entity.Property(e => e.BsRentabilidad).HasColumnName("BS_RENTABILIDAD");
            entity.Property(e => e.BsReser1).HasColumnName("BS_RESER1");
            entity.Property(e => e.BsReser2).HasColumnName("BS_RESER2");
            entity.Property(e => e.BsReser3).HasColumnName("BS_RESER3");
            entity.Property(e => e.BsReser4).HasColumnName("BS_RESER4");
            entity.Property(e => e.BsTimbal1)
                .HasMaxLength(17)
                .HasColumnName("BS_TIMBAL1");
            entity.Property(e => e.BsTimbal2)
                .HasMaxLength(17)
                .HasColumnName("BS_TIMBAL2");
            entity.Property(e => e.BsTimbal3)
                .HasMaxLength(17)
                .HasColumnName("BS_TIMBAL3");
            entity.Property(e => e.BsTimbal4)
                .HasMaxLength(17)
                .HasColumnName("BS_TIMBAL4");
            entity.Property(e => e.BsTipbal1)
                .HasMaxLength(17)
                .HasColumnName("BS_TIPBAL1");
            entity.Property(e => e.BsTipbal2)
                .HasMaxLength(17)
                .HasColumnName("BS_TIPBAL2");
            entity.Property(e => e.BsTipbal3)
                .HasMaxLength(17)
                .HasColumnName("BS_TIPBAL3");
            entity.Property(e => e.BsTipbal4)
                .HasMaxLength(17)
                .HasColumnName("BS_TIPBAL4");
            entity.Property(e => e.BsTipcam1).HasColumnName("BS_TIPCAM1");
            entity.Property(e => e.BsTipcam2).HasColumnName("BS_TIPCAM2");
            entity.Property(e => e.BsTipcam3).HasColumnName("BS_TIPCAM3");
            entity.Property(e => e.BsTipcam4).HasColumnName("BS_TIPCAM4");
            entity.Property(e => e.BsTotact1).HasColumnName("BS_TOTACT1");
            entity.Property(e => e.BsTotact2).HasColumnName("BS_TOTACT2");
            entity.Property(e => e.BsTotact3).HasColumnName("BS_TOTACT3");
            entity.Property(e => e.BsTotact4).HasColumnName("BS_TOTACT4");
            entity.Property(e => e.BsTotcor1).HasColumnName("BS_TOTCOR1");
            entity.Property(e => e.BsTotcor2).HasColumnName("BS_TOTCOR2");
            entity.Property(e => e.BsTotcor3).HasColumnName("BS_TOTCOR3");
            entity.Property(e => e.BsTotcor4).HasColumnName("BS_TOTCOR4");
            entity.Property(e => e.BsTotcrr1).HasColumnName("BS_TOTCRR1");
            entity.Property(e => e.BsTotcrr2).HasColumnName("BS_TOTCRR2");
            entity.Property(e => e.BsTotcrr3).HasColumnName("BS_TOTCRR3");
            entity.Property(e => e.BsTotcrr4).HasColumnName("BS_TOTCRR4");
            entity.Property(e => e.BsTotpas1).HasColumnName("BS_TOTPAS1");
            entity.Property(e => e.BsTotpas2).HasColumnName("BS_TOTPAS2");
            entity.Property(e => e.BsTotpas3).HasColumnName("BS_TOTPAS3");
            entity.Property(e => e.BsTotpas4).HasColumnName("BS_TOTPAS4");
            entity.Property(e => e.BsTotpat1).HasColumnName("BS_TOTPAT1");
            entity.Property(e => e.BsTotpat2).HasColumnName("BS_TOTPAT2");
            entity.Property(e => e.BsTotpat3).HasColumnName("BS_TOTPAT3");
            entity.Property(e => e.BsTotpat4).HasColumnName("BS_TOTPAT4");
            entity.Property(e => e.BsUtili1).HasColumnName("BS_UTILI1");
            entity.Property(e => e.BsUtili2).HasColumnName("BS_UTILI2");
            entity.Property(e => e.BsUtili3).HasColumnName("BS_UTILI3");
            entity.Property(e => e.BsUtili4).HasColumnName("BS_UTILI4");
            entity.Property(e => e.BsUtiper1).HasColumnName("BS_UTIPER1");
            entity.Property(e => e.BsUtiper2).HasColumnName("BS_UTIPER2");
            entity.Property(e => e.BsUtiper3).HasColumnName("BS_UTIPER3");
            entity.Property(e => e.BsUtiper4).HasColumnName("BS_UTIPER4");
            entity.Property(e => e.BsVentas1).HasColumnName("BS_VENTAS1");
            entity.Property(e => e.BsVentas2).HasColumnName("BS_VENTAS2");
            entity.Property(e => e.BsVentas3).HasColumnName("BS_VENTAS3");
            entity.Property(e => e.BsVentas4).HasColumnName("BS_VENTAS4");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsBa>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsBa");

            entity.Property(e => e.BaActCorOtr2).HasColumnName("BA_ActCorOtr2");
            entity.Property(e => e.BaActCorOtr3).HasColumnName("BA_ActCorOtr3");
            entity.Property(e => e.BaActCorOtr4).HasColumnName("BA_ActCorOtr4");
            entity.Property(e => e.BaActcorotr1).HasColumnName("BA_ACTCOROTR1");
            entity.Property(e => e.BaActotr1).HasColumnName("BA_ACTOTR1");
            entity.Property(e => e.BaActotr2).HasColumnName("BA_ACTOTR2");
            entity.Property(e => e.BaActotr3).HasColumnName("BA_ACTOTR3");
            entity.Property(e => e.BaActotr4).HasColumnName("BA_ACTOTR4");
            entity.Property(e => e.BaBanpro1).HasColumnName("BA_BANPRO1");
            entity.Property(e => e.BaBanpro2).HasColumnName("BA_BANPRO2");
            entity.Property(e => e.BaBanpro3).HasColumnName("BA_BANPRO3");
            entity.Property(e => e.BaBanpro4).HasColumnName("BA_BANPRO4");
            entity.Property(e => e.BaCajban1).HasColumnName("BA_CAJBAN1");
            entity.Property(e => e.BaCajban2).HasColumnName("BA_CAJBAN2");
            entity.Property(e => e.BaCajban3).HasColumnName("BA_CAJBAN3");
            entity.Property(e => e.BaCajban4).HasColumnName("BA_CAJBAN4");
            entity.Property(e => e.BaCapita1).HasColumnName("BA_CAPITA1");
            entity.Property(e => e.BaCapita2).HasColumnName("BA_CAPITA2");
            entity.Property(e => e.BaCapita3).HasColumnName("BA_CAPITA3");
            entity.Property(e => e.BaCapita4).HasColumnName("BA_CAPITA4");
            entity.Property(e => e.BaCorotr1).HasColumnName("BA_COROTR1");
            entity.Property(e => e.BaCorotr2).HasColumnName("BA_COROTR2");
            entity.Property(e => e.BaCorotr3).HasColumnName("BA_COROTR3");
            entity.Property(e => e.BaCorotr4).HasColumnName("BA_COROTR4");
            entity.Property(e => e.BaFecbal1)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBAL1");
            entity.Property(e => e.BaFecbal2)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBAL2");
            entity.Property(e => e.BaFecbal3)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBAL3");
            entity.Property(e => e.BaFecbal4)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBAL4");
            entity.Property(e => e.BaFijo1).HasColumnName("BA_FIJO1");
            entity.Property(e => e.BaFijo2).HasColumnName("BA_FIJO2");
            entity.Property(e => e.BaFijo3).HasColumnName("BA_FIJO3");
            entity.Property(e => e.BaFijo4).HasColumnName("BA_FIJO4");
            entity.Property(e => e.BaIndliq1).HasColumnName("BA_INDLIQ1");
            entity.Property(e => e.BaIndliq2).HasColumnName("BA_INDLIQ2");
            entity.Property(e => e.BaIndliq3).HasColumnName("BA_INDLIQ3");
            entity.Property(e => e.BaIndliq4).HasColumnName("BA_INDLIQ4");
            entity.Property(e => e.BaInvent1).HasColumnName("BA_INVENT1");
            entity.Property(e => e.BaInvent2).HasColumnName("BA_INVENT2");
            entity.Property(e => e.BaInvent3).HasColumnName("BA_INVENT3");
            entity.Property(e => e.BaInvent4).HasColumnName("BA_INVENT4");
            entity.Property(e => e.BaLarpla1).HasColumnName("BA_LARPLA1");
            entity.Property(e => e.BaLarpla2).HasColumnName("BA_LARPLA2");
            entity.Property(e => e.BaLarpla3).HasColumnName("BA_LARPLA3");
            entity.Property(e => e.BaLarpla4).HasColumnName("BA_LARPLA4");
            entity.Property(e => e.BaMoneda1)
                .HasMaxLength(17)
                .HasColumnName("BA_MONEDA1");
            entity.Property(e => e.BaMoneda2)
                .HasMaxLength(17)
                .HasColumnName("BA_MONEDA2");
            entity.Property(e => e.BaMoneda3)
                .HasMaxLength(17)
                .HasColumnName("BA_MONEDA3");
            entity.Property(e => e.BaMoneda4)
                .HasMaxLength(17)
                .HasColumnName("BA_MONEDA4");
            entity.Property(e => e.BaPasotr1).HasColumnName("BA_PASOTR1");
            entity.Property(e => e.BaPasotr2).HasColumnName("BA_PASOTR2");
            entity.Property(e => e.BaPasotr3).HasColumnName("BA_PASOTR3");
            entity.Property(e => e.BaPasotr4).HasColumnName("BA_PASOTR4");
            entity.Property(e => e.BaPastot1).HasColumnName("BA_PASTOT1");
            entity.Property(e => e.BaPastot2).HasColumnName("BA_PASTOT2");
            entity.Property(e => e.BaPastot3).HasColumnName("BA_PASTOT3");
            entity.Property(e => e.BaPastot4).HasColumnName("BA_PASTOT4");
            entity.Property(e => e.BaPatOtr2).HasColumnName("BA_PatOtr2");
            entity.Property(e => e.BaPatOtr3).HasColumnName("BA_PatOtr3");
            entity.Property(e => e.BaPatOtr4).HasColumnName("BA_PatOtr4");
            entity.Property(e => e.BaPatotr1).HasColumnName("BA_PATOTR1");
            entity.Property(e => e.BaPorcob1).HasColumnName("BA_PORCOB1");
            entity.Property(e => e.BaPorcob2).HasColumnName("BA_PORCOB2");
            entity.Property(e => e.BaPorcob3).HasColumnName("BA_PORCOB3");
            entity.Property(e => e.BaPorcob4).HasColumnName("BA_PORCOB4");
            entity.Property(e => e.BaQuien)
                .HasColumnType("tinyint(4)")
                .HasColumnName("BA_QUIEN");
            entity.Property(e => e.BaReser1).HasColumnName("BA_RESER1");
            entity.Property(e => e.BaReser2).HasColumnName("BA_RESER2");
            entity.Property(e => e.BaReser3).HasColumnName("BA_RESER3");
            entity.Property(e => e.BaReser4).HasColumnName("BA_RESER4");
            entity.Property(e => e.BaTimbal1)
                .HasMaxLength(17)
                .HasColumnName("BA_TIMBAL1");
            entity.Property(e => e.BaTimbal2)
                .HasMaxLength(17)
                .HasColumnName("BA_TIMBAL2");
            entity.Property(e => e.BaTimbal3)
                .HasMaxLength(17)
                .HasColumnName("BA_TIMBAL3");
            entity.Property(e => e.BaTimbal4)
                .HasMaxLength(17)
                .HasColumnName("BA_TIMBAL4");
            entity.Property(e => e.BaTipbal1)
                .HasMaxLength(17)
                .HasColumnName("BA_TIPBAL1");
            entity.Property(e => e.BaTipbal2)
                .HasMaxLength(17)
                .HasColumnName("BA_TIPBAL2");
            entity.Property(e => e.BaTipbal3)
                .HasMaxLength(17)
                .HasColumnName("BA_TIPBAL3");
            entity.Property(e => e.BaTipbal4)
                .HasMaxLength(17)
                .HasColumnName("BA_TIPBAL4");
            entity.Property(e => e.BaTipcam1).HasColumnName("BA_TIPCAM1");
            entity.Property(e => e.BaTipcam2).HasColumnName("BA_TIPCAM2");
            entity.Property(e => e.BaTipcam3).HasColumnName("BA_TIPCAM3");
            entity.Property(e => e.BaTipcam4).HasColumnName("BA_TIPCAM4");
            entity.Property(e => e.BaTotact1).HasColumnName("BA_TOTACT1");
            entity.Property(e => e.BaTotact2).HasColumnName("BA_TOTACT2");
            entity.Property(e => e.BaTotact3).HasColumnName("BA_TOTACT3");
            entity.Property(e => e.BaTotact4).HasColumnName("BA_TOTACT4");
            entity.Property(e => e.BaTotcor1).HasColumnName("BA_TOTCOR1");
            entity.Property(e => e.BaTotcor2).HasColumnName("BA_TOTCOR2");
            entity.Property(e => e.BaTotcor3).HasColumnName("BA_TOTCOR3");
            entity.Property(e => e.BaTotcor4).HasColumnName("BA_TOTCOR4");
            entity.Property(e => e.BaTotcrr1).HasColumnName("BA_TOTCRR1");
            entity.Property(e => e.BaTotcrr2).HasColumnName("BA_TOTCRR2");
            entity.Property(e => e.BaTotcrr3).HasColumnName("BA_TOTCRR3");
            entity.Property(e => e.BaTotcrr4).HasColumnName("BA_TOTCRR4");
            entity.Property(e => e.BaTotpas1).HasColumnName("BA_TOTPAS1");
            entity.Property(e => e.BaTotpas2).HasColumnName("BA_TOTPAS2");
            entity.Property(e => e.BaTotpas3).HasColumnName("BA_TOTPAS3");
            entity.Property(e => e.BaTotpas4).HasColumnName("BA_TOTPAS4");
            entity.Property(e => e.BaTotpat1).HasColumnName("BA_TOTPAT1");
            entity.Property(e => e.BaTotpat2).HasColumnName("BA_TOTPAT2");
            entity.Property(e => e.BaTotpat3).HasColumnName("BA_TOTPAT3");
            entity.Property(e => e.BaTotpat4).HasColumnName("BA_TOTPAT4");
            entity.Property(e => e.BaUtili1).HasColumnName("BA_UTILI1");
            entity.Property(e => e.BaUtili2).HasColumnName("BA_UTILI2");
            entity.Property(e => e.BaUtili3).HasColumnName("BA_UTILI3");
            entity.Property(e => e.BaUtili4).HasColumnName("BA_UTILI4");
            entity.Property(e => e.BaUtiper1).HasColumnName("BA_UTIPER1");
            entity.Property(e => e.BaUtiper2).HasColumnName("BA_UTIPER2");
            entity.Property(e => e.BaUtiper3).HasColumnName("BA_UTIPER3");
            entity.Property(e => e.BaUtiper4).HasColumnName("BA_UTIPER4");
            entity.Property(e => e.BaVentas1).HasColumnName("BA_VENTAS1");
            entity.Property(e => e.BaVentas2).HasColumnName("BA_VENTAS2");
            entity.Property(e => e.BaVentas3).HasColumnName("BA_VENTAS3");
            entity.Property(e => e.BaVentas4).HasColumnName("BA_VENTAS4");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsBc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsBc");

            entity.Property(e => e.BcMonExt)
                .HasMaxLength(1)
                .HasColumnName("Bc_MonExt");
            entity.Property(e => e.BcMonNac)
                .HasMaxLength(1)
                .HasColumnName("Bc_MonNac");
            entity.Property(e => e.BcNombre)
                .HasMaxLength(30)
                .HasColumnName("Bc_Nombre");
            entity.Property(e => e.BcNroCta)
                .HasMaxLength(25)
                .HasColumnName("Bc_NroCta");
            entity.Property(e => e.BcSector)
                .HasMaxLength(35)
                .HasColumnName("Bc_Sector");
            entity.Property(e => e.BcTelefo)
                .HasMaxLength(15)
                .HasColumnName("Bc_Telefo");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsBi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsBi");

            entity.Property(e => e.BiNombre)
                .HasMaxLength(50)
                .HasColumnName("BI_NOMBRE");
            entity.Property(e => e.BiTipo)
                .HasMaxLength(20)
                .HasColumnName("BI_TIPO");
            entity.Property(e => e.BiValor).HasColumnName("BI_VALOR");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsEmp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsEmp");

            entity.Property(e => e.AcNombre)
                .HasMaxLength(850)
                .HasColumnName("AC_NOMBRE");
            entity.Property(e => e.EeCodigo)
                .HasMaxLength(11)
                .HasColumnName("EE_CODIGO");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EmNombre)
                .HasMaxLength(120)
                .HasColumnName("EM_NOMBRE");
            entity.Property(e => e.EmRegtri)
                .HasMaxLength(40)
                .HasColumnName("EM_REGTRI");
            entity.Property(e => e.PaiNombre)
                .HasMaxLength(45)
                .HasColumnName("PAI_NOMBRE");
            entity.Property(e => e.ReNombre)
                .HasMaxLength(40)
                .HasColumnName("RE_NOMBRE");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsEmpPj>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsEmpPJ");

            entity.Property(e => e.Comentario)
                .HasColumnType("mediumtext")
                .HasColumnName("COMENTARIO");
            entity.Property(e => e.EePorAcc)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("EE_PorAcc");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EmNombre)
                .HasMaxLength(120)
                .HasColumnName("EM_NOMBRE");
            entity.Property(e => e.EmRegtri)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_REGTRI");
            entity.Property(e => e.PaiNombreCas)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("Pai_Nombre_Cas");
            entity.Property(e => e.ReNombre)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("RE_NOMBRE");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsExp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsExp");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.ExAno)
                .HasMaxLength(4)
                .HasColumnName("EX_ANO");
            entity.Property(e => e.ExMonto)
                .HasMaxLength(17)
                .HasColumnName("EX_MONTO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsFoto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsFoto");

            entity.Property(e => e.EfLocal)
                .HasColumnType("mediumblob")
                .HasColumnName("EF_LOCAL");
            entity.Property(e => e.EfLocal2)
                .HasColumnType("mediumblob")
                .HasColumnName("EF_LOCAL2");
            entity.Property(e => e.EfLocal2Txt)
                .HasMaxLength(200)
                .HasColumnName("EF_LOCAL2_TXT");
            entity.Property(e => e.EfLocal3)
                .HasColumnType("mediumblob")
                .HasColumnName("EF_LOCAL3");
            entity.Property(e => e.EfLocal3Txt)
                .HasMaxLength(200)
                .HasColumnName("EF_LOCAL3_TXT");
            entity.Property(e => e.EfLocal4)
                .HasColumnType("mediumblob")
                .HasColumnName("EF_LOCAL4");
            entity.Property(e => e.EfLocal4Txt)
                .HasMaxLength(200)
                .HasColumnName("EF_LOCAL4_TXT");
            entity.Property(e => e.EfLocalGnralTxt)
                .HasMaxLength(400)
                .HasColumnName("EF_LOCAL_GNRAL_TXT");
            entity.Property(e => e.EfLocalTxt)
                .HasMaxLength(200)
                .HasColumnName("EF_LOCAL_TXT");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsFotoIndicadore>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsFoto_Indicadores");

            entity.Property(e => e.Codigo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("CODIGO");
            entity.Property(e => e.CrCodigoImg)
                .HasColumnType("mediumblob")
                .HasColumnName("CR_CODIGO_IMG");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsImp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsImp");

            entity.Property(e => e.EiAno)
                .HasMaxLength(4)
                .HasColumnName("EI_ANO");
            entity.Property(e => e.EiMonto)
                .HasMaxLength(17)
                .HasColumnName("EI_MONTO");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsLit>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsLit");

            entity.Property(e => e.Campo1)
                .HasMaxLength(8)
                .HasColumnName("CAMPO1");
            entity.Property(e => e.Campo2)
                .HasMaxLength(32)
                .HasColumnName("CAMPO2");
            entity.Property(e => e.Campo3)
                .HasMaxLength(40)
                .HasColumnName("CAMPO3");
            entity.Property(e => e.Campo4)
                .HasMaxLength(10)
                .HasColumnName("CAMPO4");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Titulo1)
                .HasMaxLength(10)
                .HasColumnName("TITULO1");
            entity.Property(e => e.Titulo2)
                .HasMaxLength(20)
                .HasColumnName("TITULO2");
            entity.Property(e => e.Titulo3)
                .HasMaxLength(20)
                .HasColumnName("TITULO3");
            entity.Property(e => e.Titulo4)
                .HasMaxLength(10)
                .HasColumnName("TITULO4");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsMorCom>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsMorCom");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.McAcreed)
                .HasMaxLength(35)
                .HasColumnName("MC_ACREED");
            entity.Property(e => e.McFecha)
                .HasMaxLength(10)
                .HasColumnName("MC_FECHA");
            entity.Property(e => e.McFecinc)
                .HasMaxLength(10)
                .HasColumnName("MC_FECINC");
            entity.Property(e => e.McMonme).HasColumnName("MC_MONME");
            entity.Property(e => e.McMonmn).HasColumnName("MC_MONMN");
            entity.Property(e => e.McNrodoc)
                .HasMaxLength(10)
                .HasColumnName("MC_NRODOC");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsPer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsPer");

            entity.Property(e => e.CaNombre)
                .HasMaxLength(100)
                .HasColumnName("CA_NOMBRE");
            entity.Property(e => e.CamDescri)
                .HasColumnType("mediumtext")
                .HasColumnName("CAM_DESCRI");
            entity.Property(e => e.CamEpPrinci)
                .HasColumnType("mediumtext")
                .HasColumnName("CAM_EP_PRINCI");
            entity.Property(e => e.CamParAno)
                .HasColumnType("mediumtext")
                .HasColumnName("CAM_PAR_ANO");
            entity.Property(e => e.CamParCargo)
                .HasColumnType("mediumtext")
                .HasColumnName("CAM_PAR_CARGO");
            entity.Property(e => e.CamParEmpresa)
                .HasColumnType("mediumtext")
                .HasColumnName("CAM_PAR_EMPRESA");
            entity.Property(e => e.CamParPais)
                .HasColumnType("mediumtext")
                .HasColumnName("CAM_PAR_PAIS");
            entity.Property(e => e.CamRelCargo)
                .HasColumnType("mediumtext")
                .HasColumnName("CAM_REL_CARGO");
            entity.Property(e => e.CamRelDesde)
                .HasColumnType("mediumtext")
                .HasColumnName("CAM_REL_DESDE");
            entity.Property(e => e.CamRelEmpresa)
                .HasColumnType("mediumtext")
                .HasColumnName("CAM_REL_EMPRESA");
            entity.Property(e => e.CamRelHasta)
                .HasColumnType("mediumtext")
                .HasColumnName("CAM_REL_HASTA");
            entity.Property(e => e.CamRelPais)
                .HasColumnType("mediumtext")
                .HasColumnName("CAM_REL_PAIS");
            entity.Property(e => e.CamRelRegtri)
                .HasColumnType("mediumtext")
                .HasColumnName("CAM_REL_REGTRI");
            entity.Property(e => e.CamTipo)
                .HasColumnType("mediumtext")
                .HasColumnName("CAM_TIPO");
            entity.Property(e => e.CamValor)
                .HasColumnType("mediumtext")
                .HasColumnName("CAM_VALOR");
            entity.Property(e => e.Campo1)
                .HasMaxLength(200)
                .HasColumnName("CAMPO1");
            entity.Property(e => e.Campo2)
                .HasMaxLength(200)
                .HasColumnName("CAMPO2");
            entity.Property(e => e.Campo3)
                .HasMaxLength(200)
                .HasColumnName("CAMPO3");
            entity.Property(e => e.Campo4)
                .HasMaxLength(200)
                .HasColumnName("CAMPO4");
            entity.Property(e => e.Campo5)
                .HasMaxLength(200)
                .HasColumnName("CAMPO5");
            entity.Property(e => e.Campo6)
                .HasMaxLength(200)
                .HasColumnName("CAMPO6");
            entity.Property(e => e.Campo7)
                .HasMaxLength(200)
                .HasColumnName("CAMPO7");
            entity.Property(e => e.Campo8)
                .HasMaxLength(200)
                .HasColumnName("CAMPO8");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EpApenom)
                .HasColumnType("smallint(6)")
                .HasColumnName("EP_APENOM");
            entity.Property(e => e.EpDesde)
                .HasMaxLength(100)
                .HasColumnName("EP_DESDE");
            entity.Property(e => e.EpFoto)
                .HasMaxLength(5)
                .HasColumnName("EP_FOTO");
            entity.Property(e => e.EpNumero)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("EP_NUMERO");
            entity.Property(e => e.EpPrinci)
                .HasMaxLength(1)
                .HasColumnName("EP_PRINCI");
            entity.Property(e => e.PeAntcred)
                .HasColumnType("mediumtext")
                .HasColumnName("PE_ANTCRED");
            entity.Property(e => e.PeAntece)
                .HasColumnType("mediumtext")
                .HasColumnName("PE_ANTECE");
            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_CODIGO");
            entity.Property(e => e.PeCombie)
                .HasColumnType("text")
                .HasColumnName("PE_COMBIE");
            entity.Property(e => e.PeDirecc)
                .HasMaxLength(200)
                .HasColumnName("PE_DIRECC");
            entity.Property(e => e.PeDireccCome)
                .HasMaxLength(800)
                .HasColumnName("PE_DIRECC_COME");
            entity.Property(e => e.PeDocide)
                .HasMaxLength(100)
                .HasColumnName("PE_DOCIDE");
            entity.Property(e => e.PeEstciv)
                .HasMaxLength(100)
                .HasColumnName("PE_ESTCIV");
            entity.Property(e => e.PeFecnac)
                .HasMaxLength(100)
                .HasColumnName("PE_FECNAC");
            entity.Property(e => e.PeGrains)
                .HasMaxLength(255)
                .HasColumnName("PE_GRAINS");
            entity.Property(e => e.PeLogpar)
                .HasColumnType("smallint(6)")
                .HasColumnName("PE_LOGPAR");
            entity.Property(e => e.PeLogpro)
                .HasColumnType("smallint(6)")
                .HasColumnName("PE_LOGPRO");
            entity.Property(e => e.PeLogrel)
                .HasColumnType("int(11)")
                .HasColumnName("PE_LOGREL");
            entity.Property(e => e.PeLugnac)
                .HasMaxLength(50)
                .HasColumnName("PE_LUGNAC");
            entity.Property(e => e.PeMadre)
                .HasMaxLength(255)
                .HasColumnName("PE_MADRE");
            entity.Property(e => e.PeNacion)
                .HasMaxLength(100)
                .HasColumnName("PE_NACION");
            entity.Property(e => e.PeNombre)
                .HasMaxLength(100)
                .HasColumnName("PE_NOMBRE");
            entity.Property(e => e.PePadre)
                .HasMaxLength(255)
                .HasColumnName("PE_PADRE");
            entity.Property(e => e.PeRegtri)
                .HasMaxLength(100)
                .HasColumnName("PE_REGTRI");
            entity.Property(e => e.PeTelefo)
                .HasMaxLength(100)
                .HasColumnName("PE_TELEFO");
            entity.Property(e => e.PfFoto)
                .HasColumnType("mediumblob")
                .HasColumnName("PF_FOTO");
            entity.Property(e => e.PfFotoTxt)
                .HasMaxLength(255)
                .HasColumnName("PF_FOTO_TXT");
            entity.Property(e => e.PfNombre)
                .HasMaxLength(100)
                .HasColumnName("PF_NOMBRE");
            entity.Property(e => e.Poracc)
                .HasMaxLength(100)
                .HasColumnName("PORACC");
            entity.Property(e => e.SexDescri)
                .HasMaxLength(15)
                .HasColumnName("SEX_DESCRI");
            entity.Property(e => e.SitNombre)
                .HasMaxLength(100)
                .HasColumnName("SIT_NOMBRE");
            entity.Property(e => e.TitDescri)
                .HasMaxLength(50)
                .HasColumnName("TIT_DESCRI");
            entity.Property(e => e.TitParAno)
                .HasMaxLength(50)
                .HasColumnName("TIT_PAR_ANO");
            entity.Property(e => e.TitParCargo)
                .HasMaxLength(100)
                .HasColumnName("TIT_PAR_CARGO");
            entity.Property(e => e.TitParEmpresa)
                .HasMaxLength(50)
                .HasColumnName("TIT_PAR_EMPRESA");
            entity.Property(e => e.TitParPais)
                .HasMaxLength(50)
                .HasColumnName("TIT_PAR_PAIS");
            entity.Property(e => e.TitParticipado)
                .HasMaxLength(100)
                .HasColumnName("TIT_PARTICIPADO");
            entity.Property(e => e.TitPropiedades)
                .HasMaxLength(100)
                .HasColumnName("TIT_PROPIEDADES");
            entity.Property(e => e.TitRelCargo)
                .HasMaxLength(100)
                .HasColumnName("TIT_REL_CARGO");
            entity.Property(e => e.TitRelEmpresa)
                .HasMaxLength(150)
                .HasColumnName("TIT_REL_EMPRESA");
            entity.Property(e => e.TitRelPais)
                .HasMaxLength(100)
                .HasColumnName("TIT_REL_PAIS");
            entity.Property(e => e.TitRelRegtri)
                .HasMaxLength(100)
                .HasColumnName("TIT_REL_REGTRI");
            entity.Property(e => e.TitRelacionado)
                .HasMaxLength(150)
                .HasColumnName("TIT_RELACIONADO");
            entity.Property(e => e.TitTipo)
                .HasMaxLength(100)
                .HasColumnName("TIT_TIPO");
            entity.Property(e => e.TitValor)
                .HasMaxLength(50)
                .HasColumnName("TIT_VALOR");
            entity.Property(e => e.Titulo1)
                .HasMaxLength(50)
                .HasColumnName("TITULO1");
            entity.Property(e => e.Titulo2)
                .HasMaxLength(50)
                .HasColumnName("TITULO2");
            entity.Property(e => e.Titulo3)
                .HasMaxLength(50)
                .HasColumnName("TITULO3");
            entity.Property(e => e.Titulo4)
                .HasMaxLength(50)
                .HasColumnName("TITULO4");
            entity.Property(e => e.Titulo5)
                .HasMaxLength(50)
                .HasColumnName("TITULO5");
            entity.Property(e => e.Titulo6)
                .HasMaxLength(50)
                .HasColumnName("TITULO6");
            entity.Property(e => e.Titulo7)
                .HasMaxLength(50)
                .HasColumnName("TITULO7");
            entity.Property(e => e.Titulo8)
                .HasMaxLength(50)
                .HasColumnName("TITULO8");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsProAcep>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsProAcep");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.PaBoletin)
                .HasMaxLength(10)
                .HasColumnName("PA_BOLETIN");
            entity.Property(e => e.PaDiaatr)
                .HasColumnType("int(11)")
                .HasColumnName("PA_DIAATR");
            entity.Property(e => e.PaFecpro)
                .HasMaxLength(10)
                .HasColumnName("PA_FECPRO");
            entity.Property(e => e.PaFecreg)
                .HasMaxLength(10)
                .HasColumnName("PA_FECREG");
            entity.Property(e => e.PaGirador)
                .HasMaxLength(50)
                .HasColumnName("PA_GIRADOR");
            entity.Property(e => e.PaMonme).HasColumnName("PA_MONME");
            entity.Property(e => e.PaMonmn).HasColumnName("PA_MONMN");
            entity.Property(e => e.PaNumdoc)
                .HasMaxLength(10)
                .HasColumnName("PA_NUMDOC");
            entity.Property(e => e.PaTitulo)
                .HasMaxLength(50)
                .HasColumnName("PA_TITULO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsProv>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsProv");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.ProvComent)
                .HasColumnType("mediumtext")
                .HasColumnName("Prov_Coment");
            entity.Property(e => e.ProvCumple)
                .HasMaxLength(50)
                .HasColumnName("Prov_Cumple");
            entity.Property(e => e.ProvDeuAct)
                .HasMaxLength(20)
                .HasColumnName("Prov_DeuAct");
            entity.Property(e => e.ProvEstado)
                .HasMaxLength(50)
                .HasColumnName("Prov_Estado");
            entity.Property(e => e.ProvLinCre)
                .HasMaxLength(30)
                .HasColumnName("Prov_LinCre");
            entity.Property(e => e.ProvMensual)
                .HasMaxLength(50)
                .HasColumnName("PROV_MENSUAL");
            entity.Property(e => e.ProvNombre)
                .HasMaxLength(46)
                .HasColumnName("Prov_Nombre");
            entity.Property(e => e.ProvOrden)
                .HasColumnType("int(11)")
                .HasColumnName("PROV_ORDEN");
            entity.Property(e => e.ProvPais)
                .HasMaxLength(35)
                .HasColumnName("Prov_Pais");
            entity.Property(e => e.ProvPlazos)
                .HasMaxLength(50)
                .HasColumnName("Prov_Plazos");
            entity.Property(e => e.ProvTelefo)
                .HasMaxLength(80)
                .HasColumnName("Prov_Telefo");
            entity.Property(e => e.ProvTiempo)
                .HasMaxLength(50)
                .HasColumnName("Prov_Tiempo");
            entity.Property(e => e.ProvVenden)
                .HasMaxLength(50)
                .HasColumnName("Prov_Venden");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsProvSec>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsProvSec");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.ProvComent)
                .HasColumnType("mediumtext")
                .HasColumnName("Prov_Coment");
            entity.Property(e => e.ProvCumple)
                .HasMaxLength(15)
                .HasColumnName("Prov_Cumple");
            entity.Property(e => e.ProvDeuAct)
                .HasMaxLength(20)
                .HasColumnName("Prov_DeuAct");
            entity.Property(e => e.ProvEstado)
                .HasMaxLength(50)
                .HasColumnName("Prov_Estado");
            entity.Property(e => e.ProvLinCre)
                .HasMaxLength(30)
                .HasColumnName("Prov_LinCre");
            entity.Property(e => e.ProvMensual)
                .HasMaxLength(50)
                .HasColumnName("PROV_MENSUAL");
            entity.Property(e => e.ProvNombre)
                .HasMaxLength(46)
                .HasColumnName("Prov_Nombre");
            entity.Property(e => e.ProvOrden)
                .HasColumnType("int(10)")
                .HasColumnName("PROV_ORDEN");
            entity.Property(e => e.ProvPais)
                .HasMaxLength(35)
                .HasColumnName("Prov_Pais");
            entity.Property(e => e.ProvPlazos)
                .HasMaxLength(20)
                .HasColumnName("Prov_Plazos");
            entity.Property(e => e.ProvTelefo)
                .HasMaxLength(80)
                .HasColumnName("Prov_Telefo");
            entity.Property(e => e.ProvTiempo)
                .HasMaxLength(8)
                .HasColumnName("Prov_Tiempo");
            entity.Property(e => e.ProvVenden)
                .HasMaxLength(50)
                .HasColumnName("Prov_Venden");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsRepCom>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsRepCom");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.RcCodigo)
                .HasMaxLength(3)
                .HasColumnName("RC_CODIGO");
            entity.Property(e => e.RcNombre)
                .HasMaxLength(70)
                .HasColumnName("RC_NOMBRE");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlREmpVsSbd>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_rEmpVsSBD");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.SbdCalifi)
                .HasMaxLength(100)
                .HasColumnName("SBD_CALIFI");
            entity.Property(e => e.SbdMemo)
                .HasColumnType("text")
                .HasColumnName("SBD_MEMO");
            entity.Property(e => e.SbdMonme).HasColumnName("SBD_MONME");
            entity.Property(e => e.SbdMonto).HasColumnName("SBD_MONTO");
            entity.Property(e => e.SbdNombre)
                .HasMaxLength(32)
                .HasColumnName("SBD_NOMBRE");
            entity.Property(e => e.SbdSemaforo)
                .HasMaxLength(50)
                .HasColumnName("SBD_SEMAFORO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlTCiiu1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_tCIIU1");

            entity.Property(e => e.CcNombre)
                .HasMaxLength(250)
                .HasColumnName("CC_NOMBRE");
            entity.Property(e => e.CiNombre)
                .HasMaxLength(250)
                .HasColumnName("CI_NOMBRE");
            entity.Property(e => e.EmCatciiu1)
                .HasMaxLength(1)
                .HasColumnName("EM_CATCIIU1");
            entity.Property(e => e.EmCiiu1)
                .HasMaxLength(4)
                .HasColumnName("EM_CIIU1");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlTCiiu2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_tCIIU2");

            entity.Property(e => e.CcNombre)
                .HasMaxLength(250)
                .HasColumnName("CC_NOMBRE");
            entity.Property(e => e.CiNombre)
                .HasMaxLength(250)
                .HasColumnName("CI_NOMBRE");
            entity.Property(e => e.EmCatciiu1)
                .HasMaxLength(1)
                .HasColumnName("EM_CATCIIU1");
            entity.Property(e => e.EmCiiu1)
                .HasMaxLength(4)
                .HasColumnName("EM_CIIU1");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlTTempBalanceEmpresa>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_tTempBalanceEmpresa");

            entity.Property(e => e.BaAnobal)
                .HasMaxLength(4)
                .HasColumnName("BA_ANOBAL");
            entity.Property(e => e.BaFecbal)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBAL");
            entity.Property(e => e.BaTotcor).HasColumnName("BA_TOTCOR");
            entity.Property(e => e.BaTotcrr).HasColumnName("BA_TOTCRR");
            entity.Property(e => e.BaTotpat).HasColumnName("BA_TOTPAT");
            entity.Property(e => e.BaVentas).HasColumnName("BA_VENTAS");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlTTempSeguro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_tTempSeguros");

            entity.Property(e => e.Campo1)
                .HasMaxLength(40)
                .HasColumnName("CAMPO1");
            entity.Property(e => e.Campo2)
                .HasMaxLength(35)
                .HasColumnName("CAMPO2");
            entity.Property(e => e.Campo3)
                .HasMaxLength(20)
                .HasColumnName("CAMPO3");
            entity.Property(e => e.Campo4)
                .HasMaxLength(10)
                .HasColumnName("CAMPO4");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Titulo1)
                .HasMaxLength(10)
                .HasColumnName("TITULO1");
            entity.Property(e => e.Titulo2)
                .HasMaxLength(10)
                .HasColumnName("TITULO2");
            entity.Property(e => e.Titulo3)
                .HasMaxLength(10)
                .HasColumnName("TITULO3");
            entity.Property(e => e.Titulo4)
                .HasMaxLength(10)
                .HasColumnName("TITULO4");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<OlTTemporalEmpresa>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OL_tTemporalEmpresa");

            entity.Property(e => e.AboNombre)
                .HasMaxLength(90)
                .HasColumnName("ABO_NOMBRE");
            entity.Property(e => e.BaCapital).HasColumnName("BA_CAPITAL");
            entity.Property(e => e.BaEndeudamiento).HasColumnName("BA_ENDEUDAMIENTO");
            entity.Property(e => e.BaFecbal1)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBAL1");
            entity.Property(e => e.BaFecbalance)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBALANCE");
            entity.Property(e => e.BaLiquidez).HasColumnName("BA_LIQUIDEZ");
            entity.Property(e => e.BaMoneda1)
                .HasMaxLength(50)
                .HasColumnName("BA_MONEDA1");
            entity.Property(e => e.BaRentabilidad).HasColumnName("BA_RENTABILIDAD");
            entity.Property(e => e.BaTotcor1).HasColumnName("BA_TOTCOR1");
            entity.Property(e => e.BaTotcrr1).HasColumnName("BA_TOTCRR1");
            entity.Property(e => e.BaTotpat1).HasColumnName("BA_TOTPAT1");
            entity.Property(e => e.BaUtiper1).HasColumnName("BA_UTIPER1");
            entity.Property(e => e.BaVentas1).HasColumnName("BA_VENTAS1");
            entity.Property(e => e.CalCodigo)
                .HasMaxLength(3)
                .HasColumnName("CAL_CODIGO");
            entity.Property(e => e.CalNombre)
                .HasMaxLength(100)
                .HasColumnName("CAL_NOMBRE");
            entity.Property(e => e.CiNombre)
                .HasMaxLength(100)
                .HasColumnName("CI_NOMBRE");
            entity.Property(e => e.CpNombre)
                .HasMaxLength(200)
                .HasColumnName("CP_NOMBRE");
            entity.Property(e => e.CrCodigo)
                .HasMaxLength(4)
                .HasColumnName("CR_CODIGO");
            entity.Property(e => e.CrNombre)
                .HasMaxLength(85)
                .HasColumnName("CR_NOMBRE");
            entity.Property(e => e.CsCodigo)
                .HasMaxLength(3)
                .HasColumnName("CS_CODIGO");
            entity.Property(e => e.CsDescri)
                .HasMaxLength(150)
                .HasColumnName("CS_DESCRI");
            entity.Property(e => e.CsInterp)
                .HasColumnType("mediumtext")
                .HasColumnName("CS_INTERP");
            entity.Property(e => e.CupCodigo)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.CupFecped)
                .HasMaxLength(20)
                .HasColumnName("CUP_FECPED");
            entity.Property(e => e.CupIdioma)
                .HasMaxLength(255)
                .HasColumnName("CUP_IDIOMA");
            entity.Property(e => e.CupNomsol)
                .HasMaxLength(100)
                .HasColumnName("CUP_NOMSOL");
            entity.Property(e => e.CupNroord)
                .HasMaxLength(100)
                .HasColumnName("CUP_NROORD");
            entity.Property(e => e.CupRefabo)
                .HasMaxLength(80)
                .HasColumnName("CUP_REFABO");
            entity.Property(e => e.CupTipinf)
                .HasMaxLength(2)
                .HasColumnName("CUP_TIPINF");
            entity.Property(e => e.DiCodigo)
                .HasMaxLength(4)
                .HasColumnName("DI_CODIGO");
            entity.Property(e => e.DiNombre)
                .HasColumnType("text")
                .HasColumnName("DI_NOMBRE");
            entity.Property(e => e.EmActivi)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_ACTIVI");
            entity.Property(e => e.EmAfilia)
                .HasMaxLength(100)
                .HasColumnName("EM_AFILIA");
            entity.Property(e => e.EmAnalista)
                .HasColumnType("text")
                .HasColumnName("EM_ANALISTA");
            entity.Property(e => e.EmAnalistaVb)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_ANALISTA_VB");
            entity.Property(e => e.EmAnobal)
                .HasMaxLength(4)
                .HasColumnName("EM_ANOBAL");
            entity.Property(e => e.EmAnofun)
                .HasMaxLength(4)
                .HasColumnName("EM_ANOFUN");
            entity.Property(e => e.EmAntcre)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_ANTCRE");
            entity.Property(e => e.EmAntece)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_ANTECE");
            entity.Property(e => e.EmArea)
                .HasMaxLength(100)
                .HasColumnName("EM_AREA");
            entity.Property(e => e.EmAspcon)
                .HasMaxLength(100)
                .HasColumnName("EM_ASPCON");
            entity.Property(e => e.EmAudito)
                .HasMaxLength(150)
                .HasColumnName("EM_AUDITO");
            entity.Property(e => e.EmBalgen)
                .HasColumnType("smallint(6)")
                .HasColumnName("EM_BALGEN");
            entity.Property(e => e.EmBalsit)
                .HasColumnType("smallint(6)")
                .HasColumnName("EM_BALSIT");
            entity.Property(e => e.EmBanco)
                .HasColumnType("text")
                .HasColumnName("EM_BANCO");
            entity.Property(e => e.EmCalsbs)
                .HasMaxLength(20)
                .HasColumnName("EM_CALSBS");
            entity.Property(e => e.EmCapac1)
                .HasMaxLength(100)
                .HasColumnName("EM_CAPAC1");
            entity.Property(e => e.EmCapact)
                .HasMaxLength(100)
                .HasColumnName("EM_CAPACT");
            entity.Property(e => e.EmCapini)
                .HasMaxLength(100)
                .HasColumnName("EM_CAPINI");
            entity.Property(e => e.EmCargos)
                .HasMaxLength(100)
                .HasColumnName("EM_CARGOS");
            entity.Property(e => e.EmCatciiu1)
                .HasMaxLength(200)
                .HasColumnName("EM_CATCIIU1");
            entity.Property(e => e.EmCatciiu2)
                .HasMaxLength(1000)
                .HasColumnName("EM_CATCIIU2");
            entity.Property(e => e.EmCenrie)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_CENRIE");
            entity.Property(e => e.EmChkban)
                .HasMaxLength(1)
                .HasColumnName("EM_CHKBAN");
            entity.Property(e => e.EmCiiu1)
                .HasMaxLength(4)
                .HasColumnName("EM_CIIU1");
            entity.Property(e => e.EmCiiu2)
                .HasMaxLength(4)
                .HasColumnName("EM_CIIU2");
            entity.Property(e => e.EmCiudad)
                .HasMaxLength(50)
                .HasColumnName("EM_CIUDAD");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EmCodpos)
                .HasMaxLength(20)
                .HasColumnName("EM_CODPOS");
            entity.Property(e => e.EmComen)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_COMEN");
            entity.Property(e => e.EmComenTab)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_COMEN_TAB");
            entity.Property(e => e.EmComent)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_COMENT");
            entity.Property(e => e.EmComext)
                .HasMaxLength(100)
                .HasColumnName("EM_COMEXT");
            entity.Property(e => e.EmComide)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_COMIDE");
            entity.Property(e => e.EmComlit)
                .HasColumnType("text")
                .HasColumnName("EM_COMLIT");
            entity.Property(e => e.EmComnac)
                .HasMaxLength(100)
                .HasColumnName("EM_COMNAC");
            entity.Property(e => e.EmComprov)
                .HasColumnType("text")
                .HasColumnName("EM_COMPROV");
            entity.Property(e => e.EmComrep)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_COMREP");
            entity.Property(e => e.EmConinf)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_CONINF");
            entity.Property(e => e.EmCotbol)
                .HasMaxLength(3)
                .HasColumnName("EM_COTBOL");
            entity.Property(e => e.EmCrerec)
                .HasMaxLength(32)
                .HasColumnName("EM_CREREC");
            entity.Property(e => e.EmDepart)
                .HasMaxLength(50)
                .HasColumnName("EM_DEPART");
            entity.Property(e => e.EmDirecc)
                .HasMaxLength(200)
                .HasColumnName("EM_DIRECC");
            entity.Property(e => e.EmDistri)
                .HasMaxLength(50)
                .HasColumnName("EM_DISTRI");
            entity.Property(e => e.EmDomant)
                .HasMaxLength(150)
                .HasColumnName("EM_DOMANT");
            entity.Property(e => e.EmDuraci)
                .HasMaxLength(100)
                .HasColumnName("EM_DURACI");
            entity.Property(e => e.EmEmail)
                .HasMaxLength(200)
                .HasColumnName("EM_EMAIL");
            entity.Property(e => e.EmEmprel)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_EMPREL");
            entity.Property(e => e.EmEntrev)
                .HasMaxLength(200)
                .HasColumnName("EM_ENTREV");
            entity.Property(e => e.EmEquip)
                .HasMaxLength(100)
                .HasColumnName("EM_EQUIP");
            entity.Property(e => e.EmEstadoempresa)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("EM_ESTADOEMPRESA");
            entity.Property(e => e.EmExportanDonde1)
                .HasMaxLength(1000)
                .HasColumnName("EM_EXPORTAN_DONDE1");
            entity.Property(e => e.EmExportanDonde2)
                .HasMaxLength(1000)
                .HasColumnName("EM_EXPORTAN_DONDE2");
            entity.Property(e => e.EmFax)
                .HasMaxLength(200)
                .HasColumnName("EM_FAX");
            entity.Property(e => e.EmFecaum)
                .HasMaxLength(100)
                .HasColumnName("EM_FECAUM");
            entity.Property(e => e.EmFecbalAnu2)
                .HasMaxLength(10)
                .HasColumnName("EM_FECBAL_ANU2");
            entity.Property(e => e.EmFecest)
                .HasMaxLength(10)
                .HasColumnName("EM_FECEST");
            entity.Property(e => e.EmFecinf)
                .HasColumnType("datetime")
                .HasColumnName("EM_FECINF");
            entity.Property(e => e.EmFecreg)
                .HasMaxLength(10)
                .HasColumnName("EM_FECREG");
            entity.Property(e => e.EmGaome).HasColumnName("EM_GAOME");
            entity.Property(e => e.EmGaomn).HasColumnName("EM_GAOMN");
            entity.Property(e => e.EmGrado)
                .HasMaxLength(100)
                .HasColumnName("EM_GRADO");
            entity.Property(e => e.EmImportan)
                .HasMaxLength(3)
                .HasColumnName("EM_IMPORTAN");
            entity.Property(e => e.EmImportanDonde1)
                .HasMaxLength(1000)
                .HasColumnName("EM_IMPORTAN_DONDE1");
            entity.Property(e => e.EmImportanDonde2)
                .HasMaxLength(1000)
                .HasColumnName("EM_IMPORTAN_DONDE2");
            entity.Property(e => e.EmInfgen)
                .HasColumnType("text")
                .HasColumnName("EM_INFGEN");
            entity.Property(e => e.EmInfpro)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_INFPRO");
            entity.Property(e => e.EmIngecu)
                .HasColumnType("text")
                .HasColumnName("EM_INGECU");
            entity.Property(e => e.EmIniope)
                .HasMaxLength(10)
                .HasColumnName("EM_INIOPE");
            entity.Property(e => e.EmLogInffin)
                .HasColumnType("smallint(6)")
                .HasColumnName("EM_LOG_INFFIN");
            entity.Property(e => e.EmLogexp)
                .HasMaxLength(3)
                .HasColumnName("EM_LOGEXP");
            entity.Property(e => e.EmLoggrafico)
                .HasColumnType("smallint(6)")
                .HasColumnName("EM_LOGGRAFICO");
            entity.Property(e => e.EmLogpre)
                .HasColumnType("smallint(6)")
                .HasColumnName("EM_LOGPRE");
            entity.Property(e => e.EmLogrel)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("EM_LOGREL");
            entity.Property(e => e.EmLogventas)
                .HasColumnType("smallint(6)")
                .HasColumnName("EM_LOGVENTAS");
            entity.Property(e => e.EmMatriz)
                .HasMaxLength(150)
                .HasColumnName("EM_MATRIZ");
            entity.Property(e => e.EmMonacc)
                .HasMaxLength(100)
                .HasColumnName("EM_MONACC");
            entity.Property(e => e.EmMorBan)
                .HasColumnType("int(11)")
                .HasColumnName("EM_MOR_BAN");
            entity.Property(e => e.EmMorCom)
                .HasColumnType("int(11)")
                .HasColumnName("EM_MOR_COM");
            entity.Property(e => e.EmMorosidad)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_MOROSIDAD");
            entity.Property(e => e.EmMorosidadIng)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_MOROSIDAD_ING");
            entity.Property(e => e.EmMtopcr)
                .HasMaxLength(32)
                .HasColumnName("EM_MTOPCR");
            entity.Property(e => e.EmNombre)
                .HasMaxLength(120)
                .HasColumnName("EM_NOMBRE");
            entity.Property(e => e.EmNomcrr)
                .HasMaxLength(3)
                .HasColumnName("EM_NOMCRR");
            entity.Property(e => e.EmNomvia)
                .HasMaxLength(100)
                .HasColumnName("EM_NOMVIA");
            entity.Property(e => e.EmNotari)
                .HasMaxLength(100)
                .HasColumnName("EM_NOTARI");
            entity.Property(e => e.EmNument)
                .HasMaxLength(5)
                .HasColumnName("EM_NUMENT");
            entity.Property(e => e.EmNumhis)
                .HasMaxLength(50)
                .HasColumnName("EM_NUMHIS");
            entity.Property(e => e.EmObserv)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_OBSERV");
            entity.Property(e => e.EmOcDescri)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_OC_DESCRI");
            entity.Property(e => e.EmOpicre)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_OPICRE");
            entity.Property(e => e.EmPagweb)
                .HasMaxLength(100)
                .HasColumnName("EM_PAGWEB");
            entity.Property(e => e.EmPatri1)
                .HasMaxLength(100)
                .HasColumnName("EM_PATRI1");
            entity.Property(e => e.EmPatrim)
                .HasMaxLength(100)
                .HasColumnName("EM_PATRIM");
            entity.Property(e => e.EmPiso)
                .HasMaxLength(30)
                .HasColumnName("EM_PISO");
            entity.Property(e => e.EmPisos)
                .HasMaxLength(10)
                .HasColumnName("EM_PISOS");
            entity.Property(e => e.EmPrensa)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_PRENSA");
            entity.Property(e => e.EmPrensasel)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_PRENSASEL");
            entity.Property(e => e.EmPropie)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_PROPIE");
            entity.Property(e => e.EmRegen)
                .HasMaxLength(50)
                .HasColumnName("EM_REGEN");
            entity.Property(e => e.EmRegist)
                .HasMaxLength(100)
                .HasColumnName("EM_REGIST");
            entity.Property(e => e.EmRegtri)
                .HasMaxLength(18)
                .HasColumnName("EM_REGTRI");
            entity.Property(e => e.EmSeguro)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_SEGURO");
            entity.Property(e => e.EmSiglas)
                .HasMaxLength(50)
                .HasColumnName("EM_SIGLAS");
            entity.Property(e => e.EmSitfin)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_SITFIN");
            entity.Property(e => e.EmSitfinTab)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_SITFIN_TAB");
            entity.Property(e => e.EmSnopcr)
                .HasMaxLength(20)
                .HasColumnName("EM_SNOPCR");
            entity.Property(e => e.EmSubacu)
                .HasColumnType("text")
                .HasColumnName("EM_SUBACU");
            entity.Property(e => e.EmSupban)
                .HasColumnType("text")
                .HasColumnName("EM_SUPBAN");
            entity.Property(e => e.EmTcsbs).HasColumnName("EM_TCSBS");
            entity.Property(e => e.EmTelef1)
                .HasMaxLength(200)
                .HasColumnName("EM_TELEF1");
            entity.Property(e => e.EmTelef2)
                .HasMaxLength(200)
                .HasColumnName("EM_TELEF2");
            entity.Property(e => e.EmTervta)
                .HasMaxLength(100)
                .HasColumnName("EM_TERVTA");
            entity.Property(e => e.EmTiopcr)
                .HasMaxLength(100)
                .HasColumnName("EM_TIOPCR");
            entity.Property(e => e.EmTipacc)
                .HasMaxLength(100)
                .HasColumnName("EM_TIPACC");
            entity.Property(e => e.EmTipcam)
                .HasMaxLength(100)
                .HasColumnName("EM_TIPCAM");
            entity.Property(e => e.EmTipcamAnu2).HasColumnName("EM_TIPCAM_ANU2");
            entity.Property(e => e.EmTiploc)
                .HasMaxLength(100)
                .HasColumnName("EM_TIPLOC");
            entity.Property(e => e.EmTipocu)
                .HasMaxLength(100)
                .HasColumnName("EM_TIPOCU");
            entity.Property(e => e.EmTipper)
                .HasColumnType("int(11)")
                .HasColumnName("EM_TIPPER");
            entity.Property(e => e.EmTipvia)
                .HasMaxLength(15)
                .HasColumnName("EM_TIPVIA");
            entity.Property(e => e.EmTraba1)
                .HasMaxLength(100)
                .HasColumnName("EM_TRABA1");
            entity.Property(e => e.EmTraba1Anno)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_TRABA1_ANNO");
            entity.Property(e => e.EmTraba2)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_TRABA2");
            entity.Property(e => e.EmTraba2Anno)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_TRABA2_ANNO");
            entity.Property(e => e.EmTrabaj)
                .HasMaxLength(100)
                .HasColumnName("EM_TRABAJ");
            entity.Property(e => e.EmUso)
                .HasMaxLength(100)
                .HasColumnName("EM_USO");
            entity.Property(e => e.EmValacc)
                .HasMaxLength(100)
                .HasColumnName("EM_VALACC");
            entity.Property(e => e.EmValor)
                .HasMaxLength(100)
                .HasColumnName("EM_VALOR");
            entity.Property(e => e.EmVencon)
                .HasMaxLength(100)
                .HasColumnName("EM_VENCON");
            entity.Property(e => e.EmVencre)
                .HasMaxLength(100)
                .HasColumnName("EM_VENCRE");
            entity.Property(e => e.EmVentas).HasColumnName("EM_VENTAS");
            entity.Property(e => e.EmVentasAnu2).HasColumnName("EM_VENTAS_ANU2");
            entity.Property(e => e.EmVtaext)
                .HasMaxLength(100)
                .HasColumnName("EM_VTAEXT");
            entity.Property(e => e.EmVtamon)
                .HasMaxLength(100)
                .HasColumnName("EM_VTAMON");
            entity.Property(e => e.EmVtatipcam)
                .HasMaxLength(100)
                .HasColumnName("EM_VTATIPCAM");
            entity.Property(e => e.Fax)
                .HasMaxLength(100)
                .HasColumnName("FAX");
            entity.Property(e => e.JuCodigo)
                .HasMaxLength(3)
                .HasColumnName("JU_CODIGO");
            entity.Property(e => e.JuNombre)
                .HasMaxLength(80)
                .HasColumnName("JU_NOMBRE");
            entity.Property(e => e.OcCodigo)
                .HasMaxLength(3)
                .HasColumnName("OC_CODIGO");
            entity.Property(e => e.OcDescri)
                .HasColumnType("mediumtext")
                .HasColumnName("OC_DESCRI");
            entity.Property(e => e.PaCodigo)
                .HasMaxLength(2)
                .HasColumnName("PA_CODIGO");
            entity.Property(e => e.PaNombre)
                .HasMaxLength(80)
                .HasColumnName("PA_NOMBRE");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.PaiDoctrb)
                .HasMaxLength(6)
                .HasColumnName("PAI_DOCTRB");
            entity.Property(e => e.PaiNombre)
                .HasMaxLength(45)
                .HasColumnName("PAI_NOMBRE");
            entity.Property(e => e.PeNombre)
                .HasMaxLength(100)
                .HasColumnName("PE_NOMBRE");
            entity.Property(e => e.PerCodage)
                .HasMaxLength(3)
                .HasColumnName("PER_CODAGE");
            entity.Property(e => e.PerCoddig)
                .HasMaxLength(3)
                .HasColumnName("PER_CODDIG");
            entity.Property(e => e.PerCodrep)
                .HasMaxLength(3)
                .HasColumnName("PER_CODREP");
            entity.Property(e => e.PerCodsup)
                .HasMaxLength(3)
                .HasColumnName("PER_CODSUP");
            entity.Property(e => e.PerCodtra)
                .HasMaxLength(3)
                .HasColumnName("PER_CODTRA");
            entity.Property(e => e.SfNombre)
                .HasMaxLength(50)
                .HasColumnName("SF_NOMBRE");
            entity.Property(e => e.SitCodigo)
                .HasMaxLength(2)
                .HasColumnName("SIT_CODIGO");
            entity.Property(e => e.SitDesde)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("SIT_DESDE");
            entity.Property(e => e.SitNombre)
                .HasMaxLength(50)
                .HasColumnName("SIT_NOMBRE");
            entity.Property(e => e.Situacion)
                .HasColumnType("mediumtext")
                .HasColumnName("SITUACION");
            entity.Property(e => e.TaNombre)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("TA_NOMBRE");
            entity.Property(e => e.TdCodigo)
                .HasMaxLength(2)
                .HasColumnName("TD_CODIGO");
            entity.Property(e => e.TdNombre)
                .HasMaxLength(50)
                .HasColumnName("TD_NOMBRE");
            entity.Property(e => e.Telefo)
                .HasMaxLength(100)
                .HasColumnName("TELEFO");
            entity.Property(e => e.TlNombre)
                .HasMaxLength(50)
                .HasColumnName("TL_NOMBRE");
            entity.Property(e => e.TramNombre)
                .HasMaxLength(2)
                .HasColumnName("TRAM_NOMBRE");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<RAboBan>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rAboBan");

            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.BanCodigo)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("BAN_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.MonCodigo)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("MON_CODIGO");
        });

        modelBuilder.Entity<RAboVsCup>(entity =>
        {
            entity.HasKey(e => e.CupCodigo).HasName("PRIMARY");

            entity.ToTable("rAboVsCup", tb => tb.HasComment("Detalle de los Pedidos de Abonados con Cupones"));

            entity.Property(e => e.CupCodigo)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.AcCupcon)
                .HasDefaultValueSql("'0.00'")
                .HasComment("Numero de Cupones Consumidos")
                .HasColumnType("double(10,2)")
                .HasColumnName("AC_CUPCON");
            entity.Property(e => e.AcCupdis)
                .HasDefaultValueSql("'0.00'")
                .HasComment("Cupones Disponibles a la Fecha")
                .HasColumnType("double(10,2)")
                .HasColumnName("AC_CUPDIS");
            entity.Property(e => e.AcFecha)
                .HasColumnType("datetime")
                .HasColumnName("AC_FECHA");
            entity.Property(e => e.Migra)
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<RAboVsIng>(entity =>
        {
            entity.HasKey(e => e.AiCodigo).HasName("PRIMARY");

            entity.ToTable("rAboVsIng");

            entity.HasIndex(e => e.AiCodigo, "AI_CODIGO");

            entity.Property(e => e.AiCodigo)
                .HasColumnType("int(10)")
                .HasColumnName("AI_CODIGO");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.AiFecing)
                .HasColumnType("datetime")
                .HasColumnName("AI_FECING");
            entity.Property(e => e.AiFecsal)
                .HasColumnType("datetime")
                .HasColumnName("AI_FECSAL");
            entity.Property(e => e.Migra)
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<RCupVsAbo>(entity =>
        {
            entity.HasKey(e => e.EcCodigo).HasName("PRIMARY");

            entity.ToTable("rCupVsAbo", tb => tb.HasComment("Tabla Historico de Pedidos"));

            entity.Property(e => e.EcCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("EC_CODIGO");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.CrNombre)
                .HasMaxLength(50)
                .HasColumnName("CR_Nombre");
            entity.Property(e => e.CupCodigo)
                .HasMaxLength(20)
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.CupDirecc)
                .HasMaxLength(400)
                .HasColumnName("CUP_DIRECC");
            entity.Property(e => e.CupFecdes)
                .HasComment("Fecha de Despacho")
                .HasColumnType("datetime")
                .HasColumnName("CUP_FECDES");
            entity.Property(e => e.CupFecped)
                .HasColumnType("datetime")
                .HasColumnName("CUP_FECPED");
            entity.Property(e => e.CupNomsol)
                .HasMaxLength(100)
                .HasColumnName("CUP_NOMSOL");
            entity.Property(e => e.CupNroord)
                .HasMaxLength(15)
                .HasColumnName("CUP_NROORD");
            entity.Property(e => e.CupNroref)
                .HasMaxLength(80)
                .HasColumnName("CUP_NROREF");
            entity.Property(e => e.CupTipinf)
                .HasMaxLength(2)
                .HasColumnName("CUP_TIPINF");
            entity.Property(e => e.EmAnobal)
                .HasMaxLength(4)
                .HasColumnName("EM_ANOBAL");
            entity.Property(e => e.EmEntrev)
                .HasMaxLength(150)
                .HasColumnName("EM_ENTREV");
            entity.Property(e => e.EmFecCla)
                .HasMaxLength(8)
                .HasColumnName("Em_FecCla");
            entity.Property(e => e.EmPatBal).HasColumnName("Em_PatBal");
            entity.Property(e => e.EmTenden)
                .HasMaxLength(50)
                .HasColumnName("Em_Tenden");
            entity.Property(e => e.EmTipcam).HasColumnName("EM_TIPCAM");
            entity.Property(e => e.EmTrabaj)
                .HasMaxLength(50)
                .HasColumnName("Em_Trabaj");
            entity.Property(e => e.EmVenBal).HasColumnName("Em_VenBal");
            entity.Property(e => e.EpCodigo)
                .HasMaxLength(11)
                .HasColumnName("EP_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.MonNombre)
                .HasMaxLength(17)
                .HasColumnName("MON_NOMBRE");
            entity.Property(e => e.PaNombre)
                .HasMaxLength(60)
                .HasColumnName("Pa_Nombre");
            entity.Property(e => e.PerCodage)
                .HasMaxLength(3)
                .HasColumnName("PER_CODAGE");
            entity.Property(e => e.PerCoddig)
                .HasMaxLength(3)
                .HasColumnName("PER_CODDIG");
            entity.Property(e => e.PerCodrep)
                .HasMaxLength(3)
                .HasColumnName("PER_CODREP");
            entity.Property(e => e.PerCodsup)
                .HasMaxLength(3)
                .HasColumnName("PER_CODSUP");
            entity.Property(e => e.PerCodtra)
                .HasMaxLength(3)
                .HasColumnName("PER_CODTRA");
            entity.Property(e => e.RcNombre)
                .HasMaxLength(50)
                .HasColumnName("RC_NOMBRE");
            entity.Property(e => e.TramCodigo)
                .HasMaxLength(2)
                .HasColumnName("TRAM_CODIGO");
            entity.Property(e => e.TramNombre)
                .HasMaxLength(2)
                .HasColumnName("TRAM_NOMBRE");
        });

        modelBuilder.Entity<RCuponesOffLine>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rCuponesOffLine");

            entity.Property(e => e.CupCodigo)
                .HasColumnType("bigint(20)")
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.Flag)
                .HasColumnType("int(11)")
                .HasColumnName("FLAG");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<REmpBvsPro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rEmpBVsPro");

            entity.Property(e => e.CumCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("CUM_CODIGO");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PrCremax)
                .HasMaxLength(50)
                .HasColumnName("PR_CREMAX");
            entity.Property(e => e.PrCremaxIng)
                .HasMaxLength(50)
                .HasColumnName("PR_CREMAX_ING");
            entity.Property(e => e.PrNombre)
                .HasMaxLength(100)
                .HasColumnName("PR_NOMBRE");
        });

        modelBuilder.Entity<REmpBvsVta>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rEmpBVsVtas");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EvAnio)
                .HasMaxLength(4)
                .HasColumnName("EV_ANIO");
            entity.Property(e => e.EvTipcam)
                .HasColumnType("double(15,2)")
                .HasColumnName("EV_TIPCAM");
            entity.Property(e => e.EvVentas)
                .HasColumnType("double(15,2)")
                .HasColumnName("EV_VENTAS");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<REmpVsAct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rEmpVsAct");

            entity.HasIndex(e => e.EmCodigo, "FK_EM_CODIGO");

            entity.HasIndex(e => e.RamBCodigo, "FK_ramB_Codigo");

            entity.HasIndex(e => e.RamCodigo, "FK_ram_Codigo");

            entity.HasIndex(e => e.SecCodigo, "FK_sec_Codigo");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("MIGRA");
            entity.Property(e => e.RamBCodigo)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ramB_Codigo");
            entity.Property(e => e.RamCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("ram_Codigo");
            entity.Property(e => e.SecCodigo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("sec_Codigo");
        });

        modelBuilder.Entity<REmpVsAspLeg>(entity =>
        {
            entity.HasKey(e => e.EmCodigo).HasName("PRIMARY");

            entity.ToTable("rEmpVsAspLeg");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EmAfilia)
                .HasMaxLength(100)
                .HasColumnName("EM_AFILIA");
            entity.Property(e => e.EmAntece)
                .HasColumnType("text")
                .HasColumnName("EM_ANTECE");
            entity.Property(e => e.EmAnteceIng)
                .HasColumnType("text")
                .HasColumnName("EM_ANTECE_ING");
            entity.Property(e => e.EmCapac1)
                .HasMaxLength(50)
                .HasColumnName("EM_CAPAC1");
            entity.Property(e => e.EmCapac1Ing)
                .HasMaxLength(50)
                .HasColumnName("EM_CAPAC1_ING");
            entity.Property(e => e.EmCapact)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("EM_CAPACT");
            entity.Property(e => e.EmCapactComent)
                .HasMaxLength(1500)
                .HasColumnName("EM_CAPACT_COMENT");
            entity.Property(e => e.EmCapini)
                .HasMaxLength(50)
                .HasColumnName("EM_CAPINI");
            entity.Property(e => e.EmCapiniIng)
                .HasMaxLength(50)
                .HasColumnName("EM_CAPINI_ING");
            entity.Property(e => e.EmComent)
                .HasColumnType("text")
                .HasColumnName("EM_COMENT");
            entity.Property(e => e.EmComentIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMENT_ING");
            entity.Property(e => e.EmCotbol)
                .HasMaxLength(3)
                .HasColumnName("EM_COTBOL");
            entity.Property(e => e.EmDuraci)
                .HasMaxLength(300)
                .HasColumnName("EM_DURACI");
            entity.Property(e => e.EmDuraciIng)
                .HasMaxLength(300)
                .HasColumnName("EM_DURACI_ING");
            entity.Property(e => e.EmEmprel)
                .HasColumnType("text")
                .HasColumnName("EM_EMPREL");
            entity.Property(e => e.EmEmprelIng)
                .HasColumnType("text")
                .HasColumnName("EM_EMPREL_ING");
            entity.Property(e => e.EmFecaum)
                .HasMaxLength(50)
                .HasColumnName("EM_FECAUM");
            entity.Property(e => e.EmFecaumIng)
                .HasMaxLength(50)
                .HasColumnName("EM_FECAUM_ING");
            entity.Property(e => e.EmFecest)
                .HasMaxLength(10)
                .HasColumnName("EM_FECEST");
            entity.Property(e => e.EmIniope)
                .HasMaxLength(10)
                .HasColumnName("EM_INIOPE");
            entity.Property(e => e.EmMonacc)
                .HasMaxLength(17)
                .HasColumnName("EM_MONACC");
            entity.Property(e => e.EmNotari)
                .HasMaxLength(100)
                .HasColumnName("EM_NOTARI");
            entity.Property(e => e.EmOrigen)
                .HasMaxLength(20)
                .HasColumnName("EM_ORIGEN");
            entity.Property(e => e.EmOrigenIng)
                .HasMaxLength(20)
                .HasColumnName("EM_ORIGEN_ING");
            entity.Property(e => e.EmPatri1)
                .HasMaxLength(50)
                .HasColumnName("EM_PATRI1");
            entity.Property(e => e.EmPatri1Ing)
                .HasMaxLength(50)
                .HasColumnName("EM_PATRI1_ING");
            entity.Property(e => e.EmPatrim)
                .HasDefaultValueSql("'0'")
                .HasColumnName("EM_PATRIM");
            entity.Property(e => e.EmRegen)
                .HasMaxLength(50)
                .HasColumnName("EM_REGEN");
            entity.Property(e => e.EmRegenIng)
                .HasMaxLength(50)
                .HasColumnName("EM_REGEN_ING");
            entity.Property(e => e.EmRegist)
                .HasMaxLength(100)
                .HasColumnName("EM_REGIST");
            entity.Property(e => e.EmRegistIng)
                .HasMaxLength(50)
                .HasColumnName("EM_REGIST_ING");
            entity.Property(e => e.EmRrppFecha)
                .HasMaxLength(10)
                .HasColumnName("EM_RRPP_FECHA");
            entity.Property(e => e.EmRrppPor)
                .HasMaxLength(20)
                .HasColumnName("EM_RRPP_POR");
            entity.Property(e => e.EmTipacc)
                .HasMaxLength(50)
                .HasColumnName("EM_TIPACC");
            entity.Property(e => e.EmTipaccIng)
                .HasMaxLength(50)
                .HasColumnName("EM_TIPACC_ING");
            entity.Property(e => e.EmTipcam)
                .HasMaxLength(40)
                .HasColumnName("EM_TIPCAM");
            entity.Property(e => e.EmTipcamIng)
                .HasMaxLength(40)
                .HasColumnName("EM_TIPCAM_ING");
            entity.Property(e => e.EmTipfecaum)
                .HasMaxLength(50)
                .HasColumnName("EM_TIPFECAUM");
            entity.Property(e => e.EmTipfecaumIng)
                .HasMaxLength(50)
                .HasColumnName("EM_TIPFECAUM_ING");
            entity.Property(e => e.EmValacc)
                .HasMaxLength(50)
                .HasColumnName("EM_VALACC");
            entity.Property(e => e.EmValaccIng)
                .HasMaxLength(50)
                .HasColumnName("EM_VALACC_ING");
            entity.Property(e => e.EmVentas)
                .HasDefaultValueSql("'0'")
                .HasColumnName("EM_VENTAS");
            entity.Property(e => e.EmVtamon)
                .HasMaxLength(17)
                .HasColumnName("EM_VTAMON");
            entity.Property(e => e.EmVtatipcam)
                .HasDefaultValueSql("'0'")
                .HasColumnName("EM_VTATIPCAM");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiMone)
                .HasMaxLength(6)
                .HasColumnName("Pai_Mone");
        });

        modelBuilder.Entity<REmpVsB>(entity =>
        {
            entity.HasKey(e => e.EmCodigo).HasName("PRIMARY");

            entity.ToTable("rEmpVsBs");

            entity.HasIndex(e => e.EmCodigo, "EM_CODIGO");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.BsActCorOtr2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_ActCorOtr2");
            entity.Property(e => e.BsActCorOtr3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_ActCorOtr3");
            entity.Property(e => e.BsActCorOtr4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_ActCorOtr4");
            entity.Property(e => e.BsActcorotr1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_ACTCOROTR1");
            entity.Property(e => e.BsActotr1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_ACTOTR1");
            entity.Property(e => e.BsActotr2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_ACTOTR2");
            entity.Property(e => e.BsActotr3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_ACTOTR3");
            entity.Property(e => e.BsActotr4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_ACTOTR4");
            entity.Property(e => e.BsBanpro1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_BANPRO1");
            entity.Property(e => e.BsBanpro2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_BANPRO2");
            entity.Property(e => e.BsBanpro3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_BANPRO3");
            entity.Property(e => e.BsBanpro4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_BANPRO4");
            entity.Property(e => e.BsCajban1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_CAJBAN1");
            entity.Property(e => e.BsCajban2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_CAJBAN2");
            entity.Property(e => e.BsCajban3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_CAJBAN3");
            entity.Property(e => e.BsCajban4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_CAJBAN4");
            entity.Property(e => e.BsCapita1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_CAPITA1");
            entity.Property(e => e.BsCapita2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_CAPITA2");
            entity.Property(e => e.BsCapita3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_CAPITA3");
            entity.Property(e => e.BsCapita4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_CAPITA4");
            entity.Property(e => e.BsCorotr1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_COROTR1");
            entity.Property(e => e.BsCorotr2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_COROTR2");
            entity.Property(e => e.BsCorotr3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_COROTR3");
            entity.Property(e => e.BsCorotr4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_COROTR4");
            entity.Property(e => e.BsFecbal1)
                .HasMaxLength(10)
                .HasColumnName("BS_FECBAL1");
            entity.Property(e => e.BsFecbal2)
                .HasMaxLength(10)
                .HasColumnName("BS_FECBAL2");
            entity.Property(e => e.BsFecbal3)
                .HasMaxLength(10)
                .HasColumnName("BS_FECBAL3");
            entity.Property(e => e.BsFecbal4)
                .HasMaxLength(10)
                .HasColumnName("BS_FECBAL4");
            entity.Property(e => e.BsFijo1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_FIJO1");
            entity.Property(e => e.BsFijo2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_FIJO2");
            entity.Property(e => e.BsFijo3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_FIJO3");
            entity.Property(e => e.BsFijo4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_FIJO4");
            entity.Property(e => e.BsIndliq1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_INDLIQ1");
            entity.Property(e => e.BsIndliq2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_INDLIQ2");
            entity.Property(e => e.BsIndliq3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_INDLIQ3");
            entity.Property(e => e.BsIndliq4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_INDLIQ4");
            entity.Property(e => e.BsInvent1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_INVENT1");
            entity.Property(e => e.BsInvent2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_INVENT2");
            entity.Property(e => e.BsInvent3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_INVENT3");
            entity.Property(e => e.BsInvent4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_INVENT4");
            entity.Property(e => e.BsLarpla1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_LARPLA1");
            entity.Property(e => e.BsLarpla2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_LARPLA2");
            entity.Property(e => e.BsLarpla3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_LARPLA3");
            entity.Property(e => e.BsLarpla4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_LARPLA4");
            entity.Property(e => e.BsMoneda1)
                .HasMaxLength(17)
                .HasColumnName("BS_MONEDA1");
            entity.Property(e => e.BsMoneda2)
                .HasMaxLength(17)
                .HasColumnName("BS_MONEDA2");
            entity.Property(e => e.BsMoneda3)
                .HasMaxLength(17)
                .HasColumnName("BS_MONEDA3");
            entity.Property(e => e.BsMoneda4)
                .HasMaxLength(17)
                .HasColumnName("BS_MONEDA4");
            entity.Property(e => e.BsPasotr1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_PASOTR1");
            entity.Property(e => e.BsPasotr2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_PASOTR2");
            entity.Property(e => e.BsPasotr3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_PASOTR3");
            entity.Property(e => e.BsPasotr4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_PASOTR4");
            entity.Property(e => e.BsPatOtr2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_PatOtr2");
            entity.Property(e => e.BsPatOtr3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_PatOtr3");
            entity.Property(e => e.BsPatOtr4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_PatOtr4");
            entity.Property(e => e.BsPatotr1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_PATOTR1");
            entity.Property(e => e.BsPorcob1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_PORCOB1");
            entity.Property(e => e.BsPorcob2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_PORCOB2");
            entity.Property(e => e.BsPorcob3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_PORCOB3");
            entity.Property(e => e.BsPorcob4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_PORCOB4");
            entity.Property(e => e.BsReser1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_RESER1");
            entity.Property(e => e.BsReser2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_RESER2");
            entity.Property(e => e.BsReser3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_RESER3");
            entity.Property(e => e.BsReser4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_RESER4");
            entity.Property(e => e.BsTimBal1Ing)
                .HasMaxLength(17)
                .HasColumnName("BS_TimBal1_Ing");
            entity.Property(e => e.BsTimBal2Ing)
                .HasMaxLength(17)
                .HasColumnName("BS_TimBal2_Ing");
            entity.Property(e => e.BsTimBal3Ing)
                .HasMaxLength(17)
                .HasColumnName("BS_TimBal3_Ing");
            entity.Property(e => e.BsTimBal4Ing)
                .HasMaxLength(17)
                .HasColumnName("BS_TimBal4_Ing");
            entity.Property(e => e.BsTimbal1)
                .HasMaxLength(17)
                .HasColumnName("BS_TIMBAL1");
            entity.Property(e => e.BsTimbal2)
                .HasMaxLength(17)
                .HasColumnName("BS_TIMBAL2");
            entity.Property(e => e.BsTimbal3)
                .HasMaxLength(17)
                .HasColumnName("BS_TIMBAL3");
            entity.Property(e => e.BsTimbal4)
                .HasMaxLength(17)
                .HasColumnName("BS_TIMBAL4");
            entity.Property(e => e.BsTipBal1Ing)
                .HasMaxLength(17)
                .HasColumnName("BS_TipBal1_Ing");
            entity.Property(e => e.BsTipBal2Ing)
                .HasMaxLength(17)
                .HasColumnName("BS_TipBal2_Ing");
            entity.Property(e => e.BsTipBal3Ing)
                .HasMaxLength(17)
                .HasColumnName("BS_TipBal3_Ing");
            entity.Property(e => e.BsTipBal4Ing)
                .HasMaxLength(17)
                .HasColumnName("BS_TipBal4_Ing");
            entity.Property(e => e.BsTipbal1)
                .HasMaxLength(17)
                .HasColumnName("BS_TIPBAL1");
            entity.Property(e => e.BsTipbal2)
                .HasMaxLength(17)
                .HasColumnName("BS_TIPBAL2");
            entity.Property(e => e.BsTipbal3)
                .HasMaxLength(17)
                .HasColumnName("BS_TIPBAL3");
            entity.Property(e => e.BsTipbal4)
                .HasMaxLength(17)
                .HasColumnName("BS_TIPBAL4");
            entity.Property(e => e.BsTipcam1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TIPCAM1");
            entity.Property(e => e.BsTipcam2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TIPCAM2");
            entity.Property(e => e.BsTipcam3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TIPCAM3");
            entity.Property(e => e.BsTipcam4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TIPCAM4");
            entity.Property(e => e.BsTotact1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTACT1");
            entity.Property(e => e.BsTotact2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTACT2");
            entity.Property(e => e.BsTotact3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTACT3");
            entity.Property(e => e.BsTotact4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTACT4");
            entity.Property(e => e.BsTotcor1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTCOR1");
            entity.Property(e => e.BsTotcor2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTCOR2");
            entity.Property(e => e.BsTotcor3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTCOR3");
            entity.Property(e => e.BsTotcor4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTCOR4");
            entity.Property(e => e.BsTotcrr1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTCRR1");
            entity.Property(e => e.BsTotcrr2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTCRR2");
            entity.Property(e => e.BsTotcrr3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTCRR3");
            entity.Property(e => e.BsTotcrr4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTCRR4");
            entity.Property(e => e.BsTotpas1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTPAS1");
            entity.Property(e => e.BsTotpas2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTPAS2");
            entity.Property(e => e.BsTotpas3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTPAS3");
            entity.Property(e => e.BsTotpas4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTPAS4");
            entity.Property(e => e.BsTotpat1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTPAT1");
            entity.Property(e => e.BsTotpat2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTPAT2");
            entity.Property(e => e.BsTotpat3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTPAT3");
            entity.Property(e => e.BsTotpat4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_TOTPAT4");
            entity.Property(e => e.BsUtili1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_UTILI1");
            entity.Property(e => e.BsUtili2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_UTILI2");
            entity.Property(e => e.BsUtili3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_UTILI3");
            entity.Property(e => e.BsUtili4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_UTILI4");
            entity.Property(e => e.BsUtiper1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_UTIPER1");
            entity.Property(e => e.BsUtiper2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_UTIPER2");
            entity.Property(e => e.BsUtiper3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_UTIPER3");
            entity.Property(e => e.BsUtiper4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_UTIPER4");
            entity.Property(e => e.BsVentas1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_VENTAS1");
            entity.Property(e => e.BsVentas2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_VENTAS2");
            entity.Property(e => e.BsVentas3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_VENTAS3");
            entity.Property(e => e.BsVentas4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BS_VENTAS4");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<REmpVsBa>(entity =>
        {
            entity.HasKey(e => e.EmCodigo).HasName("PRIMARY");

            entity.ToTable("rEmpVsBa");

            entity.HasIndex(e => e.EmCodigo, "EM_CODIGO");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.BaActCorOtr2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_ActCorOtr2");
            entity.Property(e => e.BaActCorOtr3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_ActCorOtr3");
            entity.Property(e => e.BaActCorOtr4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_ActCorOtr4");
            entity.Property(e => e.BaActcorotr1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_ACTCOROTR1");
            entity.Property(e => e.BaActotr1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_ACTOTR1");
            entity.Property(e => e.BaActotr2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_ACTOTR2");
            entity.Property(e => e.BaActotr3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_ACTOTR3");
            entity.Property(e => e.BaActotr4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_ACTOTR4");
            entity.Property(e => e.BaBanpro1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_BANPRO1");
            entity.Property(e => e.BaBanpro2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_BANPRO2");
            entity.Property(e => e.BaBanpro3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_BANPRO3");
            entity.Property(e => e.BaBanpro4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_BANPRO4");
            entity.Property(e => e.BaCajban1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_CAJBAN1");
            entity.Property(e => e.BaCajban2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_CAJBAN2");
            entity.Property(e => e.BaCajban3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_CAJBAN3");
            entity.Property(e => e.BaCajban4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_CAJBAN4");
            entity.Property(e => e.BaCapita1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_CAPITA1");
            entity.Property(e => e.BaCapita2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_CAPITA2");
            entity.Property(e => e.BaCapita3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_CAPITA3");
            entity.Property(e => e.BaCapita4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_CAPITA4");
            entity.Property(e => e.BaCorotr1).HasColumnName("BA_COROTR1");
            entity.Property(e => e.BaCorotr2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_COROTR2");
            entity.Property(e => e.BaCorotr3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_COROTR3");
            entity.Property(e => e.BaCorotr4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_COROTR4");
            entity.Property(e => e.BaFecbal1)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBAL1");
            entity.Property(e => e.BaFecbal2)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBAL2");
            entity.Property(e => e.BaFecbal3)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBAL3");
            entity.Property(e => e.BaFecbal4)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBAL4");
            entity.Property(e => e.BaFijo1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_FIJO1");
            entity.Property(e => e.BaFijo2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_FIJO2");
            entity.Property(e => e.BaFijo3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_FIJO3");
            entity.Property(e => e.BaFijo4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_FIJO4");
            entity.Property(e => e.BaIndliq1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_INDLIQ1");
            entity.Property(e => e.BaIndliq2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_INDLIQ2");
            entity.Property(e => e.BaIndliq3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_INDLIQ3");
            entity.Property(e => e.BaIndliq4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_INDLIQ4");
            entity.Property(e => e.BaInvent1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_INVENT1");
            entity.Property(e => e.BaInvent2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_INVENT2");
            entity.Property(e => e.BaInvent3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_INVENT3");
            entity.Property(e => e.BaInvent4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_INVENT4");
            entity.Property(e => e.BaLarpla1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_LARPLA1");
            entity.Property(e => e.BaLarpla2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_LARPLA2");
            entity.Property(e => e.BaLarpla3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_LARPLA3");
            entity.Property(e => e.BaLarpla4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_LARPLA4");
            entity.Property(e => e.BaMoneda1)
                .HasMaxLength(17)
                .HasColumnName("BA_MONEDA1");
            entity.Property(e => e.BaMoneda2)
                .HasMaxLength(17)
                .HasColumnName("BA_MONEDA2");
            entity.Property(e => e.BaMoneda3)
                .HasMaxLength(17)
                .HasColumnName("BA_MONEDA3");
            entity.Property(e => e.BaMoneda4)
                .HasMaxLength(17)
                .HasColumnName("BA_MONEDA4");
            entity.Property(e => e.BaPasotr1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PASOTR1");
            entity.Property(e => e.BaPasotr2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PASOTR2");
            entity.Property(e => e.BaPasotr3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PASOTR3");
            entity.Property(e => e.BaPasotr4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PASOTR4");
            entity.Property(e => e.BaPastot1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PASTOT1");
            entity.Property(e => e.BaPastot2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PASTOT2");
            entity.Property(e => e.BaPastot3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PASTOT3");
            entity.Property(e => e.BaPastot4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PASTOT4");
            entity.Property(e => e.BaPatOtr2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PatOtr2");
            entity.Property(e => e.BaPatOtr3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PatOtr3");
            entity.Property(e => e.BaPatOtr4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PatOtr4");
            entity.Property(e => e.BaPatotr1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PATOTR1");
            entity.Property(e => e.BaPorcob1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PORCOB1");
            entity.Property(e => e.BaPorcob2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PORCOB2");
            entity.Property(e => e.BaPorcob3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PORCOB3");
            entity.Property(e => e.BaPorcob4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_PORCOB4");
            entity.Property(e => e.BaQuien)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("BA_QUIEN");
            entity.Property(e => e.BaReser1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_RESER1");
            entity.Property(e => e.BaReser2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_RESER2");
            entity.Property(e => e.BaReser3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_RESER3");
            entity.Property(e => e.BaReser4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_RESER4");
            entity.Property(e => e.BaTimBal1Ing)
                .HasMaxLength(17)
                .HasColumnName("BA_TimBal1_Ing");
            entity.Property(e => e.BaTimBal2Ing)
                .HasMaxLength(17)
                .HasColumnName("BA_TimBal2_Ing");
            entity.Property(e => e.BaTimBal3Ing)
                .HasMaxLength(17)
                .HasColumnName("BA_TimBal3_Ing");
            entity.Property(e => e.BaTimBal4Ing)
                .HasMaxLength(17)
                .HasColumnName("BA_TimBal4_Ing");
            entity.Property(e => e.BaTimbal1)
                .HasMaxLength(17)
                .HasColumnName("BA_TIMBAL1");
            entity.Property(e => e.BaTimbal2)
                .HasMaxLength(17)
                .HasColumnName("BA_TIMBAL2");
            entity.Property(e => e.BaTimbal3)
                .HasMaxLength(17)
                .HasColumnName("BA_TIMBAL3");
            entity.Property(e => e.BaTimbal4)
                .HasMaxLength(17)
                .HasColumnName("BA_TIMBAL4");
            entity.Property(e => e.BaTipBal1Ing)
                .HasMaxLength(17)
                .HasColumnName("BA_TipBal1_Ing");
            entity.Property(e => e.BaTipBal2Ing)
                .HasMaxLength(17)
                .HasColumnName("BA_TipBal2_Ing");
            entity.Property(e => e.BaTipBal3Ing)
                .HasMaxLength(17)
                .HasColumnName("BA_TipBal3_Ing");
            entity.Property(e => e.BaTipBal4Ing)
                .HasMaxLength(17)
                .HasColumnName("BA_TipBal4_Ing");
            entity.Property(e => e.BaTipbal1)
                .HasMaxLength(17)
                .HasColumnName("BA_TIPBAL1");
            entity.Property(e => e.BaTipbal2)
                .HasMaxLength(17)
                .HasColumnName("BA_TIPBAL2");
            entity.Property(e => e.BaTipbal3)
                .HasMaxLength(17)
                .HasColumnName("BA_TIPBAL3");
            entity.Property(e => e.BaTipbal4)
                .HasMaxLength(17)
                .HasColumnName("BA_TIPBAL4");
            entity.Property(e => e.BaTipcam1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TIPCAM1");
            entity.Property(e => e.BaTipcam2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TIPCAM2");
            entity.Property(e => e.BaTipcam3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TIPCAM3");
            entity.Property(e => e.BaTipcam4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TIPCAM4");
            entity.Property(e => e.BaTotact1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTACT1");
            entity.Property(e => e.BaTotact2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTACT2");
            entity.Property(e => e.BaTotact3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTACT3");
            entity.Property(e => e.BaTotact4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTACT4");
            entity.Property(e => e.BaTotcor1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTCOR1");
            entity.Property(e => e.BaTotcor2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTCOR2");
            entity.Property(e => e.BaTotcor3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTCOR3");
            entity.Property(e => e.BaTotcor4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTCOR4");
            entity.Property(e => e.BaTotcrr1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTCRR1");
            entity.Property(e => e.BaTotcrr2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTCRR2");
            entity.Property(e => e.BaTotcrr3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTCRR3");
            entity.Property(e => e.BaTotcrr4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTCRR4");
            entity.Property(e => e.BaTotpas1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTPAS1");
            entity.Property(e => e.BaTotpas2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTPAS2");
            entity.Property(e => e.BaTotpas3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTPAS3");
            entity.Property(e => e.BaTotpas4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTPAS4");
            entity.Property(e => e.BaTotpat1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTPAT1");
            entity.Property(e => e.BaTotpat2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTPAT2");
            entity.Property(e => e.BaTotpat3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTPAT3");
            entity.Property(e => e.BaTotpat4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_TOTPAT4");
            entity.Property(e => e.BaUtili1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_UTILI1");
            entity.Property(e => e.BaUtili2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_UTILI2");
            entity.Property(e => e.BaUtili3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_UTILI3");
            entity.Property(e => e.BaUtili4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_UTILI4");
            entity.Property(e => e.BaUtiper1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_UTIPER1");
            entity.Property(e => e.BaUtiper2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_UTIPER2");
            entity.Property(e => e.BaUtiper3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_UTIPER3");
            entity.Property(e => e.BaUtiper4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_UTIPER4");
            entity.Property(e => e.BaVentas1)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_VENTAS1");
            entity.Property(e => e.BaVentas2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_VENTAS2");
            entity.Property(e => e.BaVentas3)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_VENTAS3");
            entity.Property(e => e.BaVentas4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BA_VENTAS4");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<REmpVsBc>(entity =>
        {
            entity.HasKey(e => new { e.EmCodigo, e.BcOrden }).HasName("PRIMARY");

            entity.ToTable("rEmpVsBc");

            entity.HasIndex(e => e.EmCodigo, "Em_Codigo");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.BcOrden)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(2)")
                .HasColumnName("Bc_Orden");
            entity.Property(e => e.BcMonExt)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("Bc_MonExt");
            entity.Property(e => e.BcMonNac)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("Bc_MonNac");
            entity.Property(e => e.BcNombre)
                .HasMaxLength(30)
                .HasColumnName("Bc_Nombre");
            entity.Property(e => e.BcNroCta)
                .HasMaxLength(25)
                .HasColumnName("Bc_NroCta");
            entity.Property(e => e.BcSector)
                .HasMaxLength(20)
                .HasColumnName("Bc_Sector");
            entity.Property(e => e.BcTelefo)
                .HasMaxLength(15)
                .HasColumnName("Bc_Telefo");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<REmpVsBi>(entity =>
        {
            entity.HasKey(e => new { e.EmCodigo, e.BiOrden }).HasName("PRIMARY");

            entity.ToTable("rEmpVsBi");

            entity.HasIndex(e => e.EmCodigo, "EM_CODIGO");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.BiOrden)
                .HasColumnType("int(2)")
                .HasColumnName("BI_ORDEN");
            entity.Property(e => e.BiNombre)
                .HasMaxLength(50)
                .HasColumnName("BI_NOMBRE");
            entity.Property(e => e.BiNombreIng)
                .HasMaxLength(50)
                .HasColumnName("BI_NOMBRE_ING");
            entity.Property(e => e.BiTipo)
                .HasMaxLength(20)
                .HasColumnName("BI_TIPO");
            entity.Property(e => e.BiTipoIng)
                .HasMaxLength(20)
                .HasColumnName("BI_TIPO_ING");
            entity.Property(e => e.BiValor).HasColumnName("BI_VALOR");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<REmpVsEmp>(entity =>
        {
            entity.HasKey(e => new { e.EmCodigo, e.EeCodigo }).HasName("PRIMARY");

            entity.ToTable("rEmpVsEmp");

            entity.HasIndex(e => e.EeCodigo, "EE_CODIGO");

            entity.HasIndex(e => e.EeNumero, "EE_Numero");

            entity.HasIndex(e => e.EmCodigo, "EM_CODIGO");

            entity.HasIndex(e => new { e.EmCodigo, e.EeCodigo }, "EM_CODIGO_2");

            entity.HasIndex(e => new { e.EmCodigo, e.EeNumero }, "EM_CODIGO_3");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EeCodigo)
                .HasMaxLength(11)
                .HasColumnName("EE_CODIGO");
            entity.Property(e => e.EeComen)
                .HasColumnType("text")
                .HasColumnName("EE_Comen");
            entity.Property(e => e.EeComenIng)
                .HasColumnType("text")
                .HasColumnName("EE_Comen_Ing");
            entity.Property(e => e.EeDesde)
                .HasMaxLength(8)
                .HasColumnName("EE_Desde");
            entity.Property(e => e.EeNumero)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasComment("Numero de Orden (Sin Uso Momentaneamente)")
                .HasColumnName("EE_Numero");
            entity.Property(e => e.EePorAcc)
                .HasMaxLength(12)
                .HasColumnName("EE_PorAcc");
            entity.Property(e => e.EePorAcc2)
                .HasMaxLength(12)
                .HasComment("Participacion De la Empresa Subsidiaria")
                .HasColumnName("EE_PorAcc2");
            entity.Property(e => e.EePorAcc2Ing)
                .HasMaxLength(12)
                .HasColumnName("EE_PorAcc2_Ing");
            entity.Property(e => e.EePorAccIng)
                .HasMaxLength(12)
                .HasColumnName("EE_PorAcc_Ing");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.ReCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("RE_CODIGO");
            entity.Property(e => e.ReNombre)
                .HasMaxLength(30)
                .HasComment("Tipo de Relacion <= tConGen")
                .HasColumnName("RE_NOMBRE");
            entity.Property(e => e.ReNombreIng)
                .HasMaxLength(20)
                .HasColumnName("RE_NOMBRE_ING");
        });

        modelBuilder.Entity<REmpVsExp>(entity =>
        {
            entity.HasKey(e => new { e.EmCodigo, e.ExAno }).HasName("PRIMARY");

            entity.ToTable("rEmpVsExp");

            entity.HasIndex(e => e.EmCodigo, "Em_Codigo");

            entity.HasIndex(e => new { e.EmCodigo, e.ExAno }, "Em_Codigo_2");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("Em_Codigo");
            entity.Property(e => e.ExAno)
                .HasColumnType("int(4)")
                .HasColumnName("EX_Ano");
            entity.Property(e => e.ExMonto)
                .HasMaxLength(17)
                .HasColumnName("EX_Monto");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<REmpVsImp>(entity =>
        {
            entity.HasKey(e => new { e.EmCodigo, e.EiAno }).HasName("PRIMARY");

            entity.ToTable("rEmpVsImp");

            entity.HasIndex(e => e.EmCodigo, "Em_Codigo");

            entity.HasIndex(e => new { e.EmCodigo, e.EiAno }, "Em_Codigo_2");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("Em_Codigo");
            entity.Property(e => e.EiAno)
                .HasColumnType("int(4)")
                .HasColumnName("EI_Ano");
            entity.Property(e => e.EiMonto)
                .HasMaxLength(17)
                .HasColumnName("EI_Monto");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<REmpVsInfFin>(entity =>
        {
            entity.HasKey(e => e.EmCodigo).HasName("PRIMARY");

            entity.ToTable("rEmpVsInfFin");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EmAnalista)
                .HasColumnType("text")
                .HasColumnName("EM_ANALISTA");
            entity.Property(e => e.EmAnalistaIng)
                .HasColumnType("text")
                .HasColumnName("EM_ANALISTA_ING");
            entity.Property(e => e.EmAnalistaVb)
                .HasMaxLength(10)
                .HasColumnName("EM_ANALISTA_VB");
            entity.Property(e => e.EmCargos)
                .HasMaxLength(100)
                .HasColumnName("EM_CARGOS");
            entity.Property(e => e.EmCargosIng)
                .HasMaxLength(100)
                .HasColumnName("EM_CARGOS_ING");
            entity.Property(e => e.EmChkBal)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("EM_CHK_BAL");
            entity.Property(e => e.EmConinf)
                .HasColumnType("text")
                .HasColumnName("EM_CONINF");
            entity.Property(e => e.EmConinfIng)
                .HasColumnType("text")
                .HasColumnName("EM_CONINF_ING");
            entity.Property(e => e.EmEntrev)
                .HasMaxLength(200)
                .HasComment("Personas Entrevistadas")
                .HasColumnName("EM_ENTREV");
            entity.Property(e => e.EmGrado)
                .HasMaxLength(100)
                .HasComment("Grado de Colaboracion")
                .HasColumnName("EM_GRADO");
            entity.Property(e => e.EmGradoIng)
                .HasMaxLength(100)
                .HasColumnName("EM_GRADO_ING");
            entity.Property(e => e.EmInfpro)
                .HasMaxLength(200)
                .HasComment("Informacion Proporcionada")
                .HasColumnName("EM_INFPRO");
            entity.Property(e => e.EmInfproIng)
                .HasMaxLength(200)
                .HasColumnName("EM_INFPRO_ING");
            entity.Property(e => e.EmLogInffin)
                .HasDefaultValueSql("'0'")
                .HasComment("Indicador para saber cual se imprimie (0 Nada, 1 Solo Entrevistados, 2 Solo Memo, 3 Los dos juntos)")
                .HasColumnType("int(4)")
                .HasColumnName("EM_LOG_INFFIN");
            entity.Property(e => e.EmPropie)
                .HasColumnType("text")
                .HasColumnName("EM_PROPIE");
            entity.Property(e => e.EmPropieIng)
                .HasColumnType("text")
                .HasColumnName("EM_PROPIE_ING");
            entity.Property(e => e.EmSeguro)
                .HasColumnType("text")
                .HasColumnName("EM_SEGURO");
            entity.Property(e => e.EmSeguroIng)
                .HasColumnType("text")
                .HasColumnName("EM_SEGURO_ING");
            entity.Property(e => e.EmSitfin)
                .HasColumnType("text")
                .HasColumnName("EM_SITFIN");
            entity.Property(e => e.EmSitfinIng)
                .HasColumnType("text")
                .HasColumnName("EM_SITFIN_ING");
            entity.Property(e => e.EmSitfinTab)
                .HasComment("Situacion  Financiera Tabulado")
                .HasColumnType("text")
                .HasColumnName("EM_SITFIN_TAB");
            entity.Property(e => e.EmSitfinTabIng)
                .HasColumnType("text")
                .HasColumnName("EM_SITFIN_TAB_ING");
            entity.Property(e => e.GcCodigo)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(2)")
                .HasColumnName("GC_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.SfCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("SF_CODIGO");
        });

        modelBuilder.Entity<REmpVsLit>(entity =>
        {
            entity.HasKey(e => new { e.EmCodigo, e.LiOrden }).HasName("PRIMARY");

            entity.ToTable("rEmpVsLit");

            entity.HasIndex(e => e.EmCodigo, "EM_CODIGO");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.LiOrden)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(2)")
                .HasColumnName("LI_ORDEN");
            entity.Property(e => e.LiAccion)
                .HasMaxLength(32)
                .HasColumnName("LI_ACCION");
            entity.Property(e => e.LiAccionIng)
                .HasMaxLength(32)
                .HasColumnName("Li_Accion_Ing");
            entity.Property(e => e.LiDemand)
                .HasMaxLength(40)
                .HasColumnName("LI_DEMAND");
            entity.Property(e => e.LiDemandIng)
                .HasMaxLength(40)
                .HasColumnName("Li_Demand_Ing");
            entity.Property(e => e.LiEstado)
                .HasMaxLength(2)
                .HasColumnName("Li_Estado");
            entity.Property(e => e.LiFecha)
                .HasMaxLength(8)
                .HasColumnName("LI_FECHA");
            entity.Property(e => e.LiFechaIng)
                .HasMaxLength(8)
                .HasColumnName("Li_Fecha_Ing");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<REmpVsMorCom>(entity =>
        {
            entity.HasKey(e => e.McNumero).HasName("PRIMARY");

            entity.ToTable("rEmpVsMorCom", tb => tb.HasComment("Morosidad Comercial de Empresas"));

            entity.Property(e => e.McNumero)
                .HasColumnType("int(10)")
                .HasColumnName("MC_NUMERO");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.McAcreed)
                .HasMaxLength(35)
                .HasColumnName("MC_ACREED");
            entity.Property(e => e.McFecha)
                .HasMaxLength(10)
                .HasColumnName("MC_FECHA");
            entity.Property(e => e.McFecinc)
                .HasMaxLength(10)
                .HasColumnName("MC_FECINC");
            entity.Property(e => e.McMonme)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("MC_MONME");
            entity.Property(e => e.McMonmn)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("MC_MONMN");
            entity.Property(e => e.McNrodoc)
                .HasMaxLength(10)
                .HasColumnName("MC_NRODOC");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<REmpVsPe>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rEmpVsPe", tb => tb.HasComment("Tabla Relacionada de Empresa con Personas"));

            entity.HasIndex(e => new { e.EmCodigo, e.EpNumero }, "EM_CODIGO_2");

            entity.HasIndex(e => new { e.EmCodigo, e.PeCodigo }, "EM_CODIGO_3");

            entity.HasIndex(e => e.EpNumero, "EP_NUMERO");

            entity.HasIndex(e => e.PeCodigo, "PE_CODIGO");

            entity.Property(e => e.CaCodigo)
                .HasDefaultValueSql("'65'")
                .HasComment("Codigo del Cargo")
                .HasColumnType("int(3) unsigned")
                .HasColumnName("CA_CODIGO");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EpApenom)
                .HasDefaultValueSql("'0'")
                .HasComment("Si se impreme o no se impreme(Nombre o todo) algo asi es")
                .HasColumnType("int(4)")
                .HasColumnName("EP_APENOM");
            entity.Property(e => e.EpCargo)
                .HasMaxLength(100)
                .HasComment("Cargo mas especifico")
                .HasColumnName("EP_CARGO");
            entity.Property(e => e.EpCargoIng)
                .HasMaxLength(100)
                .HasColumnName("EP_Cargo_Ing");
            entity.Property(e => e.EpDesde)
                .HasMaxLength(16)
                .HasColumnName("EP_Desde");
            entity.Property(e => e.EpFoto)
                .HasDefaultValueSql("'0'")
                .HasComment("(1= Se Imprime la foto, 0= No se imprime la foto)")
                .HasColumnType("int(4)")
                .HasColumnName("EP_Foto");
            entity.Property(e => e.EpHasta)
                .HasMaxLength(16)
                .HasColumnName("EP_Hasta");
            entity.Property(e => e.EpNumero)
                .HasColumnType("int(4)")
                .HasColumnName("EP_NUMERO");
            entity.Property(e => e.EpPorAccIng)
                .HasMaxLength(12)
                .HasColumnName("EP_PorAcc_Ing");
            entity.Property(e => e.EpPoracc)
                .HasMaxLength(12)
                .HasColumnName("EP_PORACC");
            entity.Property(e => e.EpPrinci)
                .HasDefaultValueSql("'0'")
                .HasComment("Principal ejecutivo (1=Si,0=No)")
                .HasColumnType("int(4)")
                .HasColumnName("EP_PRINCI");
            entity.Property(e => e.EpTitulo1)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO1");
            entity.Property(e => e.EpTitulo2)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO2");
            entity.Property(e => e.EpTitulo3)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO3");
            entity.Property(e => e.EpTitulo4)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO4");
            entity.Property(e => e.EpTitulo5)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO5");
            entity.Property(e => e.EpTitulo6)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO6");
            entity.Property(e => e.EpTitulo7)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO7");
            entity.Property(e => e.EpTitulo8)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO8");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_CODIGO");
        });

        modelBuilder.Entity<REmpVsPeAnt>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rEmpVsPe_Ant", tb => tb.HasComment("Tabla Relacionada de Empresa con Personas"));

            entity.HasIndex(e => new { e.EmCodigo, e.EpNumero }, "EM_CODIGO_2");

            entity.HasIndex(e => new { e.EmCodigo, e.PeCodigo }, "EM_CODIGO_3");

            entity.HasIndex(e => e.EpNumero, "EP_NUMERO");

            entity.HasIndex(e => e.PeCodigo, "PE_CODIGO");

            entity.Property(e => e.CaCodigo)
                .HasDefaultValueSql("'65'")
                .HasComment("Codigo del Cargo")
                .HasColumnType("int(3) unsigned")
                .HasColumnName("CA_CODIGO");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EpApenom)
                .HasDefaultValueSql("'0'")
                .HasComment("Si se impreme o no se impreme(Nombre o todo) algo asi es")
                .HasColumnType("int(4)")
                .HasColumnName("EP_APENOM");
            entity.Property(e => e.EpCargo)
                .HasMaxLength(30)
                .HasComment("Cargo mas especifico")
                .HasColumnName("EP_CARGO");
            entity.Property(e => e.EpCargoIng)
                .HasMaxLength(30)
                .HasColumnName("EP_Cargo_Ing");
            entity.Property(e => e.EpDesde)
                .HasMaxLength(16)
                .HasColumnName("EP_Desde");
            entity.Property(e => e.EpFoto)
                .HasDefaultValueSql("'0'")
                .HasComment("(1= Se Imprime la foto, 0= No se imprime la foto)")
                .HasColumnType("int(4)")
                .HasColumnName("EP_Foto");
            entity.Property(e => e.EpNumero)
                .HasColumnType("int(4)")
                .HasColumnName("EP_NUMERO");
            entity.Property(e => e.EpPorAccIng)
                .HasMaxLength(12)
                .HasColumnName("EP_PorAcc_Ing");
            entity.Property(e => e.EpPoracc)
                .HasMaxLength(12)
                .HasColumnName("EP_PORACC");
            entity.Property(e => e.EpPrinci)
                .HasDefaultValueSql("'0'")
                .HasComment("Principal ejecutivo (1=Si,0=No)")
                .HasColumnType("int(4)")
                .HasColumnName("EP_PRINCI");
            entity.Property(e => e.EpTitulo1)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO1");
            entity.Property(e => e.EpTitulo2)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO2");
            entity.Property(e => e.EpTitulo3)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO3");
            entity.Property(e => e.EpTitulo4)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO4");
            entity.Property(e => e.EpTitulo5)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO5");
            entity.Property(e => e.EpTitulo6)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO6");
            entity.Property(e => e.EpTitulo7)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO7");
            entity.Property(e => e.EpTitulo8)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO8");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_CODIGO");
        });

        modelBuilder.Entity<REmpVsPeBk>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rEmpVsPe_bk");

            entity.Property(e => e.CaCodigo)
                .HasDefaultValueSql("'65'")
                .HasComment("Codigo del Cargo")
                .HasColumnType("int(3) unsigned")
                .HasColumnName("CA_CODIGO");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EpApenom)
                .HasDefaultValueSql("'0'")
                .HasComment("Si se impreme o no se impreme(Nombre o todo) algo asi es")
                .HasColumnType("int(4)")
                .HasColumnName("EP_APENOM");
            entity.Property(e => e.EpCargo)
                .HasMaxLength(100)
                .HasComment("Cargo mas especifico")
                .HasColumnName("EP_CARGO");
            entity.Property(e => e.EpCargoIng)
                .HasMaxLength(100)
                .HasColumnName("EP_Cargo_Ing");
            entity.Property(e => e.EpDesde)
                .HasMaxLength(16)
                .HasColumnName("EP_Desde");
            entity.Property(e => e.EpFoto)
                .HasDefaultValueSql("'0'")
                .HasComment("(1= Se Imprime la foto, 0= No se imprime la foto)")
                .HasColumnType("int(4)")
                .HasColumnName("EP_Foto");
            entity.Property(e => e.EpNumero)
                .HasColumnType("int(4)")
                .HasColumnName("EP_NUMERO");
            entity.Property(e => e.EpPorAccIng)
                .HasMaxLength(12)
                .HasColumnName("EP_PorAcc_Ing");
            entity.Property(e => e.EpPoracc)
                .HasMaxLength(12)
                .HasColumnName("EP_PORACC");
            entity.Property(e => e.EpPrinci)
                .HasDefaultValueSql("'0'")
                .HasComment("Principal ejecutivo (1=Si,0=No)")
                .HasColumnType("int(4)")
                .HasColumnName("EP_PRINCI");
            entity.Property(e => e.EpTitulo1)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO1");
            entity.Property(e => e.EpTitulo2)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO2");
            entity.Property(e => e.EpTitulo3)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO3");
            entity.Property(e => e.EpTitulo4)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO4");
            entity.Property(e => e.EpTitulo5)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO5");
            entity.Property(e => e.EpTitulo6)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO6");
            entity.Property(e => e.EpTitulo7)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO7");
            entity.Property(e => e.EpTitulo8)
                .HasMaxLength(15)
                .HasColumnName("EP_TITULO8");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_CODIGO");
        });

        modelBuilder.Entity<REmpVsProAcep>(entity =>
        {
            entity.HasKey(e => e.PaNumero).HasName("PRIMARY");

            entity.ToTable("rEmpVsProAcep", tb => tb.HasComment("Tabla de Protestos Por Aceptante de Empresas"));

            entity.Property(e => e.PaNumero)
                .HasColumnType("int(10)")
                .HasColumnName("PA_NUMERO");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaBoletin)
                .HasMaxLength(10)
                .HasColumnName("PA_BOLETIN");
            entity.Property(e => e.PaDiaatr)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(10)")
                .HasColumnName("PA_DIAATR");
            entity.Property(e => e.PaFecpro)
                .HasMaxLength(10)
                .HasColumnName("PA_FECPRO");
            entity.Property(e => e.PaFecreg)
                .HasMaxLength(10)
                .HasColumnName("PA_FECREG");
            entity.Property(e => e.PaGirador)
                .HasMaxLength(50)
                .HasColumnName("PA_GIRADOR");
            entity.Property(e => e.PaMonme)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("PA_MONME");
            entity.Property(e => e.PaMonmn)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("PA_MONMN");
            entity.Property(e => e.PaNumdoc)
                .HasMaxLength(10)
                .HasColumnName("PA_NUMDOC");
            entity.Property(e => e.PaTitulo)
                .HasMaxLength(50)
                .HasColumnName("PA_TITULO");
            entity.Property(e => e.PaTituloIng)
                .HasMaxLength(50)
                .HasColumnName("PA_TITULO_ING");
        });

        modelBuilder.Entity<REmpVsProAcepC>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rEmpVsProAcep_C");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaFecpro)
                .HasMaxLength(50)
                .HasColumnName("PA_FECPRO");
            entity.Property(e => e.PaFecreg)
                .HasMaxLength(50)
                .HasColumnName("PA_FECREG");
            entity.Property(e => e.PaGirador)
                .HasMaxLength(50)
                .HasColumnName("PA_GIRADOR");
            entity.Property(e => e.PaMonme)
                .HasColumnType("double(15,2)")
                .HasColumnName("PA_MONME");
            entity.Property(e => e.PaMonmn)
                .HasColumnType("double(15,2)")
                .HasColumnName("PA_MONMN");
            entity.Property(e => e.PaNumero)
                .HasColumnType("int(10)")
                .HasColumnName("PA_NUMERO");
            entity.Property(e => e.PaTitulo)
                .HasMaxLength(50)
                .HasColumnName("PA_TITULO");
            entity.Property(e => e.PaTituloIng)
                .HasMaxLength(50)
                .HasColumnName("PA_TITULO_ING");
        });

        modelBuilder.Entity<REmpVsProv>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rEmpVsProv");

            entity.HasIndex(e => new { e.EmCodigo, e.ProvCorrelativo }, "Em_Codigo");

            entity.HasIndex(e => new { e.EmCodigo, e.ProvNLinCre, e.ProvNPrmMen }, "Em_Codigo_2");

            entity.HasIndex(e => new { e.EmCodigo, e.ProvNombre }, "Em_Codigo_3");

            entity.Property(e => e.AudAccion)
                .HasMaxLength(10)
                .HasColumnName("aud_Accion");
            entity.Property(e => e.AudFecha)
                .HasColumnType("datetime")
                .HasColumnName("aud_Fecha");
            entity.Property(e => e.AudUsuario)
                .HasMaxLength(50)
                .HasColumnName("aud_Usuario");
            entity.Property(e => e.CumCodigo)
                .HasMaxLength(2)
                .HasColumnName("CUM_CODIGO");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("Em_Codigo");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.ProvAtendio)
                .HasMaxLength(100)
                .HasColumnName("PROV_ATENDIO");
            entity.Property(e => e.ProvComen)
                .HasColumnType("text")
                .HasColumnName("Prov_Comen");
            entity.Property(e => e.ProvComenIng)
                .HasColumnType("text")
                .HasColumnName("Prov_Comen_Ing");
            entity.Property(e => e.ProvCorrelativo)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(3)")
                .HasColumnName("PROV_CORRELATIVO");
            entity.Property(e => e.ProvCumple)
                .HasMaxLength(15)
                .HasColumnName("Prov_Cumple");
            entity.Property(e => e.ProvDeuAct)
                .HasMaxLength(20)
                .HasColumnName("Prov_DeuAct");
            entity.Property(e => e.ProvEstado)
                .HasMaxLength(50)
                .HasColumnName("Prov_Estado");
            entity.Property(e => e.ProvEstadoIng)
                .HasMaxLength(50)
                .HasColumnName("Prov_Estado_Ing");
            entity.Property(e => e.ProvFecha)
                .HasColumnType("date")
                .HasColumnName("PROV_FECHA");
            entity.Property(e => e.ProvLinCre)
                .HasMaxLength(16)
                .HasColumnName("Prov_LinCre");
            entity.Property(e => e.ProvLinCreIng)
                .HasMaxLength(16)
                .HasColumnName("Prov_LinCre_Ing");
            entity.Property(e => e.ProvLlamo)
                .HasMaxLength(1)
                .HasDefaultValueSql("'N'")
                .IsFixedLength()
                .HasColumnName("PROV_LLAMO");
            entity.Property(e => e.ProvMnLiCr)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("Prov_MnLiCr");
            entity.Property(e => e.ProvMnPrMe)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("Prov_MnPrMe");
            entity.Property(e => e.ProvNLinCre)
                .HasDefaultValueSql("'0'")
                .HasColumnName("Prov_nLinCre");
            entity.Property(e => e.ProvNPrmMen)
                .HasDefaultValueSql("'0'")
                .HasColumnName("Prov_nPrmMen");
            entity.Property(e => e.ProvNombre)
                .HasMaxLength(46)
                .HasColumnName("Prov_Nombre");
            entity.Property(e => e.ProvOrden)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(3)")
                .HasColumnName("Prov_Orden");
            entity.Property(e => e.ProvPais)
                .HasMaxLength(30)
                .HasColumnName("Prov_Pais");
            entity.Property(e => e.ProvPlazos)
                .HasMaxLength(20)
                .HasColumnName("Prov_Plazos");
            entity.Property(e => e.ProvPlazosIng)
                .HasMaxLength(20)
                .HasColumnName("Prov_Plazos_Ing");
            entity.Property(e => e.ProvPrmMen)
                .HasMaxLength(16)
                .HasColumnName("Prov_PrmMen");
            entity.Property(e => e.ProvPrmMenIng)
                .HasMaxLength(16)
                .HasColumnName("Prov_PrmMen_Ing");
            entity.Property(e => e.ProvTelefo)
                .HasMaxLength(80)
                .HasColumnName("Prov_Telefo");
            entity.Property(e => e.ProvTexto)
                .HasColumnType("text")
                .HasColumnName("PROV_TEXTO");
            entity.Property(e => e.ProvTiempo)
                .HasMaxLength(8)
                .HasColumnName("Prov_Tiempo");
            entity.Property(e => e.ProvTiempoIng)
                .HasMaxLength(8)
                .HasColumnName("Prov_Tiempo_Ing");
            entity.Property(e => e.ProvVenden)
                .HasMaxLength(50)
                .HasColumnName("Prov_Venden");
            entity.Property(e => e.ProvVendenIng)
                .HasMaxLength(50)
                .HasColumnName("Prov_Venden_Ing");
        });

        modelBuilder.Entity<REmpVsProvB>(entity =>
        {
            entity.HasKey(e => e.ProvCodigo).HasName("PRIMARY");

            entity.ToTable("rEmpVsProv_B");

            entity.Property(e => e.ProvCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("Prov_Codigo");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("Em_Codigo");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.ProvCumple)
                .HasMaxLength(50)
                .HasColumnName("Prov_Cumple");
            entity.Property(e => e.ProvCumpleIng)
                .HasMaxLength(50)
                .HasColumnName("Prov_Cumple_Ing");
            entity.Property(e => e.ProvLinCre)
                .HasMaxLength(16)
                .HasColumnName("Prov_LinCre");
            entity.Property(e => e.ProvLinCreIng)
                .HasMaxLength(50)
                .HasColumnName("Prov_LinCre_Ing");
            entity.Property(e => e.ProvMnLiCr)
                .HasMaxLength(3)
                .HasColumnName("Prov_MnLiCr");
            entity.Property(e => e.ProvNombre)
                .HasMaxLength(200)
                .HasColumnName("Prov_Nombre");
            entity.Property(e => e.ProvOrden)
                .HasColumnType("int(11)")
                .HasColumnName("Prov_Orden");
            entity.Property(e => e.ProvPais)
                .HasMaxLength(50)
                .HasColumnName("Prov_Pais");
            entity.Property(e => e.ProvPlazos)
                .HasMaxLength(20)
                .HasColumnName("Prov_Plazos");
            entity.Property(e => e.ProvPlazosIng)
                .HasMaxLength(50)
                .HasColumnName("Prov_Plazos_Ing");
            entity.Property(e => e.ProvTiempo)
                .HasMaxLength(50)
                .HasColumnName("Prov_Tiempo");
            entity.Property(e => e.ProvTiempoIng)
                .HasMaxLength(50)
                .HasColumnName("Prov_Tiempo_Ing");
        });

        modelBuilder.Entity<REmpVsRamNeg>(entity =>
        {
            entity.HasKey(e => e.EmCodigo).HasName("PRIMARY");

            entity.ToTable("rEmpVsRamNeg");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.AcCodigo)
                .HasMaxLength(2)
                .HasDefaultValueSql("'00'")
                .HasColumnName("AC_CODIGO");
            entity.Property(e => e.CsCodigo)
                .HasMaxLength(3)
                .HasColumnName("CS_CODIGO");
            entity.Property(e => e.EmActivi)
                .HasColumnType("text")
                .HasColumnName("EM_ACTIVI");
            entity.Property(e => e.EmActiviIng)
                .HasColumnType("text")
                .HasColumnName("EM_ACTIVI_ING");
            entity.Property(e => e.EmArea)
                .HasMaxLength(17)
                .HasColumnName("EM_AREA");
            entity.Property(e => e.EmAreaIng)
                .HasMaxLength(17)
                .HasColumnName("EM_AREA_ING");
            entity.Property(e => e.EmAspcon)
                .HasMaxLength(60)
                .HasColumnName("EM_ASPCON");
            entity.Property(e => e.EmAspconIng)
                .HasMaxLength(60)
                .HasColumnName("EM_ASPCON_ING");
            entity.Property(e => e.EmCatciiu1)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("EM_CATCIIU1");
            entity.Property(e => e.EmCatciiu2)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("EM_CATCIIU2");
            entity.Property(e => e.EmCiiu1)
                .HasMaxLength(4)
                .HasColumnName("EM_CIIU1");
            entity.Property(e => e.EmCiiu2)
                .HasMaxLength(4)
                .HasColumnName("EM_CIIU2");
            entity.Property(e => e.EmComen)
                .HasColumnType("text")
                .HasColumnName("EM_COMEN");
            entity.Property(e => e.EmComenIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMEN_ING");
            entity.Property(e => e.EmComenTab)
                .HasColumnType("text")
                .HasColumnName("EM_COMEN_TAB");
            entity.Property(e => e.EmComenTabIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMEN_TAB_ING");
            entity.Property(e => e.EmComext)
                .HasMaxLength(50)
                .HasColumnName("EM_COMEXT");
            entity.Property(e => e.EmComextIng)
                .HasMaxLength(50)
                .HasColumnName("EM_COMEXT_ING");
            entity.Property(e => e.EmComnac)
                .HasMaxLength(50)
                .HasColumnName("EM_COMNAC");
            entity.Property(e => e.EmComnacIng)
                .HasMaxLength(50)
                .HasColumnName("EM_COMNAC_ING");
            entity.Property(e => e.EmDomant)
                .HasMaxLength(150)
                .HasColumnName("EM_DOMANT");
            entity.Property(e => e.EmEquip)
                .HasMaxLength(60)
                .HasColumnName("EM_EQUIP");
            entity.Property(e => e.EmEquipIng)
                .HasMaxLength(60)
                .HasColumnName("EM_EQUIP_ING");
            entity.Property(e => e.EmExport1)
                .HasMaxLength(1000)
                .HasColumnName("EM_EXPORT1");
            entity.Property(e => e.EmExport1Ing)
                .HasMaxLength(1000)
                .HasColumnName("EM_EXPORT1_ING");
            entity.Property(e => e.EmExport2)
                .HasMaxLength(1000)
                .HasColumnName("EM_EXPORT2");
            entity.Property(e => e.EmExport2Ing)
                .HasMaxLength(1000)
                .HasColumnName("EM_EXPORT2_ING");
            entity.Property(e => e.EmImport1)
                .HasMaxLength(1000)
                .HasColumnName("EM_IMPORT1");
            entity.Property(e => e.EmImport1Ing)
                .HasMaxLength(1000)
                .HasColumnName("EM_IMPORT1_ING");
            entity.Property(e => e.EmImport2)
                .HasMaxLength(1000)
                .HasColumnName("EM_IMPORT2");
            entity.Property(e => e.EmImport2Ing)
                .HasMaxLength(1000)
                .HasColumnName("EM_IMPORT2_ING");
            entity.Property(e => e.EmLogexp)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("EM_LOGEXP");
            entity.Property(e => e.EmLogimp)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("EM_LOGIMP");
            entity.Property(e => e.EmMorosidad)
                .HasMaxLength(50)
                .HasColumnName("EM_MOROSIDAD");
            entity.Property(e => e.EmMorosidadIng)
                .HasMaxLength(50)
                .HasColumnName("EM_MOROSIDAD_ING");
            entity.Property(e => e.EmObserv)
                .HasColumnType("text")
                .HasColumnName("EM_OBSERV");
            entity.Property(e => e.EmObservIng)
                .HasColumnType("text")
                .HasColumnName("EM_OBSERV_ING");
            entity.Property(e => e.EmPisos)
                .HasMaxLength(2)
                .HasColumnName("EM_PISOS");
            entity.Property(e => e.EmTervta)
                .HasMaxLength(80)
                .HasColumnName("EM_TERVTA");
            entity.Property(e => e.EmTervtaIng)
                .HasMaxLength(80)
                .HasColumnName("EM_TERVTA_ING");
            entity.Property(e => e.EmTiploc)
                .HasMaxLength(50)
                .HasColumnName("EM_TIPLOC");
            entity.Property(e => e.EmTipocu)
                .HasMaxLength(50)
                .HasColumnName("EM_TIPOCU");
            entity.Property(e => e.EmTipocuIng)
                .HasMaxLength(50)
                .HasColumnName("EM_TIPOCU_ING");
            entity.Property(e => e.EmTraba1)
                .HasMaxLength(50)
                .HasColumnName("EM_TRABA1");
            entity.Property(e => e.EmTraba1Anno)
                .HasMaxLength(20)
                .HasColumnName("EM_TRABA1_ANNO");
            entity.Property(e => e.EmTraba1Ing)
                .HasMaxLength(50)
                .HasColumnName("EM_TRABA1_ING");
            entity.Property(e => e.EmTraba2)
                .HasMaxLength(50)
                .HasColumnName("EM_TRABA2");
            entity.Property(e => e.EmTraba2Anno)
                .HasMaxLength(20)
                .HasColumnName("EM_TRABA2_ANNO");
            entity.Property(e => e.EmTrabaj)
                .HasMaxLength(50)
                .HasColumnName("EM_TRABAJ");
            entity.Property(e => e.EmUso)
                .HasMaxLength(80)
                .HasColumnName("EM_USO");
            entity.Property(e => e.EmUsoIng)
                .HasMaxLength(80)
                .HasColumnName("EM_USO_ING");
            entity.Property(e => e.EmValor)
                .HasMaxLength(17)
                .HasColumnName("EM_VALOR");
            entity.Property(e => e.EmValorIng)
                .HasMaxLength(17)
                .HasColumnName("EM_VALOR_ING");
            entity.Property(e => e.EmVencon)
                .HasMaxLength(50)
                .HasColumnName("EM_VENCON");
            entity.Property(e => e.EmVenconIng)
                .HasMaxLength(50)
                .HasColumnName("EM_VENCON_ING");
            entity.Property(e => e.EmVencre)
                .HasMaxLength(50)
                .HasColumnName("EM_VENCRE");
            entity.Property(e => e.EmVencreIng)
                .HasMaxLength(50)
                .HasColumnName("EM_VENCRE_ING");
            entity.Property(e => e.EmVtaext)
                .HasMaxLength(50)
                .HasColumnName("EM_VTAEXT");
            entity.Property(e => e.EmVtaextIng)
                .HasMaxLength(50)
                .HasColumnName("EM_VTAEXT_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.RamCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("RAM_CODIGO");
            entity.Property(e => e.SecCodigo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("SEC_CODIGO");
            entity.Property(e => e.TaCodigo)
                .HasMaxLength(2)
                .HasColumnName("TA_CODIGO");
            entity.Property(e => e.TlCodigo)
                .HasMaxLength(2)
                .HasDefaultValueSql("'01'")
                .HasColumnName("TL_CODIGO");
        });

        modelBuilder.Entity<REmpVsRep>(entity =>
        {
            entity.HasKey(e => new { e.EmCodigo, e.RcCodigo }).HasName("PRIMARY");

            entity.ToTable("rEmpVsRep");

            entity.HasIndex(e => e.EmCodigo, "EM_CODIGO");

            entity.HasIndex(e => new { e.EmCodigo, e.RcCodigo }, "EM_CODIGO_2");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.RcCodigo)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Codigo de la Reputacion Comercial")
                .HasColumnName("RC_CODIGO");
            entity.Property(e => e.Migra)
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<REmpVsSb>(entity =>
        {
            entity.HasKey(e => e.EmCodigo).HasName("PRIMARY");

            entity.ToTable("rEmpVsSB");

            entity.HasIndex(e => e.EmCodigo, "Em_Codigo");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("Em_Codigo");
            entity.Property(e => e.EmArrfin)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("EM_ARRFIN");
            entity.Property(e => e.EmComext)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("EM_COMEXT");
            entity.Property(e => e.EmDescue)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("EM_DESCUE");
            entity.Property(e => e.EmGarofr)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("EM_GAROFR");
            entity.Property(e => e.EmOtrdeu)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("EM_OTRDEU");
            entity.Property(e => e.EmPresta)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("EM_PRESTA");
            entity.Property(e => e.EmTarcred)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("EM_TARCRED");
            entity.Property(e => e.EmTotdeu)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("EM_TOTDEU");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.SbAbme)
                .HasMaxLength(17)
                .HasColumnName("SB_ABME");
            entity.Property(e => e.SbAbmn)
                .HasMaxLength(17)
                .HasColumnName("SB_ABMN");
            entity.Property(e => e.SbAccme)
                .HasMaxLength(17)
                .HasColumnName("SB_ACCME");
            entity.Property(e => e.SbAccmn)
                .HasMaxLength(17)
                .HasColumnName("SB_ACCMN");
            entity.Property(e => e.SbArFme)
                .HasMaxLength(17)
                .HasColumnName("SB_ArFME");
            entity.Property(e => e.SbArFmn)
                .HasMaxLength(17)
                .HasColumnName("SB_ArFMN");
            entity.Property(e => e.SbCceme)
                .HasMaxLength(17)
                .HasColumnName("SB_CCEME");
            entity.Property(e => e.SbCcemn)
                .HasMaxLength(17)
                .HasColumnName("SB_CCEMN");
            entity.Property(e => e.SbCcme)
                .HasMaxLength(17)
                .HasColumnName("SB_CCME");
            entity.Property(e => e.SbCcmn)
                .HasMaxLength(17)
                .HasColumnName("SB_CCMN");
            entity.Property(e => e.SbCfme)
                .HasMaxLength(17)
                .HasColumnName("SB_CFME");
            entity.Property(e => e.SbCfmn)
                .HasMaxLength(17)
                .HasColumnName("SB_CFMN");
            entity.Property(e => e.SbDeVme)
                .HasMaxLength(17)
                .HasColumnName("SB_DeVME");
            entity.Property(e => e.SbDeVmn)
                .HasMaxLength(17)
                .HasColumnName("SB_DeVMN");
            entity.Property(e => e.SbDefici)
                .HasMaxLength(7)
                .HasColumnName("SB_Defici");
            entity.Property(e => e.SbDlme)
                .HasMaxLength(17)
                .HasColumnName("SB_DLME");
            entity.Property(e => e.SbDlmn)
                .HasMaxLength(17)
                .HasColumnName("SB_DLMN");
            entity.Property(e => e.SbDpme)
                .HasMaxLength(17)
                .HasColumnName("SB_DPME");
            entity.Property(e => e.SbDpmn)
                .HasMaxLength(17)
                .HasColumnName("SB_DPMN");
            entity.Property(e => e.SbDudoso)
                .HasMaxLength(7)
                .HasColumnName("SB_Dudoso");
            entity.Property(e => e.SbFecReg)
                .HasMaxLength(10)
                .HasColumnName("SB_FecReg");
            entity.Property(e => e.SbGaOme)
                .HasMaxLength(17)
                .HasColumnName("SB_GaOME");
            entity.Property(e => e.SbGaOmn)
                .HasMaxLength(17)
                .HasColumnName("SB_GaOMN");
            entity.Property(e => e.SbNormal)
                .HasMaxLength(7)
                .HasColumnName("SB_Normal");
            entity.Property(e => e.SbOtrMe)
                .HasMaxLength(17)
                .HasColumnName("SB_OtrME");
            entity.Property(e => e.SbOtrMn)
                .HasMaxLength(17)
                .HasColumnName("SB_OtrMN");
            entity.Property(e => e.SbOtros)
                .HasMaxLength(25)
                .HasColumnName("SB_Otros");
            entity.Property(e => e.SbOtros1)
                .HasMaxLength(30)
                .HasColumnName("SB_Otros1");
            entity.Property(e => e.SbOtros1Ing)
                .HasMaxLength(30)
                .HasColumnName("SB_Otros1_Ing");
            entity.Property(e => e.SbOtrosIng)
                .HasMaxLength(25)
                .HasColumnName("SB_Otros_Ing");
            entity.Property(e => e.SbPerdida)
                .HasMaxLength(7)
                .HasColumnName("SB_Perdida");
            entity.Property(e => e.SbPreMe)
                .HasMaxLength(17)
                .HasColumnName("SB_PreME");
            entity.Property(e => e.SbPreMn)
                .HasMaxLength(17)
                .HasColumnName("SB_PreMN");
            entity.Property(e => e.SbProPot)
                .HasMaxLength(7)
                .HasColumnName("SB_ProPot");
            entity.Property(e => e.SbSccme)
                .HasMaxLength(17)
                .HasColumnName("SB_SCCME");
            entity.Property(e => e.SbSccmn)
                .HasMaxLength(17)
                .HasColumnName("SB_SCCMN");
            entity.Property(e => e.SbTccme)
                .HasMaxLength(17)
                .HasColumnName("SB_TCCME");
            entity.Property(e => e.SbTccmn)
                .HasMaxLength(17)
                .HasColumnName("SB_TCCMN");
            entity.Property(e => e.SbTotMe)
                .HasMaxLength(17)
                .HasColumnName("SB_TotME");
            entity.Property(e => e.SbTotMn)
                .HasMaxLength(17)
                .HasColumnName("SB_TotMN");
        });

        modelBuilder.Entity<REmpVsSbd>(entity =>
        {
            entity.HasKey(e => new { e.EmCodigo, e.SbdOrden }).HasName("PRIMARY");

            entity.ToTable("rEmpVsSBD");

            entity.HasIndex(e => e.EmCodigo, "Em_Codigo");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("Em_Codigo");
            entity.Property(e => e.SbdOrden)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(2)")
                .HasColumnName("SBD_Orden");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.SbdCalifi)
                .HasMaxLength(100)
                .HasColumnName("SBD_CALIFI");
            entity.Property(e => e.SbdCalifiIng)
                .HasMaxLength(100)
                .HasColumnName("SBD_CALIFI_ING");
            entity.Property(e => e.SbdDefici)
                .HasMaxLength(5)
                .HasColumnName("SBD_Defici");
            entity.Property(e => e.SbdDudoso)
                .HasMaxLength(5)
                .HasColumnName("SBD_Dudoso");
            entity.Property(e => e.SbdMemo)
                .HasColumnType("text")
                .HasColumnName("SBD_Memo");
            entity.Property(e => e.SbdMemoIng)
                .HasColumnType("text")
                .HasColumnName("SBD_Memo_Ing");
            entity.Property(e => e.SbdMonMe)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("SBD_MonME");
            entity.Property(e => e.SbdMonto)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("SBD_Monto");
            entity.Property(e => e.SbdNombre)
                .HasMaxLength(32)
                .HasColumnName("SBD_Nombre");
            entity.Property(e => e.SbdNormal)
                .HasMaxLength(5)
                .HasColumnName("SBD_Normal");
            entity.Property(e => e.SbdPerdida)
                .HasMaxLength(5)
                .HasColumnName("SBD_Perdida");
            entity.Property(e => e.SbdProPot)
                .HasMaxLength(5)
                .HasColumnName("SBD_ProPot");
            entity.Property(e => e.SbdSemaforo)
                .HasMaxLength(50)
                .HasColumnName("SBD_Semaforo");
        });

        modelBuilder.Entity<REmpVsSbdB>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rEmpVsSBD_B");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("Em_Codigo");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaNumero2)
                .HasColumnType("int(11)")
                .HasColumnName("PA_NUMERO2");
            entity.Property(e => e.SbdCalifi)
                .HasMaxLength(100)
                .HasColumnName("SBD_CALIFI");
            entity.Property(e => e.SbdCalifiIng)
                .HasMaxLength(100)
                .HasColumnName("SBD_CALIFI_ING");
            entity.Property(e => e.SbdMonMe)
                .HasColumnType("double(15,2)")
                .HasColumnName("SBD_MonME");
            entity.Property(e => e.SbdMonto)
                .HasColumnType("double(15,2)")
                .HasColumnName("SBD_Monto");
            entity.Property(e => e.SbdNombre)
                .HasMaxLength(200)
                .HasColumnName("SBD_Nombre");
            entity.Property(e => e.SbdOrden)
                .HasColumnType("int(2)")
                .HasColumnName("SBD_Orden");
        });

        modelBuilder.Entity<REmpVsSbdC>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rEmpVsSBD_C");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("Em_Codigo");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaNumero2)
                .HasColumnType("int(11)")
                .HasColumnName("PA_NUMERO2");
            entity.Property(e => e.SbdCalifi)
                .HasMaxLength(100)
                .HasColumnName("SBD_CALIFI");
            entity.Property(e => e.SbdCalifiIng)
                .HasMaxLength(100)
                .HasColumnName("SBD_CALIFI_ING");
            entity.Property(e => e.SbdMonMe)
                .HasColumnType("double(15,2)")
                .HasColumnName("SBD_MonME");
            entity.Property(e => e.SbdMonto)
                .HasColumnType("double(15,2)")
                .HasColumnName("SBD_Monto");
            entity.Property(e => e.SbdNombre)
                .HasMaxLength(200)
                .HasColumnName("SBD_Nombre");
            entity.Property(e => e.SbdOrden)
                .HasColumnType("int(2)")
                .HasColumnName("SBD_Orden");
        });

        modelBuilder.Entity<REmpVsSe>(entity =>
        {
            entity.HasKey(e => new { e.EmCodigo, e.EsOrden }).HasName("PRIMARY");

            entity.ToTable("rEmpVsSe");

            entity.HasIndex(e => e.EmCodigo, "Em_Codigo");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("Em_Codigo");
            entity.Property(e => e.EsOrden)
                .HasColumnType("int(2)")
                .HasColumnName("ES_Orden");
            entity.Property(e => e.EsCia)
                .HasMaxLength(40)
                .HasColumnName("ES_CIA");
            entity.Property(e => e.EsContra)
                .HasMaxLength(30)
                .HasColumnName("ES_Contra");
            entity.Property(e => e.EsContraIng)
                .HasMaxLength(30)
                .HasColumnName("ES_Contra_Ing");
            entity.Property(e => e.EsMonto)
                .HasMaxLength(20)
                .HasColumnName("ES_Monto");
            entity.Property(e => e.EsMontoIng)
                .HasMaxLength(20)
                .HasColumnName("ES_Monto_Ing");
            entity.Property(e => e.EsVence)
                .HasMaxLength(10)
                .HasColumnName("ES_Vence");
            entity.Property(e => e.EsVenceIng)
                .HasMaxLength(10)
                .HasColumnName("ES_Vence_Ing");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<REmpVsVenta>(entity =>
        {
            entity.HasKey(e => e.VeCodigo).HasName("PRIMARY");

            entity.ToTable("rEmpVsVentas");

            entity.Property(e => e.VeCodigo)
                .HasColumnType("int(10)")
                .HasColumnName("VE_CODIGO");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Migra)
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiMone)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("PAI_MONE");
            entity.Property(e => e.VeFecha)
                .HasMaxLength(10)
                .HasColumnName("VE_FECHA");
            entity.Property(e => e.VeTipcam).HasColumnName("VE_TIPCAM");
            entity.Property(e => e.VeVentas).HasColumnName("VE_VENTAS");
        });

        modelBuilder.Entity<REmpVsVentasB>(entity =>
        {
            entity.HasKey(e => e.VeCodigo).HasName("PRIMARY");

            entity.ToTable("rEmpVsVentas_B");

            entity.Property(e => e.VeCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("VE_CODIGO");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(50)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiMone)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("PAI_MONE");
            entity.Property(e => e.VeFecha)
                .HasMaxLength(50)
                .HasColumnName("VE_FECHA");
            entity.Property(e => e.VeTipcam)
                .HasMaxLength(50)
                .HasColumnName("VE_TIPCAM");
            entity.Property(e => e.VeVentas)
                .HasMaxLength(50)
                .HasColumnName("VE_VENTAS");
        });

        modelBuilder.Entity<RPerVsBc>(entity =>
        {
            entity.HasKey(e => new { e.PeCodigo, e.BcOrden }).HasName("PRIMARY");

            entity.ToTable("rPerVsBc");

            entity.HasIndex(e => e.PeCodigo, "PE_Codigo");

            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_Codigo");
            entity.Property(e => e.BcOrden)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(2)")
                .HasColumnName("Bc_Orden");
            entity.Property(e => e.BcMonExt)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("Bc_MonExt");
            entity.Property(e => e.BcMonNac)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("Bc_MonNac");
            entity.Property(e => e.BcNombre)
                .HasMaxLength(30)
                .HasColumnName("Bc_Nombre");
            entity.Property(e => e.BcNroCta)
                .HasMaxLength(15)
                .HasColumnName("Bc_NroCta");
            entity.Property(e => e.BcSector)
                .HasMaxLength(20)
                .HasColumnName("Bc_Sector");
            entity.Property(e => e.BcTelefo)
                .HasMaxLength(15)
                .HasColumnName("Bc_Telefo");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<RPerVsBi>(entity =>
        {
            entity.HasKey(e => new { e.PeCodigo, e.BiOrden }).HasName("PRIMARY");

            entity.ToTable("rPerVsBi");

            entity.HasIndex(e => e.PeCodigo, "PE_CODIGO");

            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_CODIGO");
            entity.Property(e => e.BiOrden)
                .HasColumnType("int(2)")
                .HasColumnName("Bi_Orden");
            entity.Property(e => e.BiNombre)
                .HasMaxLength(70)
                .HasColumnName("BI_NOMBRE");
            entity.Property(e => e.BiNombreIng)
                .HasMaxLength(70)
                .HasColumnName("Bi_Nombre_Ing");
            entity.Property(e => e.BiTipo)
                .HasMaxLength(20)
                .HasColumnName("BI_TIPO");
            entity.Property(e => e.BiTipoIng)
                .HasMaxLength(20)
                .HasColumnName("Bi_Tipo_Ing");
            entity.Property(e => e.BiValor).HasColumnName("BI_VALOR");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<RPerVsEr>(entity =>
        {
            entity.HasKey(e => new { e.PeCodigo, e.PrOrden }).HasName("PRIMARY");

            entity.ToTable("rPerVsER");

            entity.HasIndex(e => e.PeCodigo, "PE_CODIGO");

            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_CODIGO");
            entity.Property(e => e.PrOrden)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(2)")
                .HasColumnName("PR_ORDEN");
            entity.Property(e => e.CaCodigo)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("CA_CODIGO");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Hasta)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("HASTA");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("Pai_Codigo");
            entity.Property(e => e.PrAnoref)
                .HasMaxLength(16)
                .HasColumnName("PR_ANOREF");
            entity.Property(e => e.PrCargo)
                .HasMaxLength(25)
                .HasColumnName("PR_CARGO");
            entity.Property(e => e.PrCargoIng)
                .HasMaxLength(25)
                .HasColumnName("PR_Cargo_Ing");
            entity.Property(e => e.PrEmpresa)
                .HasMaxLength(100)
                .HasColumnName("PR_EMPRESA");
            entity.Property(e => e.PrFecces)
                .HasMaxLength(10)
                .HasColumnName("PR_FECCES");
            entity.Property(e => e.PrFecini)
                .HasMaxLength(10)
                .HasColumnName("PR_FECINI");
            entity.Property(e => e.PrPoracc)
                .HasMaxLength(10)
                .HasColumnName("PR_PORACC");
        });

        modelBuilder.Entity<RPerVsLit>(entity =>
        {
            entity.HasKey(e => new { e.PeCodigo, e.LiOrden }).HasName("PRIMARY");

            entity.ToTable("rPerVsLit");

            entity.HasIndex(e => e.PeCodigo, "PE_CODIGO");

            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_CODIGO");
            entity.Property(e => e.LiOrden)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(2)")
                .HasColumnName("LI_ORDEN");
            entity.Property(e => e.LiAccion)
                .HasMaxLength(32)
                .HasColumnName("LI_ACCION");
            entity.Property(e => e.LiAccionIng)
                .HasMaxLength(32)
                .HasColumnName("Li_Accion_Ing");
            entity.Property(e => e.LiDemand)
                .HasMaxLength(40)
                .HasColumnName("LI_DEMAND");
            entity.Property(e => e.LiDemandIng)
                .HasMaxLength(40)
                .HasColumnName("Li_Demand_Ing");
            entity.Property(e => e.LiEstado)
                .HasMaxLength(2)
                .HasColumnName("Li_Estado");
            entity.Property(e => e.LiFecha)
                .HasMaxLength(8)
                .HasColumnName("LI_FECHA");
            entity.Property(e => e.LiFechaIng)
                .HasMaxLength(8)
                .HasColumnName("Li_Fecha_Ing");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<RPerVsMorCom>(entity =>
        {
            entity.HasKey(e => e.McNumero).HasName("PRIMARY");

            entity.ToTable("rPerVsMorCom", tb => tb.HasComment("Morosidad Comerical de Personas"));

            entity.Property(e => e.McNumero)
                .HasColumnType("int(10)")
                .HasColumnName("MC_NUMERO");
            entity.Property(e => e.McAcreed)
                .HasMaxLength(35)
                .HasColumnName("MC_ACREED");
            entity.Property(e => e.McFecha)
                .HasMaxLength(10)
                .HasColumnName("MC_FECHA");
            entity.Property(e => e.McFecinc)
                .HasMaxLength(10)
                .HasColumnName("MC_FECINC");
            entity.Property(e => e.McMonme)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("MC_MONME");
            entity.Property(e => e.McMonmn)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("MC_MONMN");
            entity.Property(e => e.McNrodoc)
                .HasMaxLength(10)
                .HasColumnName("MC_NRODOC");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_CODIGO");
        });

        modelBuilder.Entity<RPerVsProAcep>(entity =>
        {
            entity.HasKey(e => e.PaNumero).HasName("PRIMARY");

            entity.ToTable("rPerVsProAcep", tb => tb.HasComment("Tabla de Protestos Por Aceptante de Personas."));

            entity.Property(e => e.PaNumero)
                .HasColumnType("int(10)")
                .HasColumnName("PA_NUMERO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaBoletin)
                .HasMaxLength(10)
                .HasColumnName("PA_BOLETIN");
            entity.Property(e => e.PaFecpro)
                .HasMaxLength(10)
                .HasColumnName("PA_FECPRO");
            entity.Property(e => e.PaFecreg)
                .HasMaxLength(10)
                .HasColumnName("PA_FECREG");
            entity.Property(e => e.PaGirador)
                .HasMaxLength(50)
                .HasColumnName("PA_GIRADOR");
            entity.Property(e => e.PaMonme)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("PA_MONME");
            entity.Property(e => e.PaMonmn)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("PA_MONMN");
            entity.Property(e => e.PaNumdoc)
                .HasMaxLength(10)
                .HasColumnName("PA_NUMDOC");
            entity.Property(e => e.PaTitulo)
                .HasMaxLength(50)
                .HasColumnName("PA_TITULO");
            entity.Property(e => e.PaTituloIng)
                .HasMaxLength(50)
                .HasColumnName("PA_TITULO_ING");
            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_CODIGO");
        });

        modelBuilder.Entity<RPerVsProv>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rPerVsProv");

            entity.HasIndex(e => new { e.PeCodigo, e.ProvCorrelativo }, "PE_CODIGO");

            entity.HasIndex(e => new { e.PeCodigo, e.ProvNLinCre, e.ProvNPrmMen }, "PE_CODIGO_2");

            entity.HasIndex(e => new { e.PeCodigo, e.ProvNombre }, "PE_CODIGO_3");

            entity.Property(e => e.CumCodigo)
                .HasMaxLength(2)
                .HasColumnName("CUM_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_CODIGO");
            entity.Property(e => e.ProvAtendio)
                .HasMaxLength(100)
                .HasColumnName("PROV_ATENDIO");
            entity.Property(e => e.ProvComen)
                .HasColumnType("text")
                .HasColumnName("Prov_Comen");
            entity.Property(e => e.ProvComenIng)
                .HasColumnType("text")
                .HasColumnName("Prov_Comen_Ing");
            entity.Property(e => e.ProvCorrelativo)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(3)")
                .HasColumnName("PROV_CORRELATIVO");
            entity.Property(e => e.ProvCumple)
                .HasMaxLength(100)
                .HasColumnName("Prov_Cumple");
            entity.Property(e => e.ProvDeuAct)
                .HasMaxLength(20)
                .HasColumnName("Prov_DeuAct");
            entity.Property(e => e.ProvEstado)
                .HasMaxLength(50)
                .HasColumnName("Prov_Estado");
            entity.Property(e => e.ProvEstadoIng)
                .HasMaxLength(50)
                .HasColumnName("Prov_Estado_Ing");
            entity.Property(e => e.ProvFecha)
                .HasColumnType("date")
                .HasColumnName("PROV_FECHA");
            entity.Property(e => e.ProvLinCre)
                .HasMaxLength(100)
                .HasColumnName("Prov_LinCre");
            entity.Property(e => e.ProvLinCreIng)
                .HasMaxLength(100)
                .HasColumnName("Prov_LinCre_Ing");
            entity.Property(e => e.ProvLlamo)
                .HasMaxLength(1)
                .HasDefaultValueSql("'N'")
                .IsFixedLength()
                .HasColumnName("PROV_LLAMO");
            entity.Property(e => e.ProvMnLiCr)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("Prov_MnLiCr");
            entity.Property(e => e.ProvMnPrMe)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("Prov_MnPrMe");
            entity.Property(e => e.ProvNLinCre)
                .HasDefaultValueSql("'0'")
                .HasColumnName("Prov_nLinCre");
            entity.Property(e => e.ProvNPrmMen)
                .HasDefaultValueSql("'0'")
                .HasColumnName("Prov_nPrmMen");
            entity.Property(e => e.ProvNombre)
                .HasMaxLength(46)
                .HasColumnName("Prov_Nombre");
            entity.Property(e => e.ProvOrden)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(3)")
                .HasColumnName("Prov_Orden");
            entity.Property(e => e.ProvPais)
                .HasMaxLength(30)
                .HasColumnName("Prov_Pais");
            entity.Property(e => e.ProvPlazos)
                .HasMaxLength(100)
                .HasColumnName("Prov_Plazos");
            entity.Property(e => e.ProvPlazosIng)
                .HasMaxLength(100)
                .HasColumnName("Prov_Plazos_Ing");
            entity.Property(e => e.ProvPrmMen)
                .HasMaxLength(16)
                .HasColumnName("Prov_PrmMen");
            entity.Property(e => e.ProvPrmMenIng)
                .HasMaxLength(16)
                .HasColumnName("Prov_PrmMen_Ing");
            entity.Property(e => e.ProvTelefo)
                .HasMaxLength(20)
                .HasColumnName("Prov_Telefo");
            entity.Property(e => e.ProvTexto)
                .HasColumnType("text")
                .HasColumnName("PROV_TEXTO");
            entity.Property(e => e.ProvTiempo)
                .HasMaxLength(100)
                .HasColumnName("Prov_Tiempo");
            entity.Property(e => e.ProvTiempoIng)
                .HasMaxLength(100)
                .HasColumnName("Prov_Tiempo_Ing");
            entity.Property(e => e.ProvVenden)
                .HasMaxLength(50)
                .HasColumnName("Prov_Venden");
            entity.Property(e => e.ProvVendenIng)
                .HasMaxLength(50)
                .HasColumnName("Prov_Venden_Ing");
        });

        modelBuilder.Entity<RPerVsRep>(entity =>
        {
            entity.HasKey(e => new { e.PeCodigo, e.RcCodigo }).HasName("PRIMARY");

            entity.ToTable("rPerVsRep");

            entity.HasIndex(e => e.PeCodigo, "PE_CODIGO");

            entity.HasIndex(e => new { e.PeCodigo, e.RcCodigo }, "PE_CODIGO_2");

            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_CODIGO");
            entity.Property(e => e.RcCodigo)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasComment("Codigo de la Reputacion Comercial")
                .HasColumnName("RC_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<RPerVsSbd>(entity =>
        {
            entity.HasKey(e => new { e.PeCodigo, e.SbdOrden }).HasName("PRIMARY");

            entity.ToTable("rPerVsSBD");

            entity.HasIndex(e => e.PeCodigo, "PE_Codigo");

            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_Codigo");
            entity.Property(e => e.SbdOrden)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(2)")
                .HasColumnName("SBD_Orden");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.SbdCalifi)
                .HasMaxLength(100)
                .HasColumnName("SBD_CALIFI");
            entity.Property(e => e.SbdCalifiIng)
                .HasMaxLength(100)
                .HasColumnName("SBD_CALIFI_ING");
            entity.Property(e => e.SbdDefici)
                .HasMaxLength(5)
                .HasColumnName("SBD_Defici");
            entity.Property(e => e.SbdDudoso)
                .HasMaxLength(5)
                .HasColumnName("SBD_Dudoso");
            entity.Property(e => e.SbdMonme)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("SBD_MONME");
            entity.Property(e => e.SbdMonmn)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(15,2)")
                .HasColumnName("SBD_MONMN");
            entity.Property(e => e.SbdNombre)
                .HasMaxLength(32)
                .HasColumnName("SBD_Nombre");
            entity.Property(e => e.SbdNormal)
                .HasMaxLength(5)
                .HasColumnName("SBD_Normal");
            entity.Property(e => e.SbdPerdida)
                .HasMaxLength(5)
                .HasColumnName("SBD_Perdida");
            entity.Property(e => e.SbdProPot)
                .HasMaxLength(5)
                .HasColumnName("SBD_ProPot");
        });

        modelBuilder.Entity<RPerVsTrab>(entity =>
        {
            entity.HasKey(e => e.PeCodigo).HasName("PRIMARY");

            entity.ToTable("rPerVsTrab", tb => tb.HasComment("Tabla relacionada de Persona con Trabajo"));

            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasDefaultValueSql("''")
                .HasColumnName("PE_CODIGO");
            entity.Property(e => e.CaCodigo)
                .HasDefaultValueSql("'65'")
                .HasColumnType("int(11)")
                .HasColumnName("CA_CODIGO");
            entity.Property(e => e.CaNombre)
                .HasMaxLength(50)
                .HasColumnName("CA_NOMBRE");
            entity.Property(e => e.CaNombreIng)
                .HasMaxLength(50)
                .HasColumnName("CA_NOMBRE_ING");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PtCentra)
                .HasMaxLength(100)
                .HasColumnName("PT_CENTRA");
            entity.Property(e => e.PtDetall)
                .HasColumnType("text")
                .HasColumnName("PT_DETALL");
            entity.Property(e => e.PtDetallIng)
                .HasColumnType("text")
                .HasColumnName("PT_DETALL_ING");
            entity.Property(e => e.PtDirecc)
                .HasMaxLength(150)
                .HasColumnName("PT_DIRECC");
            entity.Property(e => e.PtEstadi)
                .HasDefaultValueSql("'0'")
                .HasColumnName("PT_ESTADI");
            entity.Property(e => e.PtFecces)
                .HasMaxLength(25)
                .HasColumnName("PT_FECCES");
            entity.Property(e => e.PtFeccesIng)
                .HasMaxLength(25)
                .HasColumnName("PT_FECCES_ING");
            entity.Property(e => e.PtFecing)
                .HasMaxLength(25)
                .HasColumnName("PT_FECING");
            entity.Property(e => e.PtFecingIng)
                .HasMaxLength(25)
                .HasColumnName("PT_FECING_ING");
            entity.Property(e => e.PtInganu)
                .HasMaxLength(50)
                .HasColumnName("PT_INGANU");
            entity.Property(e => e.PtInganuIng)
                .HasMaxLength(50)
                .HasColumnName("PT_INGANU_ING");
            entity.Property(e => e.PtTelefo)
                .HasMaxLength(60)
                .HasColumnName("PT_TELEFO");
        });

        modelBuilder.Entity<RUsuVsGuid>(entity =>
        {
            entity.HasKey(e => e.UsGuid).HasName("PRIMARY");

            entity.ToTable("rUsuVsGUID");

            entity.Property(e => e.UsGuid)
                .HasMaxLength(50)
                .HasColumnName("US_GUID");
            entity.Property(e => e.CupCodigo)
                .HasColumnType("bigint(20)")
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Flag)
                .HasColumnType("int(11)")
                .HasColumnName("FLAG");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<RUsuVsIng>(entity =>
        {
            entity.HasKey(e => e.UiCodigo).HasName("PRIMARY");

            entity.ToTable("rUsuVsIng");

            entity.Property(e => e.UiCodigo)
                .HasColumnType("int(5)")
                .HasColumnName("UI_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.UiFecing)
                .HasColumnType("datetime")
                .HasColumnName("UI_FECING");
            entity.Property(e => e.UiFecsal)
                .HasColumnType("datetime")
                .HasColumnName("UI_FECSAL");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<ResumenMensual>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("resumen_mensual");

            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.Abonado)
                .HasMaxLength(150)
                .HasColumnName("abonado");
            entity.Property(e => e.Anio)
                .HasMaxLength(4)
                .HasColumnName("anio");
            entity.Property(e => e.Cantidad)
                .HasColumnType("int(11)")
                .HasColumnName("cantidad");
            entity.Property(e => e.Mes)
                .HasColumnType("tinyint(4)")
                .HasColumnName("mes");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.Pais)
                .HasMaxLength(3)
                .HasColumnName("pais");
        });

        modelBuilder.Entity<TAboVsKardex>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tAboVsKardex");

            entity.Property(e => e.AboCodigo)
                .HasMaxLength(50)
                .HasColumnName("abo_codigo");
            entity.Property(e => e.Ano)
                .HasColumnType("int(11)")
                .HasColumnName("ano");
            entity.Property(e => e.Mes)
                .HasColumnType("int(11)")
                .HasColumnName("mes");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.Valor)
                .HasPrecision(10)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<TAbonadoCupon>(entity =>
        {
            entity.HasKey(e => e.AcNumero).HasName("PRIMARY");

            entity.ToTable("tAbonadoCupon");

            entity.Property(e => e.AcNumero)
                .HasColumnType("int(11)")
                .HasColumnName("AC_NUMERO");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.AcCancom)
                .HasDefaultValueSql("'0.00'")
                .HasComment("Cantidad de Compra")
                .HasColumnType("double(10,2)")
                .HasColumnName("AC_CANCOM");
            entity.Property(e => e.AcCuprest)
                .HasDefaultValueSql("'0.00'")
                .HasComment("Cupones Restantes")
                .HasColumnType("double(10,2)")
                .HasColumnName("AC_CUPREST");
            entity.Property(e => e.AcEquiva)
                .HasDefaultValueSql("'0.00'")
                .HasComment("Equivalencia cupon de compra")
                .HasColumnType("double(10,2)")
                .HasColumnName("AC_EQUIVA");
            entity.Property(e => e.AcFactur)
                .HasMaxLength(2)
                .HasDefaultValueSql("'No'")
                .HasColumnName("AC_FACTUR");
            entity.Property(e => e.AcFecfin)
                .HasColumnType("datetime")
                .HasColumnName("AC_FECFIN");
            entity.Property(e => e.AcFecini)
                .HasColumnType("datetime")
                .HasColumnName("AC_FECINI");
            entity.Property(e => e.AcMonto)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)")
                .HasColumnName("AC_MONTO");
            entity.Property(e => e.AcPrecio)
                .HasColumnType("double(10,2)")
                .HasColumnName("AC_PRECIO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TAbonadoCuponera>(entity =>
        {
            entity.HasKey(e => e.AcNumero).HasName("PRIMARY");

            entity.ToTable("tAbonadoCuponera");

            entity.Property(e => e.AcNumero)
                .HasColumnType("int(11)")
                .HasColumnName("AC_NUMERO");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.AcCancom)
                .HasDefaultValueSql("'0.000'")
                .HasComment("Cantidad de Compra")
                .HasColumnType("double(10,3)")
                .HasColumnName("AC_CANCOM");
            entity.Property(e => e.AcCuprest)
                .HasDefaultValueSql("'0.000'")
                .HasComment("Cuponera Restantes")
                .HasColumnType("double(10,3)")
                .HasColumnName("AC_CUPREST");
            entity.Property(e => e.AcFactur)
                .HasMaxLength(2)
                .HasDefaultValueSql("'No'")
                .HasColumnName("AC_FACTUR");
            entity.Property(e => e.AcFecini)
                .HasColumnType("datetime")
                .HasColumnName("AC_FECINI");
            entity.Property(e => e.AcMonto)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("AC_MONTO");
            entity.Property(e => e.AcPrecio)
                .HasColumnType("double(10,3)")
                .HasColumnName("AC_PRECIO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TAbonadoTalonario>(entity =>
        {
            entity.HasKey(e => e.AtNumero).HasName("PRIMARY");

            entity.ToTable("tAbonadoTalonario");

            entity.Property(e => e.AtNumero)
                .HasColumnType("int(11)")
                .HasColumnName("AT_NUMERO");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.AtCancom)
                .HasDefaultValueSql("'0.000'")
                .HasComment("Cantidad de Compra")
                .HasColumnType("double(10,3)")
                .HasColumnName("AT_CANCOM");
            entity.Property(e => e.AtCuprest)
                .HasDefaultValueSql("'0.000'")
                .HasComment("Cuponera Restantes")
                .HasColumnType("double(10,3)")
                .HasColumnName("AT_CUPREST");
            entity.Property(e => e.AtFactur)
                .HasMaxLength(2)
                .HasDefaultValueSql("'No'")
                .HasColumnName("AT_FACTUR");
            entity.Property(e => e.AtFecini)
                .HasColumnType("datetime")
                .HasColumnName("AT_FECINI");
            entity.Property(e => e.AtMonto)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("AT_MONTO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TActCom>(entity =>
        {
            entity.HasKey(e => e.AcCodigo).HasName("PRIMARY");

            entity.ToTable("tActCom");

            entity.Property(e => e.AcCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("AC_CODIGO");
            entity.Property(e => e.AcNombre)
                .HasMaxLength(50)
                .HasColumnName("AC_NOMBRE");
            entity.Property(e => e.AcNombreIng)
                .HasMaxLength(50)
                .HasColumnName("AC_NOMBRE_ING");
            entity.Property(e => e.EmCiiu)
                .HasMaxLength(1)
                .HasColumnName("EM_CIIU");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TAlerta>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tAlertas");

            entity.Property(e => e.CupCodigo)
                .HasMaxLength(6)
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.CupNomsol)
                .HasMaxLength(150)
                .HasColumnName("CUP_NOMSOL");
            entity.Property(e => e.Migra).HasColumnName("MIGRA");
            entity.Property(e => e.PerCodigo1)
                .HasMaxLength(3)
                .HasColumnName("PER_CODIGO_1");
            entity.Property(e => e.PerCodigo1Fecha)
                .HasColumnType("datetime")
                .HasColumnName("PER_CODIGO_1_FECHA");
            entity.Property(e => e.PerCodigo2)
                .HasMaxLength(3)
                .HasColumnName("PER_CODIGO_2");
            entity.Property(e => e.PerCodigo2Fecha)
                .HasColumnType("datetime")
                .HasColumnName("PER_CODIGO_2_FECHA");
            entity.Property(e => e.TramCodigo)
                .HasMaxLength(2)
                .HasColumnName("TRAM_CODIGO");
        });

        modelBuilder.Entity<TAsigAgen>(entity =>
        {
            entity.HasKey(e => e.AgNumped).HasName("PRIMARY");

            entity.ToTable("tAsig_Agen");

            entity.Property(e => e.AgNumped)
                .HasColumnType("bigint(10)")
                .HasColumnName("AG_NUMPED");
            entity.Property(e => e.AgActivo).HasColumnName("AG_ACTIVO");
            entity.Property(e => e.AgCosto)
                .HasColumnType("double(10,3)")
                .HasColumnName("AG_COSTO");
            entity.Property(e => e.AgFactura)
                .HasMaxLength(2)
                .HasColumnName("AG_FACTURA");
            entity.Property(e => e.AgFecdev)
                .HasColumnType("datetime")
                .HasColumnName("AG_FECDEV");
            entity.Property(e => e.AgFecent)
                .HasColumnType("datetime")
                .HasColumnName("AG_FECENT");
            entity.Property(e => e.AgFecvcto)
                .HasColumnType("datetime")
                .HasColumnName("AG_FECVCTO");
            entity.Property(e => e.AgNumord)
                .HasColumnType("int(5)")
                .HasColumnName("AG_NUMORD");
            entity.Property(e => e.AgObserv)
                .HasMaxLength(2000)
                .HasColumnName("AG_OBSERV");
            entity.Property(e => e.AgObtbal)
                .HasMaxLength(2)
                .HasColumnName("AG_OBTBAL");
            entity.Property(e => e.AgRecome)
                .HasMaxLength(2000)
                .HasColumnName("AG_RECOME");
            entity.Property(e => e.AgRefere)
                .HasMaxLength(2000)
                .HasColumnName("AG_REFERE");
            entity.Property(e => e.AgTipinf)
                .HasMaxLength(2)
                .HasColumnName("AG_TIPINF");
            entity.Property(e => e.AgVerif)
                .HasMaxLength(25)
                .HasColumnName("AG_VERIF");
            entity.Property(e => e.CalCodigo)
                .HasMaxLength(3)
                .HasColumnName("CAL_CODIGO");
            entity.Property(e => e.CupCodigo)
                .HasMaxLength(20)
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.Migra)
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("PER_CODIGO");
            entity.Property(e => e.PerCodigoAge)
                .HasMaxLength(3)
                .HasColumnName("PER_CODIGO_AGE");
            entity.Property(e => e.TramCodigo)
                .HasMaxLength(3)
                .HasColumnName("TRAM_CODIGO");
        });

        modelBuilder.Entity<TAsigDig>(entity =>
        {
            entity.HasKey(e => e.AdNumped).HasName("PRIMARY");

            entity.ToTable("tAsig_Dig");

            entity.HasIndex(e => e.AdNumped, "AD_NUMPED").IsUnique();

            entity.Property(e => e.AdNumped)
                .HasColumnType("bigint(10)")
                .HasColumnName("AD_NUMPED");
            entity.Property(e => e.AdCosto)
                .HasColumnType("double(7,3)")
                .HasColumnName("AD_COSTO");
            entity.Property(e => e.AdFecdev)
                .HasColumnType("datetime")
                .HasColumnName("AD_FECDEV");
            entity.Property(e => e.AdFecent)
                .HasColumnType("datetime")
                .HasColumnName("AD_FECENT");
            entity.Property(e => e.AdFecvcto)
                .HasColumnType("datetime")
                .HasColumnName("AD_FECVCTO");
            entity.Property(e => e.AdLogobs)
                .HasMaxLength(2)
                .HasDefaultValueSql("'NO'")
                .HasComment("Si tiene o no Observaciones")
                .HasColumnName("AD_LOGOBS");
            entity.Property(e => e.AdRepdig)
                .HasMaxLength(2)
                .HasDefaultValueSql("'No'")
                .HasComment("No - >Solo Digitadora.   Si -> Es Digitadora / Reportera.")
                .HasColumnName("AD_REPDIG");
            entity.Property(e => e.AdTipinf)
                .HasMaxLength(2)
                .HasColumnName("AD_TIPINF");
            entity.Property(e => e.CupCodigo)
                .HasMaxLength(20)
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.Migra)
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("PER_CODIGO");
            entity.Property(e => e.PerCodigoDig)
                .HasMaxLength(3)
                .HasColumnName("PER_CODIGO_DIG");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<TAsigRep>(entity =>
        {
            entity.HasKey(e => e.ArNumped).HasName("PRIMARY");

            entity.ToTable("tAsig_Rep");

            entity.Property(e => e.ArNumped)
                .HasColumnType("bigint(20)")
                .HasColumnName("AR_NUMPED");
            entity.Property(e => e.ArActivo).HasColumnName("AR_ACTIVO");
            entity.Property(e => e.ArCosto)
                .HasColumnType("double(7,3)")
                .HasColumnName("AR_COSTO");
            entity.Property(e => e.ArFecdev)
                .HasColumnType("datetime")
                .HasColumnName("AR_FECDEV");
            entity.Property(e => e.ArFecent)
                .HasColumnType("datetime")
                .HasColumnName("AR_FECENT");
            entity.Property(e => e.ArFecvcto)
                .HasColumnType("datetime")
                .HasColumnName("AR_FECVCTO");
            entity.Property(e => e.ArLogobs)
                .HasMaxLength(2)
                .HasDefaultValueSql("'NO'")
                .HasComment("Si tuvo o no Observaciones")
                .HasColumnName("AR_LOGOBS");
            entity.Property(e => e.ArObserv)
                .HasMaxLength(2000)
                .HasColumnName("AR_OBSERV");
            entity.Property(e => e.ArObtbal)
                .HasMaxLength(2)
                .HasColumnName("AR_OBTBAL");
            entity.Property(e => e.ArRecome)
                .HasMaxLength(2000)
                .HasColumnName("AR_RECOME");
            entity.Property(e => e.ArRefere)
                .HasMaxLength(2000)
                .HasColumnName("AR_REFERE");
            entity.Property(e => e.ArTipinf)
                .HasMaxLength(2)
                .HasColumnName("AR_TIPINF");
            entity.Property(e => e.CalCodigo)
                .HasMaxLength(3)
                .HasColumnName("CAL_CODIGO");
            entity.Property(e => e.CupCodigo)
                .HasMaxLength(20)
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("PER_CODIGO");
            entity.Property(e => e.PerCodigoRep)
                .HasMaxLength(3)
                .HasColumnName("PER_CODIGO_REP");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NO'");
            entity.Property(e => e.TramCodigo)
                .HasMaxLength(3)
                .HasColumnName("TRAM_CODIGO");
        });

        modelBuilder.Entity<TAsigSup>(entity =>
        {
            entity.HasKey(e => e.AsNumped).HasName("PRIMARY");

            entity.ToTable("tAsig_Sup");

            entity.Property(e => e.AsNumped)
                .HasColumnType("bigint(10)")
                .HasColumnName("AS_NUMPED");
            entity.Property(e => e.AsFecdev)
                .HasColumnType("datetime")
                .HasColumnName("AS_FECDEV");
            entity.Property(e => e.AsFecent)
                .HasColumnType("datetime")
                .HasColumnName("AS_FECENT");
            entity.Property(e => e.CupCodigo)
                .HasMaxLength(20)
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("PER_CODIGO");
            entity.Property(e => e.PerCodigoSup)
                .HasMaxLength(3)
                .HasColumnName("PER_CODIGO_SUP");
        });

        modelBuilder.Entity<TAsigTrad>(entity =>
        {
            entity.HasKey(e => e.AtNumped).HasName("PRIMARY");

            entity.ToTable("tAsig_Trad");

            entity.Property(e => e.AtNumped)
                .HasColumnType("bigint(10)")
                .HasColumnName("AT_NUMPED");
            entity.Property(e => e.AtCosto)
                .HasColumnType("double(7,3)")
                .HasColumnName("AT_COSTO");
            entity.Property(e => e.AtFecdev)
                .HasColumnType("datetime")
                .HasColumnName("AT_FECDEV");
            entity.Property(e => e.AtFecent)
                .HasColumnType("datetime")
                .HasColumnName("AT_FECENT");
            entity.Property(e => e.AtFecvcto)
                .HasColumnType("datetime")
                .HasColumnName("AT_FECVCTO");
            entity.Property(e => e.AtLogobs)
                .HasMaxLength(2)
                .HasDefaultValueSql("'NO'")
                .HasComment("Si tiene o no Observaciones")
                .HasColumnName("AT_LOGOBS");
            entity.Property(e => e.AtTipinf)
                .HasMaxLength(2)
                .HasColumnName("AT_TIPINF");
            entity.Property(e => e.AtTradir)
                .HasMaxLength(2)
                .HasDefaultValueSql("'No'")
                .HasComment("Si se traduce directamente o no")
                .HasColumnName("AT_TRADIR");
            entity.Property(e => e.CupCodigo)
                .HasMaxLength(20)
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("PER_CODIGO");
            entity.Property(e => e.PerCodigoTra)
                .HasMaxLength(3)
                .HasColumnName("PER_CODIGO_TRA");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NO'");
        });

        modelBuilder.Entity<TAsigVirtual>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tAsig_Virtual");

            entity.Property(e => e.CupCodigo)
                .HasMaxLength(20)
                .HasColumnName("cup_Codigo");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Flag).HasColumnType("int(11)");
            entity.Property(e => e.Guid)
                .HasMaxLength(50)
                .HasColumnName("GUID");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.NumPedido)
                .HasColumnType("bigint(10)")
                .HasColumnName("num_Pedido");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("per_Codigo");
            entity.Property(e => e.PerTipo)
                .HasMaxLength(4)
                .HasColumnName("per_Tipo");
            entity.Property(e => e.PerUsuario)
                .HasMaxLength(4)
                .HasColumnName("per_Usuario");
        });

        modelBuilder.Entity<TAuditorium>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tAuditoria");

            entity.Property(e => e.AudAccion)
                .HasMaxLength(3)
                .HasColumnName("audAccion");
            entity.Property(e => e.AudCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("audCodigo");
            entity.Property(e => e.AudComentario)
                .HasMaxLength(100)
                .HasColumnName("audComentario");
            entity.Property(e => e.AudFecha)
                .HasColumnType("datetime")
                .HasColumnName("audFecha");
            entity.Property(e => e.AudFlag)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("audFlag");
            entity.Property(e => e.AudTabla)
                .HasMaxLength(50)
                .HasColumnName("audTabla");
            entity.Property(e => e.AudValor1)
                .HasMaxLength(50)
                .HasColumnName("audValor1");
            entity.Property(e => e.AudValor2)
                .HasMaxLength(50)
                .HasColumnName("audValor2");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("perCodigo");
        });

        modelBuilder.Entity<TCabEmpAval>(entity =>
        {
            entity.HasKey(e => e.EmCodigo).HasName("PRIMARY");

            entity.ToTable("tCabEmpAval");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.AvObservacion)
                .HasMaxLength(2000)
                .HasColumnName("AV_OBSERVACION");
            entity.Property(e => e.AvObservacionIng)
                .HasMaxLength(2000)
                .HasColumnName("AV_OBSERVACION_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TCabFactAbonado>(entity =>
        {
            entity.HasKey(e => e.FacCodigo).HasName("PRIMARY");

            entity.ToTable("tCabFactAbonado");

            entity.Property(e => e.FacCodigo)
                .HasMaxLength(15)
                .HasColumnName("FAC_CODIGO");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.AboFacpara)
                .HasMaxLength(150)
                .HasColumnName("ABO_FACPARA");
            entity.Property(e => e.AboTipfac)
                .HasMaxLength(2)
                .HasColumnName("ABO_TIPFAC");
            entity.Property(e => e.FacCaninf)
                .HasColumnType("int(11)")
                .HasColumnName("FAC_CANINF");
            entity.Property(e => e.FacEstado)
                .HasMaxLength(1)
                .HasColumnName("FAC_ESTADO");
            entity.Property(e => e.FacFeccan)
                .HasColumnType("datetime")
                .HasColumnName("FAC_FECCAN");
            entity.Property(e => e.FacFecfac)
                .HasColumnType("datetime")
                .HasColumnName("FAC_FECFAC");
            entity.Property(e => e.FacIgv)
                .HasColumnType("double(10,3)")
                .HasColumnName("FAC_IGV");
            entity.Property(e => e.FacMonto)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("FAC_MONTO");
            entity.Property(e => e.FacNrocup)
                .HasColumnType("double(10,3)")
                .HasColumnName("FAC_NROCUP");
            entity.Property(e => e.FacObserv)
                .HasMaxLength(20)
                .HasColumnName("FAC_OBSERV");
            entity.Property(e => e.FacSerie)
                .HasMaxLength(2)
                .HasColumnName("FAC_SERIE");
            entity.Property(e => e.FacTcEd)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("FAC_TC_ED");
            entity.Property(e => e.FacTcSd)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("FAC_TC_SD");
            entity.Property(e => e.FacValor)
                .HasColumnType("double(10,3)")
                .HasColumnName("FAC_VALOR");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.MonCodigo)
                .HasMaxLength(3)
                .HasColumnName("MON_CODIGO");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("PER_CODIGO");
        });

        modelBuilder.Entity<TCabFactAgente>(entity =>
        {
            entity.HasKey(e => e.FacCodigo).HasName("PRIMARY");

            entity.ToTable("tCabFactAgente");

            entity.Property(e => e.FacCodigo)
                .HasMaxLength(15)
                .HasColumnName("FAC_CODIGO");
            entity.Property(e => e.AgeCodigo)
                .HasMaxLength(4)
                .HasColumnName("AGE_CODIGO");
            entity.Property(e => e.FacCantid)
                .HasColumnType("int(11)")
                .HasColumnName("FAC_CANTID");
            entity.Property(e => e.FacEstado)
                .HasMaxLength(1)
                .HasColumnName("FAC_ESTADO");
            entity.Property(e => e.FacFeccan)
                .HasColumnType("datetime")
                .HasColumnName("FAC_FECCAN");
            entity.Property(e => e.FacFecfac)
                .HasColumnType("datetime")
                .HasColumnName("FAC_FECFAC");
            entity.Property(e => e.FacMonto)
                .HasColumnType("double(10,3)")
                .HasColumnName("FAC_MONTO");
            entity.Property(e => e.FacObserv)
                .HasMaxLength(20)
                .HasColumnName("FAC_OBSERV");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.MonCodigo)
                .HasMaxLength(3)
                .HasColumnName("MON_CODIGO");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("PER_CODIGO");
        });

        modelBuilder.Entity<TCabNcabonado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tCabNCAbonado");

            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.FacCodigo)
                .HasMaxLength(15)
                .HasColumnName("FAC_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.MonCodigo)
                .HasMaxLength(30)
                .HasColumnName("MON_CODIGO");
            entity.Property(e => e.NcCodigo)
                .HasMaxLength(15)
                .HasColumnName("NC_CODIGO");
            entity.Property(e => e.NcEstado)
                .HasMaxLength(1)
                .HasColumnName("NC_ESTADO");
            entity.Property(e => e.NcFecha)
                .HasColumnType("datetime")
                .HasColumnName("NC_FECHA");
            entity.Property(e => e.NcIgv).HasColumnName("NC_IGV");
            entity.Property(e => e.NcMonto).HasColumnName("NC_MONTO");
            entity.Property(e => e.NcObservacion)
                .HasMaxLength(1000)
                .HasColumnName("NC_OBSERVACION");
            entity.Property(e => e.NcValor).HasColumnName("NC_VALOR");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("PER_CODIGO");
        });

        modelBuilder.Entity<TCabObservacion>(entity =>
        {
            entity.HasKey(e => e.ObCodigo).HasName("PRIMARY");

            entity.ToTable("tCabObservacion");

            entity.HasIndex(e => e.AboCodigo, "ABO_CODIGO");

            entity.HasIndex(e => e.CupCodigo, "CUP_CODIGO");

            entity.HasIndex(e => e.ObMotivo, "OB_MOTIVO");

            entity.Property(e => e.ObCodigo)
                .HasColumnType("bigint(20)")
                .HasColumnName("OB_CODIGO");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.CupCodigo)
                .HasColumnType("bigint(20)")
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.ObCampo)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("OB_CAMPO");
            entity.Property(e => e.ObConclusion)
                .HasMaxLength(2000)
                .HasColumnName("OB_CONCLUSION");
            entity.Property(e => e.ObEstado)
                .HasColumnType("int(1)")
                .HasColumnName("OB_ESTADO");
            entity.Property(e => e.ObFecasig)
                .HasColumnType("datetime")
                .HasColumnName("OB_FECASIG");
            entity.Property(e => e.ObFecreg)
                .HasColumnType("datetime")
                .HasColumnName("OB_FECREG");
            entity.Property(e => e.ObFecsol)
                .HasColumnType("datetime")
                .HasColumnName("OB_FECSOL");
            entity.Property(e => e.ObFecvcto)
                .HasColumnType("datetime")
                .HasColumnName("OB_FECVCTO");
            entity.Property(e => e.ObMensaje)
                .HasMaxLength(2000)
                .HasColumnName("OB_MENSAJE");
            entity.Property(e => e.ObMotivo)
                .HasColumnType("tinyint(4)")
                .HasColumnName("OB_MOTIVO");
            entity.Property(e => e.ObResAbo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("OB_RES_ABO");
            entity.Property(e => e.ObResAge)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("OB_RES_AGE");
            entity.Property(e => e.ObResDrr)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("OB_RES_DRR");
            entity.Property(e => e.ObResNinguno)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("OB_RES_NINGUNO");
        });

        modelBuilder.Entity<TCalidad>(entity =>
        {
            entity.HasKey(e => e.CalCodigo).HasName("PRIMARY");

            entity.ToTable("tCalidad");

            entity.Property(e => e.CalCodigo)
                .HasMaxLength(3)
                .HasColumnName("CAL_CODIGO");
            entity.Property(e => e.CalAbrevi)
                .HasMaxLength(4)
                .HasColumnName("CAL_ABREVI");
            entity.Property(e => e.CalActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("CAL_ACTIVO");
            entity.Property(e => e.CalNombre)
                .HasMaxLength(40)
                .HasColumnName("CAL_NOMBRE");
            entity.Property(e => e.CalOrden)
                .HasColumnType("int(10)")
                .HasColumnName("CAL_ORDEN");
            entity.Property(e => e.CalPrePer)
                .HasColumnType("double(5,2)")
                .HasColumnName("CAL_PRE_PER");
            entity.Property(e => e.CalPreT1)
                .HasColumnType("double(5,2)")
                .HasColumnName("CAL_PRE_T1");
            entity.Property(e => e.CalPreT2)
                .HasColumnType("double(5,2)")
                .HasColumnName("CAL_PRE_T2");
            entity.Property(e => e.CalPreT3)
                .HasColumnType("double(5,2)")
                .HasColumnName("CAL_PRE_T3");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TCalifRef>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tCalifRef");

            entity.HasIndex(e => e.CarCodigo, "REF_CODIGO");

            entity.Property(e => e.CarActivo)
                .HasColumnType("tinyint(4)")
                .HasColumnName("CAR_ACTIVO");
            entity.Property(e => e.CarCodigo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("CAR_CODIGO");
            entity.Property(e => e.CarNombre)
                .HasMaxLength(200)
                .HasColumnName("CAR_NOMBRE");
            entity.Property(e => e.CarValor)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("CAR_VALOR");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TCalifSic>(entity =>
        {
            entity.HasKey(e => e.CsCodigo).HasName("PRIMARY");

            entity.ToTable("tCalifSic");

            entity.Property(e => e.CsCodigo)
                .HasMaxLength(3)
                .HasDefaultValueSql("''")
                .HasColumnName("CS_CODIGO");
            entity.Property(e => e.CcCodigo)
                .HasMaxLength(3)
                .HasColumnName("CC_CODIGO");
            entity.Property(e => e.CsDescri)
                .HasMaxLength(150)
                .HasColumnName("CS_DESCRI");
            entity.Property(e => e.CsDescriIng)
                .HasMaxLength(150)
                .HasColumnName("CS_DESCRI_ING");
            entity.Property(e => e.CsInterp)
                .HasColumnType("text")
                .HasColumnName("CS_INTERP");
            entity.Property(e => e.CsInterpIng)
                .HasColumnType("text")
                .HasColumnName("CS_INTERP_ING");
            entity.Property(e => e.CsSector)
                .HasMaxLength(3)
                .HasColumnName("CS_SECTOR");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TCampoValidacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tCampoValidacion");

            entity.HasIndex(e => e.CamCodigo, "CAM_CODIGO");

            entity.Property(e => e.CamCodigo)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("CAM_CODIGO");
            entity.Property(e => e.CamDescripcion)
                .HasMaxLength(50)
                .HasColumnName("CAM_DESCRIPCION");
            entity.Property(e => e.CamEstado)
                .HasColumnType("int(11)")
                .HasColumnName("CAM_ESTADO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TCargo>(entity =>
        {
            entity.HasKey(e => e.CaCodigo).HasName("PRIMARY");

            entity.ToTable("tCargo");

            entity.HasIndex(e => e.CaCodigoIng, "CA_CODIGO_ING");

            entity.HasIndex(e => e.CaNombre, "CA_NOMBRE");

            entity.HasIndex(e => e.CaNombreIng, "CA_NOMBRE_ING");

            entity.Property(e => e.CaCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("CA_CODIGO");
            entity.Property(e => e.CaCodigoIng)
                .HasMaxLength(8)
                .HasColumnName("CA_CODIGO_ING");
            entity.Property(e => e.CaNombre)
                .HasMaxLength(40)
                .HasColumnName("CA_NOMBRE");
            entity.Property(e => e.CaNombreIng)
                .HasMaxLength(40)
                .HasColumnName("CA_NOMBRE_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TCatCiiu>(entity =>
        {
            entity.HasKey(e => e.CcCodigo).HasName("PRIMARY");

            entity.ToTable("tCatCIIU");

            entity.HasIndex(e => e.CcCodigo, "CC_CODIGO");

            entity.HasIndex(e => e.CcNombre, "CC_NOMBRE");

            entity.Property(e => e.CcCodigo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("CC_CODIGO");
            entity.Property(e => e.CcDescri)
                .HasColumnType("text")
                .HasColumnName("CC_DESCRI");
            entity.Property(e => e.CcNombre)
                .HasMaxLength(250)
                .HasColumnName("CC_NOMBRE");
            entity.Property(e => e.CcNombreIng)
                .HasMaxLength(250)
                .HasColumnName("CC_NOMBRE_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TCiiu>(entity =>
        {
            entity.HasKey(e => e.CiCodigo).HasName("PRIMARY");

            entity.ToTable("tCIIU");

            entity.HasIndex(e => e.CiCodigo, "CI_CODIGO");

            entity.HasIndex(e => e.CiNombre, "CI_NOMBRE");

            entity.Property(e => e.CiCodigo)
                .HasMaxLength(4)
                .HasColumnName("CI_CODIGO");
            entity.Property(e => e.CcCodigo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("CC_CODIGO");
            entity.Property(e => e.CiNombre)
                .HasMaxLength(200)
                .HasColumnName("CI_NOMBRE");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TClaSoc>(entity =>
        {
            entity.HasKey(e => e.CsoCodigo).HasName("PRIMARY");

            entity.ToTable("tClaSoc");

            entity.Property(e => e.CsoCodigo)
                .HasColumnType("int(2)")
                .HasColumnName("CSO_CODIGO");
            entity.Property(e => e.CsoActivo)
                .HasMaxLength(1)
                .HasDefaultValueSql("'1'")
                .HasColumnName("CSO_ACTIVO");
            entity.Property(e => e.CsoNombre)
                .HasMaxLength(50)
                .HasColumnName("CSO_NOMBRE");
            entity.Property(e => e.CsoNombreIng)
                .HasMaxLength(50)
                .HasColumnName("CSO_NOMBRE_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TClasif>(entity =>
        {
            entity.HasKey(e => e.CrCodigo).HasName("PRIMARY");

            entity.ToTable("tClasif");

            entity.HasIndex(e => e.CrCodigo, "CR_CODIGO");

            entity.HasIndex(e => e.CrCodigoIng, "CR_CODIGO_ING");

            entity.HasIndex(e => e.CrNombre, "CR_NOMBRE");

            entity.HasIndex(e => e.CrNombreIng, "CR_NOMBRE_ING");

            entity.HasIndex(e => e.CrOrden, "CR_ORDEN");

            entity.HasIndex(e => e.CrOrdenIng, "CR_ORDEN_ING");

            entity.Property(e => e.CrCodigo)
                .HasMaxLength(4)
                .HasColumnName("CR_CODIGO");
            entity.Property(e => e.CrActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)")
                .HasColumnName("CR_ACTIVO");
            entity.Property(e => e.CrCodigoIng)
                .HasMaxLength(4)
                .HasColumnName("CR_CODIGO_ING");
            entity.Property(e => e.CrNombre)
                .HasMaxLength(85)
                .HasColumnName("CR_NOMBRE");
            entity.Property(e => e.CrNombreIng)
                .HasMaxLength(85)
                .HasColumnName("CR_NOMBRE_ING");
            entity.Property(e => e.CrOrden)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("CR_ORDEN");
            entity.Property(e => e.CrOrdenIng)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("CR_ORDEN_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TComentProv>(entity =>
        {
            entity.HasKey(e => e.CpCodigo).HasName("PRIMARY");

            entity.ToTable("tComentProv");

            entity.Property(e => e.CpCodigo)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .HasColumnName("CP_CODIGO");
            entity.Property(e => e.CpNombre)
                .HasMaxLength(200)
                .HasColumnName("CP_NOMBRE");
            entity.Property(e => e.CpNombreIng)
                .HasMaxLength(200)
                .HasColumnName("CP_NOMBRE_ING");
            entity.Property(e => e.CpOrden)
                .HasColumnType("int(11)")
                .HasColumnName("CP_ORDEN");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TComentProvVario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tComentProv_Varios");

            entity.Property(e => e.CpNombre)
                .HasMaxLength(300)
                .HasColumnName("CP_NOMBRE");
            entity.Property(e => e.CpNombreIng)
                .HasMaxLength(300)
                .HasColumnName("CP_NOMBRE_ING");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TComplemento>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tComplemento");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.Flag)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("FLAG");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.Monto)
                .HasColumnType("double(7,2)")
                .HasColumnName("MONTO");
            entity.Property(e => e.PerCod)
                .HasMaxLength(4)
                .HasColumnName("PER_COD");
        });

        modelBuilder.Entity<TConGen>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tConGen");

            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.TgCodigo)
                .HasMaxLength(4)
                .HasColumnName("tg_codigo");
            entity.Property(e => e.TgDesdtl)
                .HasMaxLength(50)
                .HasColumnName("tg_desdtl");
            entity.Property(e => e.TgDesrdc)
                .HasMaxLength(16)
                .HasColumnName("tg_desrdc");
            entity.Property(e => e.TgDtldes)
                .HasMaxLength(50)
                .HasColumnName("tg_dtldes");
            entity.Property(e => e.TgName)
                .HasMaxLength(50)
                .HasColumnName("tg_name");
            entity.Property(e => e.TgNombre)
                .HasMaxLength(50)
                .HasColumnName("tg_nombre");
            entity.Property(e => e.TgObsGen)
                .HasColumnType("text")
                .HasColumnName("tg_obsGen");
            entity.Property(e => e.TgObsGenIng)
                .HasColumnType("text")
                .HasColumnName("tg_ObsGen_Ing");
            entity.Property(e => e.TgOrden)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("tg_orden");
            entity.Property(e => e.TgRdcdes)
                .HasMaxLength(16)
                .HasColumnName("tg_rdcdes");
        });

        modelBuilder.Entity<TConciliacionDeCuentum>(entity =>
        {
            entity.HasKey(e => e.CdCodigo).HasName("PRIMARY");

            entity.ToTable("tConciliacionDeCuenta");

            entity.Property(e => e.CdCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("CD_CODIGO");
            entity.Property(e => e.CdFaccod)
                .HasMaxLength(15)
                .HasColumnName("CD_FACCOD");
            entity.Property(e => e.CdFacfec)
                .HasColumnType("datetime")
                .HasColumnName("CD_FACFEC");
            entity.Property(e => e.CdFacmon)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("CD_FACMON");
            entity.Property(e => e.CdNombre)
                .HasMaxLength(100)
                .HasColumnName("CD_NOMBRE");
            entity.Property(e => e.CdTipo)
                .HasMaxLength(1)
                .HasColumnName("CD_TIPO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TConclusion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tConclusion");

            entity.Property(e => e.CoCodigo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("CO_CODIGO");
            entity.Property(e => e.CoNombre)
                .HasColumnType("text")
                .HasColumnName("CO_NOMBRE");
            entity.Property(e => e.CoNombreIng)
                .HasColumnType("text")
                .HasColumnName("CO_NOMBRE_ING");
            entity.Property(e => e.CoOrden)
                .HasColumnType("tinyint(2)")
                .HasColumnName("CO_ORDEN");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(2)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TConsulta>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tConsultas");

            entity.Property(e => e.ConFecha1)
                .HasColumnType("datetime")
                .HasColumnName("con_Fecha_1");
            entity.Property(e => e.ConFecha2)
                .HasColumnType("datetime")
                .HasColumnName("con_Fecha_2");
            entity.Property(e => e.ConFecha3)
                .HasColumnType("datetime")
                .HasColumnName("con_Fecha_3");
            entity.Property(e => e.ConId)
                .HasColumnType("int(11)")
                .HasColumnName("con_ID");
            entity.Property(e => e.ConMensaje1)
                .HasMaxLength(500)
                .HasColumnName("con_Mensaje_1");
            entity.Property(e => e.ConMensaje2)
                .HasMaxLength(500)
                .HasColumnName("con_Mensaje_2");
            entity.Property(e => e.ConMensaje3)
                .HasMaxLength(500)
                .HasColumnName("con_Mensaje_3");
            entity.Property(e => e.ConPersonal)
                .HasMaxLength(5)
                .HasColumnName("con_Personal");
            entity.Property(e => e.ConTipo)
                .HasColumnType("tinyint(4)")
                .HasColumnName("con_Tipo");
            entity.Property(e => e.ConUsuario1)
                .HasMaxLength(5)
                .HasColumnName("con_Usuario_1");
            entity.Property(e => e.ConUsuario3)
                .HasMaxLength(5)
                .HasColumnName("con_Usuario_3");
            entity.Property(e => e.Flag).HasColumnType("tinyint(4)");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TConsultasTipo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tConsultas_Tipo");

            entity.Property(e => e.ConNombre)
                .HasMaxLength(50)
                .HasColumnName("con_Nombre");
            entity.Property(e => e.ConTipo)
                .HasColumnType("tinyint(4)")
                .HasColumnName("con_Tipo");
            entity.Property(e => e.Flag).HasColumnType("tinyint(4)");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TContinente>(entity =>
        {
            entity.HasKey(e => e.ConCodigo).HasName("PRIMARY");

            entity.ToTable("tContinente");

            entity.Property(e => e.ConCodigo)
                .HasMaxLength(3)
                .HasColumnName("CON_CODIGO");
            entity.Property(e => e.ConAbrevi)
                .HasMaxLength(4)
                .HasColumnName("CON_ABREVI");
            entity.Property(e => e.ConActivo)
                .HasColumnType("int(1)")
                .HasColumnName("CON_ACTIVO");
            entity.Property(e => e.ConNombre)
                .HasMaxLength(35)
                .HasColumnName("CON_NOMBRE");
            entity.Property(e => e.ConObserv)
                .HasMaxLength(150)
                .HasColumnName("CON_OBSERV");
            entity.Property(e => e.Migra)
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TControlAsignacione>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tControlAsignaciones");

            entity.Property(e => e.Acceso).HasColumnType("int(11)");
            entity.Property(e => e.Codigo).HasColumnType("int(11)");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Flag).HasColumnType("int(11)");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.Usuario).HasMaxLength(20);
        });

        modelBuilder.Entity<TControlCambio>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tControlCambios");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.Opinion).HasMaxLength(4);
        });

        modelBuilder.Entity<TCumplimiento>(entity =>
        {
            entity.HasKey(e => e.CumCodigo).HasName("PRIMARY");

            entity.ToTable("tCumplimiento");

            entity.Property(e => e.CumCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("CUM_CODIGO");
            entity.Property(e => e.CumNombre)
                .HasMaxLength(50)
                .HasColumnName("CUM_NOMBRE");
            entity.Property(e => e.CumNombreIng)
                .HasMaxLength(50)
                .HasColumnName("CUM_NOMBRE_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.TgDesrdc)
                .HasMaxLength(16)
                .HasColumnName("tg_desrdc");
            entity.Property(e => e.TgObsGen)
                .HasColumnType("text")
                .HasColumnName("tg_obsGen");
            entity.Property(e => e.TgObsGenIng)
                .HasColumnType("text")
                .HasColumnName("tg_ObsGen_Ing");
            entity.Property(e => e.TgRdcdes)
                .HasMaxLength(16)
                .HasColumnName("tg_rdcdes");
        });

        modelBuilder.Entity<TCupon>(entity =>
        {
            entity.HasKey(e => e.CupCodigo).HasName("PRIMARY");

            entity.ToTable("tCupon");

            entity.Property(e => e.CupCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("cup_codigo");
            entity.Property(e => e.Aaa)
                .HasMaxLength(4000)
                .HasDefaultValueSql("''")
                .HasColumnName("AAA");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.Age)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Balance)
                .HasMaxLength(2)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalAge)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalCodigo)
                .HasMaxLength(3)
                .HasColumnName("CAL_CODIGO");
            entity.Property(e => e.CalDig)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalRep)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalTra)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CupActivo)
                .HasColumnType("int(1)")
                .HasColumnName("CUP_ACTIVO");
            entity.Property(e => e.CupCiudad)
                .HasMaxLength(50)
                .HasColumnName("CUP_CIUDAD");
            entity.Property(e => e.CupCodpos)
                .HasMaxLength(25)
                .HasColumnName("CUP_CODPOS");
            entity.Property(e => e.CupContac)
                .HasMaxLength(100)
                .HasColumnName("CUP_CONTAC");
            entity.Property(e => e.CupDepart)
                .HasMaxLength(100)
                .HasColumnName("CUP_DEPART");
            entity.Property(e => e.CupDirecc)
                .HasMaxLength(400)
                .HasColumnName("CUP_DIRECC");
            entity.Property(e => e.CupEstado)
                .HasMaxLength(2)
                .HasColumnName("CUP_ESTADO");
            entity.Property(e => e.CupFax)
                .HasMaxLength(100)
                .HasColumnName("CUP_FAX");
            entity.Property(e => e.CupFecdes)
                .HasColumnType("datetime")
                .HasColumnName("CUP_FECDES");
            entity.Property(e => e.CupFecped)
                .HasColumnType("datetime")
                .HasColumnName("CUP_FECPED");
            entity.Property(e => e.CupFecvcto)
                .HasColumnType("datetime")
                .HasColumnName("CUP_FECVCTO");
            entity.Property(e => e.CupGasadm)
                .HasColumnType("double(10,3)")
                .HasColumnName("CUP_GASADM");
            entity.Property(e => e.CupMoncon)
                .HasMaxLength(25)
                .HasColumnName("CUP_MONCON");
            entity.Property(e => e.CupMonto)
                .HasColumnType("double(10,2)")
                .HasColumnName("CUP_MONTO");
            entity.Property(e => e.CupMoteli)
                .HasMaxLength(2000)
                .HasColumnName("CUP_MOTELI");
            entity.Property(e => e.CupNomdes)
                .HasMaxLength(150)
                .HasColumnName("CUP_NOMDES");
            entity.Property(e => e.CupNomsol)
                .HasMaxLength(150)
                .HasColumnName("CUP_NOMSOL");
            entity.Property(e => e.CupNroord)
                .HasMaxLength(20)
                .HasColumnName("CUP_NROORD");
            entity.Property(e => e.CupObserv)
                .HasMaxLength(2000)
                .HasColumnName("CUP_OBSERV");
            entity.Property(e => e.CupObtbal)
                .HasMaxLength(2)
                .HasColumnName("CUP_OBTBAL");
            entity.Property(e => e.CupOpicred)
                .HasMaxLength(800)
                .HasColumnName("CUP_OPICRED");
            entity.Property(e => e.CupPlazos)
                .HasMaxLength(20)
                .HasColumnName("CUP_PLAZOS");
            entity.Property(e => e.CupRecome)
                .HasMaxLength(1000)
                .HasColumnName("CUP_RECOME");
            entity.Property(e => e.CupRefabo)
                .HasMaxLength(80)
                .HasColumnName("CUP_REFABO");
            entity.Property(e => e.CupRefere)
                .HasMaxLength(2000)
                .HasColumnName("CUP_REFERE");
            entity.Property(e => e.CupRegtrib)
                .HasMaxLength(40)
                .HasColumnName("CUP_REGTRIB");
            entity.Property(e => e.CupRevnom)
                .HasMaxLength(80)
                .HasColumnName("CUP_REVNOM");
            entity.Property(e => e.CupSiglas)
                .HasMaxLength(100)
                .HasColumnName("CUP_SIGLAS");
            entity.Property(e => e.CupTelefo)
                .HasMaxLength(100)
                .HasColumnName("CUP_TELEFO");
            entity.Property(e => e.CupTipdes)
                .HasMaxLength(2)
                .HasComment("Tipo de informe (Tipo A,B, Rubro 1, Rubro 2, 3,4)")
                .HasColumnName("CUP_TIPDES");
            entity.Property(e => e.CupTipinf)
                .HasMaxLength(30)
                .HasColumnName("CUP_TIPINF");
            entity.Property(e => e.CupTraduc)
                .HasMaxLength(1)
                .HasColumnName("CUP_TRADUC");
            entity.Property(e => e.CupUsueli)
                .HasMaxLength(50)
                .HasComment("Usuario que elimina")
                .HasColumnName("CUP_USUELI");
            entity.Property(e => e.Dig)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.EmpPer)
                .HasMaxLength(1)
                .HasColumnName("Emp_Per");
            entity.Property(e => e.EpCodigo)
                .HasMaxLength(11)
                .HasColumnName("EP_CODIGO");
            entity.Property(e => e.Flag)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.IdiCodigo)
                .HasMaxLength(3)
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("PER_CODIGO");
            entity.Property(e => e.PreRegtrib)
                .HasMaxLength(7)
                .HasComment("Prefijo del REG. TRIB")
                .HasColumnName("PRE_REGTRIB");
            entity.Property(e => e.PrecioAgente)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Agente");
            entity.Property(e => e.PrecioDigitadora)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Digitadora");
            entity.Property(e => e.PrecioReportero)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Reportero");
            entity.Property(e => e.PrecioTraductora)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Traductora");
            entity.Property(e => e.Rep)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Tra)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TramCodigo)
                .HasMaxLength(2)
                .HasColumnName("TRAM_CODIGO");
        });

        modelBuilder.Entity<TCupon2>(entity =>
        {
            entity.HasKey(e => e.CupCodigo).HasName("PRIMARY");

            entity.ToTable("tCupon_2");

            entity.Property(e => e.CupCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("cup_codigo");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.Age)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Balance)
                .HasMaxLength(2)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalAge)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalCodigo)
                .HasMaxLength(3)
                .HasColumnName("CAL_CODIGO");
            entity.Property(e => e.CalDig)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalRep)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalTra)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CupActivo)
                .HasColumnType("int(1)")
                .HasColumnName("CUP_ACTIVO");
            entity.Property(e => e.CupCiudad)
                .HasMaxLength(50)
                .HasColumnName("CUP_CIUDAD");
            entity.Property(e => e.CupCodpos)
                .HasMaxLength(25)
                .HasColumnName("CUP_CODPOS");
            entity.Property(e => e.CupContac)
                .HasMaxLength(100)
                .HasColumnName("CUP_CONTAC");
            entity.Property(e => e.CupDepart)
                .HasMaxLength(100)
                .HasColumnName("CUP_DEPART");
            entity.Property(e => e.CupDirecc)
                .HasMaxLength(400)
                .HasColumnName("CUP_DIRECC");
            entity.Property(e => e.CupEstado)
                .HasMaxLength(2)
                .HasColumnName("CUP_ESTADO");
            entity.Property(e => e.CupFax)
                .HasMaxLength(100)
                .HasColumnName("CUP_FAX");
            entity.Property(e => e.CupFecdes)
                .HasColumnType("datetime")
                .HasColumnName("CUP_FECDES");
            entity.Property(e => e.CupFecped)
                .HasColumnType("datetime")
                .HasColumnName("CUP_FECPED");
            entity.Property(e => e.CupFecvcto)
                .HasColumnType("datetime")
                .HasColumnName("CUP_FECVCTO");
            entity.Property(e => e.CupGasadm)
                .HasColumnType("double(10,3)")
                .HasColumnName("CUP_GASADM");
            entity.Property(e => e.CupMoncon)
                .HasMaxLength(25)
                .HasColumnName("CUP_MONCON");
            entity.Property(e => e.CupMonto)
                .HasColumnType("double(10,2)")
                .HasColumnName("CUP_MONTO");
            entity.Property(e => e.CupMoteli)
                .HasMaxLength(2000)
                .HasColumnName("CUP_MOTELI");
            entity.Property(e => e.CupNomdes)
                .HasMaxLength(150)
                .HasColumnName("CUP_NOMDES");
            entity.Property(e => e.CupNomsol)
                .HasMaxLength(150)
                .HasColumnName("CUP_NOMSOL");
            entity.Property(e => e.CupNroord)
                .HasMaxLength(20)
                .HasColumnName("CUP_NROORD");
            entity.Property(e => e.CupObserv)
                .HasMaxLength(2000)
                .HasColumnName("CUP_OBSERV");
            entity.Property(e => e.CupObtbal)
                .HasMaxLength(2)
                .HasColumnName("CUP_OBTBAL");
            entity.Property(e => e.CupOpicred)
                .HasMaxLength(800)
                .HasColumnName("CUP_OPICRED");
            entity.Property(e => e.CupPlazos)
                .HasMaxLength(20)
                .HasColumnName("CUP_PLAZOS");
            entity.Property(e => e.CupRecome)
                .HasMaxLength(1000)
                .HasColumnName("CUP_RECOME");
            entity.Property(e => e.CupRefabo)
                .HasMaxLength(80)
                .HasColumnName("CUP_REFABO");
            entity.Property(e => e.CupRefere)
                .HasMaxLength(2000)
                .HasColumnName("CUP_REFERE");
            entity.Property(e => e.CupRegtrib)
                .HasMaxLength(40)
                .HasColumnName("CUP_REGTRIB");
            entity.Property(e => e.CupRevnom)
                .HasMaxLength(80)
                .HasColumnName("CUP_REVNOM");
            entity.Property(e => e.CupSiglas)
                .HasMaxLength(100)
                .HasColumnName("CUP_SIGLAS");
            entity.Property(e => e.CupTelefo)
                .HasMaxLength(100)
                .HasColumnName("CUP_TELEFO");
            entity.Property(e => e.CupTipdes)
                .HasMaxLength(2)
                .HasComment("Tipo de informe (Tipo A,B, Rubro 1, Rubro 2, 3,4)")
                .HasColumnName("CUP_TIPDES");
            entity.Property(e => e.CupTipinf)
                .HasMaxLength(30)
                .HasColumnName("CUP_TIPINF");
            entity.Property(e => e.CupTraduc)
                .HasMaxLength(1)
                .HasColumnName("CUP_TRADUC");
            entity.Property(e => e.CupUsueli)
                .HasMaxLength(50)
                .HasComment("Usuario que elimina")
                .HasColumnName("CUP_USUELI");
            entity.Property(e => e.Dig)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.EmpPer)
                .HasMaxLength(1)
                .HasColumnName("Emp_Per");
            entity.Property(e => e.EpCodigo)
                .HasMaxLength(11)
                .HasColumnName("EP_CODIGO");
            entity.Property(e => e.Flag)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.IdiCodigo)
                .HasMaxLength(3)
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("PER_CODIGO");
            entity.Property(e => e.PreRegtrib)
                .HasMaxLength(7)
                .HasComment("Prefijo del REG. TRIB")
                .HasColumnName("PRE_REGTRIB");
            entity.Property(e => e.PrecioAgente)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Agente");
            entity.Property(e => e.PrecioDigitadora)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Digitadora");
            entity.Property(e => e.PrecioReportero)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Reportero");
            entity.Property(e => e.PrecioTraductora)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Traductora");
            entity.Property(e => e.Rep)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Tra)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TramCodigo)
                .HasMaxLength(2)
                .HasColumnName("TRAM_CODIGO");
        });

        modelBuilder.Entity<TCupon3>(entity =>
        {
            entity.HasKey(e => e.CupCodigo).HasName("PRIMARY");

            entity.ToTable("tCupon_3");

            entity.Property(e => e.CupCodigo)
                .HasColumnType("bigint(20)")
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.Age)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Balance)
                .HasMaxLength(2)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalAge)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalCodigo)
                .HasMaxLength(3)
                .HasColumnName("CAL_CODIGO");
            entity.Property(e => e.CalDig)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalRep)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalTra)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CupActivo)
                .HasColumnType("int(1)")
                .HasColumnName("CUP_ACTIVO");
            entity.Property(e => e.CupCiudad)
                .HasMaxLength(50)
                .HasColumnName("CUP_CIUDAD");
            entity.Property(e => e.CupCodpos)
                .HasMaxLength(25)
                .HasColumnName("CUP_CODPOS");
            entity.Property(e => e.CupContac)
                .HasMaxLength(100)
                .HasColumnName("CUP_CONTAC");
            entity.Property(e => e.CupDepart)
                .HasMaxLength(100)
                .HasColumnName("CUP_DEPART");
            entity.Property(e => e.CupDirecc)
                .HasMaxLength(400)
                .HasColumnName("CUP_DIRECC");
            entity.Property(e => e.CupEstado)
                .HasMaxLength(2)
                .HasColumnName("CUP_ESTADO");
            entity.Property(e => e.CupFax)
                .HasMaxLength(100)
                .HasColumnName("CUP_FAX");
            entity.Property(e => e.CupFecdes)
                .HasColumnType("datetime")
                .HasColumnName("CUP_FECDES");
            entity.Property(e => e.CupFecped)
                .HasColumnType("datetime")
                .HasColumnName("CUP_FECPED");
            entity.Property(e => e.CupFecvcto)
                .HasColumnType("datetime")
                .HasColumnName("CUP_FECVCTO");
            entity.Property(e => e.CupGasadm)
                .HasColumnType("double(10,3)")
                .HasColumnName("CUP_GASADM");
            entity.Property(e => e.CupMoncon)
                .HasMaxLength(25)
                .HasColumnName("CUP_MONCON");
            entity.Property(e => e.CupMonto)
                .HasColumnType("double(10,2)")
                .HasColumnName("CUP_MONTO");
            entity.Property(e => e.CupMoteli)
                .HasMaxLength(2000)
                .HasColumnName("CUP_MOTELI");
            entity.Property(e => e.CupNomdes)
                .HasMaxLength(150)
                .HasColumnName("CUP_NOMDES");
            entity.Property(e => e.CupNomsol)
                .HasMaxLength(150)
                .HasColumnName("CUP_NOMSOL");
            entity.Property(e => e.CupNroord)
                .HasMaxLength(20)
                .HasColumnName("CUP_NROORD");
            entity.Property(e => e.CupObserv)
                .HasMaxLength(2000)
                .HasColumnName("CUP_OBSERV");
            entity.Property(e => e.CupObtbal)
                .HasMaxLength(2)
                .HasColumnName("CUP_OBTBAL");
            entity.Property(e => e.CupOpicred)
                .HasMaxLength(800)
                .HasColumnName("CUP_OPICRED");
            entity.Property(e => e.CupPlazos)
                .HasMaxLength(20)
                .HasColumnName("CUP_PLAZOS");
            entity.Property(e => e.CupRecome)
                .HasMaxLength(1000)
                .HasColumnName("CUP_RECOME");
            entity.Property(e => e.CupRefabo)
                .HasMaxLength(80)
                .HasColumnName("CUP_REFABO");
            entity.Property(e => e.CupRefere)
                .HasMaxLength(2000)
                .HasColumnName("CUP_REFERE");
            entity.Property(e => e.CupRegtrib)
                .HasMaxLength(40)
                .HasColumnName("CUP_REGTRIB");
            entity.Property(e => e.CupRevnom)
                .HasMaxLength(80)
                .HasColumnName("CUP_REVNOM");
            entity.Property(e => e.CupSiglas)
                .HasMaxLength(100)
                .HasColumnName("CUP_SIGLAS");
            entity.Property(e => e.CupTelefo)
                .HasMaxLength(100)
                .HasColumnName("CUP_TELEFO");
            entity.Property(e => e.CupTipdes)
                .HasMaxLength(2)
                .HasComment("Tipo de informe (Tipo A,B, Rubro 1, Rubro 2, 3,4)")
                .HasColumnName("CUP_TIPDES");
            entity.Property(e => e.CupTipinf)
                .HasMaxLength(30)
                .HasColumnName("CUP_TIPINF");
            entity.Property(e => e.CupTraduc)
                .HasMaxLength(1)
                .HasColumnName("CUP_TRADUC");
            entity.Property(e => e.CupUsueli)
                .HasMaxLength(50)
                .HasComment("Usuario que elimina")
                .HasColumnName("CUP_USUELI");
            entity.Property(e => e.Dig)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.EmpPer)
                .HasMaxLength(1)
                .HasColumnName("Emp_Per");
            entity.Property(e => e.EpCodigo)
                .HasMaxLength(11)
                .HasColumnName("EP_CODIGO");
            entity.Property(e => e.Flag)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.IdiCodigo)
                .HasMaxLength(3)
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("PER_CODIGO");
            entity.Property(e => e.PreRegtrib)
                .HasMaxLength(7)
                .HasComment("Prefijo del REG. TRIB")
                .HasColumnName("PRE_REGTRIB");
            entity.Property(e => e.PrecioAgente)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Agente");
            entity.Property(e => e.PrecioDigitadora)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Digitadora");
            entity.Property(e => e.PrecioReportero)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Reportero");
            entity.Property(e => e.PrecioTraductora)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Traductora");
            entity.Property(e => e.Rep)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Tra)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TramCodigo)
                .HasMaxLength(2)
                .HasColumnName("TRAM_CODIGO");
        });

        modelBuilder.Entity<TCuponDatoAdicional>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tCuponDatoAdicional");

            entity.HasIndex(e => e.EmCodigo, "EM_CODIGO");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EmCorreo)
                .HasMaxLength(100)
                .HasColumnName("EM_CORREO");
            entity.Property(e => e.EmFax)
                .HasMaxLength(100)
                .HasColumnName("EM_FAX");
            entity.Property(e => e.EmTelefono)
                .HasMaxLength(100)
                .HasColumnName("EM_TELEFONO");
            entity.Property(e => e.Migra)
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TCuponTiendum>(entity =>
        {
            entity.HasKey(e => e.CupCodigo).HasName("PRIMARY");

            entity.ToTable("tCupon_Tienda");

            entity.Property(e => e.CupCodigo)
                .HasColumnType("bigint(20)")
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.Age)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Balance)
                .HasMaxLength(2)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalAge)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalCodigo)
                .HasMaxLength(3)
                .HasColumnName("CAL_CODIGO");
            entity.Property(e => e.CalDig)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalRep)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CalTra)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.CliCodigo)
                .HasMaxLength(8)
                .HasColumnName("CLI_CODIGO");
            entity.Property(e => e.CupActivo)
                .HasColumnType("int(1)")
                .HasColumnName("CUP_ACTIVO");
            entity.Property(e => e.CupCiudad)
                .HasMaxLength(50)
                .HasColumnName("CUP_CIUDAD");
            entity.Property(e => e.CupCodpos)
                .HasMaxLength(25)
                .HasColumnName("CUP_CODPOS");
            entity.Property(e => e.CupContac)
                .HasMaxLength(100)
                .HasColumnName("CUP_CONTAC");
            entity.Property(e => e.CupDepart)
                .HasMaxLength(100)
                .HasColumnName("CUP_DEPART");
            entity.Property(e => e.CupDirecc)
                .HasMaxLength(400)
                .HasColumnName("CUP_DIRECC");
            entity.Property(e => e.CupEstado)
                .HasMaxLength(2)
                .HasColumnName("CUP_ESTADO");
            entity.Property(e => e.CupFax)
                .HasMaxLength(100)
                .HasColumnName("CUP_FAX");
            entity.Property(e => e.CupFecdes)
                .HasColumnType("datetime")
                .HasColumnName("CUP_FECDES");
            entity.Property(e => e.CupFecped)
                .HasColumnType("datetime")
                .HasColumnName("CUP_FECPED");
            entity.Property(e => e.CupFecvcto)
                .HasColumnType("datetime")
                .HasColumnName("CUP_FECVCTO");
            entity.Property(e => e.CupGasadm)
                .HasColumnType("double(10,3)")
                .HasColumnName("CUP_GASADM");
            entity.Property(e => e.CupMoncon)
                .HasMaxLength(25)
                .HasColumnName("CUP_MONCON");
            entity.Property(e => e.CupMonto)
                .HasColumnType("double(10,2)")
                .HasColumnName("CUP_MONTO");
            entity.Property(e => e.CupMoteli)
                .HasMaxLength(2000)
                .HasColumnName("CUP_MOTELI");
            entity.Property(e => e.CupNomdes)
                .HasMaxLength(150)
                .HasColumnName("CUP_NOMDES");
            entity.Property(e => e.CupNomsol)
                .HasMaxLength(150)
                .HasColumnName("CUP_NOMSOL");
            entity.Property(e => e.CupNroord)
                .HasMaxLength(20)
                .HasColumnName("CUP_NROORD");
            entity.Property(e => e.CupObserv)
                .HasMaxLength(2000)
                .HasColumnName("CUP_OBSERV");
            entity.Property(e => e.CupObtbal)
                .HasMaxLength(2)
                .HasColumnName("CUP_OBTBAL");
            entity.Property(e => e.CupOpicred)
                .HasMaxLength(800)
                .HasColumnName("CUP_OPICRED");
            entity.Property(e => e.CupPlazos)
                .HasMaxLength(20)
                .HasColumnName("CUP_PLAZOS");
            entity.Property(e => e.CupRecome)
                .HasMaxLength(1000)
                .HasColumnName("CUP_RECOME");
            entity.Property(e => e.CupRefabo)
                .HasMaxLength(80)
                .HasColumnName("CUP_REFABO");
            entity.Property(e => e.CupRefere)
                .HasMaxLength(2000)
                .HasColumnName("CUP_REFERE");
            entity.Property(e => e.CupRegtrib)
                .HasMaxLength(40)
                .HasColumnName("CUP_REGTRIB");
            entity.Property(e => e.CupRevnom)
                .HasMaxLength(80)
                .HasColumnName("CUP_REVNOM");
            entity.Property(e => e.CupSiglas)
                .HasMaxLength(100)
                .HasColumnName("CUP_SIGLAS");
            entity.Property(e => e.CupTelefo)
                .HasMaxLength(100)
                .HasColumnName("CUP_TELEFO");
            entity.Property(e => e.CupTipdes)
                .HasMaxLength(2)
                .HasComment("Tipo de informe (Tipo A,B, Rubro 1, Rubro 2, 3,4)")
                .HasColumnName("CUP_TIPDES");
            entity.Property(e => e.CupTipinf)
                .HasMaxLength(30)
                .HasColumnName("CUP_TIPINF");
            entity.Property(e => e.CupTraduc)
                .HasMaxLength(1)
                .HasColumnName("CUP_TRADUC");
            entity.Property(e => e.CupUsueli)
                .HasMaxLength(50)
                .HasComment("Usuario que elimina")
                .HasColumnName("CUP_USUELI");
            entity.Property(e => e.Dig)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.EmpPer)
                .HasMaxLength(1)
                .HasColumnName("Emp_Per");
            entity.Property(e => e.EpCodigo)
                .HasMaxLength(11)
                .HasColumnName("EP_CODIGO");
            entity.Property(e => e.Flag)
                .HasMaxLength(1)
                .HasDefaultValueSql("''");
            entity.Property(e => e.IdiCodigo)
                .HasMaxLength(3)
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("PER_CODIGO");
            entity.Property(e => e.PreRegtrib)
                .HasMaxLength(7)
                .HasComment("Prefijo del REG. TRIB")
                .HasColumnName("PRE_REGTRIB");
            entity.Property(e => e.PrecioAgente)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Agente");
            entity.Property(e => e.PrecioDigitadora)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Digitadora");
            entity.Property(e => e.PrecioReportero)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Reportero");
            entity.Property(e => e.PrecioTraductora)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Traductora");
            entity.Property(e => e.Rep)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Tra)
                .HasMaxLength(4)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TramCodigo)
                .HasMaxLength(2)
                .HasColumnName("TRAM_CODIGO");
        });

        modelBuilder.Entity<TDetEmpAval>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tDetEmpAval");

            entity.HasIndex(e => e.AvCodigo, "AV_CODIGO");

            entity.HasIndex(e => e.EmCodigo, "EM_CODIGO");

            entity.Property(e => e.AvCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("AV_CODIGO");
            entity.Property(e => e.AvEntidad)
                .HasMaxLength(200)
                .HasColumnName("AV_ENTIDAD");
            entity.Property(e => e.AvFecha)
                .HasColumnType("date")
                .HasColumnName("AV_FECHA");
            entity.Property(e => e.AvMontomn).HasColumnName("AV_MONTOMN");
            entity.Property(e => e.AvMontousd).HasColumnName("AV_MONTOUSD");
            entity.Property(e => e.AvNombre)
                .HasMaxLength(200)
                .HasColumnName("AV_NOMBRE");
            entity.Property(e => e.AvRuc)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("AV_RUC");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TDetFactAbonado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tDetFactAbonado");

            entity.HasIndex(e => e.FacCodigo, "cia_DetFactAbonado_index01");

            entity.HasIndex(e => e.CupCodigo, "cia_DetFactVenta_ibfk_1");

            entity.Property(e => e.CupCodigo)
                .HasMaxLength(20)
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.CupMonto)
                .HasColumnType("double(10,3)")
                .HasColumnName("CUP_MONTO");
            entity.Property(e => e.FacCodigo)
                .HasMaxLength(15)
                .HasColumnName("FAC_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TDetFactAgente>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tDetFactAgente");

            entity.HasIndex(e => e.FacCodigo, "cia_DetFactAgente_index01");

            entity.HasIndex(e => e.CupCodigo, "cia_DetFactAgente_index02");

            entity.Property(e => e.AgMonto)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("double(10,3)")
                .HasColumnName("AG_MONTO");
            entity.Property(e => e.CupCodigo)
                .HasColumnType("bigint(20)")
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.FacCodigo)
                .HasMaxLength(15)
                .HasColumnName("FAC_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TDetObservacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tDetObservacion");

            entity.HasIndex(e => e.ObCodigo, "OB_CODIGO");

            entity.HasIndex(e => e.PerCodigo, "PER_CODIGO");

            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.ObCodigo)
                .HasColumnType("bigint(20)")
                .HasColumnName("OB_CODIGO");
            entity.Property(e => e.ObComent)
                .HasMaxLength(200)
                .HasColumnName("OB_COMENT");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("PER_CODIGO");
        });

        modelBuilder.Entity<TDireccion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tDireccion");

            entity.Property(e => e.DiCodigo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("DI_CODIGO");
            entity.Property(e => e.DiNombre)
                .HasColumnType("text")
                .HasColumnName("DI_NOMBRE");
            entity.Property(e => e.DiNombreIng)
                .HasColumnType("text")
                .HasColumnName("DI_NOMBRE_ING");
            entity.Property(e => e.DiOrden)
                .HasColumnType("tinyint(2)")
                .HasColumnName("DI_ORDEN");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(2)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TEmpresaExc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tEmpresaExc");

            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasColumnName("nombre");
            entity.Property(e => e.PaisCod)
                .HasMaxLength(3)
                .HasColumnName("pais_cod");
            entity.Property(e => e.PaisNom)
                .HasMaxLength(3)
                .HasColumnName("pais_nom");
            entity.Property(e => e.Ruc)
                .HasMaxLength(50)
                .HasColumnName("ruc");
        });

        modelBuilder.Entity<TEmpresaTipoB>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tEmpresaTipoB");

            entity.Property(e => e.AboNombre)
                .HasMaxLength(100)
                .HasColumnName("ABO_NOMBRE");
            entity.Property(e => e.BaFecbal1)
                .HasMaxLength(100)
                .HasColumnName("BA_FECBAL1");
            entity.Property(e => e.BaMoneda1)
                .HasMaxLength(100)
                .HasColumnName("BA_MONEDA1");
            entity.Property(e => e.BaTipcam1).HasColumnName("BA_TIPCAM1");
            entity.Property(e => e.BaTotact1)
                .HasMaxLength(255)
                .HasColumnName("BA_TOTACT1");
            entity.Property(e => e.BaTotpat1)
                .HasMaxLength(255)
                .HasColumnName("BA_TOTPAT1");
            entity.Property(e => e.BaUtiper)
                .HasMaxLength(255)
                .HasColumnName("BA_UTIPER");
            entity.Property(e => e.CrCodigo)
                .HasMaxLength(100)
                .HasColumnName("CR_CODIGO");
            entity.Property(e => e.CrNombre)
                .HasMaxLength(100)
                .HasColumnName("CR_NOMBRE");
            entity.Property(e => e.EmActivi)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_ACTIVI");
            entity.Property(e => e.EmAnofun)
                .HasMaxLength(100)
                .HasColumnName("EM_ANOFUN");
            entity.Property(e => e.EmAntcre)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_ANTCRE");
            entity.Property(e => e.EmArea)
                .HasMaxLength(100)
                .HasColumnName("EM_AREA");
            entity.Property(e => e.EmBanco)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_BANCO");
            entity.Property(e => e.EmCalsbs)
                .HasMaxLength(255)
                .HasColumnName("EM_CALSBS");
            entity.Property(e => e.EmCapac1)
                .HasMaxLength(100)
                .HasColumnName("EM_CAPAC1");
            entity.Property(e => e.EmCenrie)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_CENRIE");
            entity.Property(e => e.EmCiiu)
                .HasMaxLength(255)
                .HasColumnName("EM_CIIU");
            entity.Property(e => e.EmCiudad)
                .HasMaxLength(100)
                .HasColumnName("EM_CIUDAD");
            entity.Property(e => e.EmCodpos)
                .HasMaxLength(100)
                .HasColumnName("EM_CODPOS");
            entity.Property(e => e.EmDepart)
                .HasMaxLength(100)
                .HasColumnName("EM_DEPART");
            entity.Property(e => e.EmDirecc)
                .HasMaxLength(200)
                .HasColumnName("EM_DIRECC");
            entity.Property(e => e.EmFax)
                .HasMaxLength(100)
                .HasColumnName("EM_FAX");
            entity.Property(e => e.EmFecinf)
                .HasColumnType("datetime")
                .HasColumnName("EM_FECINF");
            entity.Property(e => e.EmInfgen)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_INFGEN");
            entity.Property(e => e.EmLocal)
                .HasMaxLength(100)
                .HasColumnName("EM_LOCAL");
            entity.Property(e => e.EmLogexp)
                .HasMaxLength(3)
                .HasColumnName("EM_LOGEXP");
            entity.Property(e => e.EmLogimp)
                .HasMaxLength(3)
                .HasColumnName("EM_LOGIMP");
            entity.Property(e => e.EmNombre)
                .HasMaxLength(100)
                .HasColumnName("EM_NOMBRE");
            entity.Property(e => e.EmPagweb)
                .HasMaxLength(100)
                .HasColumnName("EM_PAGWEB");
            entity.Property(e => e.EmPresid)
                .HasMaxLength(200)
                .HasColumnName("EM_PRESID");
            entity.Property(e => e.EmPrffax)
                .HasMaxLength(100)
                .HasColumnName("EM_PRFFAX");
            entity.Property(e => e.EmPrftel)
                .HasMaxLength(100)
                .HasColumnName("EM_PRFTEL");
            entity.Property(e => e.EmPrinci)
                .HasMaxLength(200)
                .HasColumnName("EM_PRINCI");
            entity.Property(e => e.EmRegist)
                .HasMaxLength(100)
                .HasColumnName("EM_REGIST");
            entity.Property(e => e.EmRegtri)
                .HasMaxLength(100)
                .HasColumnName("EM_REGTRI");
            entity.Property(e => e.EmSiglas)
                .HasMaxLength(100)
                .HasColumnName("EM_SIGLAS");
            entity.Property(e => e.EmSupban)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_SUPBAN");
            entity.Property(e => e.EmTelefo)
                .HasMaxLength(100)
                .HasColumnName("EM_TELEFO");
            entity.Property(e => e.EmTrabaj)
                .HasMaxLength(100)
                .HasColumnName("EM_TRABAJ");
            entity.Property(e => e.EmValor)
                .HasMaxLength(100)
                .HasColumnName("EM_VALOR");
            entity.Property(e => e.EmVentas)
                .HasMaxLength(255)
                .HasColumnName("EM_VENTAS");
            entity.Property(e => e.JuNombre)
                .HasMaxLength(100)
                .HasColumnName("JU_NOMBRE");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaCodigo)
                .HasMaxLength(100)
                .HasColumnName("PA_CODIGO");
            entity.Property(e => e.PaNombre)
                .HasMaxLength(100)
                .HasColumnName("PA_NOMBRE");
            entity.Property(e => e.PaiNombre)
                .HasMaxLength(45)
                .HasColumnName("PAI_NOMBRE");
            entity.Property(e => e.SfNombre)
                .HasColumnType("mediumtext")
                .HasColumnName("SF_NOMBRE");
            entity.Property(e => e.SitNombre)
                .HasMaxLength(50)
                .HasColumnName("SIT_NOMBRE");
            entity.Property(e => e.Situacion)
                .HasColumnType("mediumtext")
                .HasColumnName("SITUACION");
            entity.Property(e => e.TdCodigo)
                .HasMaxLength(100)
                .HasColumnName("TD_CODIGO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<TEstCiv>(entity =>
        {
            entity.HasKey(e => e.EcCodigo).HasName("PRIMARY");

            entity.ToTable("tEstCiv");

            entity.Property(e => e.EcCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("EC_CODIGO");
            entity.Property(e => e.EcNombre)
                .HasMaxLength(20)
                .HasColumnName("EC_NOMBRE");
            entity.Property(e => e.EcNombreIng)
                .HasMaxLength(20)
                .HasColumnName("EC_NOMBRE_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TEstLitigio>(entity =>
        {
            entity.HasKey(e => e.ElCodigo).HasName("PRIMARY");

            entity.ToTable("tEstLitigio");

            entity.Property(e => e.ElCodigo)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .HasColumnName("EL_CODIGO");
            entity.Property(e => e.ElDescri)
                .HasMaxLength(10)
                .HasColumnName("EL_DESCRI");
            entity.Property(e => e.ElDescriIng)
                .HasMaxLength(10)
                .HasColumnName("EL_DESCRI_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TEstOpiCred>(entity =>
        {
            entity.HasKey(e => e.OcCodigo).HasName("PRIMARY");

            entity.ToTable("tEstOpiCred", tb => tb.HasComment("Estado de Opinion de Credito"));

            entity.Property(e => e.OcCodigo)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("OC_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.OcDescri)
                .HasMaxLength(400)
                .HasColumnName("OC_DESCRI");
            entity.Property(e => e.OcDescriIng)
                .HasMaxLength(400)
                .HasColumnName("OC_DESCRI_ING");
            entity.Property(e => e.OcOrden)
                .HasColumnType("int(2)")
                .HasColumnName("OC_ORDEN");
        });

        modelBuilder.Entity<TEstPer>(entity =>
        {
            entity.HasKey(e => e.EsCodigo).HasName("PRIMARY");

            entity.ToTable("tEstPer");

            entity.Property(e => e.EsCodigo)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("ES_CODIGO");
            entity.Property(e => e.EsNombre)
                .HasMaxLength(50)
                .HasColumnName("ES_NOMBRE");
            entity.Property(e => e.EsNombreIng)
                .HasMaxLength(50)
                .HasColumnName("ES_NOMBRE_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TEstRegTribPer>(entity =>
        {
            entity.HasKey(e => e.ErCodigo).HasName("PRIMARY");

            entity.ToTable("tEstRegTribPer");

            entity.Property(e => e.ErCodigo)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("ER_CODIGO");
            entity.Property(e => e.ErNombre)
                .HasMaxLength(50)
                .HasColumnName("ER_NOMBRE");
            entity.Property(e => e.ErNombreIng)
                .HasMaxLength(50)
                .HasColumnName("ER_NOMBRE_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TEstado>(entity =>
        {
            entity.HasKey(e => e.EstCodigo).HasName("PRIMARY");

            entity.ToTable("tEstado");

            entity.Property(e => e.EstCodigo)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .HasColumnName("EST_CODIGO");
            entity.Property(e => e.EstEstado).HasColumnName("EST_ESTADO");
            entity.Property(e => e.EstNombre)
                .HasMaxLength(20)
                .HasColumnName("EST_NOMBRE");
            entity.Property(e => e.EstNombreIng)
                .HasMaxLength(20)
                .HasColumnName("EST_NOMBRE_ING");
            entity.Property(e => e.EstOrden)
                .HasColumnType("int(10)")
                .HasColumnName("EST_ORDEN");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TEstadoCupon>(entity =>
        {
            entity.HasKey(e => e.EcCodigo).HasName("PRIMARY");

            entity.ToTable("tEstadoCupon");

            entity.Property(e => e.EcCodigo)
                .HasMaxLength(3)
                .HasColumnName("EC_CODIGO");
            entity.Property(e => e.EcAbrevi)
                .HasMaxLength(4)
                .HasColumnName("EC_ABREVI");
            entity.Property(e => e.EcActivo).HasColumnName("EC_ACTIVO");
            entity.Property(e => e.EcNombre)
                .HasMaxLength(70)
                .HasColumnName("EC_NOMBRE");
            entity.Property(e => e.EcObserv)
                .HasMaxLength(300)
                .HasColumnName("EC_OBSERV");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TFactura>(entity =>
        {
            entity.HasKey(e => e.FacCodigo).HasName("PRIMARY");

            entity.ToTable("tFactura");

            entity.Property(e => e.FacCodigo)
                .HasMaxLength(10)
                .HasColumnName("FAC_CODIGO");
            entity.Property(e => e.AbCodigo)
                .HasMaxLength(4)
                .HasColumnName("AB_CODIGO");
            entity.Property(e => e.FacDetalle)
                .HasColumnType("text")
                .HasColumnName("FAC_DETALLE");
            entity.Property(e => e.FacFecha)
                .HasColumnType("datetime")
                .HasColumnName("FAC_FECHA");
            entity.Property(e => e.FacMonto)
                .HasColumnType("double(15,2)")
                .HasColumnName("FAC_MONTO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TGasAdmi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tGasAdmi");

            entity.Property(e => e.GaMonto)
                .HasColumnType("double(10,3)")
                .HasColumnName("GA_MONTO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TGraCol>(entity =>
        {
            entity.HasKey(e => e.GcCodigo).HasName("PRIMARY");

            entity.ToTable("tGraCol");

            entity.Property(e => e.GcCodigo)
                .HasColumnType("int(2)")
                .HasColumnName("GC_CODIGO");
            entity.Property(e => e.GcActivo)
                .HasColumnType("int(1)")
                .HasColumnName("GC_ACTIVO");
            entity.Property(e => e.GcNombre)
                .HasMaxLength(100)
                .HasColumnName("GC_NOMBRE");
            entity.Property(e => e.GcNombreIng)
                .HasMaxLength(100)
                .HasColumnName("GC_NOMBRE_ING");
            entity.Property(e => e.GcOrden)
                .HasColumnType("int(1)")
                .HasColumnName("GC_ORDEN");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<THistorico>(entity =>
        {
            entity.HasKey(e => e.HisCodigo).HasName("PRIMARY");

            entity.ToTable("tHistorico");

            entity.Property(e => e.HisCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("HIS_CODIGO");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.AboFecing)
                .HasColumnType("datetime")
                .HasColumnName("ABO_FECING");
            entity.Property(e => e.LblHostName)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("lblHostName");
            entity.Property(e => e.LblIpaddress)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("lblIPAddress");
            entity.Property(e => e.LblIpbehindProxy)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("lblIPBehindProxy");
            entity.Property(e => e.Migra)
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TIdioma>(entity =>
        {
            entity.HasKey(e => e.IdiCodigo).HasName("PRIMARY");

            entity.ToTable("tIdioma");

            entity.Property(e => e.IdiCodigo)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.IdiAbrevi)
                .HasMaxLength(4)
                .HasColumnName("IDI_ABREVI");
            entity.Property(e => e.IdiActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("IDI_ACTIVO");
            entity.Property(e => e.IdiNombre)
                .HasMaxLength(40)
                .HasColumnName("IDI_NOMBRE");
            entity.Property(e => e.IdiObserv)
                .HasMaxLength(150)
                .HasColumnName("IDI_OBSERV");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TJuridi>(entity =>
        {
            entity.HasKey(e => e.JuCodigo).HasName("PRIMARY");

            entity.ToTable("tJuridi");

            entity.HasIndex(e => e.JuCodigo, "JU_CODIGO");

            entity.HasIndex(e => e.JuCodigoIng, "JU_CODIGO_ING");

            entity.HasIndex(e => e.JuNombre, "JU_NOMBRE");

            entity.HasIndex(e => e.JuNombreIng, "JU_NOMBRE_ING");

            entity.Property(e => e.JuCodigo)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("JU_CODIGO");
            entity.Property(e => e.JuCodigoIng)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("JU_CODIGO_ING");
            entity.Property(e => e.JuNombre)
                .HasMaxLength(80)
                .HasColumnName("JU_NOMBRE");
            entity.Property(e => e.JuNombreIng)
                .HasMaxLength(80)
                .HasColumnName("JU_NOMBRE_ING");
            entity.Property(e => e.JuSigla)
                .HasMaxLength(12)
                .HasColumnName("JU_SIGLA");
            entity.Property(e => e.JuSiglaIng)
                .HasMaxLength(10)
                .HasColumnName("JU_SIGLA_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TKardex>(entity =>
        {
            entity.HasKey(e => e.AboCodigo).HasName("PRIMARY");

            entity.ToTable("tKardex");

            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasDefaultValueSql("''")
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.AboNombre)
                .HasMaxLength(100)
                .HasColumnName("ABO_NOMBRE");
            entity.Property(e => e.CuponesCompra)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiNombre)
                .HasMaxLength(3)
                .HasColumnName("PAI_NOMBRE");
            entity.Property(e => e.Precio)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.SaldoActual)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.SaldoAnterior)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.TotalCompra)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.TotalSaldoActual)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.TotalSaldoAnterior)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.TotalUnidAtendidas)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.UnidAtendidas)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
        });

        modelBuilder.Entity<TKardexTalonario>(entity =>
        {
            entity.HasKey(e => e.AboCodigo).HasName("PRIMARY");

            entity.ToTable("tKardexTalonarios");

            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasDefaultValueSql("''")
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.AboNombre)
                .HasMaxLength(100)
                .HasColumnName("ABO_NOMBRE");
            entity.Property(e => e.CuponesCompra)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiNombre)
                .HasMaxLength(3)
                .HasColumnName("PAI_NOMBRE");
            entity.Property(e => e.Precio)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.SaldoActual)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.SaldoAnterior)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.TotalCompra)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.TotalSaldoActual)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.TotalSaldoAnterior)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.TotalUnidAtendidas)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
            entity.Property(e => e.UnidAtendidas)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("double(10,2)");
        });

        modelBuilder.Entity<TLocal>(entity =>
        {
            entity.HasKey(e => e.LoCodigo).HasName("PRIMARY");

            entity.ToTable("tLocal");

            entity.Property(e => e.LoCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("LO_CODIGO");
            entity.Property(e => e.LoNombre)
                .HasMaxLength(50)
                .HasColumnName("LO_NOMBRE");
            entity.Property(e => e.LoNombreIng)
                .HasMaxLength(50)
                .HasColumnName("LO_NOMBRE_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TMatSub>(entity =>
        {
            entity.HasKey(e => e.MatCodigo).HasName("PRIMARY");

            entity.ToTable("tMatSub");

            entity.Property(e => e.MatCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("MAT_CODIGO");
            entity.Property(e => e.MatNombre)
                .HasMaxLength(50)
                .HasColumnName("MAT_NOMBRE");
            entity.Property(e => e.MatNombreIng)
                .HasMaxLength(50)
                .HasColumnName("MAT_NOMBRE_ING");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        modelBuilder.Entity<TMonedum>(entity =>
        {
            entity.HasKey(e => e.MonCodigo).HasName("PRIMARY");

            entity.ToTable("tMoneda");

            entity.Property(e => e.MonCodigo)
                .HasMaxLength(3)
                .HasColumnName("MON_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnName("MIGRA");
            entity.Property(e => e.MonAbrevi)
                .HasMaxLength(4)
                .HasColumnName("MON_ABREVI");
            entity.Property(e => e.MonActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("MON_ACTIVO");
            entity.Property(e => e.MonNombre)
                .HasMaxLength(30)
                .HasColumnName("MON_NOMBRE");
            entity.Property(e => e.MonObserv)
                .HasMaxLength(150)
                .HasColumnName("MON_OBSERV");
        });

        modelBuilder.Entity<TNovedade>(entity =>
        {
            entity.HasKey(e => e.NovNumero).HasName("PRIMARY");

            entity.ToTable("tNovedades");

            entity.Property(e => e.NovNumero)
                .HasColumnType("int(5)")
                .HasColumnName("NOV_NUMERO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.NovDescrip)
                .HasColumnType("text")
                .HasColumnName("NOV_DESCRIP");
            entity.Property(e => e.NovFecha)
                .HasColumnType("datetime")
                .HasColumnName("NOV_FECHA");
            entity.Property(e => e.NovVersion)
                .HasMaxLength(5)
                .HasColumnName("NOV_VERSION");
        });

        modelBuilder.Entity<TObservacionTipo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tObservacion_Tipo");

            entity.Property(e => e.Flag)
                .HasColumnType("tinyint(4)")
                .HasColumnName("FLAG");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.ObNombre)
                .HasMaxLength(50)
                .HasColumnName("OB_NOMBRE");
            entity.Property(e => e.ObTipo)
                .HasColumnType("tinyint(4)")
                .HasColumnName("OB_TIPO");
        });

        modelBuilder.Entity<TOpcionSitFin>(entity =>
        {
            entity.HasKey(e => e.OfCodigo).HasName("PRIMARY");

            entity.ToTable("tOpcionSitFin");

            entity.Property(e => e.OfCodigo)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("OF_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.OfDescri1)
                .HasColumnType("text")
                .HasColumnName("OF_DESCRI1");
            entity.Property(e => e.OfDescri1Ing)
                .HasColumnType("text")
                .HasColumnName("OF_DESCRI1_ING");
            entity.Property(e => e.OfDescri2)
                .HasColumnType("text")
                .HasColumnName("OF_DESCRI2");
            entity.Property(e => e.OfDescri2Ing)
                .HasColumnType("text")
                .HasColumnName("OF_DESCRI2_ING");
            entity.Property(e => e.SfCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("SF_CODIGO");
        });

        modelBuilder.Entity<TOrdenReg>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tOrdenReg");

            entity.HasIndex(e => e.OrdNumero, "Ord_Numero");

            entity.HasIndex(e => e.OrdTabla, "Ord_Tabla");

            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.OrdNumero)
                .HasColumnType("int(11)")
                .HasColumnName("Ord_Numero");
            entity.Property(e => e.OrdTabla)
                .HasMaxLength(100)
                .HasColumnName("Ord_Tabla");
            entity.Property(e => e.OrdValor1)
                .HasMaxLength(100)
                .HasColumnName("Ord_Valor1");
            entity.Property(e => e.OrdValor2)
                .HasMaxLength(100)
                .HasColumnName("Ord_Valor2");
            entity.Property(e => e.OrdValor3)
                .HasColumnType("double(7,3)")
                .HasColumnName("Ord_Valor3");
            entity.Property(e => e.OrdValor4)
                .HasColumnType("double(7,3)")
                .HasColumnName("Ord_Valor4");
        });

        modelBuilder.Entity<TPago>(entity =>
        {
            entity.HasKey(e => e.PaCodigo).HasName("PRIMARY");

            entity.ToTable("tPago");

            entity.HasIndex(e => e.PaCodigo, "PA_CODIGO");

            entity.HasIndex(e => e.PaCodigoIng, "PA_CODIGO_ING");

            entity.HasIndex(e => e.PaNombre, "PA_NOMBRE");

            entity.HasIndex(e => e.PaNombreIng, "PA_NOMBRE_ING");

            entity.HasIndex(e => e.PaOrden, "PA_ORDEN");

            entity.HasIndex(e => e.PaOrdenIng, "PA_ORDEN_ING");

            entity.Property(e => e.PaCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("PA_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)")
                .HasColumnName("PA_ACTIVO");
            entity.Property(e => e.PaCodigoIng)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("PA_CODIGO_ING");
            entity.Property(e => e.PaNombre)
                .HasMaxLength(80)
                .HasColumnName("PA_NOMBRE");
            entity.Property(e => e.PaNombreIng)
                .HasMaxLength(80)
                .HasColumnName("PA_NOMBRE_ING");
            entity.Property(e => e.PaOrden)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("PA_ORDEN");
            entity.Property(e => e.PaOrdenIng)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("PA_ORDEN_ING");
        });

        modelBuilder.Entity<TPai>(entity =>
        {
            entity.HasKey(e => e.PaiCodigo).HasName("PRIMARY");

            entity.ToTable("tPais");

            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("Pai_Codigo");
            entity.Property(e => e.ConCodigo)
                .HasMaxLength(3)
                .HasColumnName("CON_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiAbreviatura)
                .HasMaxLength(3)
                .HasColumnName("Pai_Abreviatura");
            entity.Property(e => e.PaiDocIde)
                .HasMaxLength(6)
                .HasColumnName("Pai_DocIde");
            entity.Property(e => e.PaiDocTrb)
                .HasMaxLength(6)
                .HasColumnName("Pai_DocTrb");
            entity.Property(e => e.PaiDoctrbPer)
                .HasMaxLength(6)
                .HasColumnName("PAI_DOCTRB_PER");
            entity.Property(e => e.PaiEstado)
                .HasMaxLength(1)
                .HasDefaultValueSql("'1'")
                .IsFixedLength()
                .HasColumnName("Pai_Estado");
            entity.Property(e => e.PaiMone)
                .HasMaxLength(3)
                .HasDefaultValueSql("'0'")
                .IsFixedLength()
                .HasColumnName("Pai_Mone");
            entity.Property(e => e.PaiMoneda)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("Pai_Moneda");
            entity.Property(e => e.PaiNombreCas)
                .HasMaxLength(45)
                .HasColumnName("Pai_Nombre_Cas");
            entity.Property(e => e.PaiNombreIng)
                .HasMaxLength(45)
                .HasColumnName("Pai_Nombre_Ing");
            entity.Property(e => e.PaiPrfInt)
                .HasMaxLength(7)
                .HasColumnName("Pai_PrfInt");
            entity.Property(e => e.PaiTop)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("PAI_TOP");
            entity.Property(e => e.Sector)
                .HasMaxLength(3)
                .HasDefaultValueSql("'0'")
                .IsFixedLength();
        });

        modelBuilder.Entity<TParamSistema>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tParam_Sistema");

            entity.Property(e => e.Campo1)
                .HasMaxLength(100)
                .HasColumnName("campo1");
            entity.Property(e => e.Flag1)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("flag1");
            entity.Property(e => e.Flag2)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("flag2");
            entity.Property(e => e.Flag3)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("flag3");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.Numero1)
                .HasPrecision(10)
                .HasColumnName("numero1");
            entity.Property(e => e.Numero2)
                .HasPrecision(10)
                .HasColumnName("numero2");
            entity.Property(e => e.Numero3)
                .HasPrecision(10)
                .HasColumnName("numero3");
            entity.Property(e => e.Numero4)
                .HasPrecision(10)
                .HasColumnName("numero4");
            entity.Property(e => e.Numero5)
                .HasPrecision(10)
                .HasColumnName("numero5");
            entity.Property(e => e.Valor1)
                .HasMaxLength(100)
                .HasColumnName("valor1");
            entity.Property(e => e.Valor2)
                .HasMaxLength(100)
                .HasColumnName("valor2");
            entity.Property(e => e.Valor3)
                .HasMaxLength(100)
                .HasColumnName("valor3");
            entity.Property(e => e.Valor4)
                .HasMaxLength(100)
                .HasColumnName("valor4");
            entity.Property(e => e.Valor5)
                .HasMaxLength(100)
                .HasColumnName("valor5");
        });

        modelBuilder.Entity<TPartPoli>(entity =>
        {
            entity.HasKey(e => e.PpCodigo).HasName("PRIMARY");

            entity.ToTable("tPartPoli");

            entity.Property(e => e.PpCodigo)
                .HasColumnType("int(2)")
                .HasColumnName("PP_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PpAbrevi)
                .HasMaxLength(5)
                .HasColumnName("PP_ABREVI");
            entity.Property(e => e.PpActivo)
                .HasMaxLength(1)
                .HasDefaultValueSql("'1'")
                .HasColumnName("PP_ACTIVO");
            entity.Property(e => e.PpDescri)
                .HasMaxLength(50)
                .HasColumnName("PP_DESCRI");
        });

        modelBuilder.Entity<TPrecioAbonado>(entity =>
        {
            entity.HasKey(e => e.PaCodigo).HasName("PRIMARY");

            entity.ToTable("tPrecioAbonado");

            entity.Property(e => e.PaCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("PA_CODIGO");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.MonCodigo)
                .HasMaxLength(3)
                .HasColumnName("MON_CODIGO");
            entity.Property(e => e.PaFecha)
                .HasColumnType("datetime")
                .HasColumnName("PA_FECHA");
            entity.Property(e => e.PaPreef2)
                .HasMaxLength(15)
                .HasDefaultValueSql("'0'")
                .HasComment("Precio Para los EF")
                .HasColumnName("PA_PREEF2");
            entity.Property(e => e.PaPrenor)
                .HasMaxLength(15)
                .HasDefaultValueSql("'0 / 0'")
                .HasColumnName("PA_PRENOR");
            entity.Property(e => e.PaPresup)
                .HasMaxLength(15)
                .HasDefaultValueSql("'0 / 0'")
                .HasColumnName("PA_PRESUP");
            entity.Property(e => e.PaPreurg)
                .HasMaxLength(15)
                .HasDefaultValueSql("'0 / 0'")
                .HasColumnName("PA_PREURG");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
        });

        modelBuilder.Entity<TPrecioAgente>(entity =>
        {
            entity.HasKey(e => e.PaContador).HasName("PRIMARY");

            entity.ToTable("tPrecioAgente");

            entity.HasIndex(e => e.PaiCodigo, "cia_detalle_precio_agente_ibfk_1");

            entity.HasIndex(e => e.MonCodigo, "cia_detalle_precio_agente_ibfk_2");

            entity.Property(e => e.PaContador)
                .HasColumnType("int(11)")
                .HasColumnName("PA_CONTADOR");
            entity.Property(e => e.AgeCodigo)
                .HasMaxLength(3)
                .HasColumnName("AGE_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.MonCodigo)
                .HasMaxLength(3)
                .HasColumnName("MON_CODIGO");
            entity.Property(e => e.PaFecha)
                .HasColumnType("datetime")
                .HasColumnName("PA_FECHA");
            entity.Property(e => e.PaPrebas)
                .HasMaxLength(15)
                .HasDefaultValueSql("'0 / 0'")
                .HasColumnName("PA_PREBAS");
            entity.Property(e => e.PaPrecre)
                .HasMaxLength(15)
                .HasDefaultValueSql("'0 / 0'")
                .HasColumnName("PA_PRECRE");
            entity.Property(e => e.PaPrenat)
                .HasMaxLength(15)
                .HasDefaultValueSql("'0 / 0'")
                .HasColumnName("PA_PRENAT");
            entity.Property(e => e.PaPrenor)
                .HasMaxLength(15)
                .HasDefaultValueSql("'0 / 0'")
                .HasColumnName("PA_PRENOR");
            entity.Property(e => e.PaPrereg)
                .HasMaxLength(15)
                .HasDefaultValueSql("'0 / 0'")
                .HasColumnName("PA_PREREG");
            entity.Property(e => e.PaPresup)
                .HasMaxLength(15)
                .HasDefaultValueSql("'0 / 0'")
                .HasColumnName("PA_PRESUP");
            entity.Property(e => e.PaPret4)
                .HasMaxLength(15)
                .HasDefaultValueSql("'0 / 0'")
                .HasColumnName("PA_PRET4");
            entity.Property(e => e.PaPreurg)
                .HasMaxLength(15)
                .HasDefaultValueSql("'0 / 0'")
                .HasColumnName("PA_PREURG");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
        });

        modelBuilder.Entity<TPrecioAgenteExcepcionale>(entity =>
        {
            entity.HasKey(e => e.PeContador).HasName("PRIMARY");

            entity.ToTable("tPrecioAgenteExcepcionales");

            entity.Property(e => e.PeContador)
                .HasComment("PRECIO EXCEPCIONAL(PE")
                .HasColumnType("int(11)")
                .HasColumnName("PE_CONTADOR");
            entity.Property(e => e.AgeCodigo)
                .HasMaxLength(3)
                .HasColumnName("AGE_CODIGO");
            entity.Property(e => e.CalCodigo)
                .HasMaxLength(3)
                .HasColumnName("CAL_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.PeActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("PE_ACTIVO");
            entity.Property(e => e.PePrecio)
                .HasColumnType("double(10,3)")
                .HasColumnName("PE_PRECIO");
        });

        modelBuilder.Entity<TPrecioRepEspecial>(entity =>
        {
            entity.HasKey(e => e.PaiCodigo).HasName("PRIMARY");

            entity.ToTable("tPrecioRepEspecial");

            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasDefaultValueSql("''")
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PerCodigoRep)
                .HasMaxLength(3)
                .HasColumnName("PER_CODIGO_REP");
            entity.Property(e => e.PrPrecioA)
                .HasColumnType("double(5,2)")
                .HasColumnName("PR_PRECIO_A");
            entity.Property(e => e.PrPrecioA1)
                .HasColumnType("double(5,2)")
                .HasColumnName("PR_PRECIO_A1");
            entity.Property(e => e.PrPrecioB)
                .HasColumnType("double(5,2)")
                .HasColumnName("PR_PRECIO_B");
            entity.Property(e => e.PrPrecioB1)
                .HasColumnType("double(5,2)")
                .HasColumnName("PR_PRECIO_B1");
            entity.Property(e => e.PrPrecioC)
                .HasColumnType("double(5,2)")
                .HasColumnName("PR_PRECIO_C");
            entity.Property(e => e.PrPrecioC1)
                .HasColumnType("double(5,2)")
                .HasColumnName("PR_PRECIO_C1");
            entity.Property(e => e.PrPrecioD)
                .HasColumnType("double(5,2)")
                .HasColumnName("PR_PRECIO_D");
            entity.Property(e => e.PrPrecioX)
                .HasColumnType("double(5,2)")
                .HasColumnName("PR_PRECIO_X");
        });

        modelBuilder.Entity<TPrecioTramite>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tPrecioTramite");

            entity.HasIndex(e => e.TramCodigo, "TRAM_CODIGO");

            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PreAux1)
                .HasMaxLength(100)
                .HasColumnName("PRE_AUX1");
            entity.Property(e => e.PreAux2)
                .HasMaxLength(100)
                .HasColumnName("PRE_AUX2");
            entity.Property(e => e.PreAux3)
                .HasMaxLength(100)
                .HasColumnName("PRE_AUX3");
            entity.Property(e => e.PreAux4)
                .HasColumnType("double(8,2)")
                .HasColumnName("PRE_AUX4");
            entity.Property(e => e.PreAux5)
                .HasColumnType("double(8,2)")
                .HasColumnName("PRE_AUX5");
            entity.Property(e => e.PreAux6)
                .HasColumnType("double(8,2)")
                .HasColumnName("PRE_AUX6");
            entity.Property(e => e.PreValor)
                .HasColumnType("double(8,2)")
                .HasColumnName("PRE_VALOR");
            entity.Property(e => e.TramCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TRAM_CODIGO");
        });

        modelBuilder.Entity<TProfesion>(entity =>
        {
            entity.HasKey(e => e.PfCodigo).HasName("PRIMARY");

            entity.ToTable("tProfesion");

            entity.HasIndex(e => e.PfCodigo, "PF_CODIGO");

            entity.HasIndex(e => e.PfCodigoIng, "PF_CODIGO_ING");

            entity.HasIndex(e => e.PfNombre, "PF_NOMBRE");

            entity.HasIndex(e => e.PfNombreIng, "PF_NOMBRE_ING");

            entity.Property(e => e.PfCodigo)
                .HasMaxLength(4)
                .HasColumnName("PF_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PfCodigoIng)
                .HasMaxLength(4)
                .HasColumnName("PF_CODIGO_ING");
            entity.Property(e => e.PfNombre)
                .HasMaxLength(40)
                .HasColumnName("PF_NOMBRE");
            entity.Property(e => e.PfNombreIng)
                .HasMaxLength(40)
                .HasColumnName("PF_NOMBRE_ING");
            entity.Property(e => e.PfObserv)
                .HasColumnType("text")
                .HasColumnName("PF_OBSERV");
            entity.Property(e => e.PfObservIng)
                .HasColumnType("text")
                .HasColumnName("PF_OBSERV_ING");
        });

        modelBuilder.Entity<TRamo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tRamo");

            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.RamCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("ram_Codigo");
            entity.Property(e => e.RamFlag)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("ram_Flag");
            entity.Property(e => e.RamNombre)
                .HasMaxLength(150)
                .HasColumnName("ram_Nombre");
            entity.Property(e => e.RamNombreIng)
                .HasMaxLength(150)
                .HasColumnName("ram_Nombre_Ing");
        });

        modelBuilder.Entity<TRamoA>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tRamoA");

            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.RamCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("ram_Codigo");
            entity.Property(e => e.RamFlag)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("ram_Flag");
            entity.Property(e => e.RamNombre)
                .HasMaxLength(200)
                .HasColumnName("ram_Nombre");
            entity.Property(e => e.RamNombreIng)
                .HasMaxLength(200)
                .HasColumnName("ram_Nombre_Ing");
        });

        modelBuilder.Entity<TRamoB>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tRamoB");

            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.RamBCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("ramB_Codigo");
            entity.Property(e => e.RamBFlag)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("ramB_Flag");
            entity.Property(e => e.RamBNombre)
                .HasMaxLength(50)
                .HasColumnName("ramB_Nombre");
            entity.Property(e => e.RamBNombreIng)
                .HasMaxLength(50)
                .HasColumnName("ramB_Nombre_Ing");
            entity.Property(e => e.RamCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("ram_Codigo");
        });

        modelBuilder.Entity<TRelacion>(entity =>
        {
            entity.HasKey(e => e.ReCodigo).HasName("PRIMARY");

            entity.ToTable("tRelacion");

            entity.Property(e => e.ReCodigo)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("RE_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.ReActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)")
                .HasColumnName("RE_ACTIVO");
            entity.Property(e => e.ReNombre)
                .HasMaxLength(50)
                .HasColumnName("RE_NOMBRE");
            entity.Property(e => e.ReNombreIng)
                .HasMaxLength(50)
                .HasColumnName("RE_NOMBRE_ING");
            entity.Property(e => e.ReOrden)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)")
                .HasColumnName("RE_ORDEN");
            entity.Property(e => e.ReTipo)
                .HasMaxLength(3)
                .HasColumnName("RE_TIPO");
        });

        modelBuilder.Entity<TRepCom>(entity =>
        {
            entity.HasKey(e => e.RcCodigo).HasName("PRIMARY");

            entity.ToTable("tRepCom");

            entity.HasIndex(e => e.RcCodigo, "RC_CODIGO");

            entity.HasIndex(e => e.RcCodigoIng, "RC_CODIGO_ING");

            entity.HasIndex(e => e.RcNombre, "RC_NOMBRE");

            entity.HasIndex(e => e.RcNombreIng, "RC_NOMBRE_ING");

            entity.HasIndex(e => e.RcOrden, "RC_ORDEN");

            entity.HasIndex(e => e.RcOrdenIng, "RC_ORDEN_ING");

            entity.Property(e => e.RcCodigo)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("RC_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.RcActivo)
                .HasDefaultValueSql("'1'")
                .HasComment("Estado (1 Activo 2 Desactivado)")
                .HasColumnType("int(1)")
                .HasColumnName("RC_ACTIVO");
            entity.Property(e => e.RcCodigoIng)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("RC_CODIGO_ING");
            entity.Property(e => e.RcNombre)
                .HasMaxLength(70)
                .HasColumnName("RC_NOMBRE");
            entity.Property(e => e.RcNombreIng)
                .HasMaxLength(70)
                .HasColumnName("RC_NOMBRE_ING");
            entity.Property(e => e.RcOrden)
                .HasColumnType("int(11)")
                .HasColumnName("RC_ORDEN");
            entity.Property(e => e.RcOrdenIng)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("RC_ORDEN_ING");
            entity.Property(e => e.RcStatus)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("RC_STATUS");
        });

        modelBuilder.Entity<TRubro>(entity =>
        {
            entity.HasKey(e => e.RubCodigo).HasName("PRIMARY");

            entity.ToTable("tRubro");

            entity.Property(e => e.RubCodigo)
                .HasMaxLength(4)
                .HasColumnName("RUB_CODIGO");
            entity.Property(e => e.Migra).HasColumnName("MIGRA");
            entity.Property(e => e.RubAbrevi)
                .HasMaxLength(4)
                .HasColumnName("RUB_ABREVI");
            entity.Property(e => e.RubActivo)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("RUB_ACTIVO");
            entity.Property(e => e.RubNombre)
                .HasMaxLength(100)
                .HasColumnName("RUB_NOMBRE");
            entity.Property(e => e.RubObserv)
                .HasMaxLength(150)
                .HasColumnName("RUB_OBSERV");
        });

        modelBuilder.Entity<TSector>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tSector");

            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.SecCodigo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("sec_Codigo");
            entity.Property(e => e.SecFlag)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("sec_Flag");
            entity.Property(e => e.SecNombre)
                .HasMaxLength(100)
                .HasColumnName("sec_Nombre");
            entity.Property(e => e.SecNombreIng)
                .HasMaxLength(100)
                .HasColumnName("sec_Nombre_Ing");
        });

        modelBuilder.Entity<TSectorEconomico>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tSectorEconomico");

            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.SeActividades)
                .HasMaxLength(500)
                .HasColumnName("SE_ACTIVIDADES");
            entity.Property(e => e.SeActividadesIng)
                .HasMaxLength(500)
                .HasColumnName("SE_ACTIVIDADES_ING");
            entity.Property(e => e.SeCodigo)
                .HasMaxLength(2)
                .HasColumnName("SE_CODIGO");
            entity.Property(e => e.SeNombre)
                .HasMaxLength(80)
                .HasColumnName("SE_NOMBRE");
            entity.Property(e => e.SeNombreIng)
                .HasMaxLength(80)
                .HasColumnName("SE_NOMBRE_ING");
        });

        modelBuilder.Entity<TSexo>(entity =>
        {
            entity.HasKey(e => e.SexCodigo).HasName("PRIMARY");

            entity.ToTable("tSexo");

            entity.Property(e => e.SexCodigo)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .HasColumnName("SEX_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.SexDescri)
                .HasMaxLength(15)
                .HasColumnName("SEX_DESCRI");
            entity.Property(e => e.SexDescriIng)
                .HasMaxLength(15)
                .HasColumnName("SEX_DESCRI_ING");
        });

        modelBuilder.Entity<TSiNo>(entity =>
        {
            entity.HasKey(e => e.SnCodigo).HasName("PRIMARY");

            entity.ToTable("tSiNo");

            entity.Property(e => e.SnCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("SN_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.SnNombre)
                .HasMaxLength(2)
                .HasColumnName("SN_NOMBRE");
            entity.Property(e => e.SnNombreIng)
                .HasMaxLength(3)
                .HasColumnName("SN_NOMBRE_ING");
        });

        modelBuilder.Entity<TSitFin>(entity =>
        {
            entity.HasKey(e => e.SfCodigo).HasName("PRIMARY");

            entity.ToTable("tSitFin");

            entity.HasIndex(e => e.SfCodigo, "SF_CODIGO");

            entity.HasIndex(e => e.SfNombre, "SF_NOMBRE");

            entity.Property(e => e.SfCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("SF_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.SfComen)
                .HasColumnType("text")
                .HasColumnName("SF_COMEN");
            entity.Property(e => e.SfComenIng)
                .HasColumnType("text")
                .HasColumnName("SF_Comen_Ing");
            entity.Property(e => e.SfNombre)
                .HasMaxLength(40)
                .HasColumnName("SF_NOMBRE");
            entity.Property(e => e.SfNombreIng)
                .HasMaxLength(40)
                .HasColumnName("SF_Nombre_Ing");
        });

        modelBuilder.Entity<TSituacion>(entity =>
        {
            entity.HasKey(e => e.SitCodigo).HasName("PRIMARY");

            entity.ToTable("tSituacion");

            entity.Property(e => e.SitCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("SIT_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.SitAbrevia)
                .HasMaxLength(2)
                .HasColumnName("SIT_ABREVIA");
            entity.Property(e => e.SitNombre)
                .HasMaxLength(50)
                .HasColumnName("SIT_NOMBRE");
            entity.Property(e => e.SitNombreIng)
                .HasMaxLength(50)
                .HasColumnName("SIT_NOMBRE_ING");
        });

        modelBuilder.Entity<TSueldoPersonal>(entity =>
        {
            entity.HasKey(e => e.Nro).HasName("PRIMARY");

            entity.ToTable("tSueldoPersonal");

            entity.HasIndex(e => e.PerCodigo, "tSueldoPersonal_index01");

            entity.Property(e => e.Nro).HasColumnType("bigint(3)");
            entity.Property(e => e.FechaPago)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Pago");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.MonCodigo)
                .HasMaxLength(3)
                .HasColumnName("MON_CODIGO");
            entity.Property(e => e.Monto).HasColumnType("double(10,3)");
            entity.Property(e => e.PerCodigo)
                .HasMaxLength(4)
                .HasColumnName("PER_CODIGO");
        });

        modelBuilder.Entity<TTamano>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tTamano");

            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.TaCodigo)
                .HasMaxLength(2)
                .HasColumnName("TA_CODIGO");
            entity.Property(e => e.TaNombre)
                .HasMaxLength(50)
                .HasColumnName("TA_NOMBRE");
            entity.Property(e => e.TaNombreIng)
                .HasMaxLength(50)
                .HasColumnName("TA_NOMBRE_ING");
            entity.Property(e => e.Valor)
                .HasMaxLength(50)
                .HasColumnName("VALOR");
        });

        modelBuilder.Entity<TTempBalanceEmp>(entity =>
        {
            entity.HasKey(e => new { e.EmCodigo, e.UsCodigo, e.BaAnobal }).HasName("PRIMARY");

            entity.ToTable("tTempBalanceEmp");

            entity.HasIndex(e => e.EmCodigo, "Em_Codigo");

            entity.HasIndex(e => new { e.EmCodigo, e.UsCodigo }, "Em_Codigo_2");

            entity.HasIndex(e => new { e.EmCodigo, e.UsCodigo, e.BaAnobal }, "Em_Codigo_3");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("US_CODIGO");
            entity.Property(e => e.BaAnobal)
                .HasMaxLength(4)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("BA_ANOBAL");
            entity.Property(e => e.BaFecbal)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBAL");
            entity.Property(e => e.BaTotcor).HasColumnName("BA_TOTCOR");
            entity.Property(e => e.BaTotcrr).HasColumnName("BA_TOTCRR");
            entity.Property(e => e.BaTotpat).HasColumnName("BA_TOTPAT");
            entity.Property(e => e.BaVentas).HasColumnName("BA_VENTAS");
        });

        modelBuilder.Entity<TTempBalanceEmpresa>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tTempBalanceEmpresa");

            entity.Property(e => e.BaAnobal)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("BA_ANOBAL");
            entity.Property(e => e.BaFecbal)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBAL");
            entity.Property(e => e.BaTotcor).HasColumnName("BA_TOTCOR");
            entity.Property(e => e.BaTotcrr).HasColumnName("BA_TOTCRR");
            entity.Property(e => e.BaTotpat).HasColumnName("BA_TOTPAT");
            entity.Property(e => e.BaVentas).HasColumnName("BA_VENTAS");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasDefaultValueSql("''")
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<TTempImprimirListadoPersona>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tTempImprimirListadoPersonas");

            entity.Property(e => e.PaiNombre)
                .HasMaxLength(100)
                .HasColumnName("PAI_NOMBRE");
            entity.Property(e => e.PeCs)
                .HasMaxLength(100)
                .HasColumnName("PE_CS");
            entity.Property(e => e.PeDirecc)
                .HasMaxLength(200)
                .HasColumnName("PE_DIRECC");
            entity.Property(e => e.PeDocide)
                .HasMaxLength(100)
                .HasColumnName("PE_DOCIDE");
            entity.Property(e => e.PeFecnac)
                .HasMaxLength(100)
                .HasColumnName("PE_FECNAC");
            entity.Property(e => e.PeNombre)
                .HasMaxLength(100)
                .HasColumnName("PE_NOMBRE");
            entity.Property(e => e.PePp)
                .HasMaxLength(100)
                .HasColumnName("PE_PP");
            entity.Property(e => e.PeTelefo)
                .HasMaxLength(100)
                .HasColumnName("PE_TELEFO");
            entity.Property(e => e.PfNombre)
                .HasMaxLength(100)
                .HasColumnName("PF_NOMBRE");
        });

        modelBuilder.Entity<TTemporalCostosGenerale>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tTemporalCostosGenerales");

            entity.Property(e => e.AboCodigo)
                .HasMaxLength(100)
                .HasColumnName("Abo_Codigo");
            entity.Property(e => e.Costo).HasColumnType("double(10,3)");
            entity.Property(e => e.Dif).HasColumnType("double(10,3)");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaDespacho)
                .HasColumnType("date")
                .HasColumnName("Fecha_Despacho");
            entity.Property(e => e.GastosAdministrativos)
                .HasColumnType("double(10,3)")
                .HasColumnName("Gastos_Administrativos");
            entity.Property(e => e.Informe).HasMaxLength(2);
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.Pais).HasMaxLength(50);
            entity.Property(e => e.PrecioAgente)
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Agente");
            entity.Property(e => e.PrecioDigitadora)
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Digitadora");
            entity.Property(e => e.PrecioInforme)
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Informe");
            entity.Property(e => e.PrecioReportero)
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Reportero");
            entity.Property(e => e.PrecioTraductora)
                .HasColumnType("double(10,3)")
                .HasColumnName("Precio_Traductora");
            entity.Property(e => e.Tramite).HasMaxLength(2);
        });

        modelBuilder.Entity<TTemporalDetallePedido>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tTemporalDetallePedido");

            entity.Property(e => e.Costo).HasColumnType("double(7,2)");
            entity.Property(e => e.Fdesp)
                .HasColumnType("date")
                .HasColumnName("FDesp");
            entity.Property(e => e.Fped)
                .HasColumnType("date")
                .HasColumnName("FPed");
            entity.Property(e => e.Igv)
                .HasColumnType("double(7,2)")
                .HasColumnName("IGV");
            entity.Property(e => e.Monto).HasColumnType("double(9,2)");
            entity.Property(e => e.NombreInforme)
                .HasMaxLength(200)
                .HasColumnName("Nombre_Informe");
            entity.Property(e => e.Nro).HasColumnType("int(11)");
            entity.Property(e => e.NroReferencia).HasMaxLength(80);
            entity.Property(e => e.Pais).HasMaxLength(3);
            entity.Property(e => e.Tramite).HasMaxLength(2);
        });

        modelBuilder.Entity<TTemporalEmpresa>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tTemporalEmpresa");

            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.AtFecdev)
                .HasMaxLength(10)
                .HasColumnName("AT_FECDEV");
            entity.Property(e => e.BaFecbalance)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBALANCE");
            entity.Property(e => e.CalCodigo)
                .HasMaxLength(3)
                .HasColumnName("CAL_CODIGO");
            entity.Property(e => e.CalNombre)
                .HasMaxLength(100)
                .HasColumnName("CAL_NOMBRE");
            entity.Property(e => e.CpCodigo)
                .HasMaxLength(2)
                .HasDefaultValueSql("'0'")
                .HasColumnName("CP_CODIGO");
            entity.Property(e => e.CpNombre)
                .HasMaxLength(200)
                .HasDefaultValueSql("'0'")
                .HasColumnName("CP_NOMBRE");
            entity.Property(e => e.CpNombreIng)
                .HasMaxLength(200)
                .HasDefaultValueSql("'0'")
                .HasColumnName("CP_NOMBRE_ING");
            entity.Property(e => e.CrCodigo)
                .HasMaxLength(4)
                .HasColumnName("CR_CODIGO");
            entity.Property(e => e.CrNombre)
                .HasMaxLength(85)
                .HasColumnName("CR_NOMBRE");
            entity.Property(e => e.CupCodigo)
                .HasMaxLength(20)
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.CupFecped)
                .HasMaxLength(20)
                .HasColumnName("CUP_FECPED");
            entity.Property(e => e.CupIdioma)
                .HasMaxLength(3)
                .HasColumnName("CUP_IDIOMA");
            entity.Property(e => e.CupNroord)
                .HasMaxLength(20)
                .HasColumnName("CUP_NROORD");
            entity.Property(e => e.CupRefabo)
                .HasMaxLength(80)
                .HasColumnName("CUP_REFABO");
            entity.Property(e => e.CupTipinf)
                .HasMaxLength(4)
                .HasColumnName("CUP_TIPINF");
            entity.Property(e => e.DiCodigo)
                .HasMaxLength(4)
                .HasColumnName("DI_CODIGO");
            entity.Property(e => e.DiNombre)
                .HasColumnType("text")
                .HasColumnName("DI_NOMBRE");
            entity.Property(e => e.EmAnobal)
                .HasMaxLength(4)
                .HasColumnName("EM_ANOBAL");
            entity.Property(e => e.EmAnofun)
                .HasMaxLength(4)
                .HasColumnName("EM_ANOFUN");
            entity.Property(e => e.EmAntcre)
                .HasColumnType("text")
                .HasColumnName("EM_ANTCRE");
            entity.Property(e => e.EmAntcreIng)
                .HasColumnType("text")
                .HasColumnName("EM_ANTCRE_ING");
            entity.Property(e => e.EmArrfin)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_ARRFIN");
            entity.Property(e => e.EmArrfinMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_ARRFIN_ME");
            entity.Property(e => e.EmAudito)
                .HasMaxLength(150)
                .HasColumnName("EM_AUDITO");
            entity.Property(e => e.EmBalgen)
                .HasDefaultValueSql("'0'")
                .HasComment("0")
                .HasColumnType("int(4)")
                .HasColumnName("EM_BALGEN");
            entity.Property(e => e.EmBalsit)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(4)")
                .HasColumnName("EM_BALSIT");
            entity.Property(e => e.EmBanco)
                .HasColumnType("text")
                .HasColumnName("EM_BANCO");
            entity.Property(e => e.EmBancoIng)
                .HasColumnType("text")
                .HasColumnName("EM_BANCO_ING");
            entity.Property(e => e.EmCalsbs)
                .HasMaxLength(20)
                .HasColumnName("EM_CALSBS");
            entity.Property(e => e.EmCalsbsIng)
                .HasMaxLength(20)
                .HasColumnName("EM_CALSBS_ING");
            entity.Property(e => e.EmCenrie)
                .HasColumnType("text")
                .HasColumnName("EM_CENRIE");
            entity.Property(e => e.EmCenrieIng)
                .HasColumnType("text")
                .HasColumnName("EM_CENRIE_ING");
            entity.Property(e => e.EmChkBanco)
                .HasMaxLength(2)
                .HasDefaultValueSql("'0'")
                .IsFixedLength()
                .HasColumnName("EM_CHK_BANCO");
            entity.Property(e => e.EmChkban)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("EM_CHKBAN");
            entity.Property(e => e.EmCiudad)
                .HasMaxLength(50)
                .HasColumnName("EM_CIUDAD");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EmCodpos)
                .HasMaxLength(20)
                .HasColumnName("EM_CODPOS");
            entity.Property(e => e.EmComexte)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_COMEXTE");
            entity.Property(e => e.EmComexteMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_COMEXTE_ME");
            entity.Property(e => e.EmComide)
                .HasColumnType("text")
                .HasColumnName("EM_COMIDE");
            entity.Property(e => e.EmComideIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMIDE_ING");
            entity.Property(e => e.EmComlit)
                .HasColumnType("text")
                .HasColumnName("EM_COMLIT");
            entity.Property(e => e.EmComlitIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMLIT_ING");
            entity.Property(e => e.EmComprov)
                .HasColumnType("text")
                .HasColumnName("EM_COMPROV");
            entity.Property(e => e.EmComprovIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMPROV_ING");
            entity.Property(e => e.EmComrep)
                .HasColumnType("text")
                .HasColumnName("EM_COMREP");
            entity.Property(e => e.EmComrepIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMREP_ING");
            entity.Property(e => e.EmCrerec)
                .HasMaxLength(32)
                .HasColumnName("EM_CREREC");
            entity.Property(e => e.EmCrerecIng)
                .HasMaxLength(32)
                .HasColumnName("EM_CREREC_ING");
            entity.Property(e => e.EmDepart)
                .HasMaxLength(50)
                .HasColumnName("EM_DEPART");
            entity.Property(e => e.EmDescue)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_DESCUE");
            entity.Property(e => e.EmDescueMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_DESCUE_ME");
            entity.Property(e => e.EmDirecc)
                .HasMaxLength(200)
                .HasColumnName("EM_DIRECC");
            entity.Property(e => e.EmDistri)
                .HasMaxLength(50)
                .HasColumnName("EM_DISTRI");
            entity.Property(e => e.EmDomant)
                .HasMaxLength(150)
                .HasColumnName("EM_DOMANT");
            entity.Property(e => e.EmEmail)
                .HasMaxLength(200)
                .HasColumnName("EM_EMAIL");
            entity.Property(e => e.EmEstadoempresa)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("EM_ESTADOEMPRESA");
            entity.Property(e => e.EmFactor)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_FACTOR");
            entity.Property(e => e.EmFactorMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_FACTOR_ME");
            entity.Property(e => e.EmFax)
                .HasMaxLength(500)
                .HasColumnName("EM_FAX");
            entity.Property(e => e.EmFecbalAnu)
                .HasMaxLength(10)
                .HasColumnName("EM_FECBAL_ANU");
            entity.Property(e => e.EmFecbalAnu2)
                .HasMaxLength(10)
                .HasColumnName("EM_FECBAL_ANU2");
            entity.Property(e => e.EmFecinf)
                .HasColumnType("datetime")
                .HasColumnName("EM_FECINF");
            entity.Property(e => e.EmFecref)
                .HasColumnType("date")
                .HasColumnName("EM_FECREF");
            entity.Property(e => e.EmFecreg)
                .HasMaxLength(10)
                .HasColumnName("EM_FECREG");
            entity.Property(e => e.EmFecsbs)
                .HasMaxLength(10)
                .HasColumnName("EM_FECSBS");
            entity.Property(e => e.EmGaome)
                .HasDefaultValueSql("'0'")
                .HasColumnName("EM_GAOME");
            entity.Property(e => e.EmGaomn)
                .HasDefaultValueSql("'0'")
                .HasColumnName("EM_GAOMN");
            entity.Property(e => e.EmGarofr)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_GAROFR");
            entity.Property(e => e.EmInfgen)
                .HasColumnType("text")
                .HasColumnName("EM_INFGEN");
            entity.Property(e => e.EmInfgenIng)
                .HasColumnType("text")
                .HasColumnName("EM_INFGEN_ING");
            entity.Property(e => e.EmIngecu)
                .HasColumnType("text")
                .HasColumnName("EM_INGECU");
            entity.Property(e => e.EmIngecuIng)
                .HasColumnType("text")
                .HasColumnName("EM_INGECU_ING");
            entity.Property(e => e.EmLeabac)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_LEABAC");
            entity.Property(e => e.EmLeabacMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_LEABAC_ME");
            entity.Property(e => e.EmLogantleg)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGANTLEG");
            entity.Property(e => e.EmLogbalance)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGBALANCE");
            entity.Property(e => e.EmLoggrafico)
                .HasDefaultValueSql("'0'")
                .HasComment("Si es 1 es xq existe valores para grafico de activo corriente ,pasivo corriente y patrimonio")
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGGRAFICO");
            entity.Property(e => e.EmLogico)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("EM_LOGICO");
            entity.Property(e => e.EmLogimagen)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGIMAGEN");
            entity.Property(e => e.EmLoginffin)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGINFFIN");
            entity.Property(e => e.EmLogpagos)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGPAGOS");
            entity.Property(e => e.EmLogpre)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGPRE");
            entity.Property(e => e.EmLogramneg)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGRAMNEG");
            entity.Property(e => e.EmLogventas)
                .HasDefaultValueSql("'0'")
                .HasComment("Si es 1 es xq existe ventas para poder ver el grafico")
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGVENTAS");
            entity.Property(e => e.EmMatriz)
                .HasMaxLength(150)
                .HasColumnName("EM_MATRIZ");
            entity.Property(e => e.EmMorBan)
                .HasColumnType("int(11)")
                .HasColumnName("EM_MOR_BAN");
            entity.Property(e => e.EmMorCom)
                .HasColumnType("int(11)")
                .HasColumnName("EM_MOR_COM");
            entity.Property(e => e.EmMorosidad)
                .HasMaxLength(50)
                .HasColumnName("EM_MOROSIDAD");
            entity.Property(e => e.EmMorosidadIng)
                .HasMaxLength(50)
                .HasColumnName("EM_MOROSIDAD_ING");
            entity.Property(e => e.EmMtopcr)
                .HasMaxLength(32)
                .HasColumnName("EM_MTOPCR");
            entity.Property(e => e.EmMtopcrIng)
                .HasMaxLength(32)
                .HasColumnName("EM_MTOPCR_ING");
            entity.Property(e => e.EmNombre)
                .HasMaxLength(120)
                .HasColumnName("EM_NOMBRE");
            entity.Property(e => e.EmNomcrr)
                .HasMaxLength(3)
                .HasComment("Nombre Correcto Si o No")
                .HasColumnName("EM_NOMCRR");
            entity.Property(e => e.EmNomsol)
                .HasMaxLength(100)
                .HasColumnName("EM_NOMSOL");
            entity.Property(e => e.EmNomvia)
                .HasMaxLength(100)
                .HasColumnName("EM_NOMVIA");
            entity.Property(e => e.EmNument)
                .HasMaxLength(5)
                .HasColumnName("EM_NUMENT");
            entity.Property(e => e.EmNumhis)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasComment("Numero de historico")
                .HasColumnName("EM_NUMHIS");
            entity.Property(e => e.EmOcDescri)
                .HasColumnType("text")
                .HasColumnName("EM_OC_DESCRI");
            entity.Property(e => e.EmOcDescriIng)
                .HasColumnType("text")
                .HasColumnName("EM_OC_DESCRI_ING");
            entity.Property(e => e.EmOnline)
                .HasMaxLength(2)
                .HasColumnName("EM_ONLINE");
            entity.Property(e => e.EmOpicre)
                .HasColumnType("text")
                .HasColumnName("EM_OPICRE");
            entity.Property(e => e.EmOpicreIng)
                .HasColumnType("text")
                .HasColumnName("EM_OPICRE_ING");
            entity.Property(e => e.EmOtrdeu)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_OTRDEU");
            entity.Property(e => e.EmOtrdeuMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_OTRDEU_ME");
            entity.Property(e => e.EmOtros)
                .HasMaxLength(25)
                .HasColumnName("EM_OTROS");
            entity.Property(e => e.EmOtros2)
                .HasMaxLength(35)
                .HasColumnName("EM_OTROS2");
            entity.Property(e => e.EmOtros2Ing)
                .HasMaxLength(35)
                .HasColumnName("EM_OTROS2_ING");
            entity.Property(e => e.EmOtrosIng)
                .HasMaxLength(25)
                .HasColumnName("EM_OTROS_ING");
            entity.Property(e => e.EmPagweb)
                .HasMaxLength(100)
                .HasColumnName("EM_PAGWEB");
            entity.Property(e => e.EmPiso)
                .HasMaxLength(30)
                .HasColumnName("EM_PISO");
            entity.Property(e => e.EmPrensa)
                .HasColumnType("text")
                .HasColumnName("EM_PRENSA");
            entity.Property(e => e.EmPrensaIng)
                .HasColumnType("text")
                .HasColumnName("EM_PRENSA_ING");
            entity.Property(e => e.EmPrensasel)
                .HasColumnType("text")
                .HasColumnName("EM_PRENSASEL");
            entity.Property(e => e.EmPrensaselIng)
                .HasColumnType("text")
                .HasColumnName("EM_PRENSASEL_ING");
            entity.Property(e => e.EmPresta)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_PRESTA");
            entity.Property(e => e.EmPrestaMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_PRESTA_ME");
            entity.Property(e => e.EmPrffax)
                .HasMaxLength(500)
                .HasColumnName("EM_PRFFAX");
            entity.Property(e => e.EmPrftlf)
                .HasMaxLength(7)
                .HasColumnName("EM_PRFTLF");
            entity.Property(e => e.EmRegtri)
                .HasMaxLength(18)
                .HasColumnName("EM_REGTRI");
            entity.Property(e => e.EmRubro1)
                .HasColumnType("int(11)")
                .HasColumnName("EM_RUBRO1");
            entity.Property(e => e.EmSiglas)
                .HasMaxLength(50)
                .HasColumnName("EM_SIGLAS");
            entity.Property(e => e.EmSnopcr)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("EM_SNOPCR");
            entity.Property(e => e.EmSubacu)
                .HasColumnType("text")
                .HasColumnName("EM_SUBACU");
            entity.Property(e => e.EmSubacuIng)
                .HasColumnType("text")
                .HasColumnName("EM_SUBACU_ING");
            entity.Property(e => e.EmSupban)
                .HasColumnType("text")
                .HasColumnName("EM_SUPBAN");
            entity.Property(e => e.EmSupbanIng)
                .HasColumnType("text")
                .HasColumnName("EM_SUPBAN_ING");
            entity.Property(e => e.EmTarcred)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TARCRED");
            entity.Property(e => e.EmTarcredMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TARCRED_ME");
            entity.Property(e => e.EmTcsbs).HasColumnName("EM_TCSBS");
            entity.Property(e => e.EmTelef1)
                .HasMaxLength(500)
                .HasColumnName("EM_TELEF1");
            entity.Property(e => e.EmTelef2)
                .HasMaxLength(500)
                .HasColumnName("EM_TELEF2");
            entity.Property(e => e.EmTiopcr)
                .HasMaxLength(10)
                .HasColumnName("EM_TIOPCR");
            entity.Property(e => e.EmTipcamAnu).HasColumnName("EM_TIPCAM_ANU");
            entity.Property(e => e.EmTipcamAnu2).HasColumnName("EM_TIPCAM_ANU2");
            entity.Property(e => e.EmTipper)
                .HasColumnType("int(2)")
                .HasColumnName("EM_TIPPER");
            entity.Property(e => e.EmTipvia)
                .HasMaxLength(15)
                .HasColumnName("EM_TIPVIA");
            entity.Property(e => e.EmTotdeu)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TOTDEU");
            entity.Property(e => e.EmTotdeuMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TOTDEU_ME");
            entity.Property(e => e.EmTototr)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TOTOTR");
            entity.Property(e => e.EmTototr2)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TOTOTR2");
            entity.Property(e => e.EmTototr2Me)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TOTOTR2_ME");
            entity.Property(e => e.EmTototrMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("EM_TOTOTR_ME");
            entity.Property(e => e.EmUsuario)
                .HasMaxLength(50)
                .HasColumnName("EM_USUARIO");
            entity.Property(e => e.EmVentasAnu).HasColumnName("EM_VENTAS_ANU");
            entity.Property(e => e.EmVentasAnu2).HasColumnName("EM_VENTAS_ANU2");
            entity.Property(e => e.IdiCodigo)
                .HasMaxLength(2)
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.JuCodigo)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("JU_CODIGO");
            entity.Property(e => e.JuNombre)
                .HasMaxLength(80)
                .HasColumnName("JU_NOMBRE");
            entity.Property(e => e.OcCodigo)
                .HasMaxLength(3)
                .HasColumnName("OC_CODIGO");
            entity.Property(e => e.OcDescri)
                .HasColumnType("text")
                .HasColumnName("OC_DESCRI");
            entity.Property(e => e.OcDescriIng)
                .HasColumnType("text")
                .HasColumnName("OC_DESCRI_ING");
            entity.Property(e => e.PaCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("PA_CODIGO");
            entity.Property(e => e.PaNombre)
                .HasMaxLength(85)
                .HasColumnName("PA_NOMBRE");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.PaiDoctrb)
                .HasMaxLength(6)
                .HasColumnName("PAI_DOCTRB");
            entity.Property(e => e.PaiNombreCas)
                .HasMaxLength(45)
                .HasColumnName("PAI_NOMBRE_CAS");
            entity.Property(e => e.PeNombre)
                .HasMaxLength(100)
                .HasColumnName("PE_NOMBRE");
            entity.Property(e => e.PerCodage)
                .HasMaxLength(3)
                .HasColumnName("PER_CODAGE");
            entity.Property(e => e.PerCoddig)
                .HasMaxLength(3)
                .HasColumnName("PER_CODDIG");
            entity.Property(e => e.PerCodref)
                .HasMaxLength(100)
                .HasColumnName("PER_CODREF");
            entity.Property(e => e.PerCodrep)
                .HasMaxLength(3)
                .HasColumnName("PER_CODREP");
            entity.Property(e => e.PerCodsup)
                .HasMaxLength(3)
                .HasColumnName("PER_CODSUP");
            entity.Property(e => e.PerCodtra)
                .HasMaxLength(3)
                .HasColumnName("PER_CODTRA");
            entity.Property(e => e.SitCodigo)
                .HasMaxLength(2)
                .HasColumnName("SIT_CODIGO");
            entity.Property(e => e.SitDesde)
                .HasMaxLength(30)
                .HasColumnName("SIT_DESDE");
            entity.Property(e => e.SitNombre)
                .HasMaxLength(50)
                .HasColumnName("SIT_NOMBRE");
            entity.Property(e => e.TaNombre)
                .HasMaxLength(50)
                .HasColumnName("TA_NOMBRE");
            entity.Property(e => e.TdCodigo)
                .HasMaxLength(2)
                .HasColumnName("TD_CODIGO");
            entity.Property(e => e.TdNombre)
                .HasMaxLength(50)
                .HasColumnName("TD_NOMBRE");
            entity.Property(e => e.TlNombre)
                .HasMaxLength(50)
                .HasColumnName("TL_NOMBRE");
            entity.Property(e => e.TramCodigo)
                .HasMaxLength(2)
                .HasColumnName("TRAM_CODIGO");
            entity.Property(e => e.TramNombre)
                .HasMaxLength(2)
                .HasColumnName("TRAM_NOMBRE");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasComment("Usuario que abrio el Informe")
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<TTemporalPersona>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tTemporalPersona");

            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.AtFecdev)
                .HasComment("'Fecha de devolucion de la Traductora")
                .HasColumnType("datetime")
                .HasColumnName("AT_FECDEV");
            entity.Property(e => e.CalCodigoPer)
                .HasMaxLength(3)
                .HasDefaultValueSql("''")
                .HasColumnName("CAL_CODIGO_PER");
            entity.Property(e => e.CoCodigo)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("CO_CODIGO");
            entity.Property(e => e.CoNombre)
                .HasColumnType("text")
                .HasColumnName("CO_NOMBRE");
            entity.Property(e => e.CrCodigo)
                .HasMaxLength(4)
                .HasColumnName("CR_CODIGO");
            entity.Property(e => e.CrNombre)
                .HasMaxLength(100)
                .HasColumnName("CR_NOMBRE");
            entity.Property(e => e.CsoCodigo)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(2)")
                .HasColumnName("CSO_CODIGO");
            entity.Property(e => e.CsoNombre)
                .HasMaxLength(50)
                .HasColumnName("CSO_NOMBRE");
            entity.Property(e => e.CupCodigo)
                .HasMaxLength(20)
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.CupFecped)
                .HasMaxLength(10)
                .HasColumnName("CUP_FECPED");
            entity.Property(e => e.CupNomsol)
                .HasMaxLength(100)
                .HasColumnName("CUP_NOMSOL");
            entity.Property(e => e.CupNroref)
                .HasMaxLength(100)
                .HasColumnName("CUP_NROREF");
            entity.Property(e => e.CupTipinf)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("CUP_TIPINF");
            entity.Property(e => e.EcCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasComment("Estado Civil")
                .HasColumnName("EC_CODIGO");
            entity.Property(e => e.EcNombre)
                .HasMaxLength(20)
                .HasColumnName("EC_NOMBRE");
            entity.Property(e => e.ErCodigo)
                .HasMaxLength(2)
                .HasColumnName("ER_CODIGO");
            entity.Property(e => e.ErNombre)
                .HasMaxLength(50)
                .HasColumnName("ER_NOMBRE");
            entity.Property(e => e.ErNombreIng)
                .HasMaxLength(50)
                .HasColumnName("ER_NOMBRE_ING");
            entity.Property(e => e.EsCodigo)
                .HasMaxLength(2)
                .HasColumnName("ES_CODIGO");
            entity.Property(e => e.EsNombre)
                .HasMaxLength(50)
                .HasColumnName("ES_NOMBRE");
            entity.Property(e => e.IdiCodigo)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(2)")
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.PaCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("PA_CODIGO");
            entity.Property(e => e.PaNombre)
                .HasMaxLength(80)
                .HasColumnName("PA_NOMBRE");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.PaiDocide)
                .HasMaxLength(6)
                .HasColumnName("PAI_DOCIDE");
            entity.Property(e => e.PaiDoctrb)
                .HasMaxLength(6)
                .HasColumnName("PAI_DOCTRB");
            entity.Property(e => e.PaiNombreCas)
                .HasMaxLength(45)
                .HasColumnName("PAI_NOMBRE_CAS");
            entity.Property(e => e.PaiNombreTrab)
                .HasMaxLength(50)
                .HasComment("Pais del Centro de Trabajo")
                .HasColumnName("PAI_NOMBRE_TRAB");
            entity.Property(e => e.PeAlias)
                .HasMaxLength(100)
                .HasColumnName("PE_ALIAS");
            entity.Property(e => e.PeAntCua)
                .HasColumnType("text")
                .HasColumnName("Pe_AntCua");
            entity.Property(e => e.PeAntCuaIng)
                .HasColumnType("text")
                .HasColumnName("Pe_AntCua_Ing");
            entity.Property(e => e.PeAntcred)
                .HasColumnType("text")
                .HasColumnName("PE_ANTCRED");
            entity.Property(e => e.PeAntcredIng)
                .HasColumnType("text")
                .HasColumnName("PE_ANTCRED_ING");
            entity.Property(e => e.PeAntece)
                .HasColumnType("text")
                .HasColumnName("PE_ANTECE");
            entity.Property(e => e.PeAnteceIng)
                .HasColumnType("text")
                .HasColumnName("Pe_Antece_Ing");
            entity.Property(e => e.PeArrfin)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_ARRFIN");
            entity.Property(e => e.PeArrfinMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_ARRFIN_ME");
            entity.Property(e => e.PeAsegur)
                .HasMaxLength(60)
                .HasColumnName("PE_ASEGUR");
            entity.Property(e => e.PeBanco)
                .HasColumnType("text")
                .HasColumnName("PE_BANCO");
            entity.Property(e => e.PeBancoIng)
                .HasColumnType("text")
                .HasColumnName("Pe_Banco_Ing");
            entity.Property(e => e.PeCalsbs)
                .HasMaxLength(20)
                .HasColumnName("PE_CALSBS");
            entity.Property(e => e.PeCalsbsIng)
                .HasMaxLength(20)
                .HasColumnName("PE_CALSBS_ING");
            entity.Property(e => e.PeCampo1)
                .HasMaxLength(100)
                .HasComment("PARA EL REPORTE")
                .HasColumnName("PE_CAMPO1");
            entity.Property(e => e.PeCampo2)
                .HasMaxLength(100)
                .HasColumnName("PE_CAMPO2");
            entity.Property(e => e.PeCampo3)
                .HasMaxLength(100)
                .HasColumnName("PE_CAMPO3");
            entity.Property(e => e.PeCampo4)
                .HasMaxLength(100)
                .HasColumnName("PE_CAMPO4");
            entity.Property(e => e.PeCampo5)
                .HasMaxLength(100)
                .HasColumnName("PE_CAMPO5");
            entity.Property(e => e.PeCampo6)
                .HasMaxLength(100)
                .HasColumnName("PE_CAMPO6");
            entity.Property(e => e.PeCampo7)
                .HasMaxLength(100)
                .HasColumnName("PE_CAMPO7");
            entity.Property(e => e.PeCampo8)
                .HasMaxLength(100)
                .HasColumnName("PE_CAMPO8");
            entity.Property(e => e.PeCelula)
                .HasMaxLength(50)
                .HasColumnName("PE_CELULA");
            entity.Property(e => e.PeCenRieIng)
                .HasColumnType("text")
                .HasColumnName("Pe_CenRie_Ing");
            entity.Property(e => e.PeCenrie)
                .HasColumnType("text")
                .HasColumnName("PE_CENRIE");
            entity.Property(e => e.PeCiudad)
                .HasMaxLength(50)
                .HasColumnName("PE_CIUDAD");
            entity.Property(e => e.PeClub)
                .HasMaxLength(100)
                .HasColumnName("PE_CLUB");
            entity.Property(e => e.PeCodigo)
                .HasMaxLength(11)
                .HasColumnName("PE_CODIGO");
            entity.Property(e => e.PeCodpos)
                .HasMaxLength(20)
                .HasColumnName("PE_CODPOS");
            entity.Property(e => e.PeColegio)
                .HasMaxLength(50)
                .HasColumnName("PE_COLEGIO");
            entity.Property(e => e.PeColegioAnno)
                .HasMaxLength(4)
                .HasColumnName("Pe_Colegio_Anno");
            entity.Property(e => e.PeComRep)
                .HasColumnType("text")
                .HasColumnName("Pe_ComRep");
            entity.Property(e => e.PeComRepIng)
                .HasColumnType("text")
                .HasColumnName("Pe_ComRep_Ing");
            entity.Property(e => e.PeCombie)
                .HasColumnType("text")
                .HasColumnName("PE_COMBIE");
            entity.Property(e => e.PeCombieIng)
                .HasColumnType("text")
                .HasColumnName("PE_COMBIE_ING");
            entity.Property(e => e.PeComer)
                .HasColumnType("text")
                .HasColumnName("PE_COMER");
            entity.Property(e => e.PeComerIng)
                .HasColumnType("text")
                .HasColumnName("Pe_Comer_Ing");
            entity.Property(e => e.PeComexte)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_COMEXTE");
            entity.Property(e => e.PeComexteMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_COMEXTE_ME");
            entity.Property(e => e.PeComide)
                .HasComment("Comentario de Identificacion")
                .HasColumnType("text")
                .HasColumnName("PE_COMIDE");
            entity.Property(e => e.PeComideIng)
                .HasColumnType("text")
                .HasColumnName("PE_COMIDE_ING");
            entity.Property(e => e.PeComlit)
                .HasComment("Pais del Centro de Trabajo")
                .HasColumnType("text")
                .HasColumnName("PE_COMLIT");
            entity.Property(e => e.PeComlitIng)
                .HasComment("Pais del Centro de Trabajo")
                .HasColumnType("text")
                .HasColumnName("PE_COMLIT_ING");
            entity.Property(e => e.PeCompri)
                .HasMaxLength(200)
                .HasColumnName("PE_COMPRI");
            entity.Property(e => e.PeComprov)
                .HasComment("Pais del Centro de Trabajo")
                .HasColumnType("text")
                .HasColumnName("PE_COMPROV");
            entity.Property(e => e.PeComprovIng)
                .HasComment("Pais del Centro de Trabajo")
                .HasColumnType("text")
                .HasColumnName("PE_COMPROV_ING");
            entity.Property(e => e.PeCondoc)
                .HasComment("Condiciones Domiciliarias")
                .HasColumnType("text")
                .HasColumnName("PE_CONDOC");
            entity.Property(e => e.PeCondocIng)
                .HasColumnType("text")
                .HasColumnName("PE_CONDOC_ING");
            entity.Property(e => e.PeCorrecto)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("PE_CORRECTO");
            entity.Property(e => e.PeCtacte)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_CTACTE");
            entity.Property(e => e.PeCtacteMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_CTACTE_ME");
            entity.Property(e => e.PeDepart)
                .HasMaxLength(50)
                .HasColumnName("PE_DEPART");
            entity.Property(e => e.PeDescue)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_DESCUE");
            entity.Property(e => e.PeDescueMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_DESCUE_ME");
            entity.Property(e => e.PeDirecc)
                .HasMaxLength(200)
                .HasColumnName("PE_DIRECC");
            entity.Property(e => e.PeDireccCome)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("PE_DIRECC_COME");
            entity.Property(e => e.PeDistri)
                .HasMaxLength(50)
                .HasColumnName("PE_DISTRI");
            entity.Property(e => e.PeDocide)
                .HasMaxLength(50)
                .HasColumnName("PE_DOCIDE");
            entity.Property(e => e.PeEmail)
                .HasMaxLength(50)
                .HasColumnName("PE_EMAIL");
            entity.Property(e => e.PeFactor)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_FACTOR");
            entity.Property(e => e.PeFactorMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_FACTOR_ME");
            entity.Property(e => e.PeFecest)
                .HasMaxLength(15)
                .HasColumnName("PE_FECEST");
            entity.Property(e => e.PeFecinf)
                .HasColumnType("datetime")
                .HasColumnName("PE_FECINF");
            entity.Property(e => e.PeFecnac)
                .HasMaxLength(50)
                .HasColumnName("PE_FECNAC");
            entity.Property(e => e.PeFecnacIng)
                .HasMaxLength(50)
                .HasColumnName("PE_FECNAC_ING");
            entity.Property(e => e.PeFecref)
                .HasComment("'Fecha de devolucion de la Traductora")
                .HasColumnType("datetime")
                .HasColumnName("PE_FECREF");
            entity.Property(e => e.PeFecreg)
                .HasMaxLength(10)
                .HasColumnName("PE_FECREG");
            entity.Property(e => e.PeFecsbs)
                .HasMaxLength(10)
                .HasColumnName("PE_FECSBS");
            entity.Property(e => e.PeFoto)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("Pe_Foto");
            entity.Property(e => e.PeGaome)
                .HasDefaultValueSql("'0'")
                .HasColumnName("PE_GAOME");
            entity.Property(e => e.PeGaomn)
                .HasDefaultValueSql("'0'")
                .HasColumnName("PE_GAOMN");
            entity.Property(e => e.PeGrains)
                .HasMaxLength(100)
                .HasColumnName("PE_GRAINS");
            entity.Property(e => e.PeGrainsIng)
                .HasMaxLength(100)
                .HasColumnName("PE_GRAINS_ING");
            entity.Property(e => e.PeHijos)
                .HasMaxLength(80)
                .HasColumnName("PE_HIJOS");
            entity.Property(e => e.PeHijosIng)
                .HasMaxLength(80)
                .HasColumnName("PE_HIJOS_ING");
            entity.Property(e => e.PeIngMe2Ing)
                .HasMaxLength(50)
                .HasColumnName("Pe_IngMe2_Ing");
            entity.Property(e => e.PeLbienes)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("PE_LBIENES");
            entity.Property(e => e.PeLogico)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("PE_LOGICO");
            entity.Property(e => e.PeLogpre)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(2)")
                .HasColumnName("Pe_LOGPRE");
            entity.Property(e => e.PeLrefer)
                .HasDefaultValueSql("'0'")
                .HasComment("Indicador de Referencias")
                .HasColumnType("int(1)")
                .HasColumnName("PE_LREFER");
            entity.Property(e => e.PeLrefier)
                .HasDefaultValueSql("'0'")
                .HasComment("Indicador Refiere")
                .HasColumnType("int(1)")
                .HasColumnName("PE_LREFIER");
            entity.Property(e => e.PeLrelac)
                .HasDefaultValueSql("'0'")
                .HasComment("Indicador de Relacionados")
                .HasColumnType("int(1)")
                .HasColumnName("PE_LRELAC");
            entity.Property(e => e.PeLugnac)
                .HasMaxLength(50)
                .HasColumnName("PE_LUGNAC");
            entity.Property(e => e.PeMadre)
                .HasMaxLength(50)
                .HasColumnName("Pe_Madre");
            entity.Property(e => e.PeMadreVive)
                .HasMaxLength(3)
                .HasColumnName("Pe_Madre_Vive");
            entity.Property(e => e.PeNacion)
                .HasMaxLength(40)
                .HasColumnName("PE_NACION");
            entity.Property(e => e.PeNacionIng)
                .HasMaxLength(40)
                .HasColumnName("PE_NACION_ING");
            entity.Property(e => e.PeNombre)
                .HasMaxLength(100)
                .HasColumnName("PE_NOMBRE");
            entity.Property(e => e.PeNombreCome)
                .HasMaxLength(200)
                .HasDefaultValueSql("''")
                .HasColumnName("PE_NOMBRE_COME");
            entity.Property(e => e.PeNomvia)
                .HasMaxLength(100)
                .HasColumnName("PE_NOMVIA");
            entity.Property(e => e.PeNument)
                .HasMaxLength(5)
                .HasColumnName("PE_NUMENT");
            entity.Property(e => e.PeObscen)
                .HasColumnType("text")
                .HasColumnName("PE_OBSCEN");
            entity.Property(e => e.PeObsdom)
                .HasColumnType("text")
                .HasColumnName("PE_OBSDOM");
            entity.Property(e => e.PeObserv)
                .HasColumnType("text")
                .HasColumnName("PE_OBSERV");
            entity.Property(e => e.PeObservIng)
                .HasColumnType("text")
                .HasColumnName("Pe_Observ_Ing");
            entity.Property(e => e.PeOtrRecIng)
                .HasColumnType("text")
                .HasColumnName("Pe_OtrRec_Ing");
            entity.Property(e => e.PeOtrdeu)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_OTRDEU");
            entity.Property(e => e.PeOtrdeuMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_OTRDEU_ME");
            entity.Property(e => e.PeOtros)
                .HasMaxLength(35)
                .HasColumnName("PE_OTROS");
            entity.Property(e => e.PeOtros2)
                .HasMaxLength(35)
                .HasColumnName("PE_OTROS2");
            entity.Property(e => e.PeOtros2Ing)
                .HasMaxLength(35)
                .HasColumnName("PE_OTROS2_ING");
            entity.Property(e => e.PeOtrosIng)
                .HasMaxLength(35)
                .HasColumnName("PE_OTROS_ING");
            entity.Property(e => e.PeOtrrec)
                .HasColumnType("text")
                .HasColumnName("PE_OTRREC");
            entity.Property(e => e.PePadre)
                .HasMaxLength(50)
                .HasColumnName("Pe_Padre");
            entity.Property(e => e.PePadreVive)
                .HasMaxLength(3)
                .HasColumnName("Pe_Padre_Vive");
            entity.Property(e => e.PePedido)
                .HasMaxLength(10)
                .HasColumnName("PE_PEDIDO");
            entity.Property(e => e.PePerRel)
                .HasColumnType("text")
                .HasColumnName("Pe_PerRel");
            entity.Property(e => e.PePerRelIng)
                .HasColumnType("text")
                .HasColumnName("Pe_PerRel_Ing");
            entity.Property(e => e.PePiso)
                .HasMaxLength(30)
                .HasColumnName("PE_PISO");
            entity.Property(e => e.PePrensa)
                .HasComment("Comentario de Prensa")
                .HasColumnType("text")
                .HasColumnName("PE_PRENSA");
            entity.Property(e => e.PePrensaIng)
                .HasColumnType("text")
                .HasColumnName("Pe_PRENSA_ING");
            entity.Property(e => e.PePrensasel)
                .HasColumnType("text")
                .HasColumnName("Pe_PRENSASEL");
            entity.Property(e => e.PePrensaselIng)
                .HasColumnType("text")
                .HasColumnName("PE_PRENSASEL_ING");
            entity.Property(e => e.PePresta)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_PRESTA");
            entity.Property(e => e.PePrestaMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_PRESTA_ME");
            entity.Property(e => e.PePrftlf)
                .HasMaxLength(7)
                .HasColumnName("PE_PRFTLF");
            entity.Property(e => e.PeRefere)
                .HasMaxLength(30)
                .HasColumnName("PE_REFERE");
            entity.Property(e => e.PeRegtri)
                .HasMaxLength(18)
                .HasColumnName("PE_REGTRI");
            entity.Property(e => e.PeRelciv)
                .HasMaxLength(50)
                .HasColumnName("PE_RELCIV");
            entity.Property(e => e.PeRelcivDni)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("PE_RELCIV_DNI");
            entity.Property(e => e.PeRelcivIng)
                .HasMaxLength(50)
                .HasColumnName("PE_RELCIV_ING");
            entity.Property(e => e.PeSer)
                .HasMaxLength(1)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("PE_SER");
            entity.Property(e => e.PeSubacu)
                .HasComment("Pais del Centro de Trabajo")
                .HasColumnType("text")
                .HasColumnName("PE_SUBACU");
            entity.Property(e => e.PeSubacuIng)
                .HasComment("Pais del Centro de Trabajo")
                .HasColumnType("text")
                .HasColumnName("PE_SUBACU_ING");
            entity.Property(e => e.PeSupban)
                .HasComment("Pais del Centro de Trabajo")
                .HasColumnType("text")
                .HasColumnName("PE_SUPBAN");
            entity.Property(e => e.PeSupbanIng)
                .HasComment("Pais del Centro de Trabajo")
                .HasColumnType("text")
                .HasColumnName("PE_SUPBAN_ING");
            entity.Property(e => e.PeTarcred)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_TARCRED");
            entity.Property(e => e.PeTarcredMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_TARCRED_ME");
            entity.Property(e => e.PeTcsbs).HasColumnName("PE_TCSBS");
            entity.Property(e => e.PeTelefo)
                .HasMaxLength(50)
                .HasColumnName("PE_TELEFO");
            entity.Property(e => e.PeTipdom)
                .HasMaxLength(50)
                .HasColumnName("PE_TIPDOM");
            entity.Property(e => e.PeTipdomIng)
                .HasMaxLength(50)
                .HasColumnName("PE_TIPDOM_ING");
            entity.Property(e => e.PeTipvia)
                .HasMaxLength(15)
                .HasColumnName("PE_TIPVIA");
            entity.Property(e => e.PeTitulo1)
                .HasMaxLength(100)
                .HasComment("PARA EL REPORTE")
                .HasColumnName("PE_TITULO1");
            entity.Property(e => e.PeTitulo2)
                .HasMaxLength(100)
                .HasColumnName("PE_TITULO2");
            entity.Property(e => e.PeTitulo3)
                .HasMaxLength(100)
                .HasColumnName("PE_TITULO3");
            entity.Property(e => e.PeTitulo4)
                .HasMaxLength(100)
                .HasColumnName("PE_TITULO4");
            entity.Property(e => e.PeTitulo5)
                .HasMaxLength(100)
                .HasColumnName("PE_TITULO5");
            entity.Property(e => e.PeTitulo6)
                .HasMaxLength(100)
                .HasColumnName("PE_TITULO6");
            entity.Property(e => e.PeTitulo7)
                .HasMaxLength(100)
                .HasColumnName("PE_TITULO7");
            entity.Property(e => e.PeTitulo8)
                .HasMaxLength(100)
                .HasColumnName("PE_TITULO8");
            entity.Property(e => e.PeTotdeu)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_TOTDEU");
            entity.Property(e => e.PeTotdeuMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_TOTDEU_ME");
            entity.Property(e => e.PeTototr)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_TOTOTR");
            entity.Property(e => e.PeTototr2)
                .HasMaxLength(35)
                .HasColumnName("PE_TOTOTR2");
            entity.Property(e => e.PeTototr2Me)
                .HasMaxLength(35)
                .HasColumnName("PE_TOTOTR2_ME");
            entity.Property(e => e.PeTototrMe)
                .HasMaxLength(17)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("PE_TOTOTR_ME");
            entity.Property(e => e.PeUsuario)
                .HasMaxLength(50)
                .HasColumnName("PE_USUARIO");
            entity.Property(e => e.PeValdom)
                .HasMaxLength(50)
                .HasColumnName("PE_VALDOM");
            entity.Property(e => e.PeValdomIng)
                .HasMaxLength(50)
                .HasColumnName("PE_VALDOM_ING");
            entity.Property(e => e.PeVer)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("PE_VER");
            entity.Property(e => e.PerCodage)
                .HasMaxLength(3)
                .HasColumnName("PER_CODAGE");
            entity.Property(e => e.PerCoddig)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("PER_CODDIG");
            entity.Property(e => e.PerCodref)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("PER_CODREF");
            entity.Property(e => e.PerCodrep)
                .HasMaxLength(3)
                .HasColumnName("PER_CODREP");
            entity.Property(e => e.PerCodsup)
                .HasMaxLength(3)
                .HasComment("'Fecha de devolucion de la Traductora")
                .HasColumnName("PER_CODSUP");
            entity.Property(e => e.PerCodtra)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("PER_CODTRA");
            entity.Property(e => e.PfCodigo)
                .HasMaxLength(4)
                .HasColumnName("PF_CODIGO");
            entity.Property(e => e.PfNombre)
                .HasMaxLength(60)
                .HasDefaultValueSql("'Profesion'")
                .HasColumnName("PF_NOMBRE");
            entity.Property(e => e.PfNombreIng)
                .HasMaxLength(60)
                .HasColumnName("PF_NOMBRE_ING");
            entity.Property(e => e.PpAbrevi)
                .HasMaxLength(50)
                .HasColumnName("PP_ABREVI");
            entity.Property(e => e.PpCodigo)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(2)")
                .HasColumnName("PP_CODIGO");
            entity.Property(e => e.RcCodigo)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("RC_CODIGO");
            entity.Property(e => e.RcNombre)
                .HasMaxLength(70)
                .HasColumnName("RC_NOMBRE");
            entity.Property(e => e.SexCodigo)
                .HasMaxLength(2)
                .HasColumnName("SEX_CODIGO");
            entity.Property(e => e.SexDescri)
                .HasMaxLength(15)
                .HasColumnName("SEX_DESCRI");
            entity.Property(e => e.SexDescriIng)
                .HasMaxLength(15)
                .HasColumnName("SEX_DESCRI_ING");
            entity.Property(e => e.TiAbrevia)
                .HasMaxLength(50)
                .HasColumnName("TI_ABREVIA");
            entity.Property(e => e.TiAbreviaIng)
                .HasMaxLength(10)
                .HasColumnName("TI_ABREVIA_ING");
            entity.Property(e => e.TiCodigo)
                .HasMaxLength(10)
                .HasColumnName("TI_CODIGO");
            entity.Property(e => e.TiNombre)
                .HasMaxLength(50)
                .HasColumnName("TI_NOMBRE");
            entity.Property(e => e.TiNombreIng)
                .HasMaxLength(50)
                .HasColumnName("TI_NOMBRE_ING");
            entity.Property(e => e.TramCodigo)
                .HasMaxLength(4)
                .HasColumnName("TRAM_CODIGO");
            entity.Property(e => e.TramNombre)
                .HasMaxLength(15)
                .HasColumnName("TRAM_NOMBRE");
            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("US_CODIGO");
        });

        modelBuilder.Entity<TTenden>(entity =>
        {
            entity.HasKey(e => e.TdCodigo).HasName("PRIMARY");

            entity.ToTable("tTenden");

            entity.Property(e => e.TdCodigo)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .HasColumnName("Td_Codigo");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.TdActivo)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)")
                .HasColumnName("TD_ACTIVO");
            entity.Property(e => e.TdImagen)
                .HasColumnType("mediumblob")
                .HasColumnName("TD_IMAGEN");
            entity.Property(e => e.TdNombre)
                .HasMaxLength(50)
                .HasColumnName("Td_Nombre");
            entity.Property(e => e.TdNombreIng)
                .HasMaxLength(50)
                .HasColumnName("Td_Nombre_Ing");
            entity.Property(e => e.TdSimbol)
                .HasMaxLength(1)
                .HasColumnName("TD_Simbol");
        });

        modelBuilder.Entity<TTipDocIden>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tTipDocIden");

            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.TiAbrevia)
                .HasMaxLength(10)
                .HasColumnName("TI_ABREVIA");
            entity.Property(e => e.TiAbreviaIng)
                .HasMaxLength(10)
                .HasColumnName("TI_ABREVIA_ING");
            entity.Property(e => e.TiCodigo)
                .HasMaxLength(10)
                .HasColumnName("TI_CODIGO");
            entity.Property(e => e.TiEmpper)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("TI_EMPPER");
            entity.Property(e => e.TiNombre)
                .HasMaxLength(50)
                .HasColumnName("TI_NOMBRE");
            entity.Property(e => e.TiNombreIng)
                .HasMaxLength(50)
                .HasColumnName("TI_NOMBRE_ING");
        });

        modelBuilder.Entity<TTipoLocal>(entity =>
        {
            entity.HasKey(e => e.TlCodigo).HasName("PRIMARY");

            entity.ToTable("tTipoLocal");

            entity.Property(e => e.TlCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TL_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.TlNombre)
                .HasMaxLength(50)
                .HasColumnName("TL_NOMBRE");
            entity.Property(e => e.TlNombreIng)
                .HasMaxLength(50)
                .HasColumnName("TL_NOMBRE_ING");
        });

        modelBuilder.Entity<TTipoTramite>(entity =>
        {
            entity.HasKey(e => e.TramCodigo).HasName("PRIMARY");

            entity.ToTable("tTipoTramite");

            entity.Property(e => e.TramCodigo)
                .HasMaxLength(2)
                .HasColumnName("TRAM_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.TramAbrev)
                .HasMaxLength(15)
                .HasColumnName("TRAM_ABREV");
            entity.Property(e => e.TramEstado)
                .HasColumnType("int(1)")
                .HasColumnName("TRAM_ESTADO");
            entity.Property(e => e.TramNombre)
                .HasMaxLength(2)
                .HasColumnName("TRAM_NOMBRE");
            entity.Property(e => e.TramObserv)
                .HasMaxLength(150)
                .HasColumnName("TRAM_OBSERV");
        });

        modelBuilder.Entity<TTmpEmpresa>(entity =>
        {
            entity.HasKey(e => e.UsCodigo).HasName("PRIMARY");

            entity.ToTable("tTmpEmpresa");

            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasComment("Usuario que abrio el Informe")
                .HasColumnName("US_CODIGO");
            entity.Property(e => e.AboCodigo)
                .HasMaxLength(4)
                .HasColumnName("ABO_CODIGO");
            entity.Property(e => e.AtFecdev)
                .HasMaxLength(10)
                .HasColumnName("AT_FECDEV");
            entity.Property(e => e.CrCodigo)
                .HasMaxLength(4)
                .HasColumnName("CR_CODIGO");
            entity.Property(e => e.CrNombre)
                .HasMaxLength(50)
                .HasColumnName("CR_NOMBRE");
            entity.Property(e => e.CupCodigo)
                .HasMaxLength(20)
                .HasColumnName("CUP_CODIGO");
            entity.Property(e => e.CupFecped)
                .HasMaxLength(20)
                .HasColumnName("CUP_FECPED");
            entity.Property(e => e.CupNroord)
                .HasMaxLength(20)
                .HasColumnName("CUP_NROORD");
            entity.Property(e => e.CupRefabo)
                .HasMaxLength(80)
                .HasColumnName("CUP_REFABO");
            entity.Property(e => e.CupTipinf)
                .HasMaxLength(2)
                .HasColumnName("CUP_TIPINF");
            entity.Property(e => e.EmAnobal)
                .HasMaxLength(4)
                .HasColumnName("EM_ANOBAL");
            entity.Property(e => e.EmAnofun)
                .HasMaxLength(4)
                .HasColumnName("EM_ANOFUN");
            entity.Property(e => e.EmAntcre)
                .HasColumnType("text")
                .HasColumnName("EM_ANTCRE");
            entity.Property(e => e.EmAntcreIng)
                .HasColumnType("text")
                .HasColumnName("EM_ANTCRE_ING");
            entity.Property(e => e.EmBalgen)
                .HasDefaultValueSql("'0'")
                .HasComment("0")
                .HasColumnType("int(4)")
                .HasColumnName("EM_BALGEN");
            entity.Property(e => e.EmBalsit)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(4)")
                .HasColumnName("EM_BALSIT");
            entity.Property(e => e.EmBanco)
                .HasColumnType("text")
                .HasColumnName("EM_BANCO");
            entity.Property(e => e.EmBancoIng)
                .HasColumnType("text")
                .HasColumnName("EM_BANCO_ING");
            entity.Property(e => e.EmCenrie)
                .HasColumnType("text")
                .HasColumnName("EM_CENRIE");
            entity.Property(e => e.EmCenrieIng)
                .HasColumnType("text")
                .HasColumnName("EM_CENRIE_ING");
            entity.Property(e => e.EmCiudad)
                .HasMaxLength(50)
                .HasColumnName("EM_CIUDAD");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(11)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EmCodpos)
                .HasMaxLength(20)
                .HasColumnName("EM_CODPOS");
            entity.Property(e => e.EmComide)
                .HasColumnType("text")
                .HasColumnName("EM_COMIDE");
            entity.Property(e => e.EmComideIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMIDE_ING");
            entity.Property(e => e.EmComlit)
                .HasColumnType("text")
                .HasColumnName("EM_COMLIT");
            entity.Property(e => e.EmComlitIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMLIT_ING");
            entity.Property(e => e.EmComprov)
                .HasColumnType("text")
                .HasColumnName("EM_COMPROV");
            entity.Property(e => e.EmComprovIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMPROV_ING");
            entity.Property(e => e.EmComrep)
                .HasColumnType("text")
                .HasColumnName("EM_COMREP");
            entity.Property(e => e.EmComrepIng)
                .HasColumnType("text")
                .HasColumnName("EM_COMREP_ING");
            entity.Property(e => e.EmDepart)
                .HasMaxLength(50)
                .HasColumnName("EM_DEPART");
            entity.Property(e => e.EmDirecc)
                .HasMaxLength(200)
                .HasColumnName("EM_DIRECC");
            entity.Property(e => e.EmDistri)
                .HasMaxLength(50)
                .HasColumnName("EM_DISTRI");
            entity.Property(e => e.EmEmail)
                .HasMaxLength(50)
                .HasColumnName("EM_EMAIL");
            entity.Property(e => e.EmFax)
                .HasMaxLength(50)
                .HasColumnName("EM_FAX");
            entity.Property(e => e.EmFecinf)
                .HasColumnType("datetime")
                .HasColumnName("EM_FECINF");
            entity.Property(e => e.EmInfgen)
                .HasColumnType("text")
                .HasColumnName("EM_INFGEN");
            entity.Property(e => e.EmInfgenIng)
                .HasColumnType("text")
                .HasColumnName("EM_INFGEN_ING");
            entity.Property(e => e.EmIngecu)
                .HasColumnType("text")
                .HasColumnName("EM_INGECU");
            entity.Property(e => e.EmIngecuIng)
                .HasColumnType("text")
                .HasColumnName("EM_INGECU_ING");
            entity.Property(e => e.EmLoggrafico)
                .HasDefaultValueSql("'0'")
                .HasComment("Si es 1 es xq existe valores para grafico de activo corriente ,pasivo corriente y patrimonio")
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGGRAFICO");
            entity.Property(e => e.EmLogico)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("EM_LOGICO");
            entity.Property(e => e.EmLogpre)
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGPRE");
            entity.Property(e => e.EmLogventas)
                .HasDefaultValueSql("'0'")
                .HasComment("Si es 1 es xq existe ventas para poder ver el grafico")
                .HasColumnType("int(1)")
                .HasColumnName("EM_LOGVENTAS");
            entity.Property(e => e.EmMtopcr)
                .HasMaxLength(32)
                .HasColumnName("EM_MTOPCR");
            entity.Property(e => e.EmMtopcrIng)
                .HasMaxLength(32)
                .HasColumnName("EM_MTOPCR_ING");
            entity.Property(e => e.EmNombre)
                .HasMaxLength(120)
                .HasColumnName("EM_NOMBRE");
            entity.Property(e => e.EmNomcrr)
                .HasMaxLength(3)
                .HasComment("Nombre Correcto Si o No")
                .HasColumnName("EM_NOMCRR");
            entity.Property(e => e.EmNomsol)
                .HasMaxLength(100)
                .HasColumnName("EM_NOMSOL");
            entity.Property(e => e.EmNomvia)
                .HasMaxLength(100)
                .HasColumnName("EM_NOMVIA");
            entity.Property(e => e.EmOpicre)
                .HasColumnType("text")
                .HasColumnName("EM_OPICRE");
            entity.Property(e => e.EmOpicreIng)
                .HasColumnType("text")
                .HasColumnName("EM_OPICRE_ING");
            entity.Property(e => e.EmPagweb)
                .HasMaxLength(50)
                .HasColumnName("EM_PAGWEB");
            entity.Property(e => e.EmPiso)
                .HasMaxLength(30)
                .HasColumnName("EM_PISO");
            entity.Property(e => e.EmPrensa)
                .HasColumnType("text")
                .HasColumnName("EM_PRENSA");
            entity.Property(e => e.EmPrensaIng)
                .HasColumnType("text")
                .HasColumnName("EM_PRENSA_ING");
            entity.Property(e => e.EmPrensasel)
                .HasColumnType("text")
                .HasColumnName("EM_PRENSASEL");
            entity.Property(e => e.EmPrensaselIng)
                .HasColumnType("text")
                .HasColumnName("EM_PRENSASEL_ING");
            entity.Property(e => e.EmPrffax)
                .HasMaxLength(7)
                .HasColumnName("EM_PRFFAX");
            entity.Property(e => e.EmPrftlf)
                .HasMaxLength(7)
                .HasColumnName("EM_PRFTLF");
            entity.Property(e => e.EmRegtri)
                .HasMaxLength(18)
                .HasColumnName("EM_REGTRI");
            entity.Property(e => e.EmSiglas)
                .HasMaxLength(50)
                .HasColumnName("EM_SIGLAS");
            entity.Property(e => e.EmSnopcr)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("EM_SNOPCR");
            entity.Property(e => e.EmSubacu)
                .HasColumnType("text")
                .HasColumnName("EM_SUBACU");
            entity.Property(e => e.EmSubacuIng)
                .HasColumnType("text")
                .HasColumnName("EM_SUBACU_ING");
            entity.Property(e => e.EmSupban)
                .HasColumnType("text")
                .HasColumnName("EM_SUPBAN");
            entity.Property(e => e.EmSupbanIng)
                .HasColumnType("text")
                .HasColumnName("EM_SUPBAN_ING");
            entity.Property(e => e.EmTelef1)
                .HasMaxLength(50)
                .HasColumnName("EM_TELEF1");
            entity.Property(e => e.EmTelef2)
                .HasMaxLength(50)
                .HasColumnName("EM_TELEF2");
            entity.Property(e => e.EmTiopcr)
                .HasMaxLength(10)
                .HasColumnName("EM_TIOPCR");
            entity.Property(e => e.EmTipper)
                .HasColumnType("int(2)")
                .HasColumnName("EM_TIPPER");
            entity.Property(e => e.EmTipvia)
                .HasMaxLength(15)
                .HasColumnName("EM_TIPVIA");
            entity.Property(e => e.EmUsuario)
                .HasMaxLength(50)
                .HasColumnName("EM_USUARIO");
            entity.Property(e => e.IdiCodigo)
                .HasMaxLength(2)
                .HasColumnName("IDI_CODIGO");
            entity.Property(e => e.JuCodigo)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("JU_CODIGO");
            entity.Property(e => e.JuNombre)
                .HasMaxLength(80)
                .HasColumnName("JU_NOMBRE");
            entity.Property(e => e.PaCodigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("PA_CODIGO");
            entity.Property(e => e.PaNombre)
                .HasMaxLength(65)
                .HasColumnName("PA_NOMBRE");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.PaiDoctrb)
                .HasMaxLength(6)
                .HasColumnName("PAI_DOCTRB");
            entity.Property(e => e.PaiNombreCas)
                .HasMaxLength(45)
                .HasColumnName("PAI_NOMBRE_CAS");
            entity.Property(e => e.PeNombre)
                .HasMaxLength(100)
                .HasColumnName("PE_NOMBRE");
            entity.Property(e => e.PerCodage)
                .HasMaxLength(3)
                .HasColumnName("PER_CODAGE");
            entity.Property(e => e.PerCoddig)
                .HasMaxLength(3)
                .HasColumnName("PER_CODDIG");
            entity.Property(e => e.PerCodrep)
                .HasMaxLength(3)
                .HasColumnName("PER_CODREP");
            entity.Property(e => e.PerCodtra)
                .HasMaxLength(3)
                .HasColumnName("PER_CODTRA");
            entity.Property(e => e.SitCodigo)
                .HasMaxLength(2)
                .HasColumnName("SIT_CODIGO");
            entity.Property(e => e.SitNombre)
                .HasMaxLength(50)
                .HasColumnName("SIT_NOMBRE");
            entity.Property(e => e.TdCodigo)
                .HasMaxLength(2)
                .HasColumnName("TD_CODIGO");
            entity.Property(e => e.TdNombre)
                .HasMaxLength(50)
                .HasColumnName("TD_NOMBRE");
            entity.Property(e => e.TramCodigo)
                .HasMaxLength(2)
                .HasColumnName("TRAM_CODIGO");
            entity.Property(e => e.TramNombre)
                .HasMaxLength(2)
                .HasColumnName("TRAM_NOMBRE");
        });

        modelBuilder.Entity<TTop>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tTop");

            entity.Property(e => e.BaFecbal1)
                .HasMaxLength(10)
                .HasColumnName("BA_FECBAL1");
            entity.Property(e => e.BaTipcam1).HasColumnName("BA_TIPCAM1");
            entity.Property(e => e.BaVentas1).HasColumnName("BA_VENTAS1");
            entity.Property(e => e.CrNombre)
                .HasMaxLength(200)
                .HasColumnName("CR_NOMBRE");
            entity.Property(e => e.EmActivi)
                .HasColumnType("mediumtext")
                .HasColumnName("EM_ACTIVI");
            entity.Property(e => e.EmAnofun)
                .HasMaxLength(100)
                .HasColumnName("EM_ANOFUN");
            entity.Property(e => e.EmCiiu)
                .HasMaxLength(100)
                .HasColumnName("EM_CIIU");
            entity.Property(e => e.EmCiudad)
                .HasMaxLength(150)
                .HasColumnName("EM_CIUDAD");
            entity.Property(e => e.EmCodpos)
                .HasMaxLength(100)
                .HasColumnName("EM_CODPOS");
            entity.Property(e => e.EmDepart)
                .HasMaxLength(100)
                .HasColumnName("EM_DEPART");
            entity.Property(e => e.EmDirecc)
                .HasMaxLength(200)
                .HasColumnName("EM_DIRECC");
            entity.Property(e => e.EmFecinf)
                .HasColumnType("datetime")
                .HasColumnName("EM_FECINF");
            entity.Property(e => e.EmLogexp)
                .HasMaxLength(3)
                .HasColumnName("EM_LOGEXP");
            entity.Property(e => e.EmLogimp)
                .HasMaxLength(3)
                .HasColumnName("EM_LOGIMP");
            entity.Property(e => e.EmMoneda)
                .HasMaxLength(100)
                .HasColumnName("EM_MONEDA");
            entity.Property(e => e.EmNombre)
                .HasMaxLength(150)
                .HasColumnName("EM_NOMBRE");
            entity.Property(e => e.EmPagweb)
                .HasMaxLength(100)
                .HasColumnName("EM_PAGWEB");
            entity.Property(e => e.EmPaicod)
                .HasColumnType("int(3)")
                .HasColumnName("EM_PAICOD");
            entity.Property(e => e.EmPais)
                .HasMaxLength(100)
                .HasColumnName("EM_PAIS");
            entity.Property(e => e.EmRegtri)
                .HasMaxLength(100)
                .HasColumnName("EM_REGTRI");
            entity.Property(e => e.EmSiglas)
                .HasMaxLength(150)
                .HasColumnName("EM_SIGLAS");
            entity.Property(e => e.EmTelefo)
                .HasMaxLength(100)
                .HasColumnName("EM_TELEFO");
            entity.Property(e => e.EmTrabaj)
                .HasMaxLength(100)
                .HasColumnName("EM_TRABAJ");
            entity.Property(e => e.EmVentas).HasColumnName("EM_VENTAS");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.PaNombre)
                .HasMaxLength(200)
                .HasColumnName("PA_NOMBRE");
            entity.Property(e => e.PeNombre)
                .HasMaxLength(150)
                .HasColumnName("PE_NOMBRE");
        });

        modelBuilder.Entity<TUsuario>(entity =>
        {
            entity.HasKey(e => e.UsCodigo).HasName("PRIMARY");

            entity.ToTable("tUsuario", tb => tb.HasComment("0 - No Imprime\r\n1 - Si Imprime"));

            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("Us_Codigo");
            entity.Property(e => e.IdPersonal)
                .HasMaxLength(4)
                .HasColumnName("Id_Personal");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.UsAnalis)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_ANALIS");
            entity.Property(e => e.UsBasdat)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_BASDAT");
            entity.Property(e => e.UsCargo)
                .HasMaxLength(50)
                .HasComment("Si->Seguir Mostrando/// No->No Volver a Mostrar")
                .HasColumnName("US_CARGO");
            entity.Property(e => e.UsConsul)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_CONSUL");
            entity.Property(e => e.UsCuadro)
                .HasColumnType("int(1)")
                .HasColumnName("US_CUADRO");
            entity.Property(e => e.UsEmail)
                .HasMaxLength(50)
                .HasComment("Si->Seguir Mostrando/// No->No Volver a Mostrar")
                .HasColumnName("US_EMAIL");
            entity.Property(e => e.UsEstado)
                .HasDefaultValueSql("'0'")
                .HasColumnName("Us_Estado");
            entity.Property(e => e.UsFactur)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_FACTUR");
            entity.Property(e => e.UsFoto)
                .HasColumnType("mediumblob")
                .HasColumnName("US_FOTO");
            entity.Property(e => e.UsImprime)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_IMPRIME");
            entity.Property(e => e.UsIngsis)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_INGSIS");
            entity.Property(e => e.UsIp)
                .HasMaxLength(15)
                .HasColumnName("Us_IP");
            entity.Property(e => e.UsLogin)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("Us_Login");
            entity.Property(e => e.UsNombre)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("Us_Nombre");
            entity.Property(e => e.UsNoveda)
                .HasMaxLength(2)
                .HasComment("Si->Seguir Mostrando/// No->No Volver a Mostrar")
                .HasColumnName("US_NOVEDA");
            entity.Property(e => e.UsPassword)
                .HasColumnType("text")
                .HasColumnName("Us_Password");
            entity.Property(e => e.UsProces)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_PROCES");
            entity.Property(e => e.UsSistema)
                .HasMaxLength(12)
                .HasColumnName("Us_Sistema");
            entity.Property(e => e.UsTipemp)
                .HasMaxLength(2)
                .HasComment("Tipo de Empleado: AD=Administrativo  PR=Produccion")
                .HasColumnName("US_TIPEMP");
            entity.Property(e => e.UsTipo)
                .HasMaxLength(1)
                .HasColumnName("US_TIPO");
            entity.Property(e => e.UsTodReg)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("Us_TodReg");
            entity.Property(e => e.UsWord)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_WORD");
        });

        modelBuilder.Entity<TUsuario2>(entity =>
        {
            entity.HasKey(e => e.UsCodigo).HasName("PRIMARY");

            entity.ToTable("tUsuario2");

            entity.Property(e => e.UsCodigo)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("Us_Codigo");
            entity.Property(e => e.IdPersonal)
                .HasMaxLength(4)
                .HasColumnName("Id_Personal");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.UsAnalis)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_ANALIS");
            entity.Property(e => e.UsBasdat)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_BASDAT");
            entity.Property(e => e.UsCargo)
                .HasMaxLength(50)
                .HasComment("Si->Seguir Mostrando/// No->No Volver a Mostrar")
                .HasColumnName("US_CARGO");
            entity.Property(e => e.UsConsul)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_CONSUL");
            entity.Property(e => e.UsCuadro)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_CUADRO");
            entity.Property(e => e.UsEmail)
                .HasMaxLength(50)
                .HasComment("Si->Seguir Mostrando/// No->No Volver a Mostrar")
                .HasColumnName("US_EMAIL");
            entity.Property(e => e.UsEstado)
                .HasDefaultValueSql("'0'")
                .HasColumnName("Us_Estado");
            entity.Property(e => e.UsFactur)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_FACTUR");
            entity.Property(e => e.UsIngsis)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_INGSIS");
            entity.Property(e => e.UsIp)
                .HasMaxLength(15)
                .HasColumnName("Us_IP");
            entity.Property(e => e.UsLogin)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("Us_Login");
            entity.Property(e => e.UsNombre)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("Us_Nombre");
            entity.Property(e => e.UsNoveda)
                .HasMaxLength(2)
                .HasComment("Si->Seguir Mostrando/// No->No Volver a Mostrar")
                .HasColumnName("US_NOVEDA");
            entity.Property(e => e.UsPassword)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("Us_Password");
            entity.Property(e => e.UsProces)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("US_PROCES");
            entity.Property(e => e.UsSistema)
                .HasMaxLength(12)
                .HasColumnName("Us_Sistema");
            entity.Property(e => e.UsTipo)
                .HasMaxLength(1)
                .HasColumnName("US_TIPO");
            entity.Property(e => e.UsTodReg)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(1)")
                .HasColumnName("Us_TodReg");
        });

        modelBuilder.Entity<TUsuarioWeb>(entity =>
        {
            entity.HasKey(e => e.UwCodigo).HasName("PRIMARY");

            entity.ToTable("tUsuarioWeb");

            entity.Property(e => e.UwCodigo)
                .HasColumnType("int(3)")
                .HasColumnName("UW_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.UwLogin)
                .HasMaxLength(50)
                .HasComment("Nombre por el cual se va a Logear")
                .HasColumnName("UW_LOGIN");
            entity.Property(e => e.UwNombre)
                .HasMaxLength(100)
                .HasColumnName("UW_NOMBRE");
            entity.Property(e => e.UwPassword)
                .HasMaxLength(50)
                .HasColumnName("UW_PASSWORD");
        });

        modelBuilder.Entity<TVirtual>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tVirtual");

            entity.Property(e => e.EmCiudad)
                .HasMaxLength(50)
                .HasColumnName("EM_CIUDAD");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(7)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EmNombre)
                .HasMaxLength(120)
                .HasColumnName("EM_NOMBRE");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.ViCadena)
                .HasMaxLength(50)
                .HasColumnName("VI_CADENA");
            entity.Property(e => e.ViCodigo)
                .HasColumnType("int(11)")
                .HasColumnName("VI_CODIGO");
            entity.Property(e => e.ViFecreg)
                .HasColumnType("datetime")
                .HasColumnName("VI_FECREG");
            entity.Property(e => e.ViFlag)
                .HasColumnType("int(1)")
                .HasColumnName("VI_FLAG");
            entity.Property(e => e.ViUsuario)
                .HasMaxLength(6)
                .HasColumnName("VI_USUARIO");
        });

        modelBuilder.Entity<TViviendaPer>(entity =>
        {
            entity.HasKey(e => e.VivCodigo).HasName("PRIMARY");

            entity.ToTable("tViviendaPers");

            entity.Property(e => e.VivCodigo)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("VIV_CODIGO");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
            entity.Property(e => e.VivNombre)
                .HasMaxLength(25)
                .HasColumnName("VIV_NOMBRE");
            entity.Property(e => e.VivNombreIng)
                .HasMaxLength(25)
                .HasColumnName("VIV_NOMBRE_ING");
        });

        modelBuilder.Entity<Tempo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_Tempo");

            entity.Property(e => e.EmEmpresa)
                .HasMaxLength(11)
                .HasColumnName("em_empresa");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasColumnName("nombre");
            entity.Property(e => e.Proceso)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("proceso");
            entity.Property(e => e.Rfc)
                .HasMaxLength(50)
                .HasColumnName("rfc");
        });

        modelBuilder.Entity<TemporalE>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TemporalE");

            entity.Property(e => e.EmAnobal)
                .HasMaxLength(100)
                .HasColumnName("EM_ANOBAL");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(50)
                .HasColumnName("EM_CODIGO");
            entity.Property(e => e.EmNombre)
                .HasMaxLength(900)
                .HasColumnName("EM_NOMBRE");
            entity.Property(e => e.PaiCodigo)
                .HasMaxLength(3)
                .HasColumnName("PAI_CODIGO");
            entity.Property(e => e.PaiNombreCas)
                .HasMaxLength(600)
                .HasColumnName("PAI_NOMBRE_CAS");
        });

        modelBuilder.Entity<TemporalP>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TemporalP");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(50)
                .HasColumnName("EM_CODIGO");
        });

        modelBuilder.Entity<TemporalV>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TemporalV");

            entity.Property(e => e.EmCodigo)
                .HasMaxLength(50)
                .HasColumnName("EM_CODIGO");
        });

        modelBuilder.Entity<ViewConsultaWeb>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_CONSULTA_WEB");

            entity.Property(e => e.Actividad).HasColumnType("text");
            entity.Property(e => e.ActividadIngles).HasColumnType("text");
            entity.Property(e => e.AnoFundacion).HasMaxLength(4);
            entity.Property(e => e.Calidad).HasMaxLength(40);
            entity.Property(e => e.CalidadCodigo).HasMaxLength(3);
            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.CodigoEmpresa)
                .HasMaxLength(11)
                .HasComment("Código Interno de la Empresa PRINCIPAL");
            entity.Property(e => e.CodigoIdioma)
                .HasDefaultValueSql("'0'")
                .HasComment("Tipo de Idioma/Traducción")
                .HasColumnType("int(2)");
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Empresa).HasMaxLength(120);
            entity.Property(e => e.Exporta)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.FechaBalance1).HasMaxLength(10);
            entity.Property(e => e.FechaBalance2).HasMaxLength(10);
            entity.Property(e => e.FechaBalance3).HasMaxLength(10);
            entity.Property(e => e.FechaInforme)
                .HasComment("Fecha del Informe")
                .HasColumnType("datetime");
            entity.Property(e => e.Importa)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.NumeroRegistro).HasMaxLength(18);
            entity.Property(e => e.Pais).HasMaxLength(45);
            entity.Property(e => e.PaisAbreviatura).HasMaxLength(3);
            entity.Property(e => e.PaisCodigo).HasMaxLength(3);
            entity.Property(e => e.PaisesExporta).HasMaxLength(1000);
            entity.Property(e => e.PaisesImporta).HasMaxLength(1000);
            entity.Property(e => e.Persona).HasMaxLength(100);
            entity.Property(e => e.Ramo).HasMaxLength(150);
            entity.Property(e => e.RamoActividad).HasMaxLength(200);
            entity.Property(e => e.RamoActividadIngles).HasMaxLength(200);
            entity.Property(e => e.RamoCodigo)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.RamoIngles).HasMaxLength(150);
            entity.Property(e => e.Sector).HasMaxLength(100);
            entity.Property(e => e.SectorIngles).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(500);
        });

        modelBuilder.Entity<WsConsulta>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("WS_Consultas");

            entity.Property(e => e.AboCodigo)
                .HasMaxLength(10)
                .HasColumnName("abo_Codigo");
            entity.Property(e => e.EmCodigo)
                .HasMaxLength(50)
                .HasColumnName("em_Codigo");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Flag).HasColumnType("tinyint(4)");
            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Migra)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("MIGRA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
