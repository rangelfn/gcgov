using Microsoft.EntityFrameworkCore;

namespace GCGov.Models;

public partial class GCGovContext : DbContext
{
    public GCGovContext()
    {
    }

    public GCGovContext(DbContextOptions<GCGovContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aditivo> Aditivos { get; set; }
    public virtual DbSet<Apostilamento> Apostilamentos { get; set; }
    public virtual DbSet<Auditoria> Auditorias { get; set; }
    public virtual DbSet<Contrato> Contratos { get; set; }
    public virtual DbSet<DotacaoOrcamentaria> DotacaoOrcamentarias { get; set; }
    public virtual DbSet<Edital> Editais { get; set; }
    public virtual DbSet<ModLicitacao> ModLicitacoes { get; set; }
    public virtual DbSet<Pagamento> Pagamentos { get; set; }
    public virtual DbSet<ViewPessoasPorContrato> PessoasPorContratos { get; set; }
    public virtual DbSet<PgtosModalidade> PgtosModalidades { get; set; }
    public virtual DbSet<PgtosTipo> PgtosTipos { get; set; }
    public virtual DbSet<Portaria> Portarias { get; set; }
    public virtual DbSet<PortariaServidor> PortariasServidores { get; set; }
    public virtual DbSet<Servidor> Servidores { get; set; }
    public virtual DbSet<UgDepartamento> UgDepartamentos { get; set; }
    public virtual DbSet<UgUsuario> UgUsuarios { get; set; }
    public virtual DbSet<UnidadesGestora> UnidadesGestoras { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<ViewContratosPagamento> ViewContratosPagamentos { get; set; }
    public virtual DbSet<ViewDespesasPorContrato> DespesasPorContratos { get; set; }
    public virtual DbSet<ViewEditaisPorContrato> ViewEditaisPorContratos { get; set; }
    public virtual DbSet<ViewPagamentosTotalPorContrato> ViewPagamentosTotalPorContratos { get; set; }
    public virtual DbSet<ViewPortariasPorContrato> VwPortariasPorContratos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Aditivo>(entity =>
        {
         
            entity.HasKey(e => e.AdtId).HasName("PK__Aditivos__46EAF0F7B596C7A5");
            entity.HasIndex(e => e.AdtNum, "UC_AdtNum").IsUnique();
            entity.Property(e => e.AdtId).HasColumnName("AdtID");
            entity.Property(e => e.AdtData).HasColumnType("date");
            entity.Property(e => e.AdtNum).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ContratoId).HasColumnName("ContratoID");
            entity.Property(e => e.AdtDesc).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.AdtValor).HasColumnType("decimal(10, 2)");
            entity.HasOne(d => d.Contrato).WithMany(p => p.Aditivos)
                .HasForeignKey(d => d.ContratoId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Aditivos__Contra__0C1BC9F9");
        });

        modelBuilder.Entity<Apostilamento>(entity =>
        {
            entity.HasKey(e => e.AptId).HasName("PK__Apostila__8D24E752F4E26126");
            entity.HasIndex(e => e.AptNum, "UC_AptNum").IsUnique();
            entity.Property(e => e.AptId).HasColumnName("AptID");
            entity.Property(e => e.AptData).HasColumnType("date");
            entity.Property(e => e.AptDesc).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.AptNum).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ContratoId).HasColumnName("ContratoID");
            entity.Property(e => e.AptValor).HasColumnType("decimal(10, 2)");
            entity.HasOne(d => d.Contrato).WithMany(p => p.Apostilamentos)
                .HasForeignKey(d => d.ContratoId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Apostilam__Contr__0EF836A4");
        });

