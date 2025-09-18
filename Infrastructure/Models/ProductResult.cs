namespace Infrastructure.Models;

public class ProductResult
{
    public bool Succeeded { get; set; }
    public string? Error { get; set; }
}

public class ProductResult<T> : ProductResult
{
    public T? Content { get; set; }
}
