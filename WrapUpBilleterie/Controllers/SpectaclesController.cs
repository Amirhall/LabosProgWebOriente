using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WrapUpBilleterie.Data;
using WrapUpBilleterie.Models;
using WrapUpBilleterie.ViewModels;

namespace WrapUpBilleterie.Controllers
{
    public class SpectaclesController : Controller
    {
        private readonly R22_BilleterieContext _context;

        public SpectaclesController(R22_BilleterieContext context)
        {
            _context = context;
        }

        // GET: Spectacles
        public async Task<IActionResult> Index()
        {
            IEnumerable<VwSpectaclesRepresentationSpectateur> spectacles = await _context.VwSpectaclesRepresentationSpectateurs.ToListAsync();
            return View(spectacles);
        }

        // GET: Spectacles/Details/5
        public async Task<IActionResult> DetailsAncien(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spectacle = await _context.Spectacles
                .FirstOrDefaultAsync(m => m.SpectacleId == id);
            if (spectacle == null)
            {
                return NotFound();
            }

            return View(spectacle);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spectacle = await _context.Spectacles
                .FirstOrDefaultAsync(m => m.SpectacleId == id);
            if (spectacle == null)
            {
                return NotFound();
            }

            VwSpectaclesRepresentationSpectateur VwSpectacleVue = await _context.VwSpectaclesRepresentationSpectateurs.Where(x => x.SpectacleId == id).FirstOrDefaultAsync();
            IEnumerable<Representation> representations = await _context.Representations.Where(r => r.SpectacleId == spectacle.SpectacleId).ToListAsync();
            string imageString = await _context.Affiches
                .Where(a => a.SpectacleId == spectacle.SpectacleId)
                .Select(a => a.AfficheContent == null ? null : $"data:image/png;base64, {Convert.ToBase64String(a.AfficheContent)}")
                .FirstOrDefaultAsync();


            SpectaclesAfficheRepresentationViewModel spectaclesAfficheRepresentation = new SpectaclesAfficheRepresentationViewModel()

            {
                vwSpectacleVue = VwSpectacleVue,
                Representations = representations,
                AfficheContent = imageString

            };


            return View(spectaclesAfficheRepresentation);
        }

        // GET: Spectacles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spectacles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpectacleId,Nom,Debut,Fin,Prix")] Spectacle spectacle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spectacle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spectacle);
        }

        // GET: Spectacles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spectacle = await _context.Spectacles.FindAsync(id);
            if (spectacle == null)
            {
                return NotFound();
            }
            return View(spectacle);
        }

        // POST: Spectacles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpectacleId,Nom,Debut,Fin,Prix")] Spectacle spectacle)
        {
            if (id != spectacle.SpectacleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spectacle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpectacleExists(spectacle.SpectacleId))
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
            return View(spectacle);
        }

        // GET: Spectacles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spectacle = await _context.Spectacles
                .FirstOrDefaultAsync(m => m.SpectacleId == id);
            if (spectacle == null)
            {
                return NotFound();
            }

            return View(spectacle);
        }

        // POST: Spectacles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spectacle = await _context.Spectacles.FindAsync(id);
            if (spectacle != null)
            {
                _context.Spectacles.Remove(spectacle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpectacleExists(int id)
        {
            return _context.Spectacles.Any(e => e.SpectacleId == id);
        }
    }
}
