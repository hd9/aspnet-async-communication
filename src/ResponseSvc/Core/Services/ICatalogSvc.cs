using HildenCo.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResponseSvc.Core.Services
{
    public interface ICatalogSvc
    {
        Product GetProductBySlug(string id);
        List<Product> GetAllProducts();
    }
}