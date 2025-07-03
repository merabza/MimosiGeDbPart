namespace MimosiGeDb.Models;

public sealed class RsTaxRate
{
    public int Id { get; set; }
    public required string Code { get; set; }
    public short? BenefCategoryId { get; set; }
    public short? QuoteTypeId { get; set; }
    public string? TaxRate { get; set; }
    public RsBeneficiaryCategory? BenefCategory { get; set; }
    public RsQuoteType? QuoteType { get; set; }
}