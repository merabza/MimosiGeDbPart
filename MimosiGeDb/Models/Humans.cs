using System;

namespace MimosiGeDb.Models;

public partial class Humans
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LegalName { get; set; }

    public string PersonalId { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? LegalAddress { get; set; }

    public string? ActualAddress { get; set; }

    public string? Employment { get; set; }

    public DateTime? BirthDate { get; set; }
}