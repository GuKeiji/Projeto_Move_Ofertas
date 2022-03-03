using move_ofertas.webAPI.Domains;
using move_ofertas.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Repositories
{
    public class OfertasRepository : IOfertaRepository
    {
        public void AlterarDescricao(string descricao, int id)
        {
            throw new NotImplementedException();
        }

        public Ofertum BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void CadastrarOferta(Ofertum novaOferta)
        {
            throw new NotImplementedException();
        }

        public void CancelarOferta(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Ofertum> ListarMinhasOfertas(int id, int idTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public List<Ofertum> ListarTodas()
        {
            throw new NotImplementedException();
        }

        public void RemoverOferta(int id)
        {
            throw new NotImplementedException();
        }
    }
}
