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
using DAW_Pets.LogicaNegocio.Interface;
using Microsoft.Extensions.Configuration;

namespace DAW_Pets.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IWebServiceEngine _ws;
        private readonly IMaestro _maestro;

        public SecurityController(IWebServiceEngine _ws, IMaestro _maestro)
        {
            this._maestro = _maestro;
            this._ws = _ws;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string user, string pwd)
        {
            var usr = _ws.GetById_Service<Usuario>("Servicios:Login", string.Format("{0}/{1}",user, pwd)).Result.Objeto;
            if (usr is not null)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usr.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, string.Format("{0} {1} {2}",usr.Persona.Nombre, usr.Persona.Paterno, usr.Persona.Materno)));
                identity.AddClaim(new Claim("DId", string.Format("{0}-{1}",usr.Persona.TipDoc,usr.Persona.NumDoc)));
                identity.AddClaim(new Claim(ClaimTypes.Email, usr.Persona.Email));
                identity.AddClaim(new Claim(ClaimTypes.StreetAddress, usr.Persona.Direccion));
                identity.AddClaim(new Claim(ClaimTypes.HomePhone, usr.Persona.Fijo));
                identity.AddClaim(new Claim(ClaimTypes.MobilePhone, usr.Persona.Telefono));
                identity.AddClaim(new Claim(ClaimTypes.OtherPhone, usr.Persona.Trabajo));
                identity.AddClaim(new Claim(ClaimTypes.Role, usr.Rol.Descripcion));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.Now.AddHours(1) });
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Security");
        }



    }
}
