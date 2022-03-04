using move_ofertas.webAPI.Contexts;
using move_ofertas.webAPI.Domains;
using move_ofertas.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        MoveOfertasContext ctx = new MoveOfertasContext();
        public List<Tipousuario> ListarTodos()
        {
            return ctx.Tipousuarios.ToList();
        }
    }
}
