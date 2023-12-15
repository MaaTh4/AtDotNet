using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssementDotNet.AtDotnet.Data;
using AssementDotNet.AtDotnet.Models;

namespace AssementDotNet.AtDotnet.Controllers
{
    public class PersonagemCreatorController : Controller
    {
        private readonly AssementDotNetContext _context;

        public PersonagemCreatorController(AssementDotNetContext context)
        {
            _context = context;
        }

        // GET: PersonagemCreator
        public async Task<IActionResult> Index()
        {
            return _context.PersonagemCreator != null ?
                        View(await _context.PersonagemCreator.ToListAsync()) :
                        Problem("Entity set 'AssementDotNetContext.PersonagemCreator'  is null.");
        }

        // GET: PersonagemCreator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonagemCreator == null)
            {
                return NotFound();
            }

            var personagemCreator = await _context.PersonagemCreator
                .FirstOrDefaultAsync(m => m.age == id);
            if (personagemCreator == null)
            {
                return NotFound();
            }

            return View(personagemCreator);
        }

        // GET: PersonagemCreator/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonagemCreator/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("age,name,classe,poder,raca")] PersonagemCreator personagemCreator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personagemCreator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personagemCreator);
        }

        // GET: PersonagemCreator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonagemCreator == null)
            {
                return NotFound();
            }

            var personagemCreator = await _context.PersonagemCreator.FindAsync(id);
            if (personagemCreator == null)
            {
                return NotFound();
            }
            return View(personagemCreator);
        }

        // POST: PersonagemCreator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("age,name,classe,poder,raca")] PersonagemCreator personagemCreator)
        {
            if (id != personagemCreator.age)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personagemCreator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonagemCreatorExists(personagemCreator.age))
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
            return View(personagemCreator);
        }

        // GET: PersonagemCreator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonagemCreator == null)
            {
                return NotFound();
            }

            var personagemCreator = await _context.PersonagemCreator
                .FirstOrDefaultAsync(m => m.age == id);
            if (personagemCreator == null)
            {
                return NotFound();
            }

            return View(personagemCreator);
        }

        // POST: PersonagemCreator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonagemCreator == null)
            {
                return Problem("Entity set 'AssementDotNetContext.PersonagemCreator'  is null.");
            }
            var personagemCreator = await _context.PersonagemCreator.FindAsync(id);
            if (personagemCreator != null)
            {
                _context.PersonagemCreator.Remove(personagemCreator);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonagemCreatorExists(int id)
        {
            return (_context.PersonagemCreator?.Any(e => e.age == id)).GetValueOrDefault();
        }
    }
}
