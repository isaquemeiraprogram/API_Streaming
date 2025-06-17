using API_Streaming.Context;

namespace API_Streaming.Services
{
    public class ArtistaService
    {
        private readonly DataBase _context;

        public ArtistaService(DataBase _context)
        {
            this._context = _context;
        }
    }
}
