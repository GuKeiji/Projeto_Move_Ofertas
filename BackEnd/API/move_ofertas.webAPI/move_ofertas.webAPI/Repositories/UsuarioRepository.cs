using move_ofertas.webAPI.Contexts;
using move_ofertas.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {

        MoveOfertasContext ctx = new MoveOfertasContext();
        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public void Cadastrar(Usuario novousuario)
        {
            ctx.Add(novousuario);

            ctx.SaveChanges();
        }
    }
}
