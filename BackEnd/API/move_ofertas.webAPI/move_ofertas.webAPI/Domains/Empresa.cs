using System;
using System.Collections.Generic;

#nullable disable

namespace move_ofertas.webAPI.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Oferta = new HashSet<Ofertum>();
        }

        public int IdEmpresa { get; set; }
        public int? IdUsuario { get; set; }
        public string NomeEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Ofertum> Oferta { get; set; }
    }
}
