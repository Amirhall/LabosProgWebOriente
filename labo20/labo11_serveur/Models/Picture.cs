namespace semaine11_serveur.Models
{
    public class Picture
    {
        // salut ça va ? ta session se passe bien ? tu prends soin de toi ? 
        public int Id { get; set; }

        // Deux seules propriétés nécessaires pour faire référence à une image
        public string FileName { get; set; } = null!;
        public string MimeType { get; set; } = null!;

    }
}
