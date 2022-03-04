using move_ofertas.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Usuarios
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);

        void Cadastrar(Usuario novousuario);
    }
}
