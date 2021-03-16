using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webcore.Data;
using webcore.Models;

namespace webcore.Controllers
{
    public class duclongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public duclongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: duclongs
        public async Task<IActionResult> Index()
        {
            return View(await _context.duclong.ToListAsync());
        }

        // GET: duclongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duclong = await _context.duclong
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duclong == null)
            {
                return NotFound();
            }

            return View(duclong);
        }

        // GET: duclongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: duclongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DuclongQuestion,DuclongAnswer")] duclong duclong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duclong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(duclong);
        }

        // GET: duclongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duclong = await _context.duclong.FindAsync(id);
            if (duclong == null)
            {
                return NotFound();
            }
            return View(duclong);
        }

        // POST: duclongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DuclongQuestion,DuclongAnswer")] duclong duclong)
        {
            if (id != duclong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duclong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!duclongExists(duclong.Id))
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
            return View(duclong);
        }

        // GET: duclongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duclong = await _context.duclong
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duclong == null)
            {
                return NotFound();
            }

            return View(duclong);
        }

        // POST: duclongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duclong = await _context.duclong.FindAsync(id);
            _context.duclong.Remove(duclong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool duclongExists(int id)
        {
            return _context.duclong.Any(e => e.Id == id);
        }
    }
}
