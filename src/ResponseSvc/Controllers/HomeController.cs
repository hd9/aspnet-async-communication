using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResponseSvc.Core.Services;
using ResponseSvc.Models;

namespace ResponseSvc.Controllers
{
    public class HomeController : Controller
    {
        readonly ICatalogSvc _svc;

        public HomeController(ICatalogSvc svc)
        {
            _svc = svc;
        }

        public IActionResult Index()
        {
            var prods = _svc.GetAllProducts();
            return View(prods);
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
