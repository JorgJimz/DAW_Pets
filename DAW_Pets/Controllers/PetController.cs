using DAW_Pets.LogicaNegocio.Interface;
using DAW_Pets.Models;
using DAW_Pets.Models.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Pets.Controllers
{
    public class PetController : Controller
    {
        private readonly IWebServiceEngine _ws;
        private readonly IMaestro _maestro;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PetController(IWebServiceEngine _ws, IMaestro _maestro, IHostingEnvironment _hostingEnvironment)
        {
            this._maestro = _maestro;
            this._ws = _ws;
            this._hostingEnvironment = _hostingEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _ws.GetAll_Service<Mascota>("Servicios:Mascota");
            return View(response.Listado);
        }

        public async Task<IActionResult> List()
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
            if (ModelState.GetFieldValidationState("NeoComentario") == ModelValidationState.Valid)
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
        public async Task<IActionResult> Create([Bind("Id,Nombre,Raza,Color,Edad,Tipo,Descripcion,Direccion,Situacion,Observaciones,Alimentacion,EsperanzaVida,ActividadFisica,Peso,Altura,Tamaño,Clima,Habitat,Caracter,ImagenFile")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                if (mascota.ImagenFile != null)
                {
                    var uniqueFileName = GetUniqueFileName(mascota.ImagenFile.FileName);
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    mascota.ImagenFile.CopyTo(new FileStream(filePath, FileMode.Create));
                    mascota.Imagen = uniqueFileName;
                }
                var rs = await _ws.Post_Service<Mascota>("Servicios:Mascota", mascota);
                ViewBag.Message = rs.Header.DescRetorno;
                return RedirectToAction("List");
            }

            return View();
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

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}
