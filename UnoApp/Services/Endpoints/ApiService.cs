using Refit;

namespace UnoApp.Services.Endpoints;

public static class ApiService
{
    private const string BaseUrl = "http://192.168.1.10:8080";
    //private const string BaseUrl = "http://localhost:8080";
    public static IProductService Client { get; private set; }

    static ApiService()
    {
        // Khởi tạo Refit
        Client = RestService.For<IProductService>(BaseUrl);
    }
}
