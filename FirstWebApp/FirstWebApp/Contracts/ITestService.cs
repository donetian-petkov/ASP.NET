using FirstWebApp.Models;

namespace FirstWebApp.Contracts;

public interface ITestService
{
    string GetProduct(TestModel model);

}