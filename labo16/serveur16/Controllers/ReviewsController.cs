using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using serveur16.Data;
using serveur16.Models;
using serveur16.Models.DTOs;

namespace serveur16.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly serveur16Context _context;
        private readonly UserManager<User> _userManager;

        public ReviewsController(serveur16Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDisplayDTO>>> GetReview()
        {
            IEnumerable<Review> reviews = await _context.Review.ToListAsync();

            // Conversion de la liste de Comment en liste de CommentDisplayDTO
            return Ok(reviews.Select(c => new ReviewDisplayDTO(c)));


        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditReview(int id, ReviewDTO reviewDTO)
        {
            User? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            Review? review = await _context.Review.FindAsync(id);

            if (review == null) return NotFound();
            if (user == null || !user.Reviews.Contains(review)) return Unauthorized(new { Message = "Hey touche pas, c'est pas à toi !" });
  

            review.Text = reviewDTO.Text;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Review.AnyAsync(x => x.Id == id)) return null; // Commentaire n'existe plus ?
                else throw; // Erreur avec la BD
            }

            return Ok(new { Message = "Commentaire modifié", ReviewDisplayDTO = new ReviewDisplayDTO(review)  });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpvoteReview(int id)
        {
            User? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            Review? review = await _context.Review.FindAsync(id);

            if (review == null) return NotFound();
            if (user == null) return NotFound("Utilisateur non trouvé");
            if (user.Reviews.Contains(review)) return Unauthorized(new { Message = "On ne peut pas se donner un upvote" });

            if (review.Upvoters.Contains(user))
            {
                review.Upvoters.Remove(user);
            }
            else { 
                review.Upvoters.Add(user);
            
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Review.AnyAsync(x => x.Id == id)) return null; // Commentaire n'existe plus ?
                else throw; // Erreur avec la BD
            }

            return Ok(new { Message = "Ajout de upvote", ReviewDisplayDTO = new ReviewDisplayDTO(review) });
        }

        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(ReviewDTO reviewDTO)
        {
            User? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            if (user == null) return Unauthorized(); // Non authentifié ou token invalide

            Review r = new Review { Id = 0, Author = user, Game = reviewDTO.Game, Text = reviewDTO.Text };

            _context.Review.Add(r);
            await _context.SaveChangesAsync();


            return Ok(new ReviewDisplayDTO(r));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            User? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            Review? review = await _context.Review.FindAsync(id);
            if (review== null) return NotFound();
            if (user == null || !user.Reviews.Contains(review)) return Unauthorized();

            _context.Remove(review);
            await _context.SaveChangesAsync();


            return Ok(new { Message = "Commentaire supprimé." });

        }
    }
}
