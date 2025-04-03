using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using serveur15.Data;
using serveur15.Models;

namespace serveur15.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ZookeepersController : ControllerBase
    {
        private readonly serveur15Context _context;

        public ZookeepersController(serveur15Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zookeeper>>> GetZookeeper()
        {
            return await _context.Zookeeper.ToListAsync();
        }

        // PostZookeeper
        [HttpPost]
        public async Task<ActionResult<Zookeeper>> PostZookeeper(Zookeeper zookeeper)
        {
            _context.Zookeeper.Add(zookeeper);
            await _context.SaveChangesAsync();
            return zookeeper;
        }

        // DeleteZookeeper
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZookeeper(int id)
        {
            // Chercher le post avec l'id fourni
            Zookeeper? zookeeper = await _context.Zookeeper.FindAsync(id);

            // Il n'existe pas ? On arrête ici
            if (zookeeper == null) return NotFound();

            // Supprimer tous les commentaires du post !
            foreach (Dinosaur d in zookeeper.Dinosaurs)
            {
                _context.Dinosaur.Remove(d);
            }

            // Supprimer le post et enfin, sauvegarder tous les changements
            _context.Zookeeper.Remove(zookeeper);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Suppression du zookeeper complétée !" });

        }
    }
    }
