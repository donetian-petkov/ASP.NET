using FirstWebApp.Contracts;
using FirstWebApp.Models;

namespace FirstWebApp.Services;

public class TestService : ITestService
{
    public string GetProduct(TestModel model)
    {
        return model.Product;
    }
}