using serveur15.Data;

namespace serveur15.Services
{
    public class DinosaurService
    {
        private readonly serveur15Context _context;

        public DinosaurService(serveur15Context context)
        {
            _context = context;
        }
    }
}
