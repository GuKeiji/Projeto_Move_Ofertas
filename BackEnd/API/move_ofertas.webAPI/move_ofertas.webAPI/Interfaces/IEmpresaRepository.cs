using move_ofertas.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Interfaces
{
    interface IEmpresaRepository
    {
        void Cadastrar(Empresa novaEmpresa);

        List<Empresa> ListarTodos();

        void Atualizar(int id, Empresa empresaAtualizada);

        Empresa BuscarPorId(int id);

        void Deletar(int id);
    }
}
