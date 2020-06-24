using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HildenCo.Core;
using HildenCo.Core.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RequestSvc.Models;

namespace RequestSvc.Controllers
{
    public class HomeController : Controller
    {

        IRequestClient<ProductInfoRequest> _client;

        public HomeController(IRequestClient<ProductInfoRequest> client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/api/products/{slug}")]
        public async Task<IActionResult> GetBySlug(string slug, int timeout)
        {
            Product p = null;
            // request from the remote service
            using (var request = _client.Create(new ProductInfoRequest { Slug = slug, Delay = timeout }))
            {
                var response = await request.GetResponse<ProductInfoResponse>();
                p = response.Message.Product;
            }

            return Ok(p);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
