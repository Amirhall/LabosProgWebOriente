using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using S08_Labo.Data;
using S08_Labo.Models;
using S08_Labo.Models.ViewModel;

namespace S08_Labo.Controllers
{
    public class ArtistesController : Controller
    {
        private readonly S08EmployesContext _context;

        public ArtistesController(S08EmployesContext context)
        {
            _context = context;
        }

        // GET: Artistes
        public async Task<IActionResult> Index()
        {
            var s08EmployesContext = _context.Artistes.Include(a => a.Employe);
            return View(await s08EmployesContext.ToListAsync());
        }
        public async Task<IActionResult> Index2()
        {

            IEnumerable<VwListeArtiste> artistes = await _context.VwListeArtistes.ToListAsync();
            return View(artistes);
        }

        // GET: Artistes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artistes
                .Include(a => a.Employe)
                .FirstOrDefaultAsync(m => m.ArtisteId == id);
            if (artiste == null)
            {
                return NotFound();
            }

            return View(artiste);
        }

        // GET: Artistes/Create
        public IActionResult Create()
        {
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId");
            return View();
        }

        // POST: Artistes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Artiste,Employe")] ArtisteEmployeViewModel artisteEmployeViewModel)
        {

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter{ ParameterName= "@Prenom",Value= artisteEmployeViewModel.Employe.Prenom},
                    new SqlParameter{ ParameterName= "@Nom",Value= artisteEmployeViewModel.Employe.Nom},
                    new SqlParameter{ ParameterName= "@NoTel",Value= artisteEmployeViewModel.Employe.NoTel},
                    new SqlParameter{ ParameterName= "@Courriel",Value= artisteEmployeViewModel.Employe.Courriel},
                    new SqlParameter{ ParameterName= "@Specialite",Value= artisteEmployeViewModel.Artiste.Specialite},


                };


                string query = "EXEC Employes.USP_AjouterArtiste @Prenom, @Nom, @NoTel, @Courriel,@Specialite";
                await _context.Database.ExecuteSqlRawAsync(query,parameters.ToArray());


                await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Artistes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artistes.FindAsync(id);
            if (artiste == null)
            {
                return NotFound();
            }
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId", artiste.EmployeId);
            return View(artiste);
        }

        // POST: Artistes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtisteId,Specialite,EmployeId")] Artiste artiste)
        {
            if (id != artiste.ArtisteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artiste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtisteExists(artiste.ArtisteId))
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
            ViewData["EmployeId"] = new SelectList(_context.Employes, "EmployeId", "EmployeId", artiste.EmployeId);
            return View(artiste);
        }

        // GET: Artistes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artistes
                .Include(a => a.Employe)
                .FirstOrDefaultAsync(m => m.ArtisteId == id);
            if (artiste == null)
            {
                return NotFound();
            }

            return View(artiste);
        }

        // POST: Artistes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {




            string query = "DELETE FROM Employes.Artiste WHERE ArtisteID =@id";
            SqlParameter idParameter = new SqlParameter("@id", id);
            await _context.Database.ExecuteSqlRawAsync(query,idParameter);


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ArtisteExists(int id)
        {
            return _context.Artistes.Any(e => e.ArtisteId == id);
        }
    }
}
