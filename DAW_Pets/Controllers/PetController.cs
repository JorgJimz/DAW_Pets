using DAW_Pets.LogicaNegocio.Interface;
using DAW_Pets.Models;
using DAW_Pets.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Pets.Controllers
{
    public class PetController : Controller
    {
        private readonly IWebServiceEngine _ws;
        private readonly IMaestro _maestro;

        public PetController(IWebServiceEngine _ws, IMaestro _maestro)
        {
            this._maestro = _maestro;
            this._ws = _ws;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _ws.GetAll_Service<Mascota>("Servicios:Mascota");
            return View(response.Listado);
        }

        public async Task<IActionResult> GetComments()
        {
            var response = await _ws.GetAll_Service<Mascota>("Servicios:Mascota");
            return View(response.Listado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(Mascota ComentarioMascota)
        {
            WS_Response<Comentario> nComment = null;
            if (ModelState.IsValid)
            {
                Comentario c = new Comentario()
                {
                    UsuarioId = ComentarioMascota.NeoComentario.UsuarioId,
                    MascotaId = ComentarioMascota.NeoComentario.MascotaId,
                    Fecha = DateTime.Now,
                    Comentario1 = ComentarioMascota.NeoComentario.Comentario1
                };
                nComment = await _ws.Post_Service<Comentario>("Servicios:Comentario", c);
                ViewBag.Message = nComment.Header.DescRetorno;
            }

            return Json(nComment);
        }

        public ActionResult Details(int id)
        {
            var mascota = _ws.GetById_Service<Mascota>("Servicios:Mascota", id.ToString()).Result.Objeto;
            if (mascota.Id != 0)
            {
                ViewBag.Vida = _maestro.GetAll_Vida().Lista.Select(x =>
                {
                    if (int.Parse(x.Atributo1) <= mascota.EsperanzaVida && int.Parse(x.Atributo2) >= mascota.EsperanzaVida)
                    {
                        x.Selected = true;
                    }
                    return x;
                }).ToList();

                ViewBag.Actividad = _maestro.GetAll_Actividad().Lista.Select(x =>
                {
                    if (x.Valor.Equals(mascota.ActividadFisica))
                    {
                        x.Selected = true;
                    }
                    return x;
                }).ToList();

                ViewBag.Habitat = _maestro.GetAll_Habitat().Lista;
                return PartialView(mascota);
            }
            else
            {
                ViewBag.Message = "Sin información para mostrar. Comuníquese con TI.";
                return PartialView("../Person/_Info");
            }


        }

        public ActionResult Create()
        {
            ViewBag.Actividad = _maestro.GetAll_Actividad().Lista;
            ViewBag.Especie = _maestro.GetAll_Especie().Lista;
            ViewBag.Situacion = _maestro.GetAll_Situacion().Lista;
            ViewBag.Caracter = _maestro.GetAll_Caracter().Lista;
            ViewBag.Clima = _maestro.GetAll_Clima().Lista;
            ViewBag.Habitat = _maestro.GetAll_Habitat().Lista;
            ViewBag.Tamano = _maestro.GetAll_Tamano().Lista;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Raza,Color,Edad,Tipo,Descripcion,Direccion,Situacion,Observaciones,Alimentacion,EsperanzaVida,ActividadFisica,Peso,Altura,Tamaño,Clima,Habitat,Caracter")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                var rs = await _ws.Post_Service<Mascota>("Servicios:Mascota", mascota);
            }

            return PartialView("_Info");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
