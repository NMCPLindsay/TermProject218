using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ProjectContext _context;

        public CandidatesController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Candidates.Include(c => c.Party).Include(c => c.State);
            return View(await projectContext.ToListAsync());
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = await _context.Candidates
                .Include(c => c.Party)
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidates == null)
            {
                return NotFound();
            }

            return View(candidates);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            ViewData["PartyId"] = new SelectList(_context.Party, "Id", "Name");
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Id");
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PartyId,StateId")] Candidates candidates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PartyId"] = new SelectList(_context.Party, "Id", "Name", candidates.PartyId);
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Id", candidates.StateId);
            return View(candidates);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = await _context.Candidates.FindAsync(id);
            if (candidates == null)
            {
                return NotFound();
            }
            ViewData["PartyId"] = new SelectList(_context.Party, "Id", "Name", candidates.PartyId);
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Id", candidates.StateId);
            return View(candidates);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PartyId,StateId")] Candidates candidates)
        {
            if (id != candidates.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatesExists(candidates.Id))
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
            ViewData["PartyId"] = new SelectList(_context.Party, "Id", "Name", candidates.PartyId);
            ViewData["StateId"] = new SelectList(_context.State, "Id", "Id", candidates.StateId);
            return View(candidates);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = await _context.Candidates
                .Include(c => c.Party)
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidates == null)
            {
                return NotFound();
            }

            return View(candidates);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidates = await _context.Candidates.FindAsync(id);
            _context.Candidates.Remove(candidates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatesExists(int id)
        {
            return _context.Candidates.Any(e => e.Id == id);
        }
    }
}
