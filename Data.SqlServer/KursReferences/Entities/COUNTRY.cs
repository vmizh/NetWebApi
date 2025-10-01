namespace Data.SqlServer.KursReferences.Entities;

public class COUNTRY
{
    public string ID { get; set; } = null!;

    public string ALPHA2 { get; set; } = null!;

    public string ALPHA3 { get; set; } = null!;

    public string ISO { get; set; } = null!;

    public string FOREIGN_NAME { get; set; } = null!;

    public string RUSSIAN_NAME { get; set; } = null!;

    public string? NOTES { get; set; }

    public string NAME { get; set; } = null!;

    public string? LOCATION { get; set; }

    public string? LOCATION_PRECISE { get; set; }

    public byte[]? SMALL_FLAG { get; set; }

    public DateTime? UpdateDate { get; set; }
}
