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
using serveur15.Models.DTOs;

namespace serveur15.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DinosaursController : ControllerBase
    {
        private readonly serveur15Context _context;

        public DinosaursController(serveur15Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dinosaur>>> GetDinosaur()
        {
            return await _context.Dinosaur.ToListAsync();
        }

        // PostDinosaur
        [HttpPost]
        public async Task<ActionResult<Dinosaur>> PostDinosaur(DinosaurDTO dinosaurDTO)
        {
            Zookeeper? zookeeper = await _context.Zookeeper.FindAsync(dinosaurDTO.ZookeeperID);
            if (zookeeper == null) return NotFound(new { Message = "Ce zookeeper n'existe pas. Il a peut-être été supprimé ?" });
            Dinosaur dinosaur = new Dinosaur { Name = dinosaurDTO.Name, Specie = dinosaurDTO.Specie, Id = 0, Zookeeper = zookeeper, Incidents = new List<Incident>() };
            _context.Dinosaur.Add(dinosaur);
            await _context.SaveChangesAsync();
            return dinosaur;
        }
        // DeleteDinosaur
    }
}