        modelBuilder.Entity<Auditoria>(entity =>
        {
            entity.HasKey(e => e.AuditoriaId).HasName("PK__Auditori__095694E3CB27DF6E");
            entity.Property(e => e.AuditoriaId).HasColumnName("AuditoriaID");
            entity.Property(e => e.Acao).HasMaxLength(10).IsUnicode(false);
            entity.Property(e => e.Antes).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.Chave).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.DataHora).HasColumnType("date");
            entity.Property(e => e.Depois).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.Tabela).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.Usuario).HasMaxLength(70).IsUnicode(false);
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.ContratoId).HasName("PK__Contrato__B238E953E80E5665");
            entity.HasIndex(e => e.Extrato, "UC_Extrato").IsUnique();
            entity.Property(e => e.ContratoId).HasColumnName("ContratoID");
            entity.Property(e => e.Contratada).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Contratante).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.DataAssinatura).HasColumnType("date");
            entity.Property(e => e.DataInicio).HasColumnType("date");
            entity.Property(e => e.Extrato).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.LinkPublico).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ModLicitacaoId).HasColumnName("ModLicitacaoID");
            entity.Property(e => e.Objeto).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.ProcessoSei).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ProtocoloDiof).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.UgDpId).HasColumnName("UgDpID");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.HasOne(d => d.ModLicitacao).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.ModLicitacaoId)
                .HasConstraintName("FK__Contratos__ModLi__047AA831");
            entity.HasOne(d => d.UgCodigo).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.UgCodigoId)
                .HasConstraintName("FK__Contratos__UgCod__056ECC6A");
            entity.HasOne(d => d.UgDp).WithMany(p => p.Contratos).HasForeignKey(d => d.UgDpId)
                .HasConstraintName("FK__Contratos__UgDpI__0662F0A3");
        });

        modelBuilder.Entity<ViewDespesasPorContrato>(entity =>
        {
            entity.HasNoKey().ToView("DespesasPorContratos");
            entity.Property(e => e.Acao).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Contratada).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Elemento).HasMaxLength(8).IsUnicode(false);
            entity.Property(e => e.Fonte).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.ModId).HasColumnName("ModID");
            entity.Property(e => e.Natureza).HasMaxLength(14).IsUnicode(false);
            entity.Property(e => e.Objeto).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.ProcessoSei).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Programa).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<DotacaoOrcamentaria>(entity =>
        {
            entity.HasKey(e => e.NaturezaDespesa).HasName("PK__DotacaoO__006DDAF49D1143B5");
            entity.Property(e => e.NaturezaDespesa).ValueGeneratedNever();
        });

        modelBuilder.Entity<Edital>(entity =>
        {
            entity.HasKey(e => e.EdtId).HasName("PK__Editais__1E817285C0807669");
            entity.HasIndex(e => e.EdtNum, "UC_EdtNum").IsUnique();
            entity.Property(e => e.EdtId).HasColumnName("EdtID");
            entity.Property(e => e.ContratoId).HasColumnName("ContratoID");
            entity.Property(e => e.EdtData).HasColumnType("date");
            entity.Property(e => e.EdtLink).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.EdtNum).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.EdtTipo).HasMaxLength(255).IsUnicode(false);
            entity.HasOne(d => d.Contrato).WithMany(p => p.Editais)
                .HasForeignKey(d => d.ContratoId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Editais__Contrat__093F5D4E");
        });

        modelBuilder.Entity<ModLicitacao>(entity =>
        {
            entity.HasKey(e => e.ModLicitacaoId).HasName("PK__ModLicit__FE9CF016C0C5EC6E");
            entity.ToTable("ModLicitacao");
            entity.Property(e => e.ModLicitacaoId).HasColumnName("ModLicitacaoID");
            entity.Property(e => e.ModNome).HasMaxLength(255).IsUnicode(false);
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.PgtoId).HasName("PK__Pagament__DCC60064C7FA0206");
            entity.HasIndex(e => e.NotaLancamento, "UC_NotaLancamento").IsUnique();
            entity.Property(e => e.PgtoId).HasColumnName("PgtoID");
            entity.Property(e => e.DataPagamento).HasColumnType("date");
            entity.Property(e => e.NotaLancamento).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.OrdemBancaria).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Parcela).HasMaxLength(10).IsUnicode(false);
            entity.Property(e => e.PgtoTipoId).HasColumnName("PgtoTipoID");
            entity.Property(e => e.PreparacaoPagamento).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.HasOne(d => d.PgtoTipo).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.PgtoTipoId).OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Pagamento__PgtoT__1A69E950");
        });

        modelBuilder.Entity<PgtosModalidade>(entity =>
        {
            entity.HasKey(e => e.PgtoModId).HasName("PK__PgtosMod__CDE0E121192A7843");
            entity.ToTable("PgtosModalidade");
            entity.Property(e => e.PgtoModId).HasColumnName("PgtoModID");
            entity.Property(e => e.PgtoModNome).HasMaxLength(255).IsUnicode(false);
        });

        modelBuilder.Entity<PgtosTipo>(entity =>
        {
            entity.HasKey(e => e.PgtoTipoId).HasName("PK__PgtosTip__CA71D8F6BA7EF8E2");
            entity.Property(e => e.PgtoTipoId).HasColumnName("PgtoTipoID");
            entity.Property(e => e.ContratoId).HasColumnName("ContratoID");
            entity.Property(e => e.DataCadastro).HasColumnType("date");
            entity.Property(e => e.NotaEmpenho).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.PgtoModId).HasColumnName("PgtoModID");
            entity.HasOne(d => d.Contrato).WithMany(p => p.PgtosTipos)
                .HasForeignKey(d => d.ContratoId).OnDelete(DeleteBehavior.Cascade)
             .HasConstraintName("FK__PgtosTipo__Contr__1699586C");
            entity.HasOne(d => d.NaturezaDespesaNavigation).WithMany(p => p.PgtosTipos)
                .HasForeignKey(d => d.NaturezaDespesa).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PgtosTipo__Natur__178D7CA5");
            entity.HasOne(d => d.PgtoMod).WithMany(p => p.PgtosTipos)
             .HasForeignKey(d => d.PgtoModId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PgtosTipo__PgtoM__15A53433");
        });

        modelBuilder.Entity<Portaria>(entity =>
        {
            entity.HasKey(e => e.PortariaId).HasName("PK__Portaria__19534B500D08A0D8");
            entity.Property(e => e.PortariaId).HasColumnName("PortariaID");
            entity.Property(e => e.ContratoId).HasColumnName("ContratoID");
            entity.Property(e => e.DataInicio).HasColumnType("date");
            entity.Property(e => e.DataPublicacao).HasColumnType("date");
            entity.Property(e => e.PortariaNumero).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ProtocoloDiof).HasMaxLength(255).IsUnicode(false);
            entity.HasOne(d => d.Contrato).WithMany(p => p.Portaria)
                .HasForeignKey(d => d.ContratoId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Portarias__Contr__1E3A7A34");
        });

        modelBuilder.Entity<PortariaServidor>(entity =>
        {
            entity.HasKey(e => e.PortariasPessoasId).HasName("PK__Portaria__3F98A5D10F60BA5E");
            entity.Property(e => e.PortariasPessoasId).HasColumnName("PortariasPessoasID");
            entity.Property(e => e.Funcao).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.PortariaId).HasColumnName("PortariaID");
            entity.Property(e => e.Resolucao).HasMaxLength(255).IsUnicode(false);
            entity.HasOne(d => d.MatriculaNavigation).WithMany(p => p.PortariasServidores)
                .HasForeignKey(d => d.Matricula).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Portarias__Matri__27C3E46E");
            entity.HasOne(d => d.Portaria).WithMany(p => p.PortariasServidores)
                .HasForeignKey(d => d.PortariaId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Portarias__Porta__26CFC035");
        });

        modelBuilder.Entity<Servidor>(entity =>
        {
            entity.HasKey(e => e.Matricula).HasName("PK__Servidor__0FB9FB4E339FD2DB");
            entity.Property(e => e.Matricula).ValueGeneratedNever();
            entity.Property(e => e.Cpf).HasMaxLength(11).IsUnicode(false).HasColumnName("CPF");
            entity.Property(e => e.Nome).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.UgDpId).HasColumnName("UgDpID");
            entity.HasOne(d => d.UgCodigo).WithMany(p => p.Servidores)
                .HasForeignKey(d => d.UgCodigoId)
                .HasConstraintName("FK__Servidore__UgCod__22FF2F51");
            entity.HasOne(d => d.UgDp).WithMany(p => p.Servidores)
                .HasForeignKey(d => d.UgDpId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Servidore__UgDpI__23F3538A");
        });

        modelBuilder.Entity<UgDepartamento>(entity =>
        {
            entity.HasKey(e => e.UgDpId).HasName("PK__UgDepart__7D98AA99128B9E4F");
            entity.Property(e => e.UgDpId).HasColumnName("UgDpID");
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.UgDpNome).HasMaxLength(255).IsUnicode(false);
            entity.HasOne(d => d.UgCodigo).WithMany(p => p.UgDepartamentos)
                .HasForeignKey(d => d.UgCodigoId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__UgDeparta__UgCod__762C88DA");
        });

        modelBuilder.Entity<UgUsuario>(entity =>
        {
            entity.HasKey(e => e.UgUsuariosId).HasName("PK__UgUsuari__390F23C2D0392C03");
            entity.Property(e => e.UgUsuariosId).HasColumnName("UgUsuariosID");
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.HasOne(d => d.UgCodigo).WithMany(p => p.UgUsuarios)
                .HasForeignKey(d => d.UgCodigoId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__UgUsuario__UgCod__7FB5F314");
            entity.HasOne(d => d.Usuario).WithMany(p => p.UgUsuarios)
                .HasForeignKey(d => d.UsuarioId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__UgUsuario__Usuar__7EC1CEDB");
        });

        modelBuilder.Entity<UnidadesGestora>(entity =>
        {
            entity.HasKey(e => e.UgCodigoId).HasName("PK__Unidades__EBE58E8F5419954B");
            entity.Property(e => e.UgCodigoId).ValueGeneratedNever().HasColumnName("UgCodigoID");
            entity.Property(e => e.UgCnpj).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgContato).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgNome).HasMaxLength(255).IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE798B299829D");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Email).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.LoginCpf).HasMaxLength(255).IsUnicode(false).HasColumnName("LoginCPF");
            entity.Property(e => e.Nome).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Senha).HasMaxLength(255).IsUnicode(false);
        });

        modelBuilder.Entity<ViewContratosPagamento>(entity =>
        {
            entity.HasNoKey().ToView("ViewContratosPagamentos");
            entity.Property(e => e.Contratada).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.DataPagamento).HasColumnType("date");
            entity.Property(e => e.ModId).HasColumnName("ModID");
            entity.Property(e => e.NotaEmpenho).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.NotaLancamento).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Objeto).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.OrdemBancaria).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.PgtoModalidade).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.PreparacaoPagamento).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ProcessoSei).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorPagamento).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<ViewContratosPagamento>(entity =>
        {
            entity.HasNoKey().ToView("ViewContratosPagamentos");
            entity.Property(e => e.Contratada).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.DataPagamento).HasColumnType("date");
            entity.Property(e => e.ModId).HasColumnName("ModID");
            entity.Property(e => e.NotaEmpenho).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.NotaLancamento).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Objeto).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.OrdemBancaria).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.PgtoModalidade).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.PreparacaoPagamento).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ProcessoSei).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorPagamento).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<ViewEditaisPorContrato>(entity =>
        {
            entity.HasNoKey().ToView("ViewEditaisPorContratos");
            entity.Property(e => e.Contratada).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.EdtData).HasColumnType("date");
            entity.Property(e => e.EdtNum).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.EdtTipo).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ModId).HasColumnName("ModID");
            entity.Property(e => e.Objeto).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.ProcessoSei).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<ViewPagamentosTotalPorContrato>(entity =>
        {
            entity.HasNoKey().ToView("ViewPagamentosTotalPorContrato");
            entity.Property(e => e.Contratada).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ModId).HasColumnName("ModID");
            entity.Property(e => e.NotasLancamento).HasMaxLength(8000).IsUnicode(false);
            entity.Property(e => e.Objeto).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.ProcessoSei).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorTotalPagamentos).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<ViewPessoasPorContrato>(entity =>
        {
            entity.HasNoKey().ToView("PessoasPorContratos");
            entity.Property(e => e.Contratada).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Funcao).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Matricula).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ModId).HasColumnName("ModID");
            entity.Property(e => e.Nome).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Objeto).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.ProcessoSei).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Tipo).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<ViewPortariasPorContrato>(entity =>
        {
            entity.HasNoKey().ToView("ViewPortariasPorContratos");
            entity.Property(e => e.Contratada).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.DataPublicacao).HasColumnType("date");
            entity.Property(e => e.ModId).HasColumnName("ModID");
            entity.Property(e => e.Objeto).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.PortariaNumero).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ProcessoSei).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ProtocoloDiof).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}