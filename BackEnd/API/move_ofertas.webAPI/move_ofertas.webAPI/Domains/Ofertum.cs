using System;
using System.Collections.Generic;

#nullable disable

namespace move_ofertas.webAPI.Domains
{
    public partial class Ofertum
    {
        public Ofertum()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdOferta { get; set; }
        public short? IdCategoria { get; set; }
        public int? IdEmpresa { get; set; }
        public byte? IdSituacao { get; set; }
        public string NomeProduto { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public string Descricao { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
        public virtual Imagemofertum Imagemofertum { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
