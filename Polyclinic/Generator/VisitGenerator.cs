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
           {
               var validNumbers = new List<int>();

               for (var i = 101; i <= 120; i++) validNumbers.Add(i);
               for (var i = 201; i <= 220; i++) validNumbers.Add(i);
               for (var i = 301; i <= 315; i++) validNumbers.Add(i);

               var number = f.Random.ListItem(validNumbers);
               var letter = f.Random.ArrayElement(["A", "B", "C"]);
               return $"{number}-{letter}";
           })
           .RuleFor(x => x.IsAgain, f => f.Random.Bool(0.3f)) 
           .Generate(count);
}
