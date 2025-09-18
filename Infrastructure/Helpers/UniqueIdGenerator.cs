using Infrastructure.Interfaces;

namespace Infrastructure.Helpers;

public class UniqueIdGenerator : IUniqueIdGenerator
{
    public static string Generate()
    {
        return Guid.NewGuid().ToString();
    }
}
