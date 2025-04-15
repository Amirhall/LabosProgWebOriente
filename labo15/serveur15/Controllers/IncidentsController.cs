using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serveur15.Data;
using serveur15.Models;
using serveur15.Models.DTOs;

namespace serveur15.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly serveur15Context _context;

        public IncidentsController(serveur15Context context)
        {
            _context = context;
        }

        // PostIncident
        [HttpPost]
        public async Task<ActionResult<Incident>> PostIncident(IncidentDTO incidentDTO)
        {
            List<Dinosaur>? dinoList = new List<Dinosaur>();
            for(int i = 0; i < incidentDTO.InvolvedDinosaursID.Count; i++){
                Dinosaur dino =  await _context.Dinosaur.FindAsync(incidentDTO.InvolvedDinosaursID[i]);
                dinoList.Add(dino);
            }
            if (dinoList == null) return NotFound(new { Message = "Ces dinos n'ont pas été trouver" });
            Incident incident = new Incident { Date = DateTime.Now, Description = incidentDTO.Description, Id = 0, NbCasualties = incidentDTO.NbCasualties, InvolvedDinosaurs = dinoList };
            _context.Incident.Add(incident);
            await _context.SaveChangesAsync();
            return incident;
        }
    }
}
