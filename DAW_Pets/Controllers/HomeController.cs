using DAW_Pets.LogicaNegocio.Interface;
using DAW_Pets.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DAW_Pets.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebServiceEngine _ws;

        public HomeController(IWebServiceEngine _ws)
        {
            this._ws = _ws;
        }
        public IActionResult Index()
        {            
            return View();
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
