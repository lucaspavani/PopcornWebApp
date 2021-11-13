using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PopcornWebApp.Data;
using PopcornWebApp.Models;

namespace PopcornWebApp.Controllers
{
    public class AudioTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AudioTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AudioTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AudioTypes.ToListAsync());
        }

        // GET: AudioTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audioTypes = await _context.AudioTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (audioTypes == null)
            {
                return NotFound();
            }

            return View(audioTypes);
        }

        // GET: AudioTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AudioTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] AudioTypes audioTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(audioTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(audioTypes);
        }

        // GET: AudioTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audioTypes = await _context.AudioTypes.FindAsync(id);
            if (audioTypes == null)
            {
                return NotFound();
            }
            return View(audioTypes);
        }

        // POST: AudioTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] AudioTypes audioTypes)
        {
            if (id != audioTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(audioTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AudioTypesExists(audioTypes.Id))
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
            return View(audioTypes);
        }

        // GET: AudioTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audioTypes = await _context.AudioTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (audioTypes == null)
            {
                return NotFound();
            }

            return View(audioTypes);
        }

        // POST: AudioTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var audioTypes = await _context.AudioTypes.FindAsync(id);
            _context.AudioTypes.Remove(audioTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AudioTypesExists(int id)
        {
            return _context.AudioTypes.Any(e => e.Id == id);
        }
    }
}
