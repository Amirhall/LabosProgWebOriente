using serveur15.Data;

namespace serveur15.Services
{
    public class ZookeeperService
    {
        private readonly serveur15Context _context;

        public ZookeeperService(serveur15Context context)
        {
            _context = context;
        }
    }
}
