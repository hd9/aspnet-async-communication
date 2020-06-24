using HildenCo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResponseSvc.Core.Services
{
    /// <summary>
    /// Simulates an account service 
    /// </summary>
    public class CatalogSvc : ICatalogSvc
    {

        // our fake, in memory-database
        readonly List<Product> _inventory = new List<Product>
        {
            new Product { Name = "PS4", Slug = "g-ps4", Description = "The PlayStation 4 is an eighth-generation home video game console developed by Sony Computer Entertainment. Announced as the successor to the PlayStation 3 in February 2013, it was launched on November 15 in North America, November 29 in Europe, South America and Australia, and on February 22, 2014 in Japan.", Price = 299 },
            new Product { Name = "Xbox One", Slug = "g-xbx1", Description = "The Xbox One is an eighth-generation home video game console developed by Microsoft. Announced in May 2013, it is the successor to Xbox 360 and the third console in the Xbox series of video game consoles", Price = 299 },
            new Product { Name = "Nintendo Switch", Slug = "g-nsw", Description = "The Nintendo Switch is a video game console developed by Nintendo, released worldwide in most regions on March 3, 2017. It is a hybrid console that can be used as a home console and portable device.", Price = 299 },
            new Product { Name = "PS5", Slug = "g-ps5", Description = "The PlayStation 5 is the successof of PS4, a home video game console developed by Sony Interactive Entertainment. Announced in 2019 as the successor to the PlayStation 4, it is scheduled to launch in late 2020.", Price = 499 },
            new Product { Name = "Xbox Series X", Slug = "g-xbxx", Description = "The Xbox Series X is an upcoming home video game console developed by Microsoft. It was announced during E3 2019 as \"Project Scarlett\" and is scheduled for release in late 2020.", Price = 499 },
        };

        public List<Product> GetAllProducts()
        {
            return _inventory.ToList();
        }

        public Product GetProductBySlug(string slug)
        {
            return _inventory.FirstOrDefault(x =>
                string.Equals(x.Slug, slug, StringComparison.InvariantCultureIgnoreCase)
            );
        }
    }
}
