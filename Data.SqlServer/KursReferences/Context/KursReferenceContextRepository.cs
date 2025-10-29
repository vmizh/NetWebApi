namespace Data.SqlServer.KursReferences.Context;

public class KursReferenceContextRepository : IKursReferenceContextRepository
{

    public KursReferenceContextRepository()
    {
        Register(new DbContextInfo
        {
            Id = Guid.Parse("1F2D40CC-0B5B-401B-8C96-16F576F15AD5"),
            Name = "КомСпецПроект",
            RedisId = 2
        },"Server=main9,1433;Initial Catalog=KomSpecProject;Persist Security Info=False; " +
                    "User ID=sa;Password=CbvrfFhntvrf65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;" );

        Register(new DbContextInfo
            {
                Id = Guid.Parse("26FE1821-1A45-4CA1-A178-2DFAA82A949E"),
                Name = "Gokite.Piter",
                RedisId = 8
            },"Server=main9,1433;Initial Catalog=SPBSurf;Persist Security Info=False; " +
              "User ID=sa;Password=CbvrfFhntvrf65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;" );

        Register(new DbContextInfo
            {
                Id = Guid.Parse("5F58635E-6F05-4FF6-AE47-31B9EF2F2327"),
                Name = "MontenegroSURF",
                RedisId = 7
            },"Server=main9,1433;Initial Catalog=MontenegroSURF;Persist Security Info=False; " +
              "User ID=sa;Password=CbvrfFhntvrf65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;" );

        Register(new DbContextInfo
            {
                Id = Guid.Parse("117B9C94-49B9-4011-9002-3ED7B0E39175"),
                Name = "LocalTest",
                RedisId = 15
            },"Server=192.168.89.101,1433;Initial Catalog=AlfaTest;Persist Security Info=False; " +
              "User ID=sa;Password=CbvrfFhntvrf65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;" );

        Register(new DbContextInfo
            {
                Id = Guid.Parse("2137148B-1B06-4502-AA18-73C6DE58CB14"),
                Name = "RedStar",
                RedisId = 3
            },"Server=main9,1433;Initial Catalog=RedStar;Persist Security Info=False; " +
              "User ID=sa;Password=CbvrfFhntvrf65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;" );

        Register(new DbContextInfo
            {
                Id = Guid.Parse("02109D96-0829-4F08-9CE6-821454D7315D"),
                Name = "AlfaNew",
                RedisId = 1
            },"Server=main9,1433;Initial Catalog=AlfaNew;Persist Security Info=False; " +
              "User ID=sa;Password=CbvrfFhntvrf65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;" );

        Register(new DbContextInfo
            {
                Id = Guid.Parse("CB036A8E-4BAA-4D38-AA7C-92B534A4A24D"),
                Name = "Gokite.Tarifa",
                RedisId = 6
            },"Server=main9,1433;Initial Catalog=[Gokite.terifa];Persist Security Info=False; " +
              "User ID=sa;Password=CbvrfFhntvrf65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;" );

        Register(new DbContextInfo
            {
                Id = Guid.Parse("DA85E2C2-1D84-4996-A2E2-FA222DA2B83E"),
                Name = "CORE.PITER",
                RedisId = 5
            },"Server=main9,1433;Initial Catalog=[CORE.PITER];Persist Security Info=False; " +
              "User ID=sa;Password=CbvrfFhntvrf65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;" );

        Register(new DbContextInfo
            {
                Id = Guid.Parse("4DDCA347-D439-4348-8159-FC78D4152F62"),
                Name = "Спарк Инвест",
                RedisId = 4
            },"Server=main9,1433;Initial Catalog=Spark;Persist Security Info=False; " +
              "User ID=sa;Password=CbvrfFhntvrf65;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;" );
    }
    public void Register(DbContextInfo info, string _connString)
    {
        ContextDictionary[info] = new KursReferenceContext(_connString);
    }

    public KursReferenceContext? GetContext(string _name)
    {
        var idx = ContextDictionary.Keys.FirstOrDefault(_ => _.Name == _name);
        return idx == null ? null : ContextDictionary[idx];
    }

    public KursReferenceContext? GetContext(Guid id)
    {
        var idx = ContextDictionary.Keys.FirstOrDefault(_ => _.Id == id);
        return idx == null ? null : ContextDictionary[idx];
    }

    public Dictionary<DbContextInfo, KursReferenceContext?> GetAllCContexts()
    {
        return ContextDictionary;
    }

    public string GetContextName(Guid id)
    {
        var idx = ContextDictionary.Keys.FirstOrDefault(_ => _.Id == id);
        return idx == null ? "Контекст базы не найден" : idx.Name;
    }

    private Dictionary<DbContextInfo, KursReferenceContext?> ContextDictionary { get; } = [];
}
