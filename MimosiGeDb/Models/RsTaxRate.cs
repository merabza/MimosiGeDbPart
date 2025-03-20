namespace MimosiGeDb.Models;

public class RsTaxRate
{
    public int Id { get; set; }

    public short? BenefCategoryId { get; set; }

    public short? QuoteTypeId { get; set; }

    public string? TaxRate { get; set; }

    public virtual RsBenefCategory? BenefCategory { get; set; }

    public virtual RsQuoteType? QuoteType { get; set; }
}