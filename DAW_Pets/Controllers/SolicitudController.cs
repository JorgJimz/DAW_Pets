using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAW_Pets.Models;
using DAW_Pets.LogicaNegocio.Interface;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DAW_Pets.Controllers
{
    public class SolicitudController : Controller
    {
        private readonly IWebServiceEngine _ws;
        private readonly IMaestro _maestro;

        public SolicitudController(IWebServiceEngine _ws, IMaestro _maestro)
        {
            this._ws = _ws;
            this._maestro = _maestro;
        }

        // GET: Solicitud
        public async Task<IActionResult> Index()
        {
            var response = await _ws.GetAll_Service<Solicitud>("Servicios:Solicitud");
            return View(response.Listado);
        }

        // GET: Solicitud/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View();
        }

        // GET: Solicitud/Create
        public IActionResult Create()
        {
            ViewBag.Habitat = _maestro.GetAll_Habitat().Lista;
            return View();
        }

        // POST: Solicitud/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,UsuarioId,MascotaId,Detalle,QPersonas,TipoDomicilio,Ubicacion,Cubierto,Bebe,Alergia,Mudanza,Estado,FechaModificacion,UsuarioModificacion")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                var rs = await _ws.Post_Service<Solicitud>("Servicios:Solicitud", solicitud);
                ViewBag.Message = rs.Header.DescRetorno;
            }
            return PartialView("../Person/_Info");
        }

        // GET: Solicitud/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var solicitud = _ws.GetById_Service<Solicitud>("Servicios:Solicitud", id.ToString()).Result.Objeto;
            ViewBag.Estado = _maestro.GetAll_Estado().Lista;
            return View(solicitud);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Solicitud solicitud)
        {
            try
            {
                await _ws.Put_Service<Solicitud>("Servicios:Solicitud", solicitud, solicitud.Id.ToString());
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));            
        }

        // GET: Solicitud/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            return View();
        }

    }
}
