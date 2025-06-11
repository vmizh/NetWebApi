using Data.SqlServer.KursSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Version = Data.SqlServer.KursSystem.Entities.Version;

namespace Data.SqlServer.KursSystem.Context;

public partial class KursSystemContext : DbContext
{
    public KursSystemContext()
    {
    }

    public KursSystemContext(DbContextOptions<KursSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DataSource> DataSources { get; set; }

    public virtual DbSet<Error> Errors { get; set; }

    public virtual DbSet<FormLayout> FormLayouts { get; set; }

    public virtual DbSet<KontragentCash> KontragentCashes { get; set; }

    public virtual DbSet<KursMenuGroup> KursMenuGroups { get; set; }

    public virtual DbSet<KursMenuItem> KursMenuItems { get; set; }

    public virtual DbSet<LastDocument> LastDocuments { get; set; }

    public virtual DbSet<LastMenuUserSearch> LastMenuUserSearches { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<ObjectRightResposibilityCenter> ObjectRightResposibilityCenters { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<SignatureScheme> SignatureSchemes { get; set; }

    public virtual DbSet<SignatureSchemesInfo> SignatureSchemesInfos { get; set; }

    public virtual DbSet<SignatureType> SignatureTypes { get; set; }

    public virtual DbSet<TasksLog> TasksLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserMenuFavorite> UserMenuFavorites { get; set; }

    public virtual DbSet<UserMenuOrder> UserMenuOrders { get; set; }

    public virtual DbSet<UserMenuRight> UserMenuRights { get; set; }

    public virtual DbSet<UserRightsResponsibilityCenter> UserRightsResponsibilityCenters { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<Version> Versions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(
            "Server=main9,1433;Initial Catalog=KursSystem;Persist Security Info=False;User ID=sa;Password=CbvrfFhntvrf65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataSource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DataSources_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DBName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RedisDBId).HasDefaultValue(0);
            entity.Property(e => e.Server)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ShowName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Users).WithMany(p => p.DBs)
                .UsingEntity<Dictionary<string, object>>(
                    "UsersLinkDB",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsersLinkDB_UserId"),
                    l => l.HasOne<DataSource>().WithMany()
                        .HasForeignKey("DBId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsersLinkDB_DBId"),
                    j =>
                    {
                        j.HasKey("DBId", "UserId");
                        j.ToTable("UsersLinkDB");
                    });
        });

        modelBuilder.Entity<Error>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ErrorText).IsUnicode(false);
            entity.Property(e => e.Host)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Moment).HasColumnType("datetime");
            entity.Property(e => e.Note)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Db).WithMany(p => p.Errors)
                .HasForeignKey(d => d.DbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Errors_DbId");

            entity.HasOne(d => d.User).WithMany(p => p.Errors)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Errors_UserId");
        });

        modelBuilder.Entity<FormLayout>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_FormLayout_Id");

            entity.ToTable("FormLayout");

            entity.HasIndex(e => new { e.FormName, e.UserId }, "IDX_FormLayout_FormName");

            entity.HasIndex(e => new { e.UserId, e.FormName, e.ControlName }, "UK_FormLayout").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ControlName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FormName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Layout).IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.WindowState).IsUnicode(false);

            entity.HasOne(d => d.Form).WithMany(p => p.FormLayouts)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK_FormLayout_FormId");

            entity.HasOne(d => d.User).WithMany(p => p.FormLayouts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FormLayout_UserId");
        });

        modelBuilder.Entity<KontragentCash>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_KontragentCashes_Id");

            entity.HasIndex(e => new { e.UserId, e.DBId, e.KontragentDC }, "KEY_KontragentCashes").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.KontragentDC).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.LastUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.DB).WithMany(p => p.KontragentCashes)
                .HasForeignKey(d => d.DBId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KontragentCashes_DBId");

            entity.HasOne(d => d.User).WithMany(p => p.KontragentCashes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KontragentCashes_UserId");
        });

        modelBuilder.Entity<KursMenuGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MAIN_DOCUMENT_GROUP");

            entity.ToTable("KursMenuGroup", tb => tb.HasComment("тАБЛИЦА ФОРМИРОВАНИЯ ГЛАВНОГО ЭКРАНА. ГРУППЫ"));

            entity.HasIndex(e => e.Name, "UK_MAIN_DOCUMENT_GROUP_NAME").IsUnique();

            entity.HasIndex(e => e.OrderBy, "UK_MAIN_DOCUMENT_GROUP_ORDERBY").IsUnique();

            entity.Property(e => e.Id).HasComment("Ключ");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Наименование группы");
            entity.Property(e => e.Note)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("пРИМЕЧАНИЯ");
            entity.Property(e => e.Picture).HasColumnType("image");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_KursMenuGroup_ParentId");
        });

        modelBuilder.Entity<KursMenuItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MAIN_DOCUMENT_ITEM");

            entity.ToTable("KursMenuItem", tb => tb.HasComment("Список документов для главного окна приложения"));

            entity.HasIndex(e => new { e.GroupId, e.Name }, "IX_GROUP_ITEM").IsUnique();

            entity.HasIndex(e => new { e.GroupId, e.OrderBy }, "IX_MAIN_DOCUMENT_ITEM");

            entity.HasIndex(e => e.Name, "UK_MAIN_DOCUMENT_ITEM_NAME").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("Ключ");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Код имени для обектана стороне клиента");
            entity.Property(e => e.GroupId).HasComment("Ссылка на группу документов");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Наименование");
            entity.Property(e => e.Note)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("Примечание");
            entity.Property(e => e.OrderBy).HasComment("Порядок отрисовки на экране");
            entity.Property(e => e.Picture).HasComment("Картинка");

            entity.HasOne(d => d.Group).WithMany(p => p.KursMenuItems)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KursMenuItem_GroupId");
        });

        modelBuilder.Entity<LastDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LastDocument_Id");

            entity.ToTable("LastDocument",
                tb => tb.HasComment(
                    "[Display(Name = \"Не документ\")] None = 0,\r\n\r\n        [Display(Name = \"Приходный касовый ордер\")]\r\n        CashIn = 33,\r\n\r\n        [Display(Name = \"Расходный касовый ордер\")]\r\n        CashOut = 34,\r\n\r\n        [Display(Name = \"Банковская проводка\")]\r\n        Bank = 101,\r\n        [Display(Name = \"Обмен валюты\")] CurrencyChange = 251,\r\n        [Display(Name = \"Акт взаимозачета\")] MutualAccounting = 110,\r\n        [Display(Name = \"Акт конвертации\")] CurrencyConvertAccounting = 111,\r\n\r\n        [Display(Name = \"Инвентаризационная ведомость\")]\r\n        InventoryList = 359,\r\n\r\n        [Display(Name = \"Приходный складской ордер\")]\r\n        StoreOrderIn = 357,\r\n\r\n        [Display(Name = \"Счет-фактура клиентам\")]\r\n        InvoiceClient = 84,\r\n\r\n        [Display(Name = \"Счет-фактура поставщиков\")]\r\n        InvoiceProvider = 26,\r\n\r\n        [Display(Name = \"Расходная накладная\")]\r\n        Waybill = 368,\r\n\r\n        [Display(Name = \"Ведомость начисления заработной платы\")]\r\n        PayRollVedomost = 903,\r\n\r\n        [Display(Name = \"Акт валютной таксировки номенклатур\")]\r\n        NomenklTransfer = 10001,\r\n\r\n        [Display(Name = \"Справочник проектов\")]\r\n        ProjectsReference = 10002"));

            entity.HasIndex(e => new { e.UserId, e.DbId, e.DocDC, e.DocId }, "UK_LastDocument");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Creator)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.DocDC).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.LastChanger)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LastOpen).HasColumnType("datetime");

            entity.HasOne(d => d.Db).WithMany(p => p.LastDocuments)
                .HasForeignKey(d => d.DbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LastDocument_DbId");

            entity.HasOne(d => d.User).WithMany(p => p.LastDocuments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LastDocument_UserId");
        });

        modelBuilder.Entity<LastMenuUserSearch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LastMenuUserSearch_Id");

            entity.ToTable("LastMenuUserSearch");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.LastOpen).HasColumnType("datetime");

            entity.HasOne(d => d.Db).WithMany(p => p.LastMenuUserSearches)
                .HasForeignKey(d => d.DbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LastMenuUserSearch_DbId");

            entity.HasOne(d => d.Menu).WithMany(p => p.LastMenuUserSearches)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LastMenuUserSearch_MenuId");

            entity.HasOne(d => d.User).WithMany(p => p.LastMenuUserSearches)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LastMenuUserSearch_UserId");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Log");

            entity.ToTable("Log");

            entity.Property(e => e.Level).HasMaxLength(50);
            entity.Property(e => e.Logged)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Logger).HasMaxLength(250);
            entity.Property(e => e.MachineName).HasMaxLength(50);
            entity.Property(e => e.ProgramName).HasMaxLength(500);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<ObjectRightResposibilityCenter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ObjectRightResposibilityCenter_Id");

            entity.ToTable("ObjectRightResposibilityCenter",
                tb => tb.HasComment(
                    "Права центров ответственности на объекты(контр-ты,склады,кассы,банк.счета, товары)"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Note)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ObjectDC).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.ObjectTypeId).HasComment("1-Контрагенты, 2-Склады, 3-Кассы, 4-Банк.Счета, 5-Товары");
            entity.Property(e => e.RespCentDC).HasColumnType("numeric(18, 0)");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RefreshToken_Id");

            entity.ToTable("RefreshToken");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");
            entity.Property(e => e.TS).HasColumnType("smalldatetime");
            entity.Property(e => e.TokenHash)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.TokenSalt)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_RefreshToken_User");
        });

        modelBuilder.Entity<SignatureScheme>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SignatureSchemes_Id");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Note).IsUnicode(false);

            entity.HasOne(d => d.Db).WithMany(p => p.SignatureSchemes)
                .HasForeignKey(d => d.DbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SignatureSchemes_DbId");

            entity.HasOne(d => d.DocumentTYpe).WithMany(p => p.SignatureSchemes)
                .HasForeignKey(d => d.DocumentTYpeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SignatureSchemes_DocumentTYpeId");
        });

        modelBuilder.Entity<SignatureSchemesInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SignatureSchemesInfo_Id");

            entity.ToTable("SignatureSchemesInfo");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsRequired).HasDefaultValue(true);
            entity.Property(e => e.Note).IsUnicode(false);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_SignatureSchemesInfo_ParentId");

            entity.HasOne(d => d.Scheme).WithMany(p => p.SignatureSchemesInfos)
                .HasForeignKey(d => d.SchemeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SignatureSchemesInfo_SchemeId");

            entity.HasOne(d => d.Sign).WithMany(p => p.SignatureSchemesInfos)
                .HasForeignKey(d => d.SignId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SignatureSchemesInfo_SignId");
        });

        modelBuilder.Entity<SignatureType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SignatureType_Id");

            entity.ToTable("SignatureType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Note).IsUnicode(false);

            entity.HasOne(d => d.Db).WithMany(p => p.SignatureTypes)
                .HasForeignKey(d => d.DbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SignatureType_DbId");

            entity.HasMany(d => d.Users).WithMany(p => p.Signs)
                .UsingEntity<Dictionary<string, object>>(
                    "SignatureLink",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_SignatureLink_UserId"),
                    l => l.HasOne<SignatureType>().WithMany()
                        .HasForeignKey("SignId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_SignatureLink_SignId"),
                    j =>
                    {
                        j.HasKey("SignId", "UserId");
                        j.ToTable("SignatureLink");
                    });
        });

        modelBuilder.Entity<TasksLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TasksLog_Id");

            entity.ToTable("TasksLog");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ExecTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TypeName).HasMaxLength(200);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users_Id");

            entity.HasIndex(e => e.Name, "KEY_Users_Name").IsUnique();

            entity.HasIndex(e => e.Name, "UK_Users_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Avatar).HasColumnType("image");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Note)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordSalt)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ThemeName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserMenuFavorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserMenuFavorites_Id");

            entity.HasIndex(e => new { e.UserId, e.DbId, e.MenuId }, "KEY_UserMenuFavorites").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Db).WithMany(p => p.UserMenuFavorites)
                .HasForeignKey(d => d.DbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserMenuFavorites_DbId");

            entity.HasOne(d => d.Menu).WithMany(p => p.UserMenuFavorites)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserMenuFavorites_MenuId");

            entity.HasOne(d => d.User).WithMany(p => p.UserMenuFavorites)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserMenuFavorites_UserId");
        });

        modelBuilder.Entity<UserMenuOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserMenuOrder_Id");

            entity.ToTable("UserMenuOrder");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<UserMenuRight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserMenuRight_Id");

            entity.ToTable("UserMenuRight");

            entity.HasIndex(e => new { e.DBId, e.LoginName, e.MenuId }, "UK_UserMenuRight").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.LoginName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.DB).WithMany(p => p.UserMenuRights)
                .HasForeignKey(d => d.DBId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserMenuRight_DBId");

            entity.HasOne(d => d.Menu).WithMany(p => p.UserMenuRights)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserMenuRight_MenuId");
        });

        modelBuilder.Entity<UserRightsResponsibilityCenter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserRightsResponsibilityCenter_Id");

            entity.ToTable("UserRightsResponsibilityCenter", tb => tb.HasComment("Права пользователей на ЦО"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.RespCentDC).HasColumnType("numeric(18, 0)");

            entity.HasOne(d => d.Db).WithMany(p => p.UserRightsResponsibilityCenters)
                .HasForeignKey(d => d.DbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRightsResponsibilityCenter_DbId");

            entity.HasOne(d => d.User).WithMany(p => p.UserRightsResponsibilityCenters)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRightsResponsibilityCenter_UserId");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_UserRoles_id");

            entity.HasIndex(e => e.Name, "UK_UserRoles_Name").IsUnique();

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Note).IsUnicode(false);

            entity.HasMany(d => d.Menus).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRolesLinkMenuItem",
                    r => r.HasOne<KursMenuItem>().WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRolesLinkMenuItem_MenuId"),
                    l => l.HasOne<UserRole>().WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRolesLinkMenuItem_RolesId"),
                    j =>
                    {
                        j.HasKey("RolesId", "MenuId");
                        j.ToTable("UserRolesLinkMenuItem");
                    });
        });

        modelBuilder.Entity<Version>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Versions__3214EC075B4B34F3");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ServerPath).HasMaxLength(1000);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
