using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;
using Bogus.DataSets;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class UpdateSaleHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// The generated Sales will have valid:
    /// - Id (pk Table)
    /// - NumberSale (Number sale)
    /// - Customer (valid format)
    /// - Agency (Brazilian format)
    /// - Products (List products)
    /// </summary>
    private static readonly Faker<UpdateSaleCommand> createSaleHandlerFaker = new Faker<UpdateSaleCommand>()
        .RuleFor(u => u.Id, f => Guid.Parse("50a09863-b029-4d6b-86df-3fda6250dec7"))
        .RuleFor(u => u.NumberSale, f => f.Random.Number(11, 99))
        .RuleFor(u => u.Customer, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Male))
        .RuleFor(u => u.Agency, f => f.Commerce.Product())
        .RuleFor(u => u.Products, f => Products().Generate(3));

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated Sale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static UpdateSaleCommand GenerateValidCommand()
    {
        return createSaleHandlerFaker.Generate();
    }

    /// <summary>
    /// Generates a valid list Products
    /// </summary>
    /// <returns>List Products Fake</returns>
    private static Faker<Product> Products()
    {
        var products = new Faker<Product>()
            .StrictMode(true)
            .RuleFor(o => o.Name, f => f.Name.FullName(f.PickRandom<Name.Gender>()))
            .RuleFor(o => o.Description, f => f.Vehicle.Manufacturer())
            .RuleFor(o => o.UnitPrice, f => f.Random.Decimal(0, 1))
            .RuleFor(o => o.Amount, f => f.Random.Number(11, 99))
            .RuleFor(o => o.Discount, f => f.Random.Number(11, 99))
            .RuleFor(o => o.TotalValue, f => f.Random.Decimal(0, 1))
            .RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.SaleId, f => Guid.Parse("50a09863-b029-4d6b-86df-3fda6250dec7"))
            .RuleFor(u => u.Status, f => f.PickRandom(ProductStatus.Active, ProductStatus.Canceled));              

        return products;
    }   
}
