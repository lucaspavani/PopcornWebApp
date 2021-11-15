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
    public class SessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sessions
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sessions.Include(s => s.AnimationTypes).Include(s => s.AudioTypes).Include(s => s.Movies).Include(s => s.Rooms);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessions = await _context.Sessions
                .Include(s => s.AnimationTypes)
                .Include(s => s.AudioTypes)
                .Include(s => s.Movies)
                .Include(s => s.Rooms)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sessions == null)
            {
                return NotFound();
            }

            return View(sessions);
        }

        // GET: Sessions/Create
        public IActionResult Create()
        {
            ViewData["AnimationTypesFK"] = new SelectList(_context.AnimationTypes, "Id", "Type");
            ViewData["AudioTypesFK"] = new SelectList(_context.AudioTypes, "Id", "Type");
            ViewData["MoviesFK"] = new SelectList(_context.Movies, "Id", "MovieTitle");
            ViewData["RoomsFK"] = new SelectList(_context.Rooms, "Id", "RoomName");
            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SessionDate,SessionStart,SessionEnd,TicketPrice,AnimationTypesFK,AudioTypesFK,MoviesFK,RoomsFK")] Sessions sessions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sessions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimationTypesFK"] = new SelectList(_context.AnimationTypes, "Id", "Type", sessions.AnimationTypesFK);
            ViewData["AudioTypesFK"] = new SelectList(_context.AudioTypes, "Id", "Type", sessions.AudioTypesFK);
            ViewData["MoviesFK"] = new SelectList(_context.Movies, "Id", "MovieImage", sessions.MoviesFK);
            ViewData["RoomsFK"] = new SelectList(_context.Rooms, "Id", "RoomName", sessions.RoomsFK);
            return View(sessions);
        }

        // GET: Sessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessions = await _context.Sessions.FindAsync(id);
            if (sessions == null)
            {
                return NotFound();
            }
            ViewData["AnimationTypesFK"] = new SelectList(_context.AnimationTypes, "Id", "Type", sessions.AnimationTypesFK);
            ViewData["AudioTypesFK"] = new SelectList(_context.AudioTypes, "Id", "Type", sessions.AudioTypesFK);
            ViewData["MoviesFK"] = new SelectList(_context.Movies, "Id", "MovieTitle", sessions.MoviesFK);
            ViewData["RoomsFK"] = new SelectList(_context.Rooms, "Id", "RoomName", sessions.RoomsFK);
            return View(sessions);
        }

        // POST: Sessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SessionDate,SessionStart,SessionEnd,TicketPrice,AnimationTypesFK,AudioTypesFK,MoviesFK,RoomsFK")] Sessions sessions)
        {
            if (id != sessions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionsExists(sessions.Id))
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
            ViewData["AnimationTypesFK"] = new SelectList(_context.AnimationTypes, "Id", "Type", sessions.AnimationTypesFK);
            ViewData["AudioTypesFK"] = new SelectList(_context.AudioTypes, "Id", "Type", sessions.AudioTypesFK);
            ViewData["MoviesFK"] = new SelectList(_context.Movies, "Id", "MovieTitle", sessions.MoviesFK);
            ViewData["RoomsFK"] = new SelectList(_context.Rooms, "Id", "RoomName", sessions.RoomsFK);
            return View(sessions);
        }

        // GET: Sessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessions = await _context.Sessions
                .Include(s => s.AnimationTypes)
                .Include(s => s.AudioTypes)
                .Include(s => s.Movies)
                .Include(s => s.Rooms)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sessions == null)
            {
                return NotFound();
            }

            return View(sessions);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sessions = await _context.Sessions.FindAsync(id);
            _context.Sessions.Remove(sessions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionsExists(int id)
        {
            return _context.Sessions.Any(e => e.Id == id);
        }
    }
}
