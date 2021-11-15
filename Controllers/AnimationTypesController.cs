using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PopcornWebApp.Data;
using PopcornWebApp.Models;

namespace PopcornWebApp.Controllers
{
    public class AnimationTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimationTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnimationTypes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnimationTypes.ToListAsync());
        }

        // GET: AnimationTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnimationTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] AnimationTypes animationTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animationTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animationTypes);
        }

        // GET: AnimationTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animationTypes = await _context.AnimationTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animationTypes == null)
            {
                return NotFound();
            }

            return View(animationTypes);
        }

        // POST: AnimationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animationTypes = await _context.AnimationTypes.FindAsync(id);
            _context.AnimationTypes.Remove(animationTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimationTypesExists(int id)
        {
            return _context.AnimationTypes.Any(e => e.Id == id);
        }
    }
}
