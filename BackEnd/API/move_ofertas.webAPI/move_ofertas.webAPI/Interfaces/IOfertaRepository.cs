using move_ofertas.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Interfaces
{
    interface IOfertaRepository
    {
        
            void CadastrarOferta(Ofertum novaOferta);
            void AlterarDescricao(string descricao, int id);
            void RemoverOferta(int id);
            void CancelarOferta(int Id);
            Ofertum BuscarPorId(int id);
            List<Ofertum> ListarMinhasOfertas(int id, int idTipoUsuario);
            List<Ofertum> ListarTodas();
        
    }

}
