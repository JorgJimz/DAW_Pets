using DAW_Pets.Models;
using DAW_Pets.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore;

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
            var usr = db.Usuario.Include(p => p.Persona).Where(x => x.Login.Equals(user) && x.Password.Equals(pwd)).SingleOrDefault();
            if (usr is not null) {
                SessionHelper.SetObjectAsJson(HttpContext.Session, "logged", usr);
                return RedirectToAction("Index","Home");
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Security");
        }



    }
}
