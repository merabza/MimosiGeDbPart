namespace MimosiGeDb.Models;

public partial class RsTaxRates
{
    public int Id { get; set; }

    public short? BenefCategoryId { get; set; }

    public short? QuoteTypeId { get; set; }

    public string? TaxRate { get; set; }

    public virtual RsBenefCategories? BenefCategory { get; set; }

    public virtual RsQuoteTypes? QuoteType { get; set; }
}