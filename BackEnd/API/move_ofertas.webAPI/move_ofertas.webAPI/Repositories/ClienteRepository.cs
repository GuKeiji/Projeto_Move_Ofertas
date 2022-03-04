using move_ofertas.webAPI.Contexts;
using move_ofertas.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Clientes
{
   
    public class ClienteRepository : IClienteRepository
    {
        MoveOfertasContext ctx = new MoveOfertasContext();

       
        public void Cadastrar(Cliente novocliente)
        {
            if (DateTime.Now > novocliente.DataNascimento)
            {
                ctx.Add(novocliente);

                ctx.SaveChanges();
            }
        }

        public List<Cliente> ListarTodos()
        {
            return ctx.Clientes.ToList();
        }
    }
}
