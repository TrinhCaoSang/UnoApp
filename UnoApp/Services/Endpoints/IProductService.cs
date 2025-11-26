using Refit;

namespace UnoApp.Services.Endpoints;

public interface IProductService
{
    [Get("/api/products")]
    Task<UnoApp.Models.ApiResponse<List<Product>>> GetProductsAsync();

    //[Get("/api/products/{id}")]
    //Task<Product> GetProductDetailAsync(int id);
}
