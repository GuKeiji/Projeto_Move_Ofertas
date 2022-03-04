using move_ofertas.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<Tipousuario> ListarTodos();
    }
}
