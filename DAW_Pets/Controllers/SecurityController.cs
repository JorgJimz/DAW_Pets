using DAW_Pets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using System;
using DAW_Pets.Models.Helpers;

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
        public async Task<ActionResult> Login(string user, string pwd)
        {
            var db = new DBESANDWContext();

            var usr = db.Usuario.Include(p => p.Persona).Where(x => x.Login.Equals(user)).SingleOrDefault();            
            if (usr is not null && HashHelper.CheckHash(pwd, usr.Password, usr.Sal))
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usr.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, string.Format("{0} {1} {2}",usr.Persona.Nombre, usr.Persona.Paterno, usr.Persona.Materno)));
                identity.AddClaim(new Claim(ClaimTypes.Email, usr.Persona.Email));
                identity.AddClaim(new Claim(ClaimTypes.StreetAddress, usr.Persona.Direccion));
                identity.AddClaim(new Claim(ClaimTypes.HomePhone, usr.Persona.Fijo));
                identity.AddClaim(new Claim(ClaimTypes.MobilePhone, usr.Persona.Telefono));
                identity.AddClaim(new Claim(ClaimTypes.OtherPhone, usr.Persona.Trabajo));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.Now.AddHours(1) });
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Security");
        }



    }
}
