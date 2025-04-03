namespace serveur15.Models.DTOs
{
    public class DinosaurDTO
    {
            public string Name { get; set; } = null!;
            public string Specie { get; set; } = null!;
            public List<int> IncidentsIDs { get; set; } = new List<int>();
            public int ZookeeperID { get; set; }
    }
}
