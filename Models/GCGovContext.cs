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
    public virtual DbSet<Edital> Editais { get; set; }
    public virtual DbSet<NaturezaDespesa> NaturezasDespesas { get; set; }
    public virtual DbSet<Modalidade> Modalidades { get; set; }
    public virtual DbSet<Pagamento> Pagamentos { get; set; }
    public virtual DbSet<PgtosModalidade> PgtosModalidades { get; set; }
    public virtual DbSet<PgtosOrigem> PgtosOrigens { get; set; }
    public virtual DbSet<Portaria> Portarias { get; set; }
    public virtual DbSet<PortariaServidor> PortariasServidores { get; set; }
    public virtual DbSet<Servidor> Servidores { get; set; }
    public virtual DbSet<UgDepartamento> UgDepartamentos { get; set; }
    public virtual DbSet<UgUsuario> UgUsuarios { get; set; }
    public virtual DbSet<UnidadesGestora> UnidadesGestoras { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Tipo> Tipo { get; set; }
    public virtual DbSet<Complexidade> Complexidade { get; set; }
    public virtual DbSet<ViewPessoasPorContrato> PessoasPorContratos { get; set; }
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
         
            entity.HasKey(e => e.AdtId).HasName("PK__Aditivos__46EAF0F798F91158");
            entity.HasIndex(e => e.AdtNum, "UQ__Aditivos__05AB3439C4DCA937").IsUnique();
            entity.Property(e => e.AdtId).HasColumnName("AdtID");
            entity.Property(e => e.AdtData).HasColumnType("date");
            entity.Property(e => e.AdtNum).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ContratoId).HasColumnName("ContratoID");
            entity.Property(e => e.AdtDesc).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.AdtValor).HasColumnType("decimal(10, 2)");
            entity.HasOne(d => d.Contrato).WithMany(p => p.Aditivos)
                .HasForeignKey(d => d.ContratoId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Aditivos__Contra__7CA47C3F");
        });

        modelBuilder.Entity<Apostilamento>(entity =>
        {
            entity.HasKey(e => e.AptId).HasName("PK__Apostila__8D24E752119BE287");
            entity.HasIndex(e => e.AptNum, "UQ__Apostila__656D61EE2AAA83F2").IsUnique();
            entity.Property(e => e.AptId).HasColumnName("AptID");
            entity.Property(e => e.AptData).HasColumnType("date");
            entity.Property(e => e.AptDesc).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.AptNum).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ContratoId).HasColumnName("ContratoID");
            entity.Property(e => e.AptValor).HasColumnType("decimal(10, 2)");
            entity.HasOne(d => d.Contrato).WithMany(p => p.Apostilamentos)
                .HasForeignKey(d => d.ContratoId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Apostilam__Contr__00750D23");
        });

        modelBuilder.Entity<Auditoria>(entity =>
        {
            entity.HasKey(e => e.AuditoriaId).HasName("PK__Auditori__095694E3D5BDF910");
            entity.Property(e => e.AuditoriaId).HasColumnName("AuditoriaID");
            entity.Property(e => e.Acao).HasMaxLength(10).IsUnicode(false);
            entity.Property(e => e.Antes).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.Chave).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.DataHora).HasColumnType("date");
            entity.Property(e => e.Depois).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.Tabela).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.Usuario).HasMaxLength(70).IsUnicode(false);
        });

		modelBuilder.Entity<Complexidade>(entity =>
		{
			entity.HasKey(e => e.ComplexId).HasName("PK__Complexi__E14B3DF612E4C4B2");
			entity.ToTable("Complexidade");
			entity.Property(e => e.ComplexId).HasColumnName("ComplexID");
			entity.Property(e => e.ComplexNome).HasMaxLength(255).IsUnicode(false);
		}); 
        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.ContratoId).HasName("PK__Contrato__B238E95388C29E8D");
            entity.HasIndex(e => e.Extrato, "UQ__Contrato__D1F20E81274926C4").IsUnique();
            entity.Property(e => e.ContratoId).HasColumnName("ContratoID");
            entity.Property(e => e.Contratada).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Contratante).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.DataAssinatura).HasColumnType("date");
            entity.Property(e => e.DataInicio).HasColumnType("date");
            entity.Property(e => e.Extrato).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.LinkPublico).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ModId).HasColumnName("ModId");
            entity.Property(e => e.Objeto).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.ProcessoSei).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ProtocoloDiof).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ComplexId).HasColumnName("ComplexId");
            entity.Property(e => e.TipoId).HasColumnName("TipoId");
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.UgDpId).HasColumnName("UgDpID");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Modalidade).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.ModId)
                .HasConstraintName("FK__Contratos__ModId__731B1205");
            entity.HasOne(d => d.UgCodigo).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.UgCodigoId)
                .HasConstraintName("FK__Contratos__UgCod__740F363E");
            entity.HasOne(d => d.UgDp).WithMany(p => p.Contratos).HasForeignKey(d => d.UgDpId)
                .HasConstraintName("FK__Contratos__UgDpI__75035A77");
            entity.HasOne(d => d.Complex).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.ComplexId)
                .HasConstraintName("FK__Contratos__Compl__7132C993");
            entity.HasOne(d => d.Tipo).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.TipoId)
                .HasConstraintName("FK__Contratos__TipoI__7226EDCC");
        });

        modelBuilder.Entity<Edital>(entity =>
        {
            entity.HasKey(e => e.EdtId).HasName("PK__Editais__1E8172859374AC03");
            entity.HasIndex(e => e.EdtNum, "UQ__Editais__FBA2C042C2234F06").IsUnique();
            entity.Property(e => e.EdtId).HasColumnName("EdtID");
            entity.Property(e => e.ContratoId).HasColumnName("ContratoID");
            entity.Property(e => e.EdtData).HasColumnType("date");
            entity.Property(e => e.EdtLink).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.EdtNum).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.EdtTipo).HasMaxLength(255).IsUnicode(false);
            entity.HasOne(d => d.Contrato).WithMany(p => p.Editais)
                .HasForeignKey(d => d.ContratoId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Editais__Contrat__78D3EB5B");
        });

        modelBuilder.Entity<Modalidade>(entity =>
        {
            entity.HasKey(e => e.ModId).HasName("PK__Modalida__FB1F17A70615D70E");
            entity.ToTable("Modalidade");
            entity.Property(e => e.ModId).HasColumnName("ModId");
            entity.Property(e => e.ModNome).HasMaxLength(255).IsUnicode(false);
        });

        modelBuilder.Entity<NaturezaDespesa>(entity =>
        {
            entity.HasKey(e => e.NatDespId).HasName("PK__Natureza__E0A006FA8C5F3C69");
            entity.ToTable("NaturezaDespesa");
            entity.Property(e => e.NatDespId).ValueGeneratedNever();
            entity.Property(e => e.ElementoDespesa).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.FonteRecurso).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.ProgramaTrabalho).HasMaxLength(50).IsUnicode(false);

        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.PgtoId).HasName("PK__Pagament__DCC600649EEFD1B7");
            entity.HasIndex(e => e.NotaLancamento, "UQ__Pagament__12B0B6F1F6CEF56C").IsUnique();
            entity.Property(e => e.PgtoId).HasColumnName("PgtoID");
            entity.Property(e => e.DataPagamento).HasColumnType("date");
            entity.Property(e => e.NotaLancamento).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.OrdemBancaria).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Parcela).HasMaxLength(10).IsUnicode(false);
            entity.Property(e => e.PreparacaoPagamento).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.HasOne(d => d.PgtosOrigens).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.PgtoOrigemId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Pagamento__PgtoO__1EF99443");
        });

        modelBuilder.Entity<PgtosModalidade>(entity =>
        {
            entity.HasKey(e => e.PgtoModId).HasName("PK__PgtosMod__CDE0E12177B2323F");
            entity.ToTable("PgtosModalidade");
            entity.Property(e => e.PgtoModId).HasColumnName("PgtoModID");
            entity.Property(e => e.PgtoModNome).HasMaxLength(255).IsUnicode(false);
        });

        modelBuilder.Entity<PgtosOrigem>(entity =>
        {
            entity.HasKey(e => e.PgtoOrigemId).HasName("PK__PgtosOri__D93289D821679449");
            entity.ToTable("PgtosOrigem");
            entity.Property(e => e.PgtoOrigemId).HasColumnName("PgtoOrigemId");
            entity.Property(e => e.DataCadastro).HasColumnType("date");
            entity.Property(e => e.NotaEmpenho).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.PgtoModId).HasColumnName("PgtoModID");
            entity.Property(e => e.ContratoId).HasColumnName("ContratoID");
            entity.Property(e => e.NatDespId).HasColumnName("NatDespId");
            entity.HasOne(d => d.Contrato).WithMany(p => p.PgtosOrigens)
                .HasForeignKey(d => d.ContratoId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PgtosOrig__Contr__08162EEB");
            entity.HasOne(d => d.NatDesp).WithMany(p => p.PgtosOrigens)
                .HasForeignKey(d => d.NatDespId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PgtosOrig__NatDe__090A5324");
            entity.HasOne(d => d.PgtoMod).WithMany(p => p.PgtosOrigens)
                .HasForeignKey(d => d.PgtoModId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PgtosOrig__PgtoM__07220AB2");
        });

        modelBuilder.Entity<Portaria>(entity =>
        {
            entity.HasKey(e => e.PortariaId).HasName("PK__Portaria__19534B50A11B878A");
            entity.Property(e => e.PortariaId).HasColumnName("PortariaID");
            entity.Property(e => e.ContratoId).HasColumnName("ContratoID");
            entity.Property(e => e.DataInicio).HasColumnType("date");
            entity.Property(e => e.DataPublicacao).HasColumnType("date");
            entity.Property(e => e.PortariaNumero).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ProtocoloDiof).HasMaxLength(255).IsUnicode(false);
            entity.HasOne(d => d.Contrato).WithMany(p => p.Portaria)
                .HasForeignKey(d => d.ContratoId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Portarias__Contr__10AB74EC");
        });

        modelBuilder.Entity<PortariaServidor>(entity =>
        {
            entity.HasKey(e => e.PortariasServidorID).HasName("PK__Portaria__2434DCDB81FE3684");
            entity.Property(e => e.PortariasServidorID).HasColumnName("PortariasServidorID");
            entity.Property(e => e.Funcao).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.PortariaId).HasColumnName("PortariaID");
            entity.Property(e => e.Resolucao).HasMaxLength(255).IsUnicode(false);
            entity.HasOne(d => d.MatriculaNavigation).WithMany(p => p.PortariasServidores)
                .HasForeignKey(d => d.Matricula).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Portarias__Matri__1940BAED");
            entity.HasOne(d => d.Portaria).WithMany(p => p.PortariasServidores)
                .HasForeignKey(d => d.PortariaId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Portarias__Porta__184C96B4");
        });

		modelBuilder.Entity<Tipo>(entity =>
		{
			entity.HasKey(e => e.TipoId).HasName("PK__Tipo__97099E97546EE216");
			entity.ToTable("Tipo");
			entity.Property(e => e.TipoId).HasColumnName("TipoID");
			entity.Property(e => e.TipoNome).HasMaxLength(255).IsUnicode(false);
		});

		modelBuilder.Entity<Servidor>(entity =>
        {
            entity.HasKey(e => e.Matricula).HasName("PK__Servidor__0FB9FB4E8A404783");
            entity.Property(e => e.Matricula).ValueGeneratedNever();
            entity.Property(e => e.Cpf).HasMaxLength(11).IsUnicode(false).HasColumnName("CPF");
            entity.Property(e => e.Nome).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.UgDpId).HasColumnName("UgDpID");
            entity.HasOne(d => d.UgCodigo).WithMany(p => p.Servidores)
                .HasForeignKey(d => d.UgCodigoId)
                .HasConstraintName("FK__Servidore__UgCod__147C05D0");
            entity.HasOne(d => d.UgDp).WithMany(p => p.Servidores)
                .HasForeignKey(d => d.UgDpId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Servidore__UgDpI__15702A09");
        });

        modelBuilder.Entity<UgDepartamento>(entity =>
        {
            entity.HasKey(e => e.UgDpId).HasName("PK__UgDepart__7D98AA99BCD87F7D");
            entity.Property(e => e.UgDpId).HasColumnName("UgDpID");
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.UgDpNome).HasMaxLength(255).IsUnicode(false);
            entity.HasOne(d => d.UgCodigo).WithMany(p => p.UgDepartamentos)
                .HasForeignKey(d => d.UgCodigoId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__UgDeparta__UgCod__61F08603");
        });

        modelBuilder.Entity<UgUsuario>(entity =>
        {
            entity.HasKey(e => e.UgUsuariosId).HasName("PK__UgUsuari__390F23C2108357E8");
            entity.Property(e => e.UgUsuariosId).HasColumnName("UgUsuariosID");
            entity.Property(e => e.UgCodigoId).HasColumnName("UgCodigoID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.HasOne(d => d.UgCodigo).WithMany(p => p.UgUsuarios)
                .HasForeignKey(d => d.UgCodigoId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__UgUsuario__UgCod__67A95F59");
            entity.HasOne(d => d.Usuario).WithMany(p => p.UgUsuarios)
                .HasForeignKey(d => d.UsuarioId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__UgUsuario__Usuar__66B53B20");
        });

        modelBuilder.Entity<UnidadesGestora>(entity =>
        {
            entity.HasKey(e => e.UgCodigoId).HasName("PK__Unidades__EBE58E8F5419954B");
            entity.Property(e => e.UgCodigoId).ValueGeneratedNever().HasColumnName("UgCodigoID");
            entity.Property(e => e.UgCnpj).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgContato).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgNome).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.UgSigla).HasMaxLength(255).IsUnicode(false);

        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE79861FEA230");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Email).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.LoginCpf).HasMaxLength(255).IsUnicode(false).HasColumnName("LoginCPF");
            entity.Property(e => e.Nome).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Senha).HasMaxLength(255).IsUnicode(false);
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