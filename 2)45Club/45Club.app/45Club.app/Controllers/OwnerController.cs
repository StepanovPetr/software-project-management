using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _45Club.app.Models;
using _45Club.app.Models.Dto;
using _45Club.app.Models.Entities;

namespace _45Club.app.Controllers
{
    public class OwnerController : Controller
    {
        private readonly Context _context;

        public OwnerController(Context context)
        {
            _context = context;
        }

        // GET: Owner
        public async Task<IActionResult> Index()
        {
            return View(await _context.Owners.ToListAsync());
        }

        // GET: Owner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owners = await _context.Owners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (owners == null)
            {
                return NotFound();
            }

            return View(owners);
        }

        // GET: Owner/Create
        public IActionResult Create(int transportId)
        {
            var ownerCreate = new OwnerCreate
            {
                TransportId = transportId,
                Persons = _context.Persons.Select(p => new Models.Dto.Person
                        { Id = p.Id, Name = $"{p.FirstName} {p.LastName}" })
                    .ToArray(),
            };
            
            return View(ownerCreate);
        }

        // POST: Owner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TransportId,PersonId,IsActive")] Owners owner)
        {
            if (ModelState.IsValid)
            {
                foreach (var owners in _context.Owners.Where( o => o.TransportId == owner.TransportId))
                {
                    owners.IsActive = false;
                }
                _context.Add(owner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        // GET: Owner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owners = await _context.Owners.FindAsync(id);
            if (owners == null)
            {
                return NotFound();
            }
            return View(owners);
        }

        // POST: Owner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TransportId,PersonId,IsActive")] Owners owners)
        {
            if (id != owners.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(owners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnersExists(owners.Id))
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
            return View(owners);
        }

        // GET: Owner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owners = await _context.Owners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (owners == null)
            {
                return NotFound();
            }

            return View(owners);
        }

        // POST: Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var owners = await _context.Owners.FindAsync(id);
            _context.Owners.Remove(owners);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnersExists(int id)
        {
            return _context.Owners.Any(e => e.Id == id);
        }
    }
}
