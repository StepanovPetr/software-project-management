using System.Linq;
using System.Threading.Tasks;
using _45Club.app.Models;
using _45Club.app.Models.Dto;
using _45Club.app.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _45Club.app.Controllers
{
    public class TransportController : Controller
    {
        private readonly Context _context;

        public TransportController(Context context)
        {
            _context = context;
        }

        // GET: Transports
        public async Task<IActionResult> Index(TransportSearch transportSearch)
        {
            var transports = await _context.Transports
                .Where(t => string.IsNullOrEmpty(transportSearch.Vin) || t.Vin.Contains(transportSearch.Vin)
                    && (string.IsNullOrEmpty(transportSearch.StateSign) ||
                        t.StateSign.Contains(transportSearch.StateSign))
                    && (string.IsNullOrEmpty(transportSearch.Model) || t.StateSign.Contains(transportSearch.Model)))
                .Include(t => t.Works)
                .ToListAsync();

            return View(transports);
        }

        // GET: Transports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var transport = await _context.Transports
                .Include(t => t.Works)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transport == null) return NotFound();

            return View(transport);
        }

        // GET: Transports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,View,DateOfIssue,Model,Vin,StateSign")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(transport);
        }

        // GET: Transports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var transport = await _context.Transports.FindAsync(id);
            if (transport == null) return NotFound();
            return View(transport);
        }

        // POST: Transports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,View,DateOfIssue,Model,Vin,StateSign")]
            Transport transport)
        {
            if (id != transport.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportExists(transport.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(transport);
        }

        // GET: Transports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var transport = await _context.Transports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transport == null) return NotFound();

            return View(transport);
        }

        // POST: Transports/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transport = await _context.Transports.FindAsync(id);
            _context.Transports.Remove(transport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportExists(int id)
        {
            return _context.Transports.Any(e => e.Id == id);
        }
    }
}