using Infrastructure.Helpers;

namespace Infrastructure.Tests.Helpers;

public class UniqueIdGenerator_Tests
{
    [Fact]
    public void Generate_ShouldReturnGuidAsString_WhenSuccessful()
    {
        // Act
        string result = UniqueIdGenerator.Generate();

        // Assert
        Assert.True(Guid.TryParse(result, out Guid id));
        Assert.IsType<Guid>(id);
    }
}
