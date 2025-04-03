namespace serveur15.Models.DTOs
{
    public class IncidentDTO
    {
        public int NbCasualties { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = null!;

        public List<int> InvolvedDinosaursID { get; set; } = new List<int>();
    }
}
