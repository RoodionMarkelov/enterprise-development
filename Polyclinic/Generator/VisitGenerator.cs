using Bogus;
using Application.DTO;

namespace Generator;

/// <summary>
/// Provides methods for generating fake visit data for testing or seeding purposes.
/// </summary>
public class Generator
{
    /// <summary>
    /// Generates a list of fake VisitDto objects with realistic data.
    /// </summary>
    /// <param name="count">Number of visit records to generate.</param>
    /// <returns>A list of generated VisitDto objects.</returns>
    public static List<VisitDto> GenerateLinks(int count) =>
       new Faker<VisitDto>()
           .RuleFor(x => x.PatientId, f => f.Random.Int(1, 10))
           .RuleFor(x => x.DoctorId, f => f.Random.Int(1, 10))
           .RuleFor(x => x.DateOfVisit, f => f.Date.Between(
                new DateTime(2025, 1, 1, 8, 0, 0),  
                new DateTime(2025, 12, 31, 18, 0, 0) 
           ))
           .RuleFor(x => x.NumberOfCabinet, f =>
               $"{f.Random.Int(101, 315)}-{f.Random.ArrayElement(new[] { "A", "B", "C" })}")
           .RuleFor(x => x.IsAgain, f => f.Random.Bool(0.3f)) 
           .Generate(count);
}
