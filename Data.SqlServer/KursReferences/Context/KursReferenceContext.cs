using Data.SqlServer.KursReferences.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.KursReferences.Context;

public partial class KursReferenceContext : DbContext
{
    private readonly string _connectionString;
    public KursReferenceContext()
    {
    }

    public KursReferenceContext(string connString)
    {
        _connectionString = connString;
    }

    public KursReferenceContext(DbContextOptions<KursReferenceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<COUNTRY> COUNTRY { get; set; }

    public virtual DbSet<NomenklMain> NomenklMain { get; set; }

    public virtual DbSet<Project> Project { get; set; }

    public virtual DbSet<SD_102> SD_102 { get; set; }

    public virtual DbSet<SD_103> SD_103 { get; set; }

    public virtual DbSet<SD_111> SD_111 { get; set; }

    public virtual DbSet<SD_114> SD_114 { get; set; }

    public virtual DbSet<SD_119> SD_119 { get; set; }

    public virtual DbSet<SD_148> SD_148 { get; set; }

    public virtual DbSet<SD_175> SD_175 { get; set; }

    public virtual DbSet<SD_179> SD_179 { get; set; }

    public virtual DbSet<SD_189> SD_189 { get; set; }

    public virtual DbSet<SD_2> SD_2 { get; set; }

    public virtual DbSet<SD_22> SD_22 { get; set; }

    public virtual DbSet<SD_23> SD_23 { get; set; }

    public virtual DbSet<SD_27> SD_27 { get; set; }

    public virtual DbSet<SD_301> SD_301 { get; set; }

    public virtual DbSet<SD_303> SD_303 { get; set; }

    public virtual DbSet<SD_40> SD_40 { get; set; }

    public virtual DbSet<SD_43> SD_43 { get; set; }

    public virtual DbSet<SD_44> SD_44 { get; set; }

    public virtual DbSet<SD_50> SD_50 { get; set; }

    public virtual DbSet<SD_77> SD_77 { get; set; }

    public virtual DbSet<SD_82> SD_82 { get; set; }

    public virtual DbSet<SD_83> SD_83 { get; set; }

    public virtual DbSet<SD_99> SD_99 { get; set; }

    public virtual DbSet<UD_43> UD_43 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1251_CI_AS");

        modelBuilder.Entity<COUNTRY>(entity =>
        {
            entity.ToTable("COUNTRY", tb => tb.HasTrigger("UpdateDate_COUNTRY"));

            entity.HasIndex(e => e.ID, "IX_COUNTRY");

            entity.Property(e => e.ID)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .IsFixedLength();
            entity.Property(e => e.ALPHA2)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ALPHA3)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FOREIGN_NAME)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ISO)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LOCATION)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LOCATION_PRECISE)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NAME)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NOTES)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RUSSIAN_NAME)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SMALL_FLAG).HasColumnType("image");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<NomenklMain>(entity =>
        {
            entity.ToTable("NomenklMain", tb =>
            {
                tb.HasTrigger("UpdateDate_NomenklMain");
                tb.HasTrigger("UpdateSD_83");
            });

            entity.HasIndex(e => e.NomenklNumber, "UK_NomenklMain_NomenklNumber").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CategoryDC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.FullName).IsUnicode(false);
            entity.Property(e => e.IsComplex).HasComment("Сборочный комплект");
            entity.Property(e => e.IsDelete).HasDefaultValue(false);
            entity.Property(e => e.IsOnlyState).HasDefaultValue(true);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NomenklNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.ProductDC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.TypeDC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.UnitDC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CategoryDCNavigation).WithMany(p => p.NomenklMains)
                .HasForeignKey(d => d.CategoryDC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NomenklMain_SD_82_DOC_CODE");

            entity.HasOne(d => d.ProductDCNavigation).WithMany(p => p.NomenklMain)
                .HasForeignKey(d => d.ProductDC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NomenklMain_ProductDC");

            entity.HasOne(d => d.TypeDCNavigation).WithMany(p => p.NomenklMain)
                .HasForeignKey(d => d.TypeDC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NomenklMain_SD_119_DOC_CODE");

            entity.HasOne(d => d.UnitDCNavigation).WithMany(p => p.NomenklMain)
                .HasForeignKey(d => d.UnitDC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NomenklMain_SD_175_DOC_CODE");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Projects_Id");

            entity.ToTable(tb => tb.HasTrigger("UpdateDate_Projects"));

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ManagerDC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.ManagerDCNavigation).WithMany(p => p.Project)
                .HasPrincipalKey(p => p.DOC_CODE)
                .HasForeignKey(d => d.ManagerDC)
                .HasConstraintName("FK_Projects_ManagerDC");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Projects_ParentId");
        });

        modelBuilder.Entity<SD_102>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_102", tb => tb.HasTrigger("UpdateDate_SD_102"));

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.TD_NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();
        });

        modelBuilder.Entity<SD_103>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_103");

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.BUP_NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();
        });

        modelBuilder.Entity<SD_111>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_111", tb => tb.HasTrigger("UpdateDate_SD_111"));

            entity.HasIndex(e => e.ZACH_NAME, "UK_SD_111_ZACH_NAME").IsUnique();

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ZACH_NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();
        });

        modelBuilder.Entity<SD_114>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_114", tb =>
            {
                tb.HasTrigger("UpdateDate_SD_114");
                tb.HasTrigger("td_SD_114");
            });

            entity.HasIndex(e => e.BA_CENTR_OTV_DC, "SD_114_CENTR_OTV_FK4");

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.BA_ACC_SHORTNAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BA_BANKDC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.BA_BANK_AS_KONTRAGENT_DC).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.BA_BANK_NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BA_CENTR_OTV_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.BA_RASH_ACC)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyDC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.DateNonZero).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.StartSumma).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();

            entity.HasOne(d => d.BA_BANKDCNavigation).WithMany(p => p.SD_114)
                .HasForeignKey(d => d.BA_BANKDC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SD_114_REF_10652_SD_44");

            entity.HasOne(d => d.BA_CENTR_OTV_DCNavigation).WithMany(p => p.SD_114)
                .HasForeignKey(d => d.BA_CENTR_OTV_DC)
                .HasConstraintName("FK_SD_114_REF_51655_SD_40");

            entity.HasOne(d => d.CurrencyDCNavigation).WithMany(p => p.SD_114)
                .HasForeignKey(d => d.CurrencyDC)
                .HasConstraintName("FK_SD_114_CurrencyDC");
        });

        modelBuilder.Entity<SD_119>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_119", tb =>
            {
                tb.HasTrigger("UpdateDate_SD_119");
                tb.HasTrigger("td_sd_119");
                tb.HasTrigger("ti_sd_119");
                tb.HasTrigger("tu_sd_119");
            });

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.MC_NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();
        });

        modelBuilder.Entity<SD_148>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_148", tb => tb.HasTrigger("UpdateDate_SD_148"));

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.CK_CREDIT_SUM).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.CK_GROUP)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CK_MIN_OBOROT).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.CK_NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();
        });

        modelBuilder.Entity<SD_175>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_175", tb =>
            {
                tb.HasTrigger("UpdateDate_SD_175");
                tb.HasTrigger("td_sd_175");
                tb.HasTrigger("ti_sd_175");
                tb.HasTrigger("tu_sd_175");
            });

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.ED_IZM_NAME)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ED_IZM_OKEI)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ED_IZM_OKEI_CODE)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();
        });

        modelBuilder.Entity<SD_179>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_179", tb =>
            {
                tb.HasTrigger("UpdateDate_SD_179");
                tb.HasTrigger("td_sd_179");
                tb.HasTrigger("ti_sd_179");
                tb.HasTrigger("tu_sd_179");
            });

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.PT_NAME)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();
        });

        modelBuilder.Entity<SD_189>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_189", tb => tb.HasTrigger("UpdateDate_SD_189"));

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.OOT_NAME)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OOT_USL_OPL_DEF_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();

            entity.HasOne(d => d.OOT_USL_OPL_DEF_DCNavigation).WithMany(p => p.SD_189)
                .HasForeignKey(d => d.OOT_USL_OPL_DEF_DC)
                .HasConstraintName("FK_SD_189_REFERENCE_SD_179");
        });

        modelBuilder.Entity<SD_2>(entity =>
        {
            entity.HasKey(e => e.TABELNUMBER).HasName("SD_2_PK");

            entity.ToTable("SD_2", tb =>
            {
                tb.HasTrigger("UpdateDate_SD_2");
                tb.HasTrigger("td_sd_2");
                tb.HasTrigger("ti_sd_2");
                tb.HasTrigger("tu_sd_2");
            });

            entity.HasIndex(e => e.DOC_CODE, "IX_SD_2_ID").IsUnique();

            entity.HasIndex(e => e.DOC_CODE, "SD_2_DC_UIX").IsUnique();

            entity.HasIndex(e => e.NAME, "SD_2_NAME_IX");

            entity.Property(e => e.TABELNUMBER).ValueGeneratedNever();
            entity.Property(e => e.CHANGE_DATE).HasColumnType("datetime");
            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NAME_FIRST)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NAME_LAST)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NAME_OGLY)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NAME_SECOND)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PAYROL_START).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.PHOTO).HasColumnType("image");
            entity.Property(e => e.STATUS_NOTES)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();
            entity.Property(e => e.crs_dc).HasColumnType("numeric(15, 0)");

            entity.HasOne(d => d.crs_dcNavigation).WithMany(p => p.SD_2)
                .HasForeignKey(d => d.crs_dc)
                .HasConstraintName("FK_SD_2_SD_301_DOC_CODE");
        });

        modelBuilder.Entity<SD_22>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_22", tb =>
            {
                tb.HasTrigger("UpdateDate_SD_22");
                tb.HasTrigger("td_sd_22");
                tb.HasTrigger("ti_sd_22");
                tb.HasTrigger("tu_sd_22");
            });

            entity.HasIndex(e => e.CA_CENTR_OTV_DC, "SD_22_CENTR_OTV_FK2");

            entity.HasIndex(e => e.CA_CRS_DC, "SD_22_CRS_FK1");

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.CA_CENTR_OTV_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.CA_CRS_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.CA_KONTRAGENT_DC).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.CA_KONTR_DC).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.CA_NAME)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();

            entity.HasOne(d => d.CA_CENTR_OTV_DCNavigation).WithMany(p => p.SD_22)
                .HasForeignKey(d => d.CA_CENTR_OTV_DC)
                .HasConstraintName("FK_SD_22_REF_51654_SD_40");
        });

        modelBuilder.Entity<SD_23>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_23", tb =>
            {
                tb.HasTrigger("UpdateDate_SD_23");
                tb.HasTrigger("td_sd_23");
                tb.HasTrigger("ti_sd_23");
                tb.HasTrigger("tu_sd_23");
            });

            entity.HasIndex(e => e.REG_PARENT_DC, "SD_23_PARENT_FK1");

            entity.HasIndex(e => e.REG_STRANA_DC, "SD_23_STRANA_FK1");

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.REG_NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.REG_PARENT_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.REG_STRANA_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();

            entity.HasOne(d => d.REG_PARENT_DCNavigation).WithMany(p => p.InverseREG_PARENT_DCNavigation)
                .HasForeignKey(d => d.REG_PARENT_DC)
                .HasConstraintName("FK_SD_23_REF_42315_SD_23");
        });

        modelBuilder.Entity<SD_27>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_27", tb =>
            {
                tb.HasTrigger("UpdateDate_SD_27");
                tb.HasTrigger("td_sd_27");
                tb.HasTrigger("ti_sd_27");
                tb.HasTrigger("tu_sd_27");
            });

            entity.HasIndex(e => e.Id, "KEY_SD_27").IsUnique();

            entity.HasIndex(e => e.SKL_REGION_DC, "SD_27_REGION_FK1");

            entity.HasIndex(e => e.TABELNUMBER, "SD_27_TN_FK2");

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.IsOutBalans).HasDefaultValue(false);
            entity.Property(e => e.SKL_KONTR_TO_SPIS_DC).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.SKL_NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SKL_REGION_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_SD_27_ParentId");

            entity.HasOne(d => d.SKL_REGION_DCNavigation).WithMany(p => p.SD_27)
                .HasForeignKey(d => d.SKL_REGION_DC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SD_27_SD_23_DOC_CODE");
        });

        modelBuilder.Entity<SD_301>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE).HasName("PK_SD_301_1__22");

            entity.ToTable("SD_301", tb =>
            {
                tb.HasTrigger("UpdateDate_SD_301");
                tb.HasTrigger("ti_sd_301");
            });

            entity.HasIndex(e => e.Id, "KEY_SD_301").IsUnique();

            entity.HasIndex(e => e.Id, "UK_SD_301_ID").IsUnique();

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.CRS_BIG_SYMBOL)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CRS_CODE)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CRS_NAME)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("Cyrillic_General_BIN");
            entity.Property(e => e.CRS_SHORTNAME)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CRS_SMALL_SYMBOL)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NalogCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.NalogName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SMALL_SUMBOL).HasColumnType("image");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();
        });

        modelBuilder.Entity<SD_303>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_303", tb =>
            {
                tb.HasTrigger("UpdateDate_SD_303");
                tb.HasTrigger("td_sd_303");
                tb.HasTrigger("ti_sd_303");
                tb.HasTrigger("tu_sd_303");
            });

            entity.HasIndex(e => new { e.SHPZ_STATIA_DC, e.SHPZ_ELEMENT_DC }, "SD_303_SELECT_IX");

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.SHPZ_ELEMENT_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.SHPZ_NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SHPZ_SHIRF)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SHPZ_STATIA_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();

            entity.HasOne(d => d.SHPZ_STATIA_DCNavigation).WithMany(p => p.SD_303)
                .HasForeignKey(d => d.SHPZ_STATIA_DC)
                .HasConstraintName("FK_SD_303_REF_30781_SD_99");
        });

        modelBuilder.Entity<SD_40>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_40", tb => tb.HasTrigger("UpdateDate_SD_40"));

            entity.HasIndex(e => e.CENT_PARENT_DC, "SD_40_PARENT_FK1");

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.CENT_FULLNAME)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CENT_NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CENT_PARENT_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.IS_DELETED).HasDefaultValue(0);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();

            entity.HasOne(d => d.CENT_PARENT_DCNavigation).WithMany(p => p.InverseCENT_PARENT_DCNavigation)
                .HasForeignKey(d => d.CENT_PARENT_DC)
                .HasConstraintName("FK_SD_40_REFERENCE_SD_40");
        });

        modelBuilder.Entity<SD_43>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_43", tb =>
            {
                tb.HasTrigger("S43_KONTR_CHANGED");
                tb.HasTrigger("td_sd_43");
                tb.HasTrigger("ti_sd_43");
                tb.HasTrigger("tu_sd_43");
            });

            entity.HasIndex(e => e.INN, "SD_43_INN_IX");

            entity.HasIndex(e => e.NAME, "SD_43_NAME_IX");

            entity.HasIndex(e => e.Id, "UK_SD_43_Id").IsUnique();

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.AB_BUDGET_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.AB_MINISTRY_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.AB_OTRASL_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.ADDRESS)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CLIENT_CATEG_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.CONTAKT_LICO)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.E_MAIL)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FAX)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FLAG_BALANS).HasDefaultValue((short)1);
            entity.Property(e => e.GLAVBUH)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HEADER)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.INN)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.KASSIR)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.KPP)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LAST_CALC_BALANS)
                .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .HasColumnType("datetime");
            entity.Property(e => e.LAST_MAX_VERSION)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.MAX_KREDIT_SUM).HasColumnType("numeric(18, 4)");
            entity.Property(e => e.NAL_PAYER_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NAME_FULL)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NOTES)
                .HasMaxLength(220)
                .IsUnicode(false);
            entity.Property(e => e.OKONH)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.OKPO)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PASSPORT)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PREFIX_IN_NUMBER)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.REGION_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.SPOSOB_OTPRAV_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.START_BALANS).HasColumnType("datetime");
            entity.Property(e => e.START_SUMMA).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.TEL)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TELEKS)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TYPE_PROP)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.VALUTA_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.WWW)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.CLIENT_CATEG_DCNavigation).WithMany(p => p.SD_43)
                .HasForeignKey(d => d.CLIENT_CATEG_DC)
                .HasConstraintName("FK_SD_43_REF_71157_SD_148");

            entity.HasOne(d => d.EG).WithMany(p => p.SD_43)
                .HasForeignKey(d => d.EG_ID)
                .HasConstraintName("FK_SD_43_EG_ID_UD_43");

            entity.HasOne(d => d.REGION_DCNavigation).WithMany(p => p.SD_43)
                .HasForeignKey(d => d.REGION_DC)
                .HasConstraintName("FK_SD_43_REF_41565_SD_23");

            entity.HasOne(d => d.TABELNUMBERNavigation).WithMany(p => p.SD_43)
                .HasForeignKey(d => d.TABELNUMBER)
                .HasConstraintName("FK_SD_43_TABELNUMBER_SD_2");

            entity.HasOne(d => d.VALUTA_DCNavigation).WithMany(p => p.SD_43)
                .HasForeignKey(d => d.VALUTA_DC)
                .HasConstraintName("SD_43_VALUTA_SD_301_DOC_CODE");
        });

        modelBuilder.Entity<SD_44>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_44", tb =>
            {
                tb.HasTrigger("UpdateDate_SD_44");
                tb.HasTrigger("td_sd_44");
                tb.HasTrigger("ti_sd_44");
                tb.HasTrigger("tu_sd_44");
            });

            entity.HasIndex(e => e.BANK_NAME, "SD_44_NAME_IX");

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.ADDRESS)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BANK_NAME)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.BANK_NICKNAME)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CORRESP_ACC)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MFO_NEW)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MFO_OLD)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.POST_CODE)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SUB_CORR_ACC)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();
        });

        modelBuilder.Entity<SD_50>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_50", tb => tb.HasTrigger("UpdateDate_SD_50"));

            entity.HasIndex(e => e.PROD_PARENT_DC, "SD_50_PARENT_FK1");

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.PROD_ED_IZM)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PROD_FULL_NAME)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.PROD_NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PROD_PARENT_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();

            entity.HasOne(d => d.PROD_PARENT_DCNavigation).WithMany(p => p.InversePROD_PARENT_DCNavigation)
                .HasForeignKey(d => d.PROD_PARENT_DC)
                .HasConstraintName("FK_SD_50_REF_61261_SD_50");
        });

        modelBuilder.Entity<SD_77>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_77", tb => tb.HasTrigger("UpdateDate_SD_77"));

            entity.HasIndex(e => e.TV_SHPZ_DC, "SD_77_SHPZ_FK1");

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.TV_NAME)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TV_SHPZ_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();

            entity.HasOne(d => d.TV_SHPZ_DCNavigation).WithMany(p => p.SD_77)
                .HasForeignKey(d => d.TV_SHPZ_DC)
                .HasConstraintName("FK_SD_77_REF_51650_SD_303");
        });

        modelBuilder.Entity<SD_82>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_82", tb =>
            {
                tb.HasTrigger("UpdateDate_SD_82");
                tb.HasTrigger("td_sd_82");
                tb.HasTrigger("ti_sd_82");
                tb.HasTrigger("tu_sd_82");
            });

            entity.HasIndex(e => e.CAT_PARENT_DC, "SD_82_PARENT_FK1");

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.CAT_NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CAT_OKP)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CAT_PARENT_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.CAT_PATH_NAME)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();

            entity.HasOne(d => d.CAT_PARENT_DCNavigation).WithMany(p => p.InverseCAT_PARENT_DCNavigation)
                .HasForeignKey(d => d.CAT_PARENT_DC)
                .HasConstraintName("FK_SD_82_REF_37221_SD_82");
        });

        modelBuilder.Entity<SD_83>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_83", tb =>
            {
                tb.HasComment("Status");
                tb.HasTrigger("td_sd_83");
                tb.HasTrigger("ti_sd_83");
                tb.HasTrigger("tu_sd_83");
            });

            entity.HasIndex(e => e.Id, "KEY_SD_83").IsUnique();

            entity.HasIndex(e => e.NOM_CATEG_DC, "SD_83_CATEG_FK1").HasFillFactor(51);

            entity.HasIndex(e => e.NOM_CO_ZAK_DEF_DC, "SD_83_CO_DEF_FK2");

            entity.HasIndex(e => e.NOM_CO_REALIZ_DEF_DC, "SD_83_CO_REALIZ_DEF_FK4");

            entity.HasIndex(e => new { e.DOC_CODE, e.NOM_KOMPLEKT_ID }, "SD_83_KOMPL_ID_IX").IsUnique();

            entity.HasIndex(e => e.NOM_NOMENKL, "SD_83_NOMNUM_UIX")
                .IsUnique()
                .HasFillFactor(51);

            entity.HasIndex(e => e.NOM_TARA_DC, "SD_83_TARA_FK");

            entity.HasIndex(e => e.Id, "UK_SD_83_ID").IsUnique();

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsUslugaInRent).HasDefaultValue(false);
            entity.Property(e => e.NOM_BAR_KOD)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NOM_BASE_KOMPLEKT_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.NOM_CATEG_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.NOM_CO_REALIZ_DEF_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.NOM_CO_ZAK_DEF_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.NOM_DELETED).HasDefaultValue(0);
            entity.Property(e => e.NOM_ED_IZM_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.NOM_FULL_NAME).IsUnicode(false);
            entity.Property(e => e.NOM_GTD_FROM_NOMENKL_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.NOM_KOMPLEKT_ID).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.NOM_NACEN_KOMPL_SUM).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.NOM_NACEN_OTD_SUM).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.NOM_NAME)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NOM_NOMENKL)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NOM_NOTES)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NOM_OKP)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NOM_POLNOE_IMIA)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NOM_PRODUCTOR_DC).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.NOM_PRODUCT_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.NOM_PROIZVODSTVO).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.NOM_SALE_CRS_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.NOM_SALE_CRS_PRICE).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.NOM_SALE_PRICE).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.NOM_SHPZ)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NOM_SHPZ_DEF_IN_COMPL_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.NOM_STRANA_IZGOTOV)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NOM_TARA_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.NOM_TYPE_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Main).WithMany(p => p.SD_83)
                .HasForeignKey(d => d.MainId)
                .HasConstraintName("FK_SD_83_NomenklMain_Id");

            entity.HasOne(d => d.NOM_CATEG_DCNavigation).WithMany(p => p.SD_83)
                .HasForeignKey(d => d.NOM_CATEG_DC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SD_83_SD_82_DOC_CODE");

            entity.HasOne(d => d.NOM_CO_REALIZ_DEF_DCNavigation).WithMany(p => p.SD_83NOM_CO_REALIZ_DEF_DCNavigations)
                .HasForeignKey(d => d.NOM_CO_REALIZ_DEF_DC)
                .HasConstraintName("FK_SD_83_REF_CO_REALIZ_SD_40");

            entity.HasOne(d => d.NOM_CO_ZAK_DEF_DCNavigation).WithMany(p => p.SD_83NOM_CO_ZAK_DEF_DCNavigations)
                .HasForeignKey(d => d.NOM_CO_ZAK_DEF_DC)
                .HasConstraintName("FK_SD_83_REFERENCE_SD_40");

            entity.HasOne(d => d.NOM_ED_IZM_DCNavigation).WithMany(p => p.SD_83)
                .HasForeignKey(d => d.NOM_ED_IZM_DC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SD_83_REF_37217_SD_175");

            entity.HasOne(d => d.NOM_GTD_FROM_NOMENKL_DCNavigation)
                .WithMany(p => p.InverseNOM_GTD_FROM_NOMENKL_DCNavigation)
                .HasForeignKey(d => d.NOM_GTD_FROM_NOMENKL_DC)
                .HasConstraintName("FK_SD_83_REF_88174_SD_83");

            entity.HasOne(d => d.NOM_PRODUCTOR_DCNavigation).WithMany(p => p.SD_83)
                .HasForeignKey(d => d.NOM_PRODUCTOR_DC)
                .HasConstraintName("FK_SD_83_REF_49622_SD_43");

            entity.HasOne(d => d.NOM_PRODUCT_DCNavigation).WithMany(p => p.SD_83)
                .HasForeignKey(d => d.NOM_PRODUCT_DC)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SD_83_REF_16881_SD_50");

            entity.HasOne(d => d.NOM_SHPZ_DEF_IN_COMPL_DCNavigation).WithMany(p => p.SD_83)
                .HasForeignKey(d => d.NOM_SHPZ_DEF_IN_COMPL_DC)
                .HasConstraintName("FK_SD_83_REF_69073_SD_303");

            entity.HasOne(d => d.NOM_TARA_DCNavigation).WithMany(p => p.InverseNOM_TARA_DCNavigation)
                .HasForeignKey(d => d.NOM_TARA_DC)
                .HasConstraintName("FK_SD_83_REFERENCE_SD_83");

            entity.HasOne(d => d.NOM_TYPE_DCNavigation).WithMany(p => p.SD_83)
                .HasForeignKey(d => d.NOM_TYPE_DC)
                .HasConstraintName("FK_SD_83_REF_69767_SD_119");
        });

        modelBuilder.Entity<SD_99>(entity =>
        {
            entity.HasKey(e => e.DOC_CODE);

            entity.ToTable("SD_99", tb => tb.HasTrigger("UpdateDate_SD_99"));

            entity.HasIndex(e => e.SZ_PARENT_DC, "SD_99_PARENT_FK1");

            entity.Property(e => e.DOC_CODE).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.SZ_NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SZ_PARENT_DC).HasColumnType("numeric(15, 0)");
            entity.Property(e => e.SZ_SHIFR)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();

            entity.HasOne(d => d.SZ_PARENT_DCNavigation).WithMany(p => p.InverseSZ_PARENT_DCNavigation)
                .HasForeignKey(d => d.SZ_PARENT_DC)
                .HasConstraintName("FK_SD_99_REF_51075_SD_99");
        });

        modelBuilder.Entity<UD_43>(entity =>
        {
            entity.HasKey(e => e.EG_ID);

            entity.ToTable("UD_43", tb => tb.HasTrigger("UpdateDate_UD_43"));

            entity.Property(e => e.EG_ID).ValueGeneratedNever();
            entity.Property(e => e.EG_NAME)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()").IsUnicode();

            entity.HasOne(d => d.EG_PARENT).WithMany(p => p.InverseEG_PARENT)
                .HasForeignKey(d => d.EG_PARENT_ID)
                .HasConstraintName("FK_UD_43_EG_PARENT_ID_UD_43");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
