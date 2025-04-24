using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using S09_Labo.Data;
using S09_Labo.Models;
using S09_Labo.ViewModels;

namespace S09_Labo.Controllers
{
    public class MusiqueController : Controller
    {
        private readonly S09LaboContext _context;

        public MusiqueController(S09LaboContext context)
        {
            _context = context;
        }

        // GET: Chanteurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chanteurs.ToListAsync());
        }


        public async Task<IActionResult> ChanteursEtChansons()
        {
            // On va récupérer toutes les chansons et les chanteurs pour les envoyer à la vue
            ChanteursChansonsViewModel ccvm = new ChanteursChansonsViewModel()
            {
                Chanteurs = await _context.Chanteurs.ToListAsync(),
                Chansons = await _context.Chansons.ToListAsync()
            };
            return View(ccvm);
        }

        public async Task<IActionResult> Chanteurs()
        {
            // À cause du lazy loading, on charge les chansons de la BD :
            List<Chanson> chansons = await _context.Chansons.ToListAsync();

            // Ensuite on va chercher les chanteurs ET on compte leur nombre de chansons pour chacun
            List<ChanteurEtNbChansonsViewModel> cencvm = await _context.Chanteurs
                .Select(x => new ChanteurEtNbChansonsViewModel()
                {
                    Chanteur = x,
                    NbChansons = x.Chansons.Count
                }).ToListAsync();
            return View(cencvm);
        }

        public async Task<IActionResult> UnChanteurEtSesChansons(string chanteurRecherche)
        {
            // Trouver un chanteur par son nom. Pas sensible à la casse
            Chanteur? chanteur = await _context.Chanteurs.Where(x => x.Nom.ToUpper() == chanteurRecherche.ToUpper()).FirstOrDefaultAsync();
            if (chanteur == null)
            {
                ViewData["chanteurNonTrouve"] = "Cet artiste n'existe pas.";
                return RedirectToAction("Index", "Musique");
            }
            // Obtenir la liste des chansons du chanteur (Sera modifié à la migration 1.3)
            // La fouille est basée sur le titre de la chanson au lieu de son id...
            List<Chanson> chansons = await _context.Chansons.Where(x => x.ChanteurId == chanteur.ChanteurId).ToListAsync();

            return View(new ChanteurEtSesChansonsViewModel()
            {
                Chanteur = chanteur,
                Chansons = chansons
            });
        }
        private bool ChanteurExists(string id)
        {
            return _context.Chanteurs.Any(e => e.Nom == id);
        }
    }
}
