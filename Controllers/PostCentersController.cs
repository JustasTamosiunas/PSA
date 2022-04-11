using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PostCentersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostCentersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostCenters
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostCenters.ToListAsync());
        }

        // GET: PostCenters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCenter = await _context.PostCenters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postCenter == null)
            {
                return NotFound();
            }

            return View(postCenter);
        }

        // GET: PostCenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Street,City,BuildingNo,Name")] PostCenter postCenter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postCenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postCenter);
        }

        // GET: PostCenters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCenter = await _context.PostCenters.FindAsync(id);
            if (postCenter == null)
            {
                return NotFound();
            }
            return View(postCenter);
        }

        // POST: PostCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Street,City,BuildingNo,Latitude,Longitude,Name")] PostCenter postCenter)
        {
            if (id != postCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postCenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostCenterExists(postCenter.Id))
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
            return View(postCenter);
        }

        // GET: PostCenters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCenter = await _context.PostCenters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postCenter == null)
            {
                return NotFound();
            }

            return View(postCenter);
        }

        // POST: PostCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postCenter = await _context.PostCenters.FindAsync(id);
            _context.PostCenters.Remove(postCenter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostCenterExists(int id)
        {
            return _context.PostCenters.Any(e => e.Id == id);
        }
    }
}
