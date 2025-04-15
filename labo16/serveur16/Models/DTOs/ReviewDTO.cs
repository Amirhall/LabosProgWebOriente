using System.ComponentModel.DataAnnotations.Schema;

namespace serveur16.Models.DTOs
{
    public class ReviewDTO
    {
        public string Text { get; set; } = null!;
        public string Game { get; set; } = null!;


    }
}
