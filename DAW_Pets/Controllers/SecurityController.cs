using DAW_Pets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Pets.Controllers
{
    public class SecurityController : Controller
    {
        // GET: SecurityController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string pwd)
        {
            var db = new DBESANDWContext();
            if (db.Usuario.Any(x => x.Login.Equals(user) && x.Password.Equals(pwd))) {
                return RedirectToAction("Index","Home");
            }
            return View("Index");
        }
        
    }
}
