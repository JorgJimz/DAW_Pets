using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAW_Pets.Models.Helpers;
using DAW_Pets.Models;
using DAW_Pets.LogicaNegocio.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DAW_Pets.Controllers
{
    public class PersonController : Controller
    {
        private readonly IWebServiceEngine _ws;

        public PersonController(IWebServiceEngine _ws)
        {
            this._ws = _ws;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _ws.GetAll_Service<Persona>("Servicios:Persona");
            return View(response.Listado);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _ws.GetById_Service<Persona>("Servicios:Persona", id.Value.ToString());
            if (persona.Objeto == null)
            {
                return NotFound();
            }

            return View(persona.Objeto);
        }

        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipDoc,NumDoc,Nombre,Paterno,Materno,Fijo,Telefono,Trabajo,Email,Direccion,Pwd,ConfirmPwd,Estado")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                var rs = await _ws.Post_Service<Persona>("Servicios:Persona", persona);

                ViewBag.Accion = (persona.Estado == 1)? HeaderEnum.Redireccion.ToString(): "";
                ViewBag.Message = rs.Header.DescRetorno;
            }

            return PartialView("_Info");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _ws.GetById_Service<Persona>("Servicios:Persona", id.Value.ToString());
            if (persona.Objeto == null)
            {
                return NotFound();
            }
            return View(persona.Objeto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, [Bind("Id")] Persona persona)
         {
             if (id != persona.Id)
             {
                 return NotFound();
             }

             if (ModelState.GetFieldValidationState("Id") == ModelValidationState.Valid)
             {
                 try
                 {
                    Usuario u = new Usuario() {  PersonaId = persona.Id };
                    await _ws.Put_Service<Usuario>("Servicios:Usuario", u, u.PersonaId.ToString());                 
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                    return NotFound();
                }
                 return RedirectToAction(nameof(Index));
             }
             return View(persona);
         }
        
    }
}
