namespace DTO.KursReferences.Kontragent;

public record KontragentFullDto : KontragentDto
{
    public string? INN { get; set; }
    public string? KPP { get; set; }
    public string? Director { get; set; }
    public string? GlavBuh { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? OKPO { get; set; }
    public string? OKONH { get; set; }
    public bool? IsPersona { get; set; }

    public string? Passport { get; set; }
    //IEmployee Employee { get; set; }
    //IClientCategory ClientCategory { get; set; }
    //IEmployee ResponsibleEmployee { get; set; }
    //IRegion Region { get; set; }

    public DateTime? StartBalans { get; set; }
    public decimal? StartSumma { get; set; }
    public string? EMail { get; set; }
    public int? OrderCount { get; set; }
}
