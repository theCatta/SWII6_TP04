using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Data;
using tpSw04.Models;
using Common.Services;

namespace ClientWeb.Controllers
{
    public class CarroController : Controller
    {
        private readonly CarroService carroService;

        public CarroController(CarroService service)
        {
            carroService = service;
        }

        // GET: Carros
        public async Task<IActionResult> Index()
        {
            return View(await carroService.GetAll());
        }

        // GET: Carros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Carro = await carroService.GetById((int)id);

            if (Carro == null)
            {
                return NotFound();
            }

            return View(Carro);
        }

        // GET: Carros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Type,Text")] Carro Carro)
        {
            if (ModelState.IsValid)
            {
                await carroService.Create(Carro);
                return RedirectToAction(nameof(Index));
            }
            return View(Carro);
        }

        // GET: Carros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Carro = await carroService.GetById((int)id);

            if (Carro == null)
            {
                return NotFound();
            }

            return View(Carro);
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Type,Text")] Carro Carro)
        {
            if (id != Carro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await carroService.Update(id, Carro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(Carro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(Carro);
        }

        // GET: Carros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Carro = await carroService.GetById((int)id);

            if (Carro == null)
            {
                return NotFound();
            }

            await carroService.Delete(Carro.Id);

            return View(Carro);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await carroService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
            return !carroService.GetById(id).IsFaulted;
        }
    }
}
