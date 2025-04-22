using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using semaine11_serveur.Data;
using semaine11_serveur.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace semaine11_serveur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly semaine11_serveurContext _context;

        public PicturesController(semaine11_serveurContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetPictureIds()
        {
            // À modifier
            List<int> pictures = await _context.Picture.Select(p => p.Id).ToListAsync();
            return Ok(pictures);
        }

        [HttpGet("{size}/{id}")]
        public async Task<ActionResult> GetPicture(string size, int id)
        {
            Picture? si = await _context.Picture.FindAsync(id);
            if (si == null) return NotFound();

            // Si la size fournit ne correspond pas à "big" OU "smol", erreur.
            if (!Regex.Match(size, "large|small").Success) return BadRequest(new { Message = "La taille demandée n'existe pas." });

            // Récupération du fichier sur le disque
            byte[] bytes = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/" + size + "/" + si.FileName);
            return File(bytes, si.MimeType);

            // À modifier
        }

        [HttpPost]
        public async Task<ActionResult> PostPicture()
        {
            List<int> ids = new List<int> { };
            try
            {
                IFormCollection formCollection = await Request.ReadFormAsync();
                for (int i=0; i < formCollection.Files.Count(); i++) { 
                    IFormFile? file = formCollection.Files.GetFile("monImage" + i); // ⛔ Même clé que dans le FormData 😠

                    if (file == null) return BadRequest(new { Message = "Fournis une image, niochon" });

                    Image image = Image.Load(file.OpenReadStream());

                    Picture si = new Picture
                    {
                        Id = 0,
                        FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName),
                        MimeType = file.ContentType
                    };

                    // ⛔ Ce dossier (projet/images/big) DOIT déjà exister 📂 !! Créez-le d'abord !
                    image.Save(Directory.GetCurrentDirectory() + "/images/large/" + si.FileName);

                    // 🤏 Optionnel mais souhaitable : réduire la taille de l'image pour sauvegarder une
                    // copie miniature. Remarquez qu'on a utilisé un sous-dossier différent ! 📂
                    image.Mutate(i => i.Resize(
                        new ResizeOptions() { Mode = ResizeMode.Min, Size = new Size() { Height = 200 } }));
                    image.Save(Directory.GetCurrentDirectory() + "/images/small/" + si.FileName);

                    _context.Picture.Add(si);
                    ids.Add(si.Id);
                
                }
                await _context.SaveChangesAsync();

                // La seule chose dont le client pourrait avoir besoin, c'est l'id de l'image.
                // On aurait pu ne rien retourner aussi, selon les besoins du client Angular.
                return Ok(ids);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePicture(int id)
        {
            Picture? si = await _context.Picture.FindAsync(id);
            if (si == null) return NotFound(new { Message = "Aucune image trouvée avec cet id." });
            System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/large/" + si.FileName);
            System.IO.File.Delete(Directory.GetCurrentDirectory() + "/images/small/" + si.FileName);

            _context.Picture.Remove(si);
            await _context.SaveChangesAsync();


            // À modifier
            return Ok();
        }
    }
}
