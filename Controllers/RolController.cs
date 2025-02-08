using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca82.Data.Repositories.Context;
using Biblioteca82.Models.Domain;

namespace Biblioteca82.Controllers
{
    public class RolController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rol
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roles.ToListAsync());
        }

        // GET: Rol/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolEntity = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolEntity == null)
            {
                return NotFound();
            }

            return View(rolEntity);
        }

        // GET: Rol/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rol/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Id,EsBorrado")] RolEntity rolEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rolEntity);
        }

        // GET: Rol/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolEntity = await _context.Roles.FindAsync(id);
            if (rolEntity == null)
            {
                return NotFound();
            }
            return View(rolEntity);
        }

        // POST: Rol/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nombre,Id,EsBorrado")] RolEntity rolEntity)
        {
            if (id != rolEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolEntityExists(rolEntity.Id))
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
            return View(rolEntity);
        }

        // GET: Rol/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolEntity = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolEntity == null)
            {
                return NotFound();
            }

            return View(rolEntity);
        }

        // POST: Rol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolEntity = await _context.Roles.FindAsync(id);
            if (rolEntity != null)
            {
                _context.Roles.Remove(rolEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolEntityExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
